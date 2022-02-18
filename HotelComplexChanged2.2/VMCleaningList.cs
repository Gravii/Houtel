using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HotelComplexChanged2._2
{
    internal class VMCleaningList : INotifyPropertyChanged
    {
        Db db;
        private Cleaning selectedCleaning;

        public Cleaning SelectedCleaning
        { 
            get => selectedCleaning;
            set
            {
                selectedCleaning = value;
                SignalChanged("Cleaning");
            }
        }

        public ObservableCollection<Cleaning> Cleanings { get; set; }
        public ObservableCollection<Staff> Staffs { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }

        public CustomCommand AddCleaning { get; set; }
        public CustomCommand SaveCleaning { get; set; }
        public CustomCommand RemoveCleaning { get; set; }
        public CustomCommand Refresh { get; set; }
        public VMCleaningList()
        {
            db = Db.GetDb();
            Staffs = new ObservableCollection<Staff>(db.Staffs);
            Rooms = new ObservableCollection<Room>(db.Rooms);

            AddCleaning = new CustomCommand(() =>
            {
                SelectedCleaning = new Cleaning { };
                db.Cleanings.Add(SelectedCleaning);
                LoadCleangs();
            });
            Refresh = new CustomCommand(() =>
            {
                LoadCleangs();
                SignalChanged("Cleaning");
            });
            SaveCleaning = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadCleangs();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                SignalChanged("Cleaning");
            });
            RemoveCleaning = new CustomCommand(() =>
            {
                if (SelectedCleaning != null)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить данные об уборке?", "Предупреждение",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        try
                        {
                            db.Cleanings.Remove(SelectedCleaning);
                            db.SaveChanges();
                            Cleanings = new ObservableCollection<Cleaning>(db.Cleanings);
                            SignalChanged("Cleaning");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                LoadCleangs();
                SignalChanged("Cleaning");
            });
        }

        private void LoadCleangs()
        {
            Cleanings = new ObservableCollection<Cleaning>(db.Cleanings);
            SignalChanged("Cleaning");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}