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
using Game;
using System.Windows.Threading;

namespace Game.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Window_GameScreen.xaml
    /// </summary>
    public partial class Window_GameScreen : Window
    {
        bool goLeft, goRight, goUp, goDown;
        int playerSpeed = 5;

        DispatcherTimer gameTimer = new DispatcherTimer();
        
        


        
        public Window_GameScreen()
        {
            InitializeComponent();

            Test.Focus();

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer.Start();


        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft == true && Canvas.GetLeft(Player) > 5)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);
                kolizja("l");
            }

            if (goRight == true && Canvas.GetLeft(Player) + (Player.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
                kolizja("p");
            }

            if (goUp == true && Canvas.GetTop(Player) > 5)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) - playerSpeed);
                kolizja("g");
            }

            if (goDown == true && Canvas.GetTop(Player) + (Player.Height * 2) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) + playerSpeed);
                kolizja("d");
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                goLeft = true;
            }
            if (e.Key == Key.D)
            {
                goRight = true;
            }
            if (e.Key == Key.W)
            {
                goUp = true;
            }
            if (e.Key == Key.S)
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                goLeft = false;
            }
            if (e.Key == Key.D)
            {
                goRight = false;
            }
            if (e.Key == Key.W)
            {
                goUp = false;
            }
            if (e.Key == Key.S)
            {
                goDown = false;
            }
        }

        private void kolizja(string kierunek)
        {
            foreach(var x in Test.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "kolizja")
                {
                    Rect playerHB = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
                    Rect Kolidowanie = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);//hitboxy

                    if (playerHB.IntersectsWith(Kolidowanie))
                    {
                        if (kierunek == "l")
                        {
                            Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
                            
                        }
                        else if(kierunek == "p")
                        {
                            Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);
                            
                        }
                        else if (kierunek == "g")
                        {
                            Canvas.SetTop(Player, Canvas.GetTop(Player) + playerSpeed);

                        }
                        else if (kierunek == "d")
                        {
                            Canvas.SetTop(Player, Canvas.GetTop(Player) - playerSpeed);

                        }

                    }
                }   
            }
        }
    }
}
