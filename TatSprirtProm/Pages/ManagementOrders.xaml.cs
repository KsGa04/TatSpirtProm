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
using static TatSprirtProm.Pages.ManagementProducts;

namespace TatSprirtProm.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagementOrders.xaml
    /// </summary>
    public partial class ManagementOrders : Page
    {
        private TatSpirtPromEntities db = new TatSpirtPromEntities();
        public class Product_order
        {
            public int id;
            public string name_product { get; set; }
            public string comment { get; set; }
            public int count { get; set; }
        }
        public ManagementOrders()
        {
            InitializeComponent();
            var productsWithCounts = db.Product
    .Join(
        db.Orders,
        product => product.id_product,
        order => order.id_product,
        (product, order) => new Product_order
        {
            id = product.id_product,
            name_product = order.Product.name_product,
            comment = order.comment,
            count = (int)order.count
        }).ToList();
            lvWarehouses.ItemsSource = productsWithCounts; 
        }
    }
}
