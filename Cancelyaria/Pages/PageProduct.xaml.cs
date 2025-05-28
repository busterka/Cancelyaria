using Cancelyaria.Class;
using Cancelyaria.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        private List<Product> products;    // Все товары
        private List<Product> filteredProducts; // Отфильтрованные

        public PageProduct()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            products = App.Context.Product.ToList();
            filteredProducts = new List<Product>(products);
            dgProducts.ItemsSource = filteredProducts;
        }

        // Обработчик для TextBox фильтра по названию
        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = txtFilter.Text.ToLower();

            filteredProducts = products
                .Where(p => p.Description != null && p.Description.ToLower().Contains(filterText))
                .ToList();

            dgProducts.ItemsSource = filteredProducts;
        }

        // Обработчик кнопки "Перейти в корзину"
        private void BtnKorzina_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new PageKorzina(App.CartItems));
        }

        // Обработчик кнопки "Добавить в корзину" в DataGrid
        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is Product selectedProduct)
            {
                var existingItem = App.CartItems.FirstOrDefault(ci => ci.ProductID == selectedProduct.ProductID);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    App.CartItems.Add(new CartItem
                    {
                        ProductID = selectedProduct.ProductID,
                        ProductName = selectedProduct.Description,
                        Quantity = 1,
                        Discount = selectedProduct.CurrentDiscounts ?? "0"
                    });
                }

                MessageBox.Show($"Товар '{selectedProduct.Description}' добавлен в корзину.", "Добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}