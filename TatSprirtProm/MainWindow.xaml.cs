using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TatSprirtProm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.AddStorage());
        }

        private void managementStorage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ManagementStorage());
        }

        private void managementProduct_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ManagementProducts());
        }

        private void catalog_Click(object sender, RoutedEventArgs e)
        {
        }

        private void delivery_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Delivery());
        }

        private void managementOrders_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
