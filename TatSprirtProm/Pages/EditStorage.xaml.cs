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
    /// Логика взаимодействия для EditStorage.xaml
    /// </summary>
    public partial class EditStorage : Page
    {
        private TatSpirtPromEntities _db = new TatSpirtPromEntities();
        private byte[] _image = null;
        public EditStorage(int id)
        {
            InitializeComponent();
            Storage storage =  _db.Storage.Where(x => x.id_storage == id).FirstOrDefault();
            txtName.Text = storage.name_storage;
            txtArea.Text = storage.area.ToString();
            txtAddress.Text = storage.address.ToString();
            cbEmployee.SelectedIndex = (int)storage.responsible_person;

            foreach (var d in _db.Users)
            {
                cbEmployee.Items.Add(d.fio_user);
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Storage storage = new Storage();
            storage.address = txtAddress.Text;
            storage.name_storage = txtName.Text;
            storage.responsible_person = cbEmployee.SelectedIndex;
            storage.area = txtArea.Text;
            _db.SaveChanges();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtArea.Text = string.Empty;
            cbEmployee.SelectedIndex = 0;

        }
    }
}
