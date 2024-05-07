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
    /// Логика взаимодействия для NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Page
    {
        public TatSpirtPromEntities db = new TatSpirtPromEntities();
        public NewOrder()
        {
            InitializeComponent();
            txtPrice.IsEnabled = false;
            foreach (var d in db.Product)
            {
                cbSupplier.Items.Add(d.name_product);
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Orders delivery = new Orders();
            delivery.data_order = (DateTime)dpDeliveryDate.SelectedDate;
            delivery.comment = txtComment.Text;
            delivery.total_price = Convert.ToDecimal(txtPrice.Text);
            delivery.count = Convert.ToInt32(txtQuantity.Text);
            delivery.id_product = cbSupplier.SelectedIndex;
            delivery.id_organization = Auth.UserID;
            db.Orders.Add(delivery);
            db.SaveChanges();
        }
    }
}
