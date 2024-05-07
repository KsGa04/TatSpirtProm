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
    /// Логика взаимодействия для NewDelivery.xaml
    /// </summary>
    public partial class NewDelivery : Page
    {
        public TatSpirtPromEntities db = new TatSpirtPromEntities();
        public NewDelivery()
        {
            InitializeComponent();
            foreach (var d in db.Product)
            {
                cbSupplier.Items.Add(d.name_product);
            }
            foreach (var d in db.Storage)
            {
                cbWarehouse.Items.Add(d.address);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.data_delivery = (DateTime)dpDeliveryDate.SelectedDate;
            delivery.comment = txtComment.Text;
            delivery.count = Convert.ToInt32(txtQuantity.Text);
            delivery.id_storage = cbWarehouse.SelectedIndex;
            delivery.id_product = cbSupplier.SelectedIndex;
            db.Delivery.Add(delivery);

            Storage_product storage_Product = new Storage_product();
            storage_Product.id_product = cbSupplier.SelectedIndex;
            storage_Product.id_storage = cbWarehouse.SelectedIndex;
            db.Storage_product.Add(storage_Product);
            db.SaveChanges();
            MessageBox.Show("Поставка создана");
            NavigationService.GoBack();
        }
    }
}
