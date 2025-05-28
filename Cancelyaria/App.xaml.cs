using Cancelyaria.Class;
using Cancelyaria.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cancelyaria
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Frame MainFrame { get; set; }
        public static CancelyariaEntities Context { get; } = new CancelyariaEntities();
        public static List<CartItem> CartItems = new List<CartItem>();
    }
}
