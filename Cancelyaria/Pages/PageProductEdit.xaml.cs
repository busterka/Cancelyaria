using Cancelyaria.Entities;
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
using System.Data.Entity;
using System.Collections.ObjectModel;
namespace Cancelyaria.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProductEdit.xaml
    /// </summary>
    public partial class PageProductEdit : Page
    {
        private CancelyariaEntities context;
        public ObservableCollection<Product> Products { get; set; }

        public PageProductEdit()
        {
            InitializeComponent();
            context = App.Context;

            context.Product.Load();          
            Products = context.Product.Local;
            dgProducts.ItemsSource = Products;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                context.SaveChanges();
                MessageBox.Show("Изменения сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}