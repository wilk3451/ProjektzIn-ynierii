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
using System.Media;
using System.Threading;

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
        int[] kierunkiX = new int[] { 1, 1, -1, -1, 1 };
        int[] kierunkiY = new int[] { 1, -1, 1, -1, 1};
        float enemySpeed = 1;

        public bool is_in_room = false;

        public int lastSide = 0;
        public int BulletlastSide = 0;
        public int licznikKierunkow=0;

        public static Vector2 respawnLocation = new Vector2(100, 100); // polożenie gracza na początku gry

        public Player player = new Player(respawnLocation, 30, 30);

        public List<Bullet> bullets = new List<Bullet>();

        public List<Enemy> enemies = new List<Enemy>();

        
        public int map_index = 1;
        //public List<Wall> Walls = new List<Wall>();
        
        
        
        public Map map = new Map(MapsList.get(0));


        //Agnieszka

        Random random = new Random((int)DateTime.Now.Ticks);

        public static Vector2 skarb = new Vector2(270, 350);
        
        public static Vector2 Punkty = new Vector2(0,0);
        public Wynik W = new Wynik(Punkty, 100, 30);

        /*public static Vector2 kasa = new Vector2(250, 370);
        public static Vector2 kasa2 = new Vector2(290, 370);
        public static Vector2 kasa3 = new Vector2(290, 330);
        public static Vector2 kasa4 = new Vector2(250, 330);*/

        //public Treasure killer = new Treasure(skarb, 50, 20);

        /*public Coin C = new Coin(kasa, 10, 10);
        public Emerald E = new Emerald(kasa2, 12, 12);
        public Ruby R = new Ruby(kasa3, 14, 14);
        public Diamond D = new Diamond(kasa4, 16, 16);*/

        public int HowManyC, HowManyE, HowManyR, HowManyD;

        public List<Coin> coins = new List<Coin>();
        public List<Emerald> emeralds = new List<Emerald>();
        public List<Ruby> rubys = new List<Ruby>();
        public List<Diamond> diamonds = new List<Diamond>();

        public int Score = 0;

        public bool WasTouched = false;

        //Agnieszka


        //K - s
        public Inventory inventory = new Inventory();
        public float lastSpeed; // przechowuje predkosc wrogow na czas uzywania inventory
        //K

        bool playMusic = true;
        //MediaPlayer playMedia = new MediaPlayer();
        Thread thread = new Thread(PlayMusic);


        public Window_GameScreen()
        {
            InitializeComponent();

            gameArea.Focus();

            DrawWorld();
            inventory.DrawInventory(inv);

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer.Start();

            //thread.IsBackground = true;
            //thread.Start();
        }

        

        public void DrawWorld()
        {
            player.Create(gameArea);
            
            //Agnieszka
            //killer.Create(gameArea);
            //W.Create(gameArea);
            //Agnieszka
         
            /*for (int i = 0; i < 5; i++)
            {
                Vector2 poz = new Vector2(0, 0);
                Enemy enemy = new Enemy(poz, 40, 40, 1);
                enemy.Position = enemy.RandomSpawnPosition(gameArea, player, rand);
                enemy.Create(gameArea);
                enemy.Draw();
                enemies.Add(enemy);
            }*/

            updateWorld();

        }
        void NxtLvl()
        {
            gameArea.Children.Clear();
            enemies.Clear();
            if (map_index < MapsList.length())
            {
                map.changeMap(MapsList.get(map_index++));
            }
            player.Create(gameArea);
            player.Position = new Vector2(100, 100);
            lastSide = 1;
            updateWorld();
        }
        void NxtRoom(int Room_index)
        {
            gameArea.Children.Clear();
            if (is_in_room == false)
            {
                map.changeMap(RoomList.get(Room_index));
                player.Position = RoomList.getRoomPosition(Room_index);
                is_in_room = true;
            }
            else
            {
                map.changeMap(MapsList.get(map_index - 1));
                player.Position = RoomList.getReturnPosition(Room_index);
                is_in_room = false;
            }
            player.Create(gameArea);
            //player.Position = new Vector2(100, 100);
            lastSide = 1;
            updateWorld();
        }

        private static void PlayMusic()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }


        private void GameTimerEvent(object sender, EventArgs e)
        {
            int moveDistance = (int)player.Speed;
            //directionTimer--;

            //K
            //SoundPlayer sound = new SoundPlayer("Properties.Resources.awesomeness");
            //sound.Play();
            //sound.PlayLooping(); 

            //Agnieszka
            EarnMoney();
            //Agnieszka

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
                if (isCollidingWithNxtLvlDoor(player, new Vector2(moveDistance, 0)))
                {
                    NxtLvl();
                }

                if (isCollidingWithDoor(player, new Vector2(moveDistance, 0)) != -1)
                {
                    int Room_index = isCollidingWithDoor(player, new Vector2(moveDistance,0));

                    NxtRoom(Room_index);
                    

                }
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
                if (isCollidingWithNxtLvlDoor(player, new Vector2(-moveDistance, 0)))
                {
                    NxtLvl();
                }
                if (isCollidingWithDoor(player, new Vector2( -moveDistance,0)) != -1)
                {
                    int Room_index = isCollidingWithDoor(player, new Vector2(-moveDistance,0));

                    NxtRoom(Room_index);
                    /*gameArea.Children.Clear();
                    if (is_in_room == false)
                    {
                        map.changeMap(RoomList.get(Room_index));
                        is_in_room = true;
                    }
                    else
                    {
                        map.changeMap(MapsList.get(map_index - 1));
                        is_in_room = false;
                    }
                    player.Create(gameArea);
                    player.Position = new Vector2(100, 100);
                    lastSide = 1;
                    updateWorld();*/

                }
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
                if (isCollidingWithNxtLvlDoor(player, new Vector2(0, -moveDistance)))
                {
                    NxtLvl();
                }
                if (isCollidingWithDoor(player, new Vector2(0, -moveDistance))!=-1) 
                {
                    int Room_index = isCollidingWithDoor(player, new Vector2(0, -moveDistance));

                    NxtRoom(Room_index);
                    /*gameArea.Children.Clear();
                    if (is_in_room == false)
                    {
                        map.changeMap(RoomList.get(Room_index));
                        is_in_room = true;
                    }
                    else
                    {
                        map.changeMap(MapsList.get(map_index-1));
                        is_in_room = false;
                    }
                    player.Create(gameArea);
                    player.Position = new Vector2(100, 100);
                    lastSide = 1;
                    updateWorld();*/

                }
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
                if (isCollidingWithNxtLvlDoor(player, new Vector2(0, moveDistance)))
                {
                    NxtLvl();

                }
                if (isCollidingWithDoor(player, new Vector2(0, moveDistance)) != -1)
                {
                    int Room_index = isCollidingWithDoor(player, new Vector2(0, moveDistance));

                    NxtRoom(Room_index);
                    /*gameArea.Children.Clear();
                    if (is_in_room == false)
                    {
                        map.changeMap(RoomList.get(Room_index));
                        player.Position = RoomList.getRoomPosition(Room_index);
                        is_in_room = true;
                    }
                    else
                    {
                        map.changeMap(MapsList.get(map_index - 1));
                        player.Position = RoomList.getReturnPosition(Room_index);
                        is_in_room = false;
                    }
                    player.Create(gameArea);
                    //player.Position = new Vector2(100, 100);
                    lastSide = 1;
                    updateWorld();*/

                }

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
                BulletlastSide = lastSide;
                Bullet bullet = new Bullet(poz, 6, 6, BulletlastSide);
                bullet.Create(gameArea, poz);
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
            
            //Agnieszka 
            if ((Keyboard.GetKeyStates(Key.F) & KeyStates.Down) > 0)
            {
                
                    if (isCollidingWithTreasure(player, new Vector2(0,0))>=0)
                    {
                        //killer = (isCollidingWithTreasure(player, new Vector2(0, 0)));
                        int index= (isCollidingWithTreasure(player, new Vector2(0, 0)));
                        Vector2 temp= map.treasures[index].Position;
                        
                        HowManyC = random.Next(1, 8);
                        HowManyE = random.Next(1, 6);
                        HowManyR = random.Next(1, 4);
                        HowManyD = random.Next(0, 2);

                        for (int i = 0; i <= HowManyC; i++)
                        {
                            Coin C = new Coin(temp, 10, 10);
                            C.Position = C.RandomSpawnPosition(gameArea, map.treasures[index], rand);
                            C.Create(gameArea);
                            C.Draw();
                            coins.Add(C);
                        }

                        for (int i = 0; i <= HowManyE; i++)
                        {
                            Emerald E = new Emerald(temp, 15, 15);
                            E.Position = E.RandomSpawnPosition(gameArea, map.treasures[index], rand);
                            E.Create(gameArea);
                            E.Draw();
                            emeralds.Add(E);
                        }

                        for (int i = 0; i <= HowManyR; i++)
                        {
                            Ruby R = new Ruby(temp, 16, 16);
                            R.Position = R.RandomSpawnPosition(gameArea, map.treasures[index], rand);
                            R.Create(gameArea);
                            R.Draw();
                            rubys.Add(R);
                        }

                        for (int i = 0; i <= HowManyD; i++)
                        {
                            Diamond D = new Diamond(temp, 20, 20);
                            D.Position = D.RandomSpawnPosition(gameArea, map.treasures[index], rand);
                            D.Create(gameArea);
                            D.Draw();
                            diamonds.Add(D);
                        }
                        //Karolina

                        map.treasures[index].Delete(gameArea);
                        map.treasures.RemoveAt(index);
                        //
                        //gameArea.Children.Remove(killer.Body);
                        WasTouched = true;
                    
                    }

                // Karolina - start
 
                for (int i = map.potions.Count() - 1; i >= 0; i--)
                {
                    // w warunku spr kolizji z eliksirem!
                    if (map.potions[i] != null && isColliding(player, map.potions[i]) && map.potions[i].interactable == true)
                    {
                        //inventory.AddPotion(map.potions[i]); // spr klonowanie
                        Item potion = new Item(1000, "Potion", 50);
                        inventory.addItem(potion);
                        map.potions[i].Delete(gameArea);
                        map.potions.RemoveAt(i);

                        inventory.DrawInventory(inv); // add proper update() later
                    }
                }
                
                // Karolina - end


            }
            //Agnieszka


            // Karolina - start 
            if ((Keyboard.GetKeyStates(Key.I) & KeyStates.Down) > 0)
            {
                // open inventory window
                //inventoryWindow.Show();
                
                if (Inventory.Visibility == Visibility.Hidden)
                {
                    Inventory.Visibility = Visibility.Visible;
                    lastSpeed = PauseTheGame();
                }
                /*
                else
                {
                    Inventory.Visibility = Visibility.Hidden;
                    UnpauseTheGame(lastSpeed);
                }
                */
            }

            

            // Karolina - stop



                for(int i=0;i<bullets.Count;i++)
            {
                // 20 - bullet speed
                // last side ma stary argument, wiec jak gracz w miedzyczasie sie obroci - poziski bd leciec w nowa strone
                bullets[i].Update(20);

                // Jezeli pocisk wyjdzie poza obszar gry - usun z listy pociskow
                if (isCollidingWithWall(bullets[i], new Vector2(0, 0)))
                {
                    bullets[i].markedForDeletion = true;
                    gameArea.Children.Remove(bullets[i].Body);
                    gameArea.Children.Remove(bullets[i].BulletBody);
                    
                    bullets.RemoveAt(i);
                    //updateWorld();
                }
                else
                {
                    bullets[i].Draw();
                }
            }
            



            /// ENEMIES
            licznikKierunkow = 0;

            Random r = new Random();
            foreach (var enemy in enemies)
            {
                // Karolina
                int rInt = r.Next(0, 4);
                int rInt2 = r.Next(0, 4);
                if (enemy.Position.X < 0 || enemy.Position.X > 810) { enemy.markedForDeletion = true; }
                if (enemy.Position.X < 0 || enemy.Position.X > 410) { enemy.markedForDeletion = true; }
                //
                enemy.Lastpos=enemy.Position;
                enemy.Draw();

                enemySpeed = 1;

                

                
                if (licznikKierunkow > enemyCounter) { licznikKierunkow = 0; }

                

                //Vector2 nowyKierunek = new Vector2(enemySpeed * enemy.kierunekX, enemySpeed * enemy.kierunekY);
                /*if (!isCollidingWithWall(enemy, nowyKierunek))
                {
                    enemy.Update(new Vector2(nowyKierunek.X, nowyKierunek.Y));
                }
                else {
                    enemy.Update(new Vector2(-nowyKierunek.X, -nowyKierunek.Y));
                }*/

                if (isColliding(player, enemy))
                {
                    player.CurrentHp -= 20;
                }
                


                /*
               if (enemy.kierunekX == 1 && !isCollidingWithWall(enemy, new Vector2(enemySpeed + enemy.Width, 0)))
               {
                   enemy.Update(new Vector2(-enemySpeed*2, 0));
               }

               if (enemy.kierunekX == -1 && !isCollidingWithWall(enemy, new Vector2(-enemySpeed - enemy.Width, 0)))
               {
                   enemy.Update(new Vector2(enemySpeed*2, 0));
               }

               if (enemy.kierunekY == 1 && !isCollidingWithWall(enemy, new Vector2(0, enemySpeed + enemy.Height)))
               {
                   enemy.Update(new Vector2(0, -enemySpeed * 2));
               }

               if (enemy.kierunekY == -1 && !isCollidingWithWall(enemy, new Vector2(0, -enemySpeed - enemy.Height)))
               {
                   enemy.Update(new Vector2(0, enemySpeed * 2));
               }*/
                if (isCollidingWithWall(enemy, new Vector2(enemy.kierunekX , enemy.kierunekY )))
                {


                    if (!isCollidingWithWall(enemy, new Vector2(0, enemySpeed)))
                    {
                        enemy.Update(new Vector2(0, enemySpeed));
                        enemy.kierunekY = 1;


                    }

                    else if (!isCollidingWithWall(enemy, new Vector2(0, -enemySpeed)))
                    {
                        enemy.Update(new Vector2(0, -enemySpeed));
                        enemy.kierunekY = -1;

                    }
                    
                        if (!isCollidingWithWall(enemy, new Vector2(enemySpeed, 0)))
                        {
                            enemy.Update(new Vector2(enemySpeed, 0));
                            if (!isCollidingWithWall(enemy, new Vector2(enemySpeed, 0)))
                            {
                                enemy.kierunekX = 1;
                            }
                            else
                            {
                                enemy.kierunekX = -1;
                            }

                        }
                        else if (!isCollidingWithWall(enemy, new Vector2(-enemySpeed, 0)))
                        {
                            enemy.Update(new Vector2(-enemySpeed, 0));
                            if(!isCollidingWithWall(enemy, new Vector2(-enemySpeed, 0)))
                            {
                                enemy.kierunekX = -1;
                            }
                            else {
                                enemy.kierunekX = 1;
                            }

                        }
                    
                }
                else
                {
                    enemy.Lastpos = enemy.Position;
                    if (enemy.kierunekX == 1)
                    {
                        enemy.Update(new Vector2(enemySpeed, 0));
                    }
                    if (enemy.kierunekX == -1)
                    {
                        enemy.Update(new Vector2(enemySpeed, 0));
                    }
                    if (enemy.kierunekY == 1)
                    {
                        enemy.Update(new Vector2(0, enemySpeed));
                    }
                    if (enemy.kierunekY == -1)
                    {
                        enemy.Update(new Vector2(0, enemySpeed));
                    }
                }
                /*
                if (enemy.kierunekX == 1 && !isCollidingWithWall(enemy, new Vector2(enemySpeed, 0)))
                {
                    enemy.Update(new Vector2(enemySpeed, 0));
                }
                else if(enemy.kierunekX == 1)
                {
                    enemy.kierunekX = -1;
                    enemy.Update(new Vector2(-enemySpeed, 20));
                    enemy.Flip(90);
                }

                if (enemy.kierunekX == -1 && !isCollidingWithWall(enemy, new Vector2(-enemySpeed, 0)))
                {
                    enemy.Update(new Vector2(-enemySpeed, 0));
                }
                else if (enemy.kierunekX == -1)
                {
                    enemy.kierunekX =1;
                    enemy.Update(new Vector2(enemySpeed, 20));
                    enemy.Flip(90);
                }

                if (enemy.kierunekY == 1 && !isCollidingWithWall(enemy, new Vector2(0, enemySpeed)))
                {
                    enemy.Update(new Vector2(0,enemySpeed));
                }
                else if(enemy.kierunekY == 1)
                {
                    enemy.kierunekY = -1;
                    enemy.Update(new Vector2(30, -enemySpeed));
                    enemy.Flip(90);
                }

                if (enemy.kierunekY == -1 && !isCollidingWithWall(enemy, new Vector2(0, -enemySpeed )))
                {
                    enemy.Update(new Vector2(0, enemySpeed));
                }
                else if(enemy.kierunekY == -1)
                {
                    enemy.kierunekY = -1;
                    enemy.Update(new Vector2(30, -enemySpeed));
                    enemy.Flip(90);
                }//przez te else znikaja
                */

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

            /*for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].markedForDeletion)
                {
                    enemies[i].Delete(gameArea);
                    enemies.RemoveAt(i);
                }
            }*/




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
        public int isCollidingWithTreasure(GameSprite Object, Vector2 v)//ref
        {
            for(int i=0;i<map.treasures.Count;i++)
            {
                Rect playerHB = new Rect(Canvas.GetLeft(Object.Body) + v.X, Canvas.GetTop(Object.Body) + v.Y, Object.Width, Object.Height);
                Rect treasureHB = new Rect(Canvas.GetLeft(map.treasures[i].Body), Canvas.GetTop(map.treasures[i].Body), map.treasures[i].Width, map.treasures[i].Height);

                if (playerHB.IntersectsWith(treasureHB))
                {
                    return i;
                }

            }
            return -1;
        }
        public bool isCollidingWithNxtLvlDoor(GameSprite Object, Vector2 v)
        {
            Rect playerHB = new Rect(Canvas.GetLeft(Object.Body) + v.X, Canvas.GetTop(Object.Body) + v.Y, Object.Width, Object.Height);
            foreach (NextLevel w in map.nextleveldoors)
            {
                
                

                if (playerHB.IntersectsWith(new Rect(Canvas.GetLeft(w.Body), Canvas.GetTop(w.Body), w.Width, w.Height)))
                {
                    return true;
                }

            }
            
            return false;
        }

        public int isCollidingWithDoor(GameSprite Object, Vector2 v)
        {
            Rect playerHB = new Rect(Canvas.GetLeft(Object.Body) + v.X, Canvas.GetTop(Object.Body) + v.Y, Object.Width, Object.Height);
            
            foreach (Door w in map.doors)
            {
                if (playerHB.IntersectsWith(new Rect(Canvas.GetLeft(w.Body), Canvas.GetTop(w.Body), w.Width, w.Height)))
                {
                    return w.room_index;
                }

            }
            return -1;
        }
        public bool isColliding(GameSprite o1, GameSprite o2)
        {
            /*if ((o1.Position.X + o1.Width <= o2.Position.X + o2.Width) && (o1.Position.X + o1.Width >= o2.Position.X))
            {
                if ((o1.Position.Y + o1.Height <= o2.Position.Y + o2.Height) && (o1.Position.Y + o1.Height >= o2.Position.Y))
                {
                    return true;
                }
            }*/
            Rect o1HB = new Rect(Canvas.GetLeft(o1.Body) , Canvas.GetTop(o1.Body) , o1.Width, o1.Height);
            Rect o2HB = new Rect(Canvas.GetLeft(o2.Body) , Canvas.GetTop(o2.Body) , o2.Width, o2.Height);
            if (o1HB.IntersectsWith(o2HB)) {
                return true;
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
        
        public void updateWalls()
        {
            ImageBrush wallSprite = new ImageBrush();
            wallSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/brick.png"));
            for (int wall_counter = 0; wall_counter < map.wallsinmap.Count(); wall_counter++)
            {
                gameArea.Children.Add(map.wallsinmap[wall_counter].Body);

                Canvas.SetTop(map.wallsinmap[wall_counter].Body, map.wallsinmap[wall_counter].Position.Y);
                Canvas.SetLeft(map.wallsinmap[wall_counter].Body, map.wallsinmap[wall_counter].Position.X);


                //map.wallsinmap[wall_counter].Body.Fill = new SolidColorBrush(Colors.Blue);

                // Karolina
                
                map.wallsinmap[wall_counter].Body.Fill = wallSprite;
                //

                gameArea.DataContext = map.wallsinmap[wall_counter].Body;
            }

        }

        public void updateDoors()
        {
            ImageBrush Sprite = new ImageBrush();
            Sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/door.png"));
            for (int nxt_lvl_door_counter = 0; nxt_lvl_door_counter < map.nextleveldoors.Count(); nxt_lvl_door_counter++)
            {
                gameArea.Children.Add(map.nextleveldoors[nxt_lvl_door_counter].Body);

                Canvas.SetTop(map.nextleveldoors[nxt_lvl_door_counter].Body, map.nextleveldoors[nxt_lvl_door_counter].Position.Y);
                Canvas.SetLeft(map.nextleveldoors[nxt_lvl_door_counter].Body, map.nextleveldoors[nxt_lvl_door_counter].Position.X);


                //map.nextleveldoors[nxt_lvl_door_counter].Body.Fill = new SolidColorBrush(Colors.Red);
                
                map.nextleveldoors[nxt_lvl_door_counter].Body.Fill = Sprite;


                gameArea.DataContext = map.nextleveldoors[nxt_lvl_door_counter].Body;
            }

            for (int door_counter = 0; door_counter < map.doors.Count();door_counter++)
            {
                gameArea.Children.Add(map.doors[door_counter].Body);

                Canvas.SetTop(map.doors[door_counter].Body, map.doors[door_counter].Position.Y);
                Canvas.SetLeft(map.doors[door_counter].Body, map.doors[door_counter].Position.X);


                //map.doors[door_counter].Body.Fill = new SolidColorBrush(Colors.Brown);
                
                map.doors[door_counter].Body.Fill = Sprite;


                gameArea.DataContext = map.doors[door_counter].Body;
            }
            ImageBrush TSprite = new ImageBrush();
            TSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/treasure.png"));
            for (int treasureCounter = 0; treasureCounter < map.treasures.Count(); treasureCounter++)
            {
                gameArea.Children.Add(map.treasures[treasureCounter].Body);

                Canvas.SetTop(map.treasures[treasureCounter].Body, map.treasures[treasureCounter].Position.Y);
                Canvas.SetLeft(map.treasures[treasureCounter].Body, map.treasures[treasureCounter].Position.X);

                //
                //map.treasures[treasureCounter].Body.Fill = new SolidColorBrush(Colors.Brown);
                
                map.treasures[treasureCounter].Body.Fill = TSprite;


                gameArea.DataContext = map.treasures[treasureCounter].Body;
            }
        }

        // Karolina - start
        public void updatePotions()
        {
            for (int potionsCounter = 0; potionsCounter < map.potions.Count(); potionsCounter++)
            {
                gameArea.Children.Add(map.potions[potionsCounter].Body);

                Canvas.SetTop(map.potions[potionsCounter].Body, map.potions[potionsCounter].Position.Y);
                Canvas.SetLeft(map.potions[potionsCounter].Body, map.potions[potionsCounter].Position.X);

                ImageBrush Sprite = new ImageBrush();
                if (map.potions[potionsCounter].type == TypeOfPotion.HealthRegeneration)
                {
                    Sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/GreenPotion.png"));
                }
                else if (map.potions[potionsCounter].type == TypeOfPotion.StaminaRegenerationBoost)
                {
                    Sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/GreenPotion.png"));
                }
                else if (map.potions[potionsCounter].type == TypeOfPotion.HigherAttackValue)
                {
                    Sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/GreenPotion.png"));
                }
                else if (map.potions[potionsCounter].type == TypeOfPotion.HigherDefenceValue)
                {
                    Sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/GreenPotion.png"));
                }

                map.potions[potionsCounter].Body.Fill = Sprite;


                gameArea.DataContext = map.potions[potionsCounter].Body;
            }
        }

        // Karolina - end

        public void updateEnemies()
        {
            for (int i = 0; i < 5; i++)
            {
                Vector2 poz = new Vector2(0, 0);
                Enemy enemy = new Enemy(poz, 40, 40, 1);
                enemy.Position = new Vector2((i+1)*80+250, (i + 1)*80);
                enemy.Create(gameArea);
                enemy.Draw();
                enemies.Add(enemy);
            }
        }
        public void updateInterface()
        {
            
            TextBlock score = new TextBlock();

            score.FontSize = 22;
            score.LineHeight = 30;
            score.TextWrapping = TextWrapping.Wrap;
            score.TextAlignment = TextAlignment.Center;
            string temp_string = "score: " + Score;//XDDDD
            score.Inlines.Add(new Run(temp_string));
            score.Background = Brushes.AntiqueWhite;
            Interface.Children.Add(score);
            Canvas.SetTop(score, W.Position.Y);
            Canvas.SetLeft(score, W.Position.X + 100);

            TextBlock level = new TextBlock();

            level.FontSize = 22;
            level.LineHeight = 30;
            level.TextWrapping= TextWrapping.Wrap;
            level.TextAlignment = TextAlignment.Center;
            temp_string = "level: " + map_index;
            level.Inlines.Add(new Run(temp_string));
            level.Background=Brushes.AntiqueWhite;
            Interface.Children.Add(level);
            Canvas.SetTop(level, W.Position.Y+score.LineHeight);
            Canvas.SetLeft(level, W.Position.X + 100);

            TextBlock hp = new TextBlock();

            hp.FontSize = 22;
            hp.LineHeight = 30;
            hp.TextWrapping = TextWrapping.Wrap;
            hp.TextAlignment = TextAlignment.Center;
            temp_string = "hp: " + player.Hp;
            hp.Inlines.Add(new Run(temp_string));
            hp.Background = Brushes.AntiqueWhite;
            Interface.Children.Add(hp);
            Canvas.SetTop(hp, W.Position.Y +level.LineHeight+score.LineHeight);
            Canvas.SetLeft(hp, W.Position.X + 100);



        }
        public void updateWorld()
        {
            updateDoors();
            updatePotions();
            updateEnemies();
            updateWalls();
            updateInterface();
            
        }
        
        public void EarnMoney()
        {
            
                if(coins != null)
                {
                    foreach(Coin Coin in coins)
                    {
                        if (isColliding(player, Coin))
                        {
                            Coin.czyUsunac = true;
                        }
                        else
                            Coin.czyUsunac = false;
                    }
                }

                if (coins != null)
                {
                    for (int i = coins.Count - 1; i >= 0; i--)
                    {
                        if (coins[i].czyUsunac)
                        {
                            coins[i].Delete(gameArea);
                            coins.RemoveAt(i);
                            Score += 2;
                        //W.Suma(Score, gameArea);
                        updateInterface();
                    }
                    }
                }

                if (emeralds != null)
                {
                    foreach (Emerald Emerald in emeralds)
                    {
                        if (isColliding(player, Emerald))
                        {
                            Emerald.czyUsunac = true;
                        }
                        else
                            Emerald.czyUsunac = false;
                    }
                }

                if (emeralds != null)
                {
                    for (int i = emeralds.Count - 1; i >= 0; i--)
                    {
                        if (emeralds[i].czyUsunac)
                        {
                            emeralds[i].Delete(gameArea);
                            emeralds.RemoveAt(i);
                            Score += 4;
                        //W.Suma(Score, gameArea);
                        updateInterface();
                    }
                    }
                }

                if (rubys != null)
                {
                    foreach (Ruby Ruby in rubys)
                    {
                        if (isColliding(player, Ruby))
                        {
                            Ruby.czyUsunac = true;
                        }
                        else
                            Ruby.czyUsunac = false;
                    }
                }

                if (rubys != null)
                {
                    for (int i = rubys.Count - 1; i >= 0; i--)
                    {
                        if (rubys[i].czyUsunac)
                        {
                            rubys[i].Delete(gameArea);
                            rubys.RemoveAt(i);
                            Score += 6;
                        //W.Suma(Score, gameArea);
                        updateInterface();
                    }
                    }
                }

                if (diamonds != null)
                {
                    foreach (Diamond Diamond in diamonds)
                    {
                        if (isColliding(player, Diamond))
                        {
                            Diamond.czyUsunac = true;
                        }
                        else
                            Diamond.czyUsunac = false;
                    }
                }

                if (diamonds != null)
                {
                    for (int i = diamonds.Count - 1; i >= 0; i--)
                    {
                        if (diamonds[i].czyUsunac)
                        {
                            diamonds[i].Delete(gameArea);
                            diamonds.RemoveAt(i);
                            Score += 8;
                        // W.Suma(Score, gameArea);
                        updateInterface();
                    }
                    }
                }
                //updateInterface();

                /*if(isColliding(player, C))
                {
                    C.Delete(gameArea);
                }
                else if(isColliding(player, E))
                {
                    E.Delete(gameArea);
                }
                else if(isColliding(player, R))
                {
                    R.Delete(gameArea);
                }
                else if(isColliding(player, D))
                {
                    D.Delete(gameArea);
                }*/
            
        }

        /*
        private void PlaySoundOne(object sender, RoutedEventArgs e)
        {
            SoundPlayer sound = new SoundPlayer("awesomeness.wav");
            sound.Play();
            //sound.PlayLooping(); 
        }
        */




        // Karolina - start - maj

        private void button_Close(object sender, RoutedEventArgs e)
        {
            Inventory.Visibility = Visibility.Hidden;
            UnpauseTheGame(lastSpeed);
        }


        public float PauseTheGame()
        {
            /*
            float lastSpeed = enemies[0].Speed;
            foreach( Enemy enemy in enemies)
            {
                enemy.Speed = 0;
            }
            return lastSpeed;
            */
            //gameTimer.Stop();
            return 0;
        }

        public void UnpauseTheGame(float lastSpeed)
        {
            /*
            foreach (Enemy enemy in enemies)
            {
                enemy.Speed = lastSpeed;
            }
            */
            //gameTimer.Start();
        }




        // Karolina - end




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

   



