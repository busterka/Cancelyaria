using Cancelyaria.Class;
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
    /// Логика взаимодействия для PageKorzina.xaml
    /// </summary>
    public partial class PageKorzina : Page
    {
        private List<CartItem> CartItems;

        public PageKorzina(List<CartItem> cartItems)
        {
            InitializeComponent();
            CartItems = cartItems;
            dgCartItems.ItemsSource = CartItems;
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            if (App.CartItems.Count == 0)
            {
                MessageBox.Show("Корзина пуста.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            App.CartItems.Clear();
            dgCartItems.Items.Refresh();

            NavigationService.Navigate(new PageCheck());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}