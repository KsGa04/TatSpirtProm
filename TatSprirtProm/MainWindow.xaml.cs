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
using WpfApp1.Class;

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
            if (Auth.Role == "Организация")
            {
                managementProduct.Visibility = Visibility.Collapsed;
                storage.Visibility = Visibility.Collapsed;
                managementOrders.Visibility = Visibility.Collapsed;
                delivery.Visibility = Visibility.Collapsed;
                orders.Visibility = Visibility.Collapsed;
                button_storage.Visibility = Visibility.Collapsed;
            }
            if (Auth.Role == "Администратор")
            {
                new_order.Visibility = Visibility.Collapsed;
                catalog.Visibility = Visibility.Collapsed;
            }
            MainFrame.Navigate(new Pages.ManagementProducts());
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
            MainFrame.Navigate(new Pages.ManagementProducts());
        }

        private void delivery_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.NewDelivery());
        }

        private void managementOrders_Click(object sender, RoutedEventArgs e)
        {
            if (Auth.Role == "Организация")
            {
                MainFrame.Navigate (new Pages.NewOrder());
            }
            if (Auth.Role == "Администратор")
            {
                MainFrame.Navigate(new Pages.ManagementOrders());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Hide();
        }
    }
}
