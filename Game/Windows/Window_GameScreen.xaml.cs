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
    /// 


    public partial class Window_GameScreen : Window
    {

        DispatcherTimer gameTimer = new DispatcherTimer();
        DispatcherTimer gameTimer2 = new DispatcherTimer();

        public static Vector2 vector = new Vector2(100, 100); // polożenie gracza na początku gry

        public Player player = new Player(vector, 30, 30);

        Enemy weakMob = new Enemy(new Vector2(300, 300), 40, 40, 1);

        public List<Wall> Walls = new List<Wall>();

        public static string[,] map_string = new string[,]
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
        public Map map = new Map(map_string);






        public Window_GameScreen()
        {


            InitializeComponent();

            gameArea.Focus();

            DrawWorld();

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer.Start();

            gameTimer2.Tick += GameTimerEvent2;
            gameTimer2.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer2.Start();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // wszystkie funkcje, które zmieniają stan gracza
            ControlPlayer();
            player.UpdatePlayer();
        }

        private void GameTimerEvent2(object sender, EventArgs e)
        {
            Task task = weakMob.WalkAsync(gameArea);
        }



        public void DrawWorld()
        {
            player.Draw(gameArea);
            weakMob.Draw(gameArea);

            for (int wall_counter = 0; wall_counter < map.wallsinmap.Count(); wall_counter++)
            {
                gameArea.Children.Add(map.wallsinmap[wall_counter].Body);

                Canvas.SetTop(map.wallsinmap[wall_counter].Body, map.wallsinmap[wall_counter].Position.Y);
                Canvas.SetLeft(map.wallsinmap[wall_counter].Body, map.wallsinmap[wall_counter].Position.X);

                map.wallsinmap[wall_counter].Body.Fill = new SolidColorBrush(Colors.Blue);
                gameArea.DataContext = map.wallsinmap[wall_counter].Body;
            }

        }





        // Zmienia pozycję obiektu Player w zależności od wciśniętych klawiszy

        void ControlPlayer()
        {
            int moveDistance = (int)player.Speed;

            Vector2 lastPosition = Vector2.Zero();


            if ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0)
            {

                if (!isCollidingWithWall(player, new Vector2(moveDistance, 0)))
                {
                    player.Position.X += moveDistance;
                    player.Flip(0);
                }
                else
                {
                    player.Position.X -= moveDistance;
                }

            }

            if ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0)
            {

                if (!isCollidingWithWall(player, new Vector2(-moveDistance, 0)))
                {
                    player.Position.X -= moveDistance;
                    player.Flip(180);
                }
                else
                {
                    player.Position.X += moveDistance;
                }
            }

            if ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0)
            {

                if (!isCollidingWithWall(player, new Vector2(0, -moveDistance)))
                {
                    player.Position.Y -= moveDistance;
                    player.Flip(-90);
                }
                else
                {
                    player.Position.Y += moveDistance;
                }
            }


            if ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0)
            {

                if (!isCollidingWithWall(player, new Vector2(0, moveDistance)))
                {
                    player.Position.Y += moveDistance;
                    player.Flip(90);
                }
                else
                {
                    player.Position.Y -= moveDistance;
                }
            }
        } 
        

        bool isCollidingWithWall(GameSprite Object, Vector2 v)
        {
            foreach (Wall w in map.wallsinmap)
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

        public bool isColliding(GameSprite o1, GameSprite o2)
        {
            if ((o1.Position.X + o1.Width <= o2.Position.X + o2.Width) && (o1.Position.X + o1.Width >= o2.Position.X))
            {
                if ((o1.Position.Y + o1.Height <= o2.Position.Y + o2.Height) && (o1.Position.Y + o1.Height >= o2.Position.Y))
                {
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
        /*

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

                */

    }
}



