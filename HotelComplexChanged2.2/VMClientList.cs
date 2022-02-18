using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HotelComplexChanged2._2
{
    internal class VMClientList : INotifyPropertyChanged
    {
        Db db;
        private Client selectedClient;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }

        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                SignalChanged();
            }
        }

        public CustomCommand OpenCreateClient { get; set; }
        public CustomCommand BackClietnList { get; set; }
        public CustomCommand SaveClient { get; set; }
        public CustomCommand AddClient { get; set; }
        public CustomCommand DeleteClient { get; set; }
        public CustomCommand Refresh { get; set; }
        public CustomCommand OpenEditClient { get; set; }


        Room lastOwnedRoom;
        public VMClientList(Client selectedClient = null)
        {
            db = Db.GetDb();
            LoadClients();
            if (selectedClient != null)
            {
                SelectedClient = selectedClient;
                lastOwnedRoom = SelectedClient.NumberRoom;
            }
            Rooms = new ObservableCollection<Room>(db.Rooms);

            OpenCreateClient = new CustomCommand(() =>
            {
                new WinCreateClient().ShowDialog();
                LoadClients();
            });
            OpenEditClient = new CustomCommand(() =>
            {
                new WinCreateClient(SelectedClient).ShowDialog();
                                
                LoadClients();

            });
            AddClient = new CustomCommand(() =>
            {
                SelectedClient = new Client { FirstName = "Имя", SecondName = "Фамилия", LastName = "Отчество" };
                db.Clients.Add(SelectedClient);
                LoadClients();
            });
            SaveClient = new CustomCommand(() =>
            {
                try
                {
                    if (SelectedClient != null)  // Изменение статуса номера в случае, если клиент в нём проживает или съехал
                    {
                        if (lastOwnedRoom != null && lastOwnedRoom != SelectedClient.NumberRoom)
                            lastOwnedRoom.GetStatus = db.Statuses.FirstOrDefault(s => s.Id == 1);
                        if (SelectedClient.NumberRoom != null)
                            SelectedClient.NumberRoom.GetStatus = db.Statuses.FirstOrDefault(s => s.Id == 2);
                    }
                    db.SaveChanges();
                    LoadClients();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                SignalChanged("Client");
            });
            DeleteClient = new CustomCommand(() =>
            {
                if (SelectedClient != null)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить клиента?", "Предупреждение",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        try
                        {
                            db.Clients.Remove(SelectedClient);
                            db.SaveChanges();
                            Clients = new ObservableCollection<Client>(db.Clients);
                            SignalChanged("Client");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                LoadClients();
                SignalChanged("Client");
            });
            Refresh = new CustomCommand(() =>
            {
                LoadClients();
                SignalChanged("Clients");
            });
        }

        private void LoadClients()
        {
            Clients = new ObservableCollection<Client>(db.Clients);
            SignalChanged("Client");
        }

        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}