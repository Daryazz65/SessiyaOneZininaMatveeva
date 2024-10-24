using SessiyaOneZininaMatveeva.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SessiyaOneZininaMatveeva.AppData
{
    internal class ClassHelper
    {
        // Авторизация.

        public static Moderator selectedModer;
        public static Organizer selectedOrg;
        public static Jury selectedJury;
        public static Participant selectedPart;
        private static user25Entities1 context = App.GetContext();

        public static bool Authorise(string login, string password, string role)
        {
            if (login == string.Empty || password == string.Empty)
            {
                ClassMessageBox.Error("Не все поля для ввода были заполнены.");
                return false;
            }
            else
            {
                if (role == "Организатор")
                {
                    List<Organizer> organizers = context.Organizer.ToList();
                    foreach (Organizer org in organizers)
                    {
                        if (login == org.Id.ToString() && password == org.Password)
                        {
                            selectedOrg = org;
                            return true;
                        }
                        else
                        {
                            ClassMessageBox.Error("Неправильно введен логин или пароль");
                            return false;
                        }
                    }
                }
                else if (role == "Модератор")
                {
                    List<Moderator> moderators = context.Moderator.ToList();
                    foreach (Moderator moderator in moderators)
                    {
                        if (login == moderator.Id.ToString() && password == moderator.Password)
                        {
                            selectedModer = moderator;
                            return true;
                        }
                        else
                        {
                            ClassMessageBox.Error("Неправильно введен логин или пароль");
                            return false;
                        }
                    }
                }
                else if (role == "Жюри")
                {
                    List<Jury> juries = context.Jury.ToList();
                    foreach (Jury jury in juries)
                    {
                        if (login == jury.Id.ToString() && password == jury.Email)
                        {
                            selectedJury = jury;
                            return true;
                        }
                        else
                        {
                            ClassMessageBox.Error("Неправильно введен логин или пароль");
                            return false;
                        }
                    }
                }
                else if (role == "Участник")
                {
                    List<Participant> participants = context.Participant.ToList();
                    foreach (Participant participant in participants)
                    {
                        if (login == participant.Id.ToString() && password == participant.Password)
                        {
                            selectedPart = participant;
                            return true;
                        }
                        else
                        {
                            ClassMessageBox.Error("Неправильно введен логин или пароль");
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
                if (selectedJury != null || selectedModer != null || selectedOrg != null || selectedPart != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public static string GenerateCaptcha()
        {
            List<char> chars = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                                '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            Random random = new Random();
            string output = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                output += chars[random.Next(0, chars.Count)];
            }
            return output;
        }
    } 
}
