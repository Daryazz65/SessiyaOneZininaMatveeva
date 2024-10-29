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
using static SessiyaOneZininaMatveeva.AppData.ClassHelper;

namespace SessiyaOneZininaMatveeva.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private static user25Entities _context = App.GetContext();
        public StartWindow()
        {
            List<string> roles = new List<string> { "Организатор", "Модератор", "Жюри", "Участник" };
            InitializeComponent();
            ViborRoleCmb.ItemsSource = roles;
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AuthoriseHelper.Authorise(LoginTb.Text, PasswordTb.Password, ViborRoleCmb.SelectedItem as string))
            {
                CaptchaWindow cAPTCHAWindow = new CaptchaWindow();
                if (cAPTCHAWindow.ShowDialog() == true)
                {
                    if (ViborRoleCmb.SelectedIndex == 0)
                    {
                        OrganizerWindow organizerWindow = new OrganizerWindow(AuthoriseHelper.selectedOrg);
                        organizerWindow.Show();
                        Close();
                    }
                }

            }
        }

        private void SignUpHl_Click(object sender, RoutedEventArgs e)
        {
            SignWindow signUpWindow = new SignWindow();
            signUpWindow.Show();
            Close();
        }

        private void EnterHl_Click(object sender, RoutedEventArgs e)
        {
            EventsWindow eventsWindow = new EventsWindow();
            eventsWindow.Show();
            Close();
        }
    }
}
