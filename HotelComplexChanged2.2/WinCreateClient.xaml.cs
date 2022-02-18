using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelComplexChanged2._2
{
    /// <summary>
    /// Логика взаимодействия для WinCreateClient.xaml
    /// </summary>
    public partial class WinCreateClient : Window
    {
        public WinCreateClient()
        {
            InitializeComponent();
            DataContext = new VMClientList();
        }

        public WinCreateClient(Client selectedClient)
        {
            InitializeComponent();
            DataContext = new VMClientList(selectedClient);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
