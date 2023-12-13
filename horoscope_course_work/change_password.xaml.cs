using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace horoscope_course_work
{
    /// <summary>
    /// Логика взаимодействия для change_password.xaml
    /// </summary>
    public partial class change_password : Page
    {
        public MainWindow mainWindow;
        public change_password(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.identification);
        }

        public int hash_(string pass)
        {
            int hash = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                hash += pass[i];
            }
            return hash;
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            Requests requests = new Requests();
            if (login.Text == "" || pass.Password == "")
            {
                error.Text = "Заполните все поля!";
            }
            else if (login.Text != "" && pass.Password != "")
            {
                if (pass.Password.Length > 5)
                {
                    DataTable dt = mainWindow.Select(requests.request_log + login.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        int hash = hash_(pass.Password);
                        DataTable dt_user = mainWindow.Select(requests.request_log + login.Text + "'");
                        if (dt_user.Rows.Count > 0)
                        {
                            mainWindow.Select(requests.reqest_change + hash + "' WHERE [login] = '" + login.Text + "'");
                            error.Text = "Пароль изменен! Вернитесь на главную страницу";
                        }
                    }
                    else
                    {
                        error.Text = "Аккаунт с таким именем не зарегистрирован";
                    }
                }
                else {
                    error.Text = "Пароль должен содержать более 5 символов";
                }
            }
        }
    }
}
