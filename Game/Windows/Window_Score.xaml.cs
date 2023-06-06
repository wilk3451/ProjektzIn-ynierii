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
using Game.Creatures;
using Game.UserControls;
namespace Game.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Window_Score.xaml
    /// </summary>
    public partial class Window_Score : Window
    {
        public static Vector2 end1 = new Vector2(240, 50);
        public static Vector2 end2 = new Vector2(300, 150);
        public Wynik HS = new Wynik(end1, 240, 70);
        public Wynik S = new Wynik(end2, 240, 50);

        //public object GameOver { get; private set; }

        public Window_Score()
        {
            InitializeComponent();
            Highscore_Screen();
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Highscore_Screen()
        {
            /*if (Score > Highscore)
            {
                Highscore = Score;
            }*/

            string[] KoniecGry = File.ReadAllLines(@".\Punkty.txt");

            TextBlock EndResult = new TextBlock();

            EndResult.FontSize = 52;
            EndResult.LineHeight = 60;
            EndResult.TextWrapping = TextWrapping.Wrap;
            EndResult.TextAlignment = TextAlignment.Center;
            string result1 = "Highscore: " + int.Parse(KoniecGry[0]);//XDDDD
            EndResult.Inlines.Add(new Run(result1));
            //EndResult.Background = Brushes.AntiqueWhite;
            GameOver.Children.Add(EndResult);
            Canvas.SetTop(EndResult, HS.Position.Y);
            Canvas.SetLeft(EndResult, HS.Position.X + 100);

            TextBlock CurrentScore = new TextBlock();

            CurrentScore.FontSize = 42;
            CurrentScore.LineHeight = 50;
            CurrentScore.TextWrapping = TextWrapping.Wrap;
            CurrentScore.TextAlignment = TextAlignment.Center;
            string result2 = "Score: " + int.Parse(KoniecGry[1]);//XDDDD
            CurrentScore.Inlines.Add(new Run(result2));
            //CurrentScore.Background = Brushes.AntiqueWhite;
            GameOver.Children.Add(CurrentScore);
            Canvas.SetTop(CurrentScore, S.Position.Y);
            Canvas.SetLeft(CurrentScore, S.Position.X + 100);
        }
    }
}
