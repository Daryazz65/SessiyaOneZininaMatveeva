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

namespace SessiyaOneZininaMatveeva.View.Organiezer
{
    /// <summary>
    /// Логика взаимодействия для NewEventWindow.xaml
    /// </summary>
    public partial class NewEventWindow : Window
    {
        private Organizer selectedOrganizer;
        static StackPanel stackPanels = new StackPanel() { };
        private static user25Entities context = App.GetContext();
        public NewEventWindow(Organizer selectedOrganizer)
        {
            InitializeComponent();
            JuryCmb1.ItemsSource = context.Jury.ToList();
            JuryCmb1.DisplayMemberPath = "Email";
            JuryCmb2.ItemsSource = context.Jury.ToList();
            JuryCmb2.DisplayMemberPath = "Email";
            JuryCmb3.ItemsSource = context.Jury.ToList();
            JuryCmb3.DisplayMemberPath = "Email";

            CityCmb.ItemsSource = context.City.ToList();
            CityCmb.DisplayMemberPath = "Name";
            DirectionCmb.ItemsSource = context.Direction.ToList();
            DirectionCmb.DisplayMemberPath = "Name";
        }

        private static StackPanel AddRow()
        {
            StackPanel newRow = new StackPanel() { Name = "Row" + stackPanels.Children.Count, Orientation = Orientation.Horizontal };
            newRow.Children.Add(new TextBox() { Name = "EventName" + stackPanels.Children.Count });
            newRow.Children.Add(new Border() { Width = 20 });
            newRow.Children.Add(new ComboBox()
            {
                Name = "JuryCmb" + stackPanels.Children.Count,
                ItemsSource = context.Jury.ToList(),
                DisplayMemberPath = "Email"
            });
            newRow.Children.Add(new Border() { Height = 20 });
            return newRow;
        }
        private void AddRowBtn_Click(object sender, RoutedEventArgs e)
        {
            JuryGrid.Children.Add(AddRow());
            JuryGrid.Children.Add(new Border() { Height = 20 });
            UpdateButtons();
        }

        private void DeleteROwBtn_Click(object sender, RoutedEventArgs e)
        {
            int lastElementId = JuryGrid.Children.Count - 1;
            JuryGrid.Children.RemoveAt(lastElementId);
            JuryGrid.Children.RemoveAt(lastElementId - 1);
            UpdateButtons();
        }
        private void UpdateButtons()
        {
            int childrenCount = JuryGrid.Children.Count;
            if (childrenCount > 14)
            {
                AddRowBtn.Visibility = Visibility.Collapsed;
            }
            else if (childrenCount < 16)
            {
                AddRowBtn.Visibility = Visibility.Visible;
            }
            if (childrenCount > 6)
            {
                DeleteROwBtn.Visibility = Visibility.Visible;
            }
            else if (childrenCount < 8)
            {
                DeleteROwBtn.Visibility = Visibility.Collapsed;
            }
        }
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Event newEvent = new Event()
            {
                Name = EventNameTb.Text,
                Date = (DateTime)EventDateDp.SelectedDate,
                Direction = DirectionCmb.SelectedItem as Direction
            };
            context.Event.Add(newEvent);

            List<StackPanel> rows = new List<StackPanel>();
            for (int i = 0; i < JuryGrid.Children.Count; i++)
            {
                rows.Add((StackPanel)JuryGrid.Children[i]);
            }
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Children.GetType().Equals(Border ////////////////// \\\\\\\\\\\\\\\\\))
                {

                }
                Activity newActivity = new Activity()
                {
                    Name = (rows[i].Children[0] as TextBox).Text,
                    Jury = (rows[i].Children[2] as ComboBox).SelectedItem as Jury,
                    Event = newEvent
                };
                context.Activity.Add(newActivity);
            }
            context.SaveChanges();
        }
    }
}
