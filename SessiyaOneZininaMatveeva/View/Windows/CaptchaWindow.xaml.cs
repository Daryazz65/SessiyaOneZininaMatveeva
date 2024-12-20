﻿using SessiyaOneZininaMatveeva.AppData;
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
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        string captcha;
        int errorsCount = 0;
        public CaptchaWindow()
        {
            InitializeComponent();
            captcha = AuthoriseHelper.GenerateCaptcha();
            CaptchaTbl.Text = captcha;
        }

        private void EntrytBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaTb.Text == captcha)
            {
                DialogResult = true;
            }
            else
            {
                errorsCount++;
                ClassMessageBox.Error("CAPTCHA введеа неправильно.");
                captcha = AuthoriseHelper.GenerateCaptcha();
                CaptchaTbl.Text = captcha;
                CaptchaTb.Text = string.Empty;
            }
            if (errorsCount == 3)
            {
                BlockWindow blockWindow = new BlockWindow();
                blockWindow.ShowDialog();
                errorsCount = 0;
            }
        }
    }
}
