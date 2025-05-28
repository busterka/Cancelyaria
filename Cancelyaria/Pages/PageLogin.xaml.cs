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

namespace Cancelyaria.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var user = App.Context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                MessageBox.Show($"Добро пожаловать, {user.Login}!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                switch (user.RoleID)
                {
                    case 2:
                        App.MainFrame.Navigate(new PageAdmin());
                        break;
                    case 1:
                        App.MainFrame.Navigate(new PageClient(user));
                        break;
                    case 3:
                        App.MainFrame.Navigate(new PageManajer(user));
                        break;
                    default:
                        MessageBox.Show("Неизвестная роль пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new PageReg());
        }
    }
}