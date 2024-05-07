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

namespace TatSprirtProm.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagementProducts.xaml
    /// </summary>
    public partial class ManagementProducts : Page
    {
        private TatSpirtPromEntities db = new TatSpirtPromEntities();
        private List<Product> products = new List<Product>();
        private List<Category> categories = new List<Category>();
        public class Product_category
        {
            public int id;
            public string name_product { get; set; }
            public byte[] image_product { get; set; }
            public string name_category { get; set; }
        }
        public ManagementProducts()
        {
            InitializeComponent();
            if (Auth.Role == "Организация")
            {
                add.Visibility = Visibility.Collapsed;
                Update.Visibility = Visibility.Collapsed;
            }
            lvProducts.Items.Clear();
            var productsWithCounts = db.Product
    .Join(
        db.Category,
        product => product.id_category,
        order => order.id_category,
        (product, order) => new Product_category
        {
            id = product.id_product,
            name_product = product.name_product,
            image_product = product.image_product,
            name_category = product.Category.name_category
        }).ToList();
            lvProducts.ItemsSource = productsWithCounts;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                var product = item.Content as Product_category;
                int id = product.id;
                NavigationService.Navigate(new Pages.AboutProduct(id));
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddProduct());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text;
            var productsWithCounts = db.Product
    .Join(
        db.Category,
        product => product.id_category,
        order => order.id_category,
        (product, order) => new Product_category
        {
            id = product.id_product,
            name_product = product.name_product,
            image_product = product.image_product,
            name_category = product.Category.name_category
        }).ToList();

            // Фильтруем список продуктов в соответствии с поисковым запросом
            var filteredProducts = productsWithCounts.Where(p =>
                p.name_product.ToLower().Contains(searchText.ToLower()) ||
                p.name_category.ToLower().Contains(searchText.ToLower()))
                .ToList();

            // Обновляем источник данных для ListView
            lvProducts.ItemsSource = filteredProducts;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            lvProducts.Items.Clear();
            var productsWithCounts = db.Product
    .Join(
        db.Category,
        product => product.id_category,
        order => order.id_category,
        (product, order) => new Product_category
        {
            id = product.id_product,
            name_product = product.name_product,
            image_product = product.image_product,
            name_category = product.Category.name_category
        }).ToList();
            lvProducts.ItemsSource = productsWithCounts;
        }
    }
}
