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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace horoscope_course_work
{
    /// <summary>
    /// Логика взаимодействия для sign_information.xaml
    /// </summary>
    public partial class sign_information : Page
    {
        public MainWindow mainWindow;
        public sign_information(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void oven_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_oven.txt");
        }
        private void leo_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_leo.txt");
        }
        private void telec_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_telec.txt");
        }
        private void deva_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_deva.txt");
        }
        private void vesi_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_vesi.txt");
        }
        private void scorpio_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_scorpio.txt");
        }
        private void str_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_strelec.txt");
        }
        private void rak_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_cancer.txt");
        }
        private void twins_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_twins.txt");
        }
        private void vodol_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_aquarius.txt");
        }
        private void fish_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_fish.txt");
        }
        private void kozerog_Click(object sender, RoutedEventArgs e)
        {
            descr.Text = File.ReadAllText("descriptions\\description_kozerog.txt");
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.account);
        }
    }
}
