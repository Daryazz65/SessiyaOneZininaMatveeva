using SessiyaOneZininaMatveeva.AppData;
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
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private static user25Entities2 context = App.GetContext();
        public StartWindow()
        {
            List<string> roles = new List<string> { "Организатор", "Модератор", "Жюри", "Участник" };
            InitializeComponent();
            ViborRoleCmb.ItemsSource = roles;
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClassHelper.Authorise(LoginTb.Text, PasswordTb.Password, ViborRoleCmb.SelectedItem as string))
            {
                CaptchaWindow cAPTCHAWindow = new CaptchaWindow();
                if (cAPTCHAWindow.ShowDialog() == true)
                {
                    if (ViborRoleCmb.SelectedIndex == 0)
                    {

                    }
                }

            }
        }

        private void SignHl_Click(object sender, RoutedEventArgs e)
        {
            SignWindow signWindow = new SignWindow();
            signWindow.Show();
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
