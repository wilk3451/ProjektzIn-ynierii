using System;
using System.IO;
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
using Game.Windows;
using Game.UserControls;


namespace Game
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl_MainMenu.xaml
    /// </summary>
    public partial class UserControl_MainMenu : UserControl
    {
        public UserControl_MainMenu()
        {
            InitializeComponent();
        }




        private void button_New_Game_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //(Parent as Window).Content = new UserControl_SelectCharacter();
            // normalnie w tym miejscu mogłoby być tworzone nowe okno wyboru postaci, jak gracz kliknie w postać - tamto okno musi zostac zamknięte
            // i stworzone nowe - ekranu gry z przekazanymi danymi...
            // teraz: od razu tworzy się okienko gry:

            bool NewGame = true;
            bool Continue = false;

            string folder = @"";
            string file = "StanGry.txt";
            string Path = folder + file;
            string[] info = { NewGame.ToString(), Continue.ToString() };
            File.WriteAllLines(Path, info);

            Window_GameScreen gameScreen = new Window_GameScreen()
            {
                Owner = this.Parent as Window,
                ShowInTaskbar = false
                //IsEnabled = true
            };

            gameScreen.ShowDialog();
        }

        private void button_Load_Last_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //(Parent as Window).Content = new UserControl_SelectCharacter();

            bool NewGame = false;
            bool Continue = true;

            string folder = @"";
            string file = "StanGry.txt";
            string Path = folder + file;
            string[] info = { NewGame.ToString(), Continue.ToString() };
            File.WriteAllLines(Path, info);

            Window_GameScreen gameScreen = new Window_GameScreen()
            {
                Owner = this.Parent as Window,
                ShowInTaskbar = false
            };

            gameScreen.ShowDialog();
        }

        private void button_Settings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window_MainMenu_Settings settings = new Window_MainMenu_Settings()
            {
                Owner = this.Parent as Window,
                ShowInTaskbar = false
            };

            settings.ShowDialog();
        }

        private void button_About_Click(object sender, RoutedEventArgs e)
        {
            Window_MainMenu_About about = new Window_MainMenu_About()
            {
                Owner = this.Parent as Window,
                ShowInTaskbar = false
            };

            about.ShowDialog();
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
