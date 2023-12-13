
using System.Windows;
using System.Windows.Controls;

using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace horoscope_course_work
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(Pages.identification);
        }

        public enum Pages
        { 
            identification,
            registration,
            account,
            sign_information,
            chat,
            spravka,
            change_password
        }  

        public void OpenPage(Pages page)
        {
            if(page == Pages.identification)
            {
                frame.Navigate(new identification(this));
            }
            if(page == Pages.registration)
            {
                frame.Navigate(new registration(this));
            }
            if(page == Pages.account)
            {
                frame.Navigate(new account(this));
            }
            if(page == Pages.sign_information)
            {
                frame.Navigate(new sign_information(this));
            }
            if(page == Pages.chat)
            {
                frame.Navigate(new chat(this));
            }
            if(page == Pages.spravka)
            {
                frame.Navigate(new spravka(this));
            }
            if(page == Pages.change_password)
            {
                frame.Navigate(new change_password(this));
            }
        }

        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new("dataBase");                          // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=MAREVIAR;Trusted_Connection=Yes;DataBase=PERSONAL_DATA;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        private void who_Click(object sender, RoutedEventArgs e)
        {
            if (date.Text == "")
            {
                attention1.Text = "Введите день!";
            }
            else if (month.Text == "")
            {
                attention2.Text = "Введите номер месяца!";
            }
            else
            {

                attention1.Text = "";
                attention2.Text = "";
                string mon = month.Text;
                string data = date.Text;
                if (!Regex.IsMatch(mon, @"^[0-9]+$") || !Regex.IsMatch(data, @"^[0-9]+$"))
                {
                    attention2.Text = "Введите существующую дату!";
                }
                else
                {
                    int mes = int.Parse(mon);
                    int den = int.Parse(data);

                    if ((mes == 1 || mon == "01") && (den >= 20 && den <= 31))
                    {
                        sign.Text = "Водолей";
                    }
                    else if ((mes == 2 || mon == "02") && den >= 1 && den <= 19)
                    {
                        sign.Text = "Водолей";
                    }

                    else if ((mes == 1 || mon == "01") && (den < 20 && den >= 1))
                    {
                        sign.Text = "Козерог";
                    }
                    else if ((mes == 12) && den >= 21 && den <= 31)
                    {
                        sign.Text = "Козерог";
                    }

                    else if ((mes == 2 || mon == "02") && den >= 20 && den <= 29)
                    {
                        sign.Text = "Рыбы";
                    }
                    else if ((mes == 3 || mon == "03") && (den >= 1 && den <= 20))
                    {
                        sign.Text = "Рыбы";
                    }

                    else if ((mes == 3 || mon == "03") && (den > 20 && den <= 31))
                    {
                        sign.Text = "Овен";
                    }
                    else if ((mes == 4 || mon == "04") && (den > 1 && den <= 19))
                    {
                        sign.Text = "Овен";
                    }

                    else if ((mes == 4 || mon == "04") && (den >= 20 && den <= 30))
                    {
                        sign.Text = "Телец";
                    }
                    else if ((mes == 5 || mon == "05") && (den >= 1 && den <= 20))
                    {
                        sign.Text = "Телец";
                    }

                    else if ((mes == 5 || mon == "05") && (den > 20 && den <= 31))
                    {
                        sign.Text = "Близнецы";
                    }
                    else if ((mes == 6 || mon == "06") && (den >= 1 && den <= 20))
                    {
                        sign.Text = "Близнецы";
                    }

                    else if ((mes == 6 || mon == "06") && (den > 20 && den <= 30))
                    {
                        sign.Text = "Рак";
                    }
                    else if ((mes == 7 || mon == "07") && (den >= 1 && den < 23))
                    {
                        sign.Text = "Рак";
                    }

                    else if ((mes == 7 || mon == "07") && (den >= 23 && den <= 31))
                    {
                        sign.Text = "Лев";
                    }
                    else if ((mes == 8 || mon == "08") && (den >= 1 && den <= 22))
                    {
                        sign.Text = "Лев";
                    }

                    else if ((mes == 8 || mon == "08") && (den >= 23 && den <= 31))
                    {
                        sign.Text = "Дева";
                    }
                    else if ((mes == 9 || mon == "09") && (den >= 1 && den <= 22))
                    {
                        sign.Text = "Дева";
                    }

                    else if ((mes == 9 || mon == "09") && (den >= 23 && den <= 30))
                    {
                        sign.Text = "Весы";
                    }
                    else if (mes == 10 && (den >= 1 && den <= 23))
                    {
                        sign.Text = "Весы";
                    }

                    else if ((mes == 10 || mon == "10") && (den >= 24 && den <= 31))
                    {
                        sign.Text = "Скорпион";
                    }
                    else if ((mes == 11 || mon == "11") && (den >= 1 && den <= 22))
                    {
                        sign.Text = "Скорпион";
                    }

                    else if ((mes == 11 || mon == "11") && (den > 22 && den <= 30))
                    {
                        sign.Text = "Стрелец";
                    }
                    else if ((mes == 12 || mon == "12") && (den >= 1 && den <= 20))
                    {
                        sign.Text = "Стрелец";
                    }
                    else if ((mes < 0 || den < 0 || den > 31 || mes > 12) || (mes == 2 || mon == "02" && den > 29))
                    {
                        attention2.Text = "Ошибка в дате или месяце";
                    }
                }
            }
        }

        private void sound_Click(object sender, RoutedEventArgs e)
        {
            if (song.Volume != 0)
            {
                song.Volume = 0;
            }
            else { song.Volume  = 0.15; }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e) { }
        private void month_TextChanged(object sender, TextChangedEventArgs e) { }

    }
}
