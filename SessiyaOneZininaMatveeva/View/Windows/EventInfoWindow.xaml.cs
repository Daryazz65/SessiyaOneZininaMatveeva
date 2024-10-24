using SessiyaOneZininaMatveeva.Model;
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
using System.Windows.Shapes;

namespace SessiyaOneZininaMatveeva.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EventInfoWindow.xaml
    /// </summary>
    public partial class EventInfoWindow : Window
    {
        public EventInfoWindow(Event selectedEvent)
        {
            InitializeComponent();
            EventGrid.DataContext = selectedEvent;

        }
    }
}
