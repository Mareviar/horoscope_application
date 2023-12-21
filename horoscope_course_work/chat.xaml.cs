using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
using System.IO;

namespace horoscope_course_work
{
    /// <summary>
    /// Логика взаимодействия для chat.xaml
    /// </summary>
    public partial class chat : Page
    {
        public MainWindow mainWindow;
        public chat(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (question.Text == "")
            {
                wait.Text = "Введите вопрос";
            }
            else if (question.Text != "")
            {
                ask_question();
                wait.Text = "Подождите немного... Здесь появится ответ";
            }
            else { wait.Text = "К сожалению, Вы больше не можете задать вопрос в этом месяце"; }
        }

        async void ask_question()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://open-ai21.p.rapidapi.com/conversationllama"),
                Headers =
    {
        { "X-RapidAPI-Key", "d3910abcebmsh7b830b1aebebfccp119555jsnd405e3c289eb" },
        { "X-RapidAPI-Host", "open-ai21.p.rapidapi.com" },
    },
                Content = new StringContent("{\r\n    \"messages\": [\r\n        {\r\n            \"role\": \"user\",\r\n            \"content\": \"image that you are an astrologist. " + question.Text + "? Answer in 3-5 sensenses. \"\r\n        }\r\n    ],\r\n    \"web_access\": false\r\n}")
                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };
            using var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            body = body.Substring(76);
            body = body.Replace("}", "");
            int num = body.Length;
            Translate(body, num);
        }

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
            a = a.Substring(num + 85);
            answer.Text = a;
        }   // translation to ru

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.account);
        }
    }

}

