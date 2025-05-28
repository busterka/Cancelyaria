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
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
            txtFirstName.TextChanged += (s, e) =>
       placeholderFirstName.Visibility = string.IsNullOrEmpty(txtFirstName.Text) ? Visibility.Visible : Visibility.Hidden;
            txtLastName.TextChanged += (s, e) =>
                placeholderLastName.Visibility = string.IsNullOrEmpty(txtLastName.Text) ? Visibility.Visible : Visibility.Hidden;
            txtLogin.TextChanged += (s, e) =>
                placeholderLogin.Visibility = string.IsNullOrEmpty(txtLogin.Text) ? Visibility.Visible : Visibility.Hidden;

            txtPassword.PasswordChanged += (s, e) =>
                placeholderPassword.Visibility = string.IsNullOrEmpty(txtPassword.Password) ? Visibility.Visible : Visibility.Hidden;
            txtPasswordConfirm.PasswordChanged += (s, e) =>
                placeholderPasswordConfirm.Visibility = string.IsNullOrEmpty(txtPasswordConfirm.Password) ? Visibility.Visible : Visibility.Hidden;
        }
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Password.Trim();
            string passwordConfirm = txtPasswordConfirm.Password.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Введите имя и фамилию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != passwordConfirm)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var existingUser = App.Context.Users.FirstOrDefault(u => u.Login == login);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newUser = new Entities.Users
            {
                FirstNameMiddle = firstName,
                LastName = lastName,
                Login = login,
                Password = password,
                RoleID = 1  
            };

            App.Context.Users.Add(newUser);
            App.Context.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            App.MainFrame.Navigate(new PageLogin());
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}