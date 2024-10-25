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
    /// Логика взаимодействия для EventsWindow.xaml
    /// </summary>
    public partial class EventsWindow : Window
    {
        private static user25Entities2 context = App.GetContext();
        List<Direction> directions = context.Direction.ToList();
        List<Event> events = context.Event.ToList();

        public EventsWindow()
        {
            InitializeComponent();
            EventsLb.ItemsSource = context.Event.ToList();
            directions.Insert(0, new Direction() { Name = "Все направления" });
            DirectionCmb.ItemsSource = directions;
            DirectionCmb.DisplayMemberPath = "Name";
        }

        private void SignInHL_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void DirectionCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            events = context.Event.ToList();
            if (DirectionCmb.SelectedIndex == 0)
            {
                events = context.Event.ToList();
                EventsLb.ItemsSource = events;
            }
            else
            {
                events = events.Where(ev => ev.Direction == DirectionCmb.SelectedItem as Direction).ToList();
                EventsLb.ItemsSource = events;
            }
        }

        private void EventsLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EventInfoWindow eventInfoWIndow = new EventInfoWindow(EventsLb.SelectedItem as Event);
            eventInfoWIndow.ShowDialog();
            //вапрвапрвап
            //псраопро
        }
    }
}
