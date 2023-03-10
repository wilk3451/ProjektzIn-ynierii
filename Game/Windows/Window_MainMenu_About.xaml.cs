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
using System.Windows.Shapes;

namespace Game.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Window_MainMenu_About.xaml
    /// </summary>
    public partial class Window_MainMenu_About : Window
    {
        public Window_MainMenu_About()
        {
            InitializeComponent();
        }

        private void button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
