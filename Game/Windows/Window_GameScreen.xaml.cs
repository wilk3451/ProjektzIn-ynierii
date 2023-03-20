using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Threading;
using Game.Creatures;

namespace Game.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Window_GameScreen.xaml
    /// </summary>
    public partial class Window_GameScreen : Window
    {

        DispatcherTimer gameTimer = new DispatcherTimer();

        public static Vector2 vector = new Vector2(100, 100); // polożenie gracza na początku gry

        public Player player = new Player(vector, 20, 20);

        //private static List<Shape2D> AllShapes = new List<Shape2D>();




        public Window_GameScreen()
        {
            InitializeComponent();

            gameArea.Focus();

            DrawWorld();

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer.Start();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // wszystkie funkcje, które zmieniają stan gry
            ControlPlayer();
            UpadatePlayer();
        }




        public void DrawWorld()
        {
            // Rysowanie głownego bohatera
            player.Body = new Rectangle();
            gameArea.Children.Add(player.Body);
            player.Body.Width = 20;
            player.Body.Height = 20;
            player.Body.Fill = new SolidColorBrush(Colors.Violet);
            gameArea.DataContext = player.Body;




            // Przykład ścian - dla obiektów jednego typu - lista!

            Rectangle leftWall = new Rectangle();
            gameArea.Children.Add(leftWall);
            leftWall.Width = 20;
            leftWall.Height = gameArea.Height;
            leftWall.Fill = new SolidColorBrush(Colors.Brown);
            Canvas.SetTop(leftWall, 0);
            Canvas.SetLeft(leftWall, 0);
            gameArea.DataContext = leftWall;

            Rectangle rightWall = new Rectangle();
            gameArea.Children.Add(rightWall);
            rightWall.Width = 20;
            rightWall.Height = gameArea.Height;
            rightWall.Fill = new SolidColorBrush(Colors.Brown);
            Canvas.SetTop(rightWall, 0);
            Canvas.SetLeft(rightWall, gameArea.Width - rightWall.Width);
            gameArea.DataContext = rightWall;

            Rectangle topWall = new Rectangle();
            gameArea.Children.Add(topWall);
            topWall.Width = gameArea.Width;
            topWall.Height = 20;
            topWall.Fill = new SolidColorBrush(Colors.Brown);
            Canvas.SetTop(topWall, 0);
            Canvas.SetLeft(topWall, 0);
            gameArea.DataContext = topWall;

            Rectangle bottomWall = new Rectangle();
            gameArea.Children.Add(bottomWall);
            bottomWall.Width = gameArea.Width;
            bottomWall.Height = 20;
            bottomWall.Fill = new SolidColorBrush(Colors.Brown);
            Canvas.SetTop(bottomWall, gameArea.Height - bottomWall.Height);
            Canvas.SetLeft(bottomWall, 0);
            gameArea.DataContext = bottomWall;
        }





        // Zmienia pozycję obiektu Player w zależności od wciśniętych klawiszy

        void ControlPlayer()
        {
            int moveDistance = (int)player.Speed;

            if ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0)
            {
                player.Position.X += moveDistance;
            }

            if ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0)
            {
                player.Position.X -= moveDistance;
            }

            if ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0)
            {
                player.Position.Y -= moveDistance;
            }

            if ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0)
            {
                player.Position.Y += moveDistance;
            }
        }



        // Aktualizuje pozycję gracza na obiekcie Canvas (nasz ekran gry)

        private void UpadatePlayer()
        {
            Canvas.SetLeft(player.Body, player.Position.X);
            Canvas.SetTop(player.Body, player.Position.Y);
        }





        /*
        private void kolizja(int kierunek)
        {
            foreach (var x in gameArea.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "kolizja")
                {
                    Rect playerHB = new Rect(Canvas.GetLeft(player.Body), Canvas.GetTop(player.Body), Player.Width, Player.Height);
                    Rect Kolidowanie = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);//hitboxy

                    if (playerHB.IntersectsWith(Kolidowanie))
                    {
                        if (kierunek == 1)
                        {
                            Canvas.SetLeft(player.Body, Canvas.GetLeft(player.Body) + playerSpeed);

                        }
                        else if (kierunek == 2)
                        {
                            Canvas.SetLeft(player.Body, Canvas.GetLeft(player.Body) - playerSpeed);

                        }
                        else if (kierunek == 3)
                        {
                            Canvas.SetTop(player.Body, Canvas.GetTop(player.Body) + playerSpeed);

                        }
                        else if (kierunek == 4)
                        {
                            Canvas.SetTop(player.Body, Canvas.GetTop(player.Body) - playerSpeed);

                        }
                    }
                }
            }
        }
        */


        /*
        private bool SomethingIsHere()
        {
            double mytop = Canvas.GetTop(Player);
            double mybottom = Canvas.GetBottom(Player);
            double myleft = Canvas.GetLeft(Player);
            double myright = Canvas.GetRight(Player);

            double othertop = Canvas.GetTop(Something);
            double otherbottom = Canvas.GetBottom(Something);
            double otherleft = Canvas.GetLeft(Something);
            double otherright = Canvas.GetRight(Something);

            if ((mybottom < othertop) || (mytop > otherbottom) || (myright < otherleft) || (myleft > otherright))
            {
                return false;
            }
            return true;
        }
        */





        /*
        private void movePlayer()
        {
            if (goLeft)
            {
                Canvas.SetLeft(player.Body, Canvas.GetLeft(player.Body) - playerSpeed);
                kolizja(1);
            }

            if (goRight)
            {
                Canvas.SetLeft(player.Body, Canvas.GetLeft(player.Body) + playerSpeed);
                kolizja(2);
            }

            if (goUp)
            {
                Canvas.SetTop(player.Body, Canvas.GetTop(player.Body) - playerSpeed);
                kolizja(3);
            }

            if (goDown)
            {
                Canvas.SetTop(player.Body, Canvas.GetTop(player.Body) + playerSpeed);
                kolizja(4);
            } 
        }
        */
        /*

        bool goLeft, goRight, goUp, goDown;

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

        */

    }


}
