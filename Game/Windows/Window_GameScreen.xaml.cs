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



        public List<Wall> Walls = new List<Wall>();




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



        string[,] Map =
            {
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},

            };

        public void DrawWorld()
        {
            // Rysowanie głownego bohatera
            // Body
            player.Body = new Rectangle();
            gameArea.Children.Add(player.Body);
            player.Body.Width = 20;
            player.Body.Height = 20;
            player.Body.Fill = new SolidColorBrush(Colors.Violet);
            gameArea.DataContext = player.Body;
            // Face
            player.Face = new Rectangle();
            gameArea.Children.Add(player.Face);
            player.Face.Width = 10;
            player.Face.Height = 20;
            Canvas.SetTop(player.Face, player.Position.Y);
            Canvas.SetLeft(player.Face, player.Position.X);
            player.Face.Fill = new SolidColorBrush(Colors.Black);
            gameArea.DataContext = player.Face;



            
            for(int i = 0; i < Map.GetLength(1); i++)
            {
                for(int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "w")
                    {
                        Wall sciana = new Wall(new Vector2(i*40,j*40), 40, 40);
                        sciana.Body = new Rectangle();
                        sciana.Body.Width = 40;
                        sciana.Body.Height = 40;//czemu ustawienia z konstruktora nie dzialaja?
                        gameArea.Children.Add(sciana.Body);

                        Canvas.SetTop(sciana.Body, sciana.Position.Y);
                        Canvas.SetLeft(sciana.Body, sciana.Position.X);

                        sciana.Body.Fill = new SolidColorBrush(Colors.Blue);
                        gameArea.DataContext = sciana.Body;
                        Walls.Add(sciana);
                        
                    }
                }
            }
        }





        // Zmienia pozycję obiektu Player w zależności od wciśniętych klawiszy

        void ControlPlayer()
        {
            int moveDistance = (int)player.Speed;

            Vector2 lastPosition = Vector2.Zero();

            if ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player,new Vector2(moveDistance,0)))
                {
                    player.Position.X += moveDistance;
                    player.RenderTransform = new RotateTransform(-180, player.Width / 2, player.Height / 2);
                    player.Face.RenderTransform = new RotateTransform(-180, player.Width / 2, player.Height / 2);
                }
                else {
                    player.Position.X -= moveDistance;
                    //player.RenderTransform = new RotateTransform(-180, player.Width / 2, player.Height / 2);
                    //player.Face.RenderTransform = new RotateTransform(-180, player.Width / 2, player.Height / 2);
                }
                
            }

            if ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player, new Vector2(-moveDistance, 0)))
                {
                    player.Position.X -= moveDistance;
                    player.RenderTransform = new RotateTransform(0, player.Width / 2, player.Height / 2);
                    player.Face.RenderTransform = new RotateTransform(0, player.Width / 2, player.Height / 2);
                }
                else
                {
                    player.Position.X += moveDistance;
                    //player.RenderTransform = new RotateTransform(-180, player.Width / 2, player.Height / 2);
                    //player.Face.RenderTransform = new RotateTransform(-180, player.Width / 2, player.Height / 2);
                }
            }

            if ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player, new Vector2(0,moveDistance)))
                {
                    player.Position.Y -= moveDistance;
                    player.RenderTransform = new RotateTransform(90, player.Width / 2, player.Height / 2);
                    player.Face.RenderTransform = new RotateTransform(90, player.Width / 2, player.Height / 2);
                }
                else
                {
                    player.Position.Y += moveDistance;
                    //player.RenderTransform = new RotateTransform(-90, player.Width / 2, player.Height / 2);
                    //player.Face.RenderTransform = new RotateTransform(-90, player.Width / 2, player.Height / 2);
                }
                
                
            }

            if ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player, new Vector2(0, -moveDistance)))
                {
                    player.Position.Y += moveDistance;
                    player.RenderTransform = new RotateTransform(-90, player.Width / 2, player.Height / 2);
                    player.Face.RenderTransform = new RotateTransform(-90, player.Width / 2, player.Height / 2);
                }
                else {
                    player.Position.Y -= moveDistance;
                    //player.RenderTransform = new RotateTransform(90, player.Width / 2, player.Height / 2);
                    //player.Face.RenderTransform = new RotateTransform(90, player.Width / 2, player.Height / 2);
                }
                
            }
        }



        // Aktualizuje pozycję gracza na obiekcie Canvas (nasz ekran gry)

        private void UpadatePlayer()
        {
            Canvas.SetLeft(player.Body, player.Position.X);
            Canvas.SetTop(player.Body, player.Position.Y);
            Canvas.SetLeft(player.Face, player.Position.X);
            Canvas.SetTop(player.Face, player.Position.Y);
        }

        bool isCollidingWithWall(GameSprite Object, Vector2 v)
        {
            foreach (Wall w in Walls)
            {
                Rect playerHB = new Rect(Canvas.GetLeft(Object.Body) + v.X, Canvas.GetTop(Object.Body) + v.Y, Object.Width, Object.Height);
                Rect wallHB = new Rect(Canvas.GetLeft(w.Body), Canvas.GetTop(w.Body), w.Width, w.Height);

                if (playerHB.IntersectsWith(wallHB))
                {
                    return true;
                }

            }
            return false;
        }

        public bool isColliding(GameSprite o1,GameSprite o2)
        {
            if((o1.Position.X+o1.Width<=o2.Position.X+o2.Width)&&(o1.Position.X + o1.Width >= o2.Position.X)){
                if ((o1.Position.Y + o1.Height <= o2.Position.Y + o2.Height)&& (o1.Position.Y + o1.Height >= o2.Position.Y)){
                    return true;
                }
            }
            return false;
        }


       

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
