using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TatSprirtProm
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Length < 8)
            {
                MessageBox.Show("Неправильная длина пароля");
            }
            else
            {
                using (TatSpirtPromEntities db = new TatSpirtPromEntities())
                {
                    Organization organization = new Organization();
                    organization.name_organization = txtName.Text;
                    organization.login = txtLogin.Text;
                    organization.password = txtPassword.Password;
                    MessageBox.Show("Аккаунт " + txtName.Text + " зарегистрирован");
                    txtLogin.Clear();
                    txtPassword.Clear();
                    txtName.Clear();
                    Authorization mainWindow = new Authorization();
                    mainWindow.Show();
                    mainWindow.Close();

                }
            }
        }
    }
}
