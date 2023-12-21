
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;

namespace horoscope_course_work
{
    /// <summary>
    /// Логика взаимодействия для spravka.xaml
    /// </summary>
    public partial class spravka : Page
    {
        public MainWindow mainWindow;
        public spravka(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            string text = File.ReadAllText("spravka.txt");
            spr.Text = text;
        }


        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.account);
        }

    }
}
