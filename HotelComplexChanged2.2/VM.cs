using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace HotelComplexChanged2._2
{
    internal class VM : INotifyPropertyChanged
    {
        public Page CurrentPage { get; set; }
        Db db;

        public CustomCommand StaffBase { get; set; }
        public CustomCommand ClientsBase { get; set; }
        public CustomCommand NumbersBase { get; set; }
        public CustomCommand ReserBase { get; set; }
        public CustomCommand CleaningBase { get; set; }
        public CustomCommand HistoryBase { get; set; }

        public VM()
        {
            db = Db.GetDb();

            ClientsBase = new CustomCommand(() =>
            {
                CurrentPage = new PageClientList(); // PageClientList PageRoomList PageStaffList PageCleaningList PageReserList
                SignalChanged("CurrentPage");
            });
            NumbersBase = new CustomCommand(() =>
            {
                CurrentPage = new PageRoomList();
                SignalChanged("CurrentPage");
            });
            StaffBase = new CustomCommand(() =>
            {
                CurrentPage = new PageStaffList();
                SignalChanged("CurrentPage");
            });
            CleaningBase = new CustomCommand(() =>
            {
                CurrentPage = new PageCleaningList();
                SignalChanged("CurrentPage");
            });
            ReserBase = new CustomCommand(() =>
            {
                CurrentPage = new PageReserList();
                SignalChanged("CurrentPage");
            });
            HistoryBase = new CustomCommand(() =>
            {
                //CurrentPage = new PageClientHistory();
                //SignalChanged("CurrentPage");
            });
        }

        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
