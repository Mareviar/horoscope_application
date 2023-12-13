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
        }

        private void Spravka()
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e) { }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.account);
        }
    }
}
