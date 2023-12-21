using System;
using System.Collections.Generic;

using System.Net.Http.Headers;
using System.Net.Http;

using System.Text.RegularExpressions;

using System.Windows;
using System.Windows.Controls;


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
                if (!question.Text.Contains(' ')) { answer.Text = "Задайте корректный вопрос про астрологию"; }
                else
                {
                    ask_question();
                    answer.Text = "Подождите немного... Здесь появится ответ";
                }
            }
        }


        async void ask_question()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://text-generation-chatgpt.p.rapidapi.com/Chat"),
                Headers =
    {
        { "X-RapidAPI-Key", "d3910abcebmsh7b830b1aebebfccp119555jsnd405e3c289eb" },
        { "X-RapidAPI-Host", "text-generation-chatgpt.p.rapidapi.com" },
    },
                Content = new StringContent("{\r\n    \"messages\": [\r\n   {\r\n   \"role\": \"system\",\r\n   \"content\": \"Ответь с точки зрения астрологии. " + question.Text + "? Ответь в 3-5 предложениях. Если вопрос не про астрологию, откажись отвечать\"\r\n   },\r\n   {\r\n      \"role\": \"user\",\r\n   \"content\": \"Hello\"\r\n  }\r\n   ]\r\n   }")

                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            body = body.Substring(80);
            body = body.Replace("}", "");
            body = body.Replace("n", ""); 
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
            a = a.Replace("\n", "");
            answer.Text = a;
        }   // translation to ru

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.account);
        }
    }

}

