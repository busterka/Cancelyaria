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

namespace Cancelyaria.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMNF.xaml
    /// </summary>
    public partial class PageMNF : Page
    {
        private CancelyariaEntities context;

        public PageMNF()
        {
            InitializeComponent();

            context = App.Context;

            dgManufacturers.ItemsSource = context.Manufacturers.ToList();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}