using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Net.Mime.MediaTypeNames;

namespace TatSprirtProm.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagementStorage.xaml
    /// </summary>
    public partial class ManagementStorage : Page
    {
        public TatSpirtPromEntities db = new TatSpirtPromEntities();
        public ManagementStorage()
        {
            InitializeComponent();
            ListViewLoad();
        }
        public void ListViewLoad()
        {
            using (TatSpirtPromEntities db = new TatSpirtPromEntities())
            {
                var meals = db.Storage.ToList();

                lvWarehouses.ItemsSource = meals;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddStorage());
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (lvWarehouses.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот склад?", "Удалить", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var item = lvWarehouses.SelectedItem as Storage;
                    int id = item.id_storage;
                    Storage storage = db.Storage.Where(x => x.id_storage == id).FirstOrDefault();
                    db.Storage.Remove(storage);
                    db.SaveChangesAsync();
                    ListViewLoad();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни один элемент");
            }
            ListViewLoad();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = lvWarehouses.SelectedItem as Storage;
                int id = item.id_storage;
                NavigationService.Navigate(new Pages.EditStorage(id));
            }
            catch
            {
                MessageBox.Show("Введите действительный Id");
            }
        }
    }
}
