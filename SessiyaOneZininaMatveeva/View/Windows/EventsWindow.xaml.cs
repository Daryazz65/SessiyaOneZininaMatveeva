using SessiyaOneZininaMatveeva.AppData;
using SessiyaOneZininaMatveeva.Model;
using SessiyaOneZininaMatveeva.View.Organiezer;
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
        private static user25Entities context = App.GetContext();
        List<Direction> directions = context.Direction.ToList();
        List<Event> events = context.Event.ToList();
        private Organizer _selectedUser;
        public EventsWindow()
        {
            InitializeComponent();
            EventsLb.ItemsSource = context.Event.ToList();
            directions.Insert(0, new Direction() { Name = "Все направления" });
            DirectionCmb.ItemsSource = directions;
            DirectionCmb.DisplayMemberPath = "Name";
            ProfileTbl.Visibility = Visibility.Collapsed;
            SignInTbl.Visibility = Visibility.Visible;
            NewEventBtn.Visibility = Visibility.Collapsed;
        }
        public EventsWindow(Organizer selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;
            EventsLb.ItemsSource = context.Event.ToList();
            directions.Insert(0, new Direction() { Name = "Все направления" });
            DirectionCmb.ItemsSource = directions;
            DirectionCmb.DisplayMemberPath = "Name";
            ProfileTbl.Visibility = Visibility.Visible;
            SignInTbl.Visibility = Visibility.Collapsed;
            ProfileTbl.Text = ClassHelper.selectedOrg.Fullname;
            NewEventBtn.Visibility = Visibility.Visible;
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
        }

        private void ProfileHl_Click(object sender, RoutedEventArgs e)
        {
            ProfileWIndow profileWIndow = new ProfileWIndow(selectedUser);
            profileWIndow.ShowDialog();
        }

        private void SignInHL_Click_1(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void DirectionCmb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
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

        private void NewEventBtn_Click(object sender, RoutedEventArgs e)
        {
            NewEventWindow newEventWindow = new NewEventWindow(selectedUser);
            if (newEventWindow.ShowDialog() == true)
            {
                EventsLb.ItemsSource = App.GetContext().Event.ToList();
            }
        }

        private void EventsLb_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            EventInfoWindow eventInfoWindow = new EventInfoWindow(EventsLb.SelectedItem as Event);
            eventInfoWindow.Show();
            Close();
        }

        private void SignInHL_Click_2(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void DirectionCmb_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
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

        private void NewEventBtn_Click_1(object sender, RoutedEventArgs e)
        {
            NewEventWindow newEventWindow = new NewEventWindow(selectedUser);
            if (newEventWindow.ShowDialog() == true)
            {
                EventsLb.ItemsSource = App.GetContext().Event.ToList();
            }
        }

        private void EventsLb_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {
            EventInfoWindow eventInfoWindow = new EventInfoWindow(EventsLb.SelectedItem as Event);
            eventInfoWindow.Show();
            Close();
        }

        private void ProfileHl_Click_1(object sender, RoutedEventArgs e)
        {
            ProfileWIndow profileWIndow = new ProfileWIndow(selectedUser);
            profileWIndow.ShowDialog();
        }
    }
}
