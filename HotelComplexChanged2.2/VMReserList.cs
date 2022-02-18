using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HotelComplexChanged2._2
{
    internal class VMReserList: INotifyPropertyChanged
    {
        Db db;
        private Reserv selectedReserv;

        public ObservableCollection<Reserv> Reservs { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }

        public CustomCommand AddReserv { get; set; }
        public CustomCommand SaveReserv { get; set; }
        public CustomCommand RemoveReserv { get; set; }
        public CustomCommand Refresh { get; set; }
        public Reserv SelectedReserv
        {
            get => selectedReserv;
            set
            {
                selectedReserv = value;
                SignalChanged();
            }
        }
        public VMReserList()
        {
            db = Db.GetDb();
            Clients = new ObservableCollection<Client>(db.Clients);
            Rooms = new ObservableCollection<Room>(db.Rooms);

            AddReserv = new CustomCommand(() =>
            {
                SelectedReserv = new Reserv {  };
                db.Reservs.Add(selectedReserv);
                LoadReserv();
            });
            Refresh = new CustomCommand(() =>
            {
                LoadReserv();
                SignalChanged("Reserv");
            });
            SaveReserv = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadReserv();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                SignalChanged("Reserv");
            });
            RemoveReserv = new CustomCommand(() =>
            {
                if (SelectedReserv != null)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить бронь?", "Предупреждение",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        try
                        {
                            db.Reservs.Remove(SelectedReserv);
                            db.SaveChanges();
                            Reservs = new ObservableCollection<Reserv>(db.Reservs);
                            SignalChanged("Reserv");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                LoadReserv();
                SignalChanged("Reserv");
            });
        }
        private void LoadReserv()
        {
            Reservs = new ObservableCollection<Reserv>(db.Reservs);
            SignalChanged("Reserv");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}