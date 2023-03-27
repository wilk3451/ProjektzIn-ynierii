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
using static System.Net.Mime.MediaTypeNames;

namespace Game.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Window_GameScreen.xaml
    /// </summary>
    /// 


    public partial class Window_GameScreen : Window
    {

        DispatcherTimer gameTimer = new DispatcherTimer();
        List<Rectangle> itemRemover = new List<Rectangle>();
        Random rand = new Random();


        static int enemyCounter = 3;
        int limit = 50;
        int enemySpeed = 2;
        int directionTimer = 10;
        int TimerLimit = 30;
        int[] kierunkiX = new int[] { 1, 0, -1, 1, 1};
        int[] kierunkiY = new int[] { 1, -1, 1, -1, 1};

        Rect playerHitBox;




        public static Vector2 vector = new Vector2(100, 100); // polożenie gracza na początku gry

        public Player player = new Player(vector, 30, 30);

        Enemy weakMob = new Enemy(new Vector2(300, 300), 40, 40, 1);

        public List<Bullet> bullets = new List<Bullet>();

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
        }

        /*
        private void GameTimerEvent(object sender, EventArgs e)
        {
            // wszystkie funkcje, które zmieniają stan gracza
            ControlPlayer();
        }
        */

        public void DrawWorld()
        {
            player.Draw(gameArea);
            //weakMob.Draw(gameArea);
            for (int i = 0; i < 5; i++)
                MakeEnemies();

            for (int wall_counter = 0; wall_counter < map.wallsinmap.Count(); wall_counter++)
            {
                gameArea.Children.Add(map.wallsinmap[wall_counter].Body);

                Canvas.SetTop(map.wallsinmap[wall_counter].Body, map.wallsinmap[wall_counter].Position.Y);
                Canvas.SetLeft(map.wallsinmap[wall_counter].Body, map.wallsinmap[wall_counter].Position.X);

                map.wallsinmap[wall_counter].Body.Fill = new SolidColorBrush(Colors.Blue);
                gameArea.DataContext = map.wallsinmap[wall_counter].Body;
            }

        }

         public int lastSide = 0;




        // Zmienia pozycję obiektu Player w zależności od wciśniętych klawiszy
       

        private void GameTimerEvent(object sender, EventArgs e)
        { 
            int moveDistance = (int)player.Speed;
            Vector2 lastPosition = Vector2.Zero();
            directionTimer--;
            if (directionTimer < 0) 
            {
                for (int i = 0; i < enemyCounter; i++)
                {
                    kierunkiX[i] = rand.Next(-1, 2);
                    kierunkiY[i] = rand.Next(-1, 2);
                }
                directionTimer = TimerLimit;
            }
            

            playerHitBox = new Rect(player.Position.X, player.Position.Y, player.Width, player.Height);


            if ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player, new Vector2(moveDistance, 0)))
                {
                    player.Position.X += moveDistance;
                    player.Flip(0);
                    lastSide = 0;
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
                    lastSide = 1;
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
                    lastSide = 2;
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
                    lastSide = 3;
                }
                else
                {
                    player.Position.Y -= moveDistance;
                }
            }


            if ((Keyboard.GetKeyStates(Key.E) & KeyStates.Down) > 0)
            {
                Rectangle newBullet = new Rectangle
                {
                    Tag = "bullet",
                    Height = 6,
                    Width = 6,
                    Fill = Brushes.White,
                    Stroke = Brushes.Red
                };

                Canvas.SetLeft(newBullet, player.Position.X + player.Width / 2);
                Canvas.SetTop(newBullet, player.Position.Y + player.Height / 2);

                gameArea.Children.Add(newBullet);
            }


            int licznikKierunkow = 0;

            foreach (var x in gameArea.Children.OfType<Rectangle>())
            {
                if (licznikKierunkow > enemyCounter) { licznikKierunkow = 0; }

                if (x is Rectangle && (string)x.Tag == "bullet")
                {
                    // w prawo | lewo | gore | dol
                    if (lastSide == 0) { Canvas.SetLeft(x, Canvas.GetLeft(x) + 20); } // 20 - bullet speed
                    if (lastSide == 1) { Canvas.SetLeft(x, Canvas.GetLeft(x) - 20); }
                    if (lastSide == 2) { Canvas.SetTop(x, Canvas.GetTop(x) - 20); }
                    if (lastSide == 3) { Canvas.SetTop(x, Canvas.GetTop(x) + 20); }

                    Rect bulletHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (Canvas.GetTop(x) < 10)
                    {
                        itemRemover.Add(x);
                    }

                    foreach (var y in gameArea.Children.OfType<Rectangle>())
                    {
                        if (y is Rectangle && (string)y.Tag == "enemy")
                        {
                            Rect enemyHit = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);

                            if (bulletHitBox.IntersectsWith(enemyHit))
                            {
                                itemRemover.Add(x);
                                itemRemover.Add(y);           
                            }
                        }
                    }
                }

                if (x is Rectangle && (string)x.Tag == "enemy")
                {
                    // poruszanie

                    

                    Canvas.SetTop(x, Canvas.GetTop(x) + enemySpeed * kierunkiY[++licznikKierunkow]);
                    Canvas.SetLeft(x, Canvas.GetLeft(x) + enemySpeed * kierunkiX[++licznikKierunkow]);

                    

                    if (Canvas.GetTop(x) > gameArea.Height || Canvas.GetTop(x) < 0 - gameArea.Height)
                    {
                        Canvas.SetTop(x, Canvas.GetTop(x) + enemySpeed * (0 - kierunkiY[licznikKierunkow]));
                    }
                    if (Canvas.GetLeft(x) < 0 - gameArea.Width || Canvas.GetLeft(x) > gameArea.Height)
                    {
                        Canvas.SetLeft(x, Canvas.GetLeft(x) + enemySpeed * (0 - kierunkiX[licznikKierunkow]));
                    }


                    Rect enemyHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(enemyHitBox))
                    {
                        itemRemover.Add(x);
                        // ubytek zdorwia
                    }
                }
            }

            foreach (Rectangle elementDoUsuniecia in itemRemover)
            {
                gameArea.Children.Remove(elementDoUsuniecia);
            }

            player.UpdatePlayer();
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






        private void MakeEnemies()
        {
            ImageBrush enemySprite = new ImageBrush();
            enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/enemy.png"));
       
            Rectangle newEnemy = new Rectangle
            {
                Tag = "enemy",
                Height = 50,
                Width = 56,
                Fill = enemySprite
            };

            int Top = rand.Next(30, (int)gameArea.Height - 30);
            int Left = rand.Next(30, (int)gameArea.Width - 30);
            while(Top > player.Position.Y && Top < player.Position.Y)
            {
                Top = rand.Next(30, (int)gameArea.Height - 30);
            }
            while (Left > player.Position.X && Left < player.Position.X)
            {
                Left = rand.Next(30, (int)gameArea.Width - 30);
            }
            Canvas.SetTop(newEnemy, Top);
            Canvas.SetLeft(newEnemy, Left);
            gameArea.Children.Add(newEnemy);
        }



































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



