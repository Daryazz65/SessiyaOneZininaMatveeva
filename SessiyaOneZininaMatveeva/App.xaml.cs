using SessiyaOneZininaMatveeva.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SessiyaOneZininaMatveeva
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
        public partial class App : Application
        {
            private static user25Entities context;
            public static user25Entities GetContext()
            {
                if (context == null)
                {
                    context = new user25Entities();
                }
                return context;
            }
        }
}