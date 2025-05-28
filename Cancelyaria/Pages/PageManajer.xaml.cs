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
    /// Логика взаимодействия для PageManajer.xaml
    /// </summary>
    public partial class PageManajer : Page
    {
        private Entities.Users currentUser;

        public PageManajer(Entities.Users user1)
        {
            InitializeComponent();
            currentUser = user1;

          
            txtWelcome.Text = $"Добро пожаловать, {currentUser.FirstNameMiddle} {currentUser.LastName}!";
        }

        private void BtnProductEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageProductEdit());
        }

        private void BtnMNF_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMNF());
        }

        private void BtnSUPP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageSUPP());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}