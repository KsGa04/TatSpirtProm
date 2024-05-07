using System;
using System.Linq;
using System.Windows;
using WpfApp1.Class;

namespace TatSprirtProm
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Organization auth = TatSpirtPromEntities.GetContext().Organization.FirstOrDefault(u => u.login == txtLogin.Text && u.password == txtPassword.Password);
                if (auth != null)
                {

                    Auth.IsAuth = true;
                    Auth.Role = auth.Role.name_role;
                    Auth.UserID = auth.id_organization;

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильные данные, пожалуйста, попробуйте еще раз");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void reg_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
