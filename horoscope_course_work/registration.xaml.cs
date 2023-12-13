﻿using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace horoscope_course_work
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Page
    {
        public MainWindow mainWindow;
        public registration(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public int hash_(string pas)
        {
            int hash = 0;
            for (int i = 0; i < pas.Length; i++)
            {
                hash += pas[i];
            }
            return hash;
        }

        private void log_in_Click(object sender, RoutedEventArgs e)
        {
            Requests requests = new Requests();
            int hash, second_hash;
            if (log.Text.Length > 0) // проверяем логин
            {
                DataTable dt = mainWindow.Select(requests.request_log + log.Text + "'");
                if (dt.Rows.Count == 0)
                {
                    if (pas.Password.Length >= 5) // проверяем пароль
                    {
                        if (pas_Copy.Password.Length > 0) // проверяем второй пароль
                        {
                            if (sign.Text.Length > 0)
                            {
                                hash = hash_(pas.Password.ToString());
                                second_hash = hash_(pas_Copy.Password.ToString());
                                if (hash == second_hash) // проверка на совпадение паролей
                                {
                                    mainWindow.Select(requests.request_with_sign + log.Text + "', '" + hash + "', '" + sign.Text + "', '50')");

                                    MessageBox.Show("Пользователь зарегистрирован. Закройте это окно и войдите в систему");
                                    mainWindow.OpenPage(MainWindow.Pages.identification);
                                }
                                else error.Text = ("Пароли не совпaдают");
                            }
                            else error.Text = "Введите знак зодиака";
                        }
                        else error.Text = ("Повторите пароль");
                    }
                    else error.Text = ("Укажите пароль. Пароль должен состоять из 5 и более символов");
                }
                else error.Text = ("Такое имя пользователя уже зарегистрировано!");
            }
            else error.Text = ("Введите имя пользователя");
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.identification);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
    }
}

