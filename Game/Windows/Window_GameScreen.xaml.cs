using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using Game.Items;


namespace Game.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Window_GameScreen.xaml
    /// </summary>
    /// 


    public partial class Window_GameScreen : Window
    {

        // DEKLARACJE GLOBALNYCH ZMIENNYCH      
        DispatcherTimer gameTimer = new DispatcherTimer();
        //Thread GameLoop = new Thread(Thread_GameLoop);
        public Random rand = new Random();
        static int enemyCounter = 3;
        int directionTimer = 10;
        int TimerLimit = 30;
        int[] kierunkiX = new int[] { 1, 1, -1, 1, 1 };
        int[] kierunkiY = new int[] { 1, -1, 1, -1, 1 };
        float enemySpeed = 1;
        public int lastSide = 0;

        public static Vector2 vector = new Vector2(100, 100); // polożenie gracza na początku gry

        public Player player = new Player(vector, 30, 30);

        public List<Bullet> bullets = new List<Bullet>();

        public List<Enemy> enemies = new List<Enemy>();

        public List<Wall> Walls = new List<Wall>();

        public static string[,] map_string = new string[,]
            {
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
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

        

        public void DrawWorld()
        {
            player.Create(gameArea);
         
            for (int i = 0; i < 5; i++)
            {
                Vector2 poz = new Vector2(0, 0);
                Enemy enemy = new Enemy(poz, 40, 40, 1);
                enemy.Position = enemy.RandomSpawnPosition(gameArea, player, rand);
                enemy.Create(gameArea);
                enemy.Draw();
                enemies.Add(enemy);
            }

            for (int wall_counter = 0; wall_counter < map.wallsinmap.Count(); wall_counter++)
            {
                gameArea.Children.Add(map.wallsinmap[wall_counter].Body);

                Canvas.SetTop(map.wallsinmap[wall_counter].Body, map.wallsinmap[wall_counter].Position.Y);
                Canvas.SetLeft(map.wallsinmap[wall_counter].Body, map.wallsinmap[wall_counter].Position.X);

                map.wallsinmap[wall_counter].Body.Fill = new SolidColorBrush(Colors.Blue);
                gameArea.DataContext = map.wallsinmap[wall_counter].Body;
            }

        }


        private void GameTimerEvent(object sender, EventArgs e)
        {
            int moveDistance = (int)player.Speed;
            //directionTimer--;

            /*
            if (directionTimer < 0)
            {
                for (int i = 0; i < enemyCounter; i++)
                {
                    kierunkiX[i] = rand.Next(-1, 2);
                    kierunkiY[i] = rand.Next(-1, 2);
                }
                directionTimer = TimerLimit;
            }*/


            if ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player, new Vector2(moveDistance, 0)))
                {
                    player.Update(new Vector2(moveDistance, 0), 0);
                    lastSide = 0;
                }
                else
                {
                    player.Update(new Vector2(-moveDistance, 0), 0);
                }
            }

            if ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player, new Vector2(-moveDistance, 0)))
                {
                    player.Update(new Vector2(-moveDistance, 0), 180);
                    lastSide = 1;
                }
                else
                {
                    player.Update(new Vector2(moveDistance, 0), 180);
                }
            }

            if ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player, new Vector2(0, -moveDistance)))
                {
                    player.Update(new Vector2(0, -moveDistance), -90);
                    lastSide = 2;
                }
                else
                {
                    player.Update(new Vector2(0, moveDistance), -90);
                }
            }

            if ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0)
            {
                if (!isCollidingWithWall(player, new Vector2(0, moveDistance)))
                {
                    player.Update(new Vector2(0, moveDistance), 90);
                    lastSide = 3;
                }
                else
                {
                    player.Update(new Vector2(0, -moveDistance), 90);
                }
            }

            if ((Keyboard.GetKeyStates(Key.E) & KeyStates.Down) > 0)
            {
                Vector2 poz = new Vector2(player.Position.X, player.Position.Y); // nowy wektor, bo konstruktor Bullet z jakiegos powodu zmienial pozycje gracza
                Bullet bullet = new Bullet(poz, 6, 6);
                bullet.Create(gameArea, player);
                bullets.Add(bullet);
            }

            if ((Keyboard.GetKeyStates(Key.R) & KeyStates.Down) > 0)
            {
                foreach (Enemy enemy in enemies)
                {
                    if (player.NormalAttack(enemy)) enemy.ChangeState();
                }
            }

            if ((Keyboard.GetKeyStates(Key.T) & KeyStates.Down) > 0)
            {
                foreach (Enemy enemy in enemies)
                {
                    if (player.StrongAttack(enemy)) enemy.ChangeState();
                }
            }


            foreach (var bullet in bullets)
            {
                // 20 - bullet speed
                // last side ma stary argument, wiec jak gracz w miedzyczasie sie obroci - poziski bd leciec w nowa strone
                bullet.Update(20, lastSide);

                // Jezeli pocisk wyjdzie poza obszar gry - usun z listy pociskow
                if (bullet.Position.X < 0 - gameArea.Width ||
                    bullet.Position.X > gameArea.Width ||
                    bullet.Position.Y < 0 - gameArea.Height ||
                    bullet.Position.Y > gameArea.Height)
                {
                    bullet.markedForDeletion = true;
                }
                bullet.Draw();
            }
            



            /// ENEMIES
            int licznikKierunkow = 0;


            foreach (var enemy in enemies)
            {
                enemySpeed = enemy.Speed;

                enemy.Draw();

                
                if (licznikKierunkow > enemyCounter) { licznikKierunkow = 0; }

                enemy.kierunekX = kierunkiY[++licznikKierunkow];
                enemy.kierunekY = kierunkiX[++licznikKierunkow];

                Vector2 nowyKierunek = new Vector2(enemySpeed * enemy.kierunekX, enemySpeed * enemy.kierunekY);

                enemy.Update(new Vector2(nowyKierunek.X, nowyKierunek.Y));

                if (isColliding(player, enemy))
                {
                    player.CurrentHp -= 20;
                }
                else
                {
                    enemy.ChangeStateBackToNormal();
                }

                
                // 
                if (enemy.kierunekX == 1 && isCollidingWithWall(enemy, new Vector2(enemySpeed + enemy.Width, 0)))
                {
                    enemy.Update(new Vector2(-enemySpeed*2, 0));
                }
               
                if (enemy.kierunekX == -1 && isCollidingWithWall(enemy, new Vector2(-enemySpeed - enemy.Width, 0)))
                {
                    enemy.Update(new Vector2(enemySpeed*2, 0));
                }
                
                if (enemy.kierunekY == 1 && isCollidingWithWall(enemy, new Vector2(0, enemySpeed + enemy.Height)))
                {
                    enemy.Update(new Vector2(0, -enemySpeed * 2));
                }
                
                if (enemy.kierunekY == -1 && isCollidingWithWall(enemy, new Vector2(0, -enemySpeed - enemy.Height)))
                {
                    enemy.Update(new Vector2(0, enemySpeed * 2));
                }



                if (enemy.IsDead()) 
                { 
                    enemy.markedForDeletion = true; 
                } 




                //enemy.Update(nowyKierunek);

                enemy.Draw();
                player.Draw();
            }

            if (bullets != null)
            { 
                foreach (var enemy in enemies)
                {
                    foreach (var bullet in bullets)
                    {
                        if (isColliding(bullet, enemy))
                        {
                            bullet.markedForDeletion = true;
                            enemy.markedForDeletion = true;
                        }
                        else
                        {
                            bullet.markedForDeletion = false;
                            enemy.markedForDeletion = false;
                        }
                    }
                }
            }

            if (bullets != null)
            {
                for (int i = bullets.Count - 1; i >= 0; i--)
                {
                    if (bullets[i].markedForDeletion)
                    {
                        bullets[i].Delete(gameArea);
                        bullets.RemoveAt(i);
                    }
                }
            }

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].markedForDeletion)
                {
                    enemies[i].Delete(gameArea);
                    enemies.RemoveAt(i);
                }
            }




            player.RegenerateStamina();
            player.Draw();
        }
        




        public bool isCollidingWithWall(GameSprite Object, Vector2 v)
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

        public bool isCollidingX(GameSprite o1, GameSprite o2)
        {
            if ( o1.Position.X + o1.Width + o1.Speed > o2.Position.X &&
                o1.Position.X + o1.Speed < o2.Position.X + o2.Width &&
                o1.Position.Y + o1.Height > o2.Position.Y &&
                o1.Position.Y < o2.Position.Y + o2.Height)
            {
                return true;
            }
            return false;
        }

        public bool isCollidingY(GameSprite o1, GameSprite o2)
        {
            if ( o1.Position.X + o1.Width > o2.Position.X &&
                o1.Position.X < o2.Position.X + o2.Width &&
                o1.Position.Y + o1.Height + o1.Speed > o2.Position.Y &&
                o1.Position.Y + o1.Speed < o2.Position.Y + o2.Height)
            {  
                return true;     
            }
            return false;
        }

    }

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

   



