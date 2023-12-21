using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace horoscope_course_work
{
    /// <summary>
    /// Логика взаимодействия для account.xaml
    /// </summary>
    public partial class account : Page
    {
        public MainWindow mainWindow;
        public account(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        async void Get_horoscope(string sign)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://horoscope-api.p.rapidapi.com/pt/" + sign),
                Headers =
    {
        { "X-RapidAPI-Key", "d3910abcebmsh7b830b1aebebfccp119555jsnd405e3c289eb" },
        { "X-RapidAPI-Host", "horoscope-api.p.rapidapi.com" },
    },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            body = body.Substring(70);
            int a = body.Length;
            Translate(body, a);
        }   // horoscope for today (portugues)
        public string Get_Sign()
        {
            string sign = mainWindow.sign.Text;
            switch (sign)
            {
                case "Лев":
                    return "leao";

                case "Овен":
                    return "aries";

                case "Телец":
                    return "touro";

                case "Близнецы":
                    return "gemeos";

                case "Рак":
                    return "cancer";

                case "Дева":
                    return "virgem";

                case "Весы":
                    return "libra";

                case "Скорпион":
                    return "escorpiao";

                case "Стрелец":
                    return "sagitario";

                case "Козерог":
                    return "capricornio";

                case "Водолей":
                    return "aquario";

                case "Рыбы":
                    return "peixes";

                default:
                    return "null";
            }
        }               // get the sign (portugues)

        async void Tomorrow(string sign)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://horostory.p.rapidapi.com/horoscope?sign=" + sign + "&date=tomorrow"),
                Headers =
    {
        { "X-RapidAPI-Key", "d3910abcebmsh7b830b1aebebfccp119555jsnd405e3c289eb" },
        { "X-RapidAPI-Host", "horostory.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                string a = Regex.Unescape(body);
                a = a.Substring(76);
                int num = a.Length;
                Translate(a, num);
            }
        }   // horoscope for tomorrow (english - russian)
        public string Get_Sign_for_tomorrow()
        {
            string sign = mainWindow.sign.Text;
            switch (sign)
            {
                case "Лев":
                    return "leo";

                case "Овен":
                    return "aries";

                case "Телец":
                    return "taurus";

                case "Близнецы":
                    return "gemini";

                case "Рак":
                    return "cancer";

                case "Дева":
                    return "virgo";

                case "Весы":
                    return "libra";

                case "Скорпион":
                    return "scorpio";

                case "Стрелец":
                    return "sagittarius";

                case "Козерог":
                    return "capricorn";

                case "Водолей":
                    return "aquarius";

                case "Рыбы":
                    return "pisce";

                default:
                    return "null";
            }
        }   // get the sign for tomorrow (english)


        async void Translate(string body, int num)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://translate281.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "d3910abcebmsh7b830b1aebebfccp119555jsnd405e3c289eb" },
        { "X-RapidAPI-Host", "translate281.p.rapidapi.com" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "text", body },
        { "from", "auto" },
        { "to", "ru" },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();

            }
            string a = Regex.Unescape(body);
            a = a.Substring(num + 95);
            describe.Text = a;
        }   // translation to ru


        private void describe_TextChanged(object sender, TextChangedEventArgs e) { }
        private void character_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow.sign.Text != "")
            {
                string sign = Get_Sign();
                if (sign == "sagitario")
                {
                    describe.Text = File.ReadAllText("sagit.txt");
                }
                else
                {
                    describe.Text = "Смотрим на звезды...";
                    Get_horoscope(sign);
                }
            }
        }
        private void all_signs_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.sign_information);
        }
        private void natal_map_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.chat);
        }
        private void tomorrow_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow.sign.Text != "")
            {
                string sign = Get_Sign_for_tomorrow();
                Tomorrow(sign);
            }
            else
            {
                describe.Text = "Введите дату справа";
            }
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.identification);
        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e) { }
        private void month_TextChanged(object sender, TextChangedEventArgs e) { }
        private void info_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.spravka);
        }
    }
}

