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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }
        private void BtnMNF_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(new PageMNF());
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(new PageProduct());
        }

        private void BtnSUPP_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(new PageSUPP());
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(new PageUsers());
        }

        private void BtnProductEdit_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(new PageProductEdit());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}