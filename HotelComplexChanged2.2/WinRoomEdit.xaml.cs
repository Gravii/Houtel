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
    /// Логика взаимодействия для WinRoomEdit.xaml
    /// </summary>
    public partial class WinRoomEdit : Window
    {
        public WinRoomEdit()
        {
            InitializeComponent();
            DataContext = new VMRoomList();
        }
    }
}
