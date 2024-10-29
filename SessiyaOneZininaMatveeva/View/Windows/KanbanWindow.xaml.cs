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
    /// Логика взаимодействия для KanbanWindow.xaml
    /// </summary>
    public partial class KanbanWindow : Window
    {
        private static user25Entities _context = App.GetContext();
        List<Activity> _activities = _context.Activity.ToList();
        public KanbanWindow()
        {
            InitializeComponent();
            EventsCmb.ItemsSource = _context.Event.ToList();
            EventsCmb.SelectedIndex = 0;
            EventsCmb.DisplayMemberPath = "Name";
            ActivityLb.ItemsSource = _activities.Where(a => a.Event == EventsCmb.SelectedItem as Event).ToList();
        }

        private void PdfBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EventsCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivityLb.ItemsSource = _activities.Where(a => a.Event == EventsCmb.SelectedItem as Event).ToList();

        }
    }
}