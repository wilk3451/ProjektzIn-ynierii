using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game.Creatures
{
    public class Enemy : GameSprite
    {
        public int Hp { get; private set; }
        public int CurrentHp { get; set; }
        public int Attack { get; private set; }
        public int Defence { get; private set; }
        public int Level { get; set; }

        int currentStep = 100;
        int MoveStep = 100;

        public bool markedForDeletion = false;

        public int kierunekX;
        public int kierunekY;

        //------------------------------------------------------------------
        // Body jest od GameSprite
        public System.Windows.Shapes.Ellipse HitBox { get; set; }
        public System.Windows.Shapes.Ellipse NormalAttackArea { get; set; }
        public System.Windows.Shapes.Ellipse StrongAttackArea { get; set; }
        public System.Windows.Shapes.Ellipse VisionArea { get; set; }

        public System.Windows.Shapes.Rectangle Vision { get; set; }

        //------------------------------------------------------------------

        public RotateTransform RenderTransform { get; internal set; }

        public Enemy(Vector2 Position, int Width, int Height, int Speed,
                     int hp, int currentHp, int atk, int def, int level,
                     Ellipse HitBox, Ellipse NormalAttackArea, Ellipse StrongAttackArea, Ellipse VisionArea,
                     RotateTransform renderTransform) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            this.Speed = Speed;
            this.Hp = hp;
            this.CurrentHp = currentHp;
            this.Attack = atk;
            this.Defence = def;
            this.Level = level;
            this.HitBox = HitBox;
            this.NormalAttackArea = NormalAttackArea;
            this.StrongAttackArea = StrongAttackArea;
            this.VisionArea = VisionArea;
            this.RenderTransform = renderTransform;
        }

        public Enemy(Vector2 Position, int Width, int Height, int level) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            HitBox = new System.Windows.Shapes.Ellipse();
            NormalAttackArea = new System.Windows.Shapes.Ellipse();
            StrongAttackArea = new System.Windows.Shapes.Ellipse();
            VisionArea = new System.Windows.Shapes.Ellipse();

            Vision = new System.Windows.Shapes.Rectangle();

            Speed = (float)2.0;
            Level = level;
            SetStats(Level);
        }

        private void SetStats(int level)
        {
            Hp = 100;
            Attack = 10;
            Defence = 10;

            for (int i = 1; i < level; i++)
            {
                Hp += 20 * i;
                Attack += 5 * i;
                Defence += 2 * i;
            }

            CurrentHp = Hp;
        }

        public void Create(Canvas gameArea)
        {
            // Body
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.DarkRed);
            Body.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = Body;

            ImageBrush enemySprite = new ImageBrush();
            enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/enemy.png"));
            Body.Fill = enemySprite;

            // HitBox
            gameArea.Children.Add(HitBox);
            HitBox.Width = this.Width;
            HitBox.Height = this.Height;
            Canvas.SetTop(HitBox, Position.Y);
            Canvas.SetLeft(HitBox, Position.X);
            HitBox.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = HitBox;

            //Normal Attack Area
            gameArea.Children.Add(NormalAttackArea);
            NormalAttackArea.Width = this.Width + 30;
            NormalAttackArea.Height = this.Height + 30;
            Canvas.SetTop(NormalAttackArea, Position.Y - Height / 2);
            Canvas.SetLeft(NormalAttackArea, Position.X);
            NormalAttackArea.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = NormalAttackArea;

            // Strong Attack Area - na razie to samo co Normal Attack Area
            gameArea.Children.Add(StrongAttackArea);
            StrongAttackArea.Width = this.Width + 30;
            StrongAttackArea.Height = this.Height + 30;
            Canvas.SetTop(StrongAttackArea, Position.Y - Height / 2);
            Canvas.SetLeft(StrongAttackArea, Position.X);
            HitBox.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = StrongAttackArea;

            // Vision Area
            gameArea.Children.Add(VisionArea);
            VisionArea.Width = this.Width + 60;
            VisionArea.Height = this.Height + 60;
            Canvas.SetTop(VisionArea, Position.Y - Height / 2);
            Canvas.SetLeft(VisionArea, Position.X);
            VisionArea.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = VisionArea;

            // Rectangle for Help
            /*
            gameArea.Children.Add(Vision);
            Vision.Width = this.Width + 60;
            Vision.Height = this.Height + 60;
            Canvas.SetTop(Vision, Position.Y - Height / 2);
            Canvas.SetLeft(Vision, Position.X);
            Vision.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = Vision;
            */
        }

        public void Draw()
        {
            double OffsetAttack = Position.Y + Height / 2 - NormalAttackArea.Height / 2;
            double OffsetVision = Position.Y + Height / 2 - VisionArea.Height / 2;

            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);

            Canvas.SetLeft(HitBox, Position.X);
            Canvas.SetTop(HitBox, Position.Y);

            Canvas.SetLeft(NormalAttackArea, Position.X);
            Canvas.SetTop(NormalAttackArea, OffsetAttack);

            Canvas.SetLeft(StrongAttackArea, Position.Y);
            Canvas.SetTop(StrongAttackArea, OffsetAttack);

            Canvas.SetLeft(VisionArea, Position.X);
            Canvas.SetTop(VisionArea, OffsetVision);

            //Canvas.SetLeft(Vision, Position.X);
            //Canvas.SetTop(Vision, OffsetVision);
        }


        public void Update(float speed)
        {
            Position.X += speed * kierunekX;
            Position.Y += speed * kierunekY;
        }

        /*          
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
                           
            */


        public Vector2 RandomSpawnPosition(Canvas gameArea, GameSprite toAvoid, Random rand)
        {
            int Top = rand.Next(30, (int)gameArea.Height - 30);
            int Left = rand.Next(30, (int)gameArea.Width - 30);
            while (Top > toAvoid.Position.Y && Top < toAvoid.Position.Y)
            {
                Top = rand.Next(30, (int)gameArea.Height - 30);
            }
            while (Left > toAvoid.Position.X && Left < toAvoid.Position.X)
            {
                Left = rand.Next(30, (int)gameArea.Width - 30);
            }
            return new Vector2(Top, Left);
        }




        /*
        public async Task WalkAsync(Canvas gameArea)
        {
            var tred = new DispatcherTimer { Interval = TimeSpan.FromSeconds(20) };
            tred.Start();
            
            
            if (!IsDead())
            {
                
                Position.X += Speed;
                currentStep--;
                if (currentStep < 1)
                {
                    currentStep = MoveStep;
                    Speed = -Speed;
                }
                
                 if (currentStep == 1)
                 {
                     Flip(180);
                 }
                 else if (currentStep == MoveStep)
                 {
                     Flip(0);
                 }
                 
                Flip(currentStep);
                UpdateEnemy();
                


            }
        }

        public async Task Act(Canvas gameArea, Player player)
        {
            var tred = new DispatcherTimer { Interval = TimeSpan.FromSeconds(20) };
            tred.Start();


            if (!IsDead())
            {
                Chase(player);
            }
        }

        public void Flip(int angle)
        {
            Body.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
            HitBox.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
            NormalAttackArea.RenderTransform = new RotateTransform(angle, Width / 2, NormalAttackArea.Height / 2);
            StrongAttackArea.RenderTransform = new RotateTransform(angle, Width / 2, StrongAttackArea.Height / 2);
            VisionArea.RenderTransform = new RotateTransform(angle, Width / 2, VisionArea.Height / 2);
            //Vision.RenderTransform = new RotateTransform(angle, Width / 2, Vision.Height / 2);
        }


        public void Chase(Player player)
        {
            float enemyLeft = Position.X;
            float enemyTop = Position.Y;
            float playerLeft = player.Position.X;
            float playerTop = player.Position.Y;

            Vector2 distance = new Vector2(playerLeft - enemyLeft, playerTop - enemyTop);

            if (distance.X == 0 && distance.Y == 0 || !CollisionCircles(player.HitBox, HitBox))
            {
                return;
            }

            if (distance.X > 0 && distance.Y > 0)
            {
                Position.X += Speed;
                Position.Y += Speed;
            }
            else if (distance.X < 0 && distance.Y < 0)
            {
                Position.X -= Speed;
                Position.Y -= Speed;
            }
            else if (distance.X > 0 && distance.Y < 0)
            {
                Position.X -= Speed;
                Position.Y += Speed;
            }
            else if (distance.X < 0 && distance.Y > 0)
            {
                Position.X += Speed;
                Position.Y -= Speed;
            }
            UpdateEnemy();
        }

        */

        public bool IsPlayerAround(Player player)
        {
            if (CollisionCircles(player.HitBox, VisionArea)) return true;
            return false;
        }

        public bool IsUnderAttack()
        {
            if (CurrentHp != Hp) return true;
            return false;
        }

        public void MoveLeft()
        {
            Position.X = Speed;
        }


        public Vector2 GetPosition() { return this.Position; }

        public Vector2 CheckEnemyPosition()
        {
            return this.Position;
        }


        bool Attacked = false;

        public void NormalAttack(Player player, bool Attacked)
        {
            if (CollisionCircles(player.HitBox, NormalAttackArea) && Attacked == false)
            {
                int TrueDmg = Attack - player.Defence;
                player.CurrentHp -= TrueDmg;
                Attacked = true;
            }
        }

        public void StrongAttack(Player player, bool Attacked)
        {
            if (CollisionCircles(player.HitBox, StrongAttackArea) && Attacked == false)
            {
                int TrueDmg = Attack * 3 - player.Defence;
                player.CurrentHp -= TrueDmg;
                Attacked = true;
            }
        }

        public bool IsDead()
        {
            if (CurrentHp == 0) return true;
            return false;
        }



        // destruktor
        public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
            gameArea.Children.Remove(HitBox);
            gameArea.Children.Remove(NormalAttackArea);
            gameArea.Children.Remove(StrongAttackArea);
            gameArea.Children.Remove(VisionArea);
        }





        /// WRONG
        public bool CollisionCircles(Ellipse o1, Ellipse o2)
        {
            double o1X = Canvas.GetLeft(o1) + o1.Width / 2;
            double o1Y = Canvas.GetLeft(o1) + o1.Height / 2;
            double o1Radius = o1.Height / 2;

            double o2X = Canvas.GetLeft(o2) + o2.Width / 2;
            double o2Y = Canvas.GetLeft(o2) + o2.Height / 2;
            double o2Radius = o2.Height / 2;

            double distanceBetweenCirclesSquared = (o2X - o1X) * (o2X - o1X) + (o2Y - o1Y) * (o2Y - o1Y);

            if (distanceBetweenCirclesSquared > (o1Radius + o2Radius) * (o1Radius + o2Radius))
            {
                return true;
            }
            return false;
        }
    }
}
