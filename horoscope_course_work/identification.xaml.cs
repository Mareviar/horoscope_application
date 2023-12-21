
using System;

using System.Data;
using System.IO;

using System.Windows;
using System.Windows.Controls;


namespace horoscope_course_work
{
    /// <summary>
    /// Логика взаимодействия для identification.xaml
    /// </summary>
    public partial class identification : Page
    {
        public MainWindow mainWindow;
        public identification(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }


        public int hash_func(string pas)
        {
            int  num = 0;
            for (int i = 0; i < pas.Length; i++)
            {
                num += pas[i];
            }
            int hash = ((num * 7) % (num * 3)) + 'b' + 'a' + 'v';
            return hash;
        }

        public void login_save()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("describe.txt");
                //Write a line of text
                sw.WriteLine(log.Text);
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось сохранить имя");
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        private void log_in_Click(object sender, RoutedEventArgs e)
        {
            Requests requests = new Requests();
            if (log.Text.Length > 0 || pas.Password.Length > 0) // проверяем введён ли логин     
            {
                int hash = hash_func(pas.Password);

                // проверяем введён ли пароль         
                // ищем в базе данных пользователя с такими данными         
                DataTable dt_user = mainWindow.Select(requests.request_log + log.Text + requests.request_log_hash + hash + "'");
                if (dt_user.Rows.Count > 0) // если такая запись существует       
                {
                    login_save();
                    mainWindow.OpenPage(MainWindow.Pages.account);          // переходим в лмчный кабинет!!!
                }
                else
                {
                    dt_user = mainWindow.Select(requests.request_log + log.Text + "'");
                    DataTable pswd = mainWindow.Select(requests.request_hash + hash + "'");
                    if (dt_user.Rows.Count == 0)
                    {
                        error.Text = ("Пользователь с таким именем не найден!"); // выводим ошибку  
                    }
                    else if (dt_user.Rows.Count > 0 && pswd.Rows.Count == 0)
                    {
                        error.Text = "Пароль неверный!";
                    }
                }
            }
            else error.Text = "Введите имя пользователя и пароль!"; // выводим ошибку    
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.registration);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void forget_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.change_password);
        }
    }
}
