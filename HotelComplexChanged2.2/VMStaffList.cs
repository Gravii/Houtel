using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HotelComplexChanged2._2
{
    internal class VMStaffList : INotifyPropertyChanged
    {
        Db db;
        private Duty selectedDuty;
        private Staff selectedStaff;

        public ObservableCollection<Staff> Staffs { get; set; }
        public ObservableCollection<Duty> Duties { get; set; }

        
        public Duty SelectedDuty
        {
            get => selectedDuty;
            set
            {
                selectedDuty = value;
                SignalChanged();
            }
        }
        public Staff SelectedStaff
        {
            get => selectedStaff;
            set
            {
                selectedStaff = value;
                SignalChanged();
            }
        }

        public CustomCommand OpenCreateStaff { get; set; }
        public CustomCommand OpenEditStaff { get; set; }
        public CustomCommand DeleteStaff { get; set; }
        public CustomCommand AddStaff { get; set; }
        public CustomCommand SaveStaff { get; set; }
        public CustomCommand RemoveStaff { get; set; }
        public CustomCommand Refresh { get; set; }

        public VMStaffList(Staff selectedStaff = null)
        {
            db = Db.GetDb();
            Duties = new ObservableCollection<Duty>(db.Duties);
            Staffs = new ObservableCollection<Staff>(db.Staffs);
            LoadStaff();

            OpenCreateStaff = new CustomCommand(() =>
            {
                new WinCreateStaff().ShowDialog();
                LoadStaff();
            });
            OpenEditStaff = new CustomCommand(() =>
            {
                new WinCreateStaff(SelectedStaff).ShowDialog();
                LoadStaff();
            });
            AddStaff = new CustomCommand(() =>
            {
                SelectedStaff = new Staff { };
                db.Staffs.Add(SelectedStaff);
                LoadStaff();
            });
            SaveStaff = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadStaff();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                SignalChanged("Staff");
            });
            DeleteStaff = new CustomCommand(() =>
            {
                if (SelectedStaff != null)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить сотрудника?", "Предупреждение",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        try
                        {
                            db.Staffs.Remove(SelectedStaff);
                            db.SaveChanges();
                            Staffs = new ObservableCollection<Staff>(db.Staffs);
                            SignalChanged("Client");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                LoadStaff();
                SignalChanged("Staff");
            });
            Refresh = new CustomCommand(() =>
            {
                LoadStaff();
                SignalChanged("Staff");
            });
        }
        private void LoadStaff()
        {
            Staffs = new ObservableCollection<Staff>(db.Staffs);
            SignalChanged("Staff");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}