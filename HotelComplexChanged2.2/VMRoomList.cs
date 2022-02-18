using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HotelComplexChanged2._2
{
    internal class VMRoomList : INotifyPropertyChanged
    {
        Db db;
        private Room selectedRoom;
        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<Status> Statuses { get; set; }

        public CustomCommand SaveStatus { get; set; }
        public CustomCommand Refresh { get; set; }

        public Room SelectedRoom
        {
            get => selectedRoom;
            set
            {
                selectedRoom = value;
                SignalChanged();
            }
        }
        public VMRoomList()
        {
            db = Db.GetDb();
            LoadRooms();
            Statuses = new ObservableCollection<Status>(db.Statuses);

            SaveStatus = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadRooms();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
            Refresh = new CustomCommand(() =>
            {
                LoadRooms();
                SignalChanged("Rooms");
            });
        }
        private void LoadRooms()
        {
            Rooms = new ObservableCollection<Room>(db.Rooms);
            SignalChanged("Room");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}