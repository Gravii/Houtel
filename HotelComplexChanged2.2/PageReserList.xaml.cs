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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelComplexChanged2._2
{
    /// <summary>
    /// Логика взаимодействия для PageReserList.xaml
    /// </summary>
    public partial class PageReserList : Page
    {
        public PageReserList()
        {
            InitializeComponent();
            DataContext = new VMReserList();
        }
    }
}
