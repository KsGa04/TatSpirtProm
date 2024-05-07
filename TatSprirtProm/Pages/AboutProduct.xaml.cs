using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace TatSprirtProm.Pages
{
    /// <summary>
    /// Логика взаимодействия для AboutProduct.xaml
    /// </summary>
    public partial class AboutProduct : Page
    {
        private byte[] _image;
        private TatSpirtPromEntities db = new TatSpirtPromEntities();
        public Product product1;
        int _id;
        public AboutProduct(int id)
        {
            InitializeComponent();
            _id = id;
            if (Auth.Role == "Организация")
            {
                btnEdit.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
            Product product =  db.Product.Where(x => x.id_product == id).FirstOrDefault();
            product1 = product;
            _image = product.image_product;
            MemoryStream ms = new MemoryStream(_image);
            image.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            name.Text = product.name_product;
            description.Text = product.description_product;
            price.Text = product.price.ToString();
            amount.Text = product.amount.ToString();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditProduct(_id));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            db.Product.Remove(product1);
            db.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
