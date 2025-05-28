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
using Cancelyaria.Entities;


namespace Cancelyaria.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        private Users currentUser;

       
        public PageClient(Users user)
        {
            InitializeComponent();
            currentUser = user;
            txtWelcome.Text = $"Добро пожаловать, {currentUser.FirstNameMiddle} {currentUser.LastName}!";
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new PageProduct());
        }

        private void BtnKorzina_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new PageKorzina(App.CartItems));
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}