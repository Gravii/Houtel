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
    /// Логика взаимодействия для WinCreateStaff.xaml
    /// </summary>
    public partial class WinCreateStaff : Window
    {
        public WinCreateStaff()
        {
            InitializeComponent();
            DataContext = new VMStaffList();
        }
        
        public WinCreateStaff(Staff selectedStaff)
        {
            InitializeComponent();
            DataContext = new VMStaffList(selectedStaff);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
