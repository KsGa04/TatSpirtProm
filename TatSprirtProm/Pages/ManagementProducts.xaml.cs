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

namespace TatSprirtProm.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagementProducts.xaml
    /// </summary>
    public partial class ManagementProducts : Page
    {
        private TatSpirtPromEntities db = new TatSpirtPromEntities();
        private List<Product> products = new List<Product>();
        public ManagementProducts()
        {
            InitializeComponent();
            lvProducts.Items.Clear();
            products = db.Product.ToList();
            lvProducts.ItemsSource = products;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                var product = item.Content as Product;
                int id = product.id_product;
                NavigationService.Navigate(new Pages.AboutProduct(id));
            }
        }
    }
}
