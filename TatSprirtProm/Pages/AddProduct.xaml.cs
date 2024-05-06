using Microsoft.Win32;
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
using static System.Net.Mime.MediaTypeNames;

namespace TatSprirtProm.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        private TatSpirtPromEntities _db = new TatSpirtPromEntities();
        private byte[] _image = null;
        public AddProduct()
        {
            InitializeComponent();
            foreach (var d in _db.Category)
            {
                cbCategory.Items.Add(d.name_category);
            }
        }
        private void ChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path;
            if ((bool)openFileDialog.ShowDialog())
            {
                path = openFileDialog.FileName;
                _image = System.IO.File.ReadAllBytes(path);
            }
            MemoryStream ms = new MemoryStream(_image);
            imgProduct.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.price = Convert.ToDecimal( txtPrice.Text);
            product.description_product = txtDescription.Text;
            product.name_product = txtName.Text;
            product.id_category = cbCategory.SelectedIndex;
            product.amount = txtAmount.Text;
            _db.Product.Add(product);
            _db.SaveChanges();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cbCategory.SelectedIndex = 0;
            txtAmount.Text = string.Empty;

        }
    }
}
