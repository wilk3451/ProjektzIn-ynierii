using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Game.Items;
using Game.Windows;

namespace Game.Creatures
{
    public class Player : GameSprite
    {
        public int Hp { get; private set; }
        public int CurrentHp { get; set; }
        public int Attack { get; private set; }
        public int Defence { get; private set; }
        public int Stamina { get; private set; }
        public System.Windows.Shapes.Ellipse HitBox { get; set; }
        public System.Windows.Shapes.Ellipse NormalAttackArea { get; set; }
        public System.Windows.Shapes.Ellipse StrongAttackArea { get; set; }
        public RotateTransform RenderTransform { get; internal set; }

        public List<Bullet> bullets;

        public ObservableCollection<Item> Inventory { get; set; }

        public int Direction { get; set; }

        public Player(Vector2 Position, int Width, int Height, int Speed,
                     int hp, int currentHp, int atk, int def,
                     Ellipse HitBox, Ellipse NormalAttackArea, Ellipse StrongAttackArea,
                     RotateTransform renderTransform,
                     int Direction) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            this.Speed = Speed;
            this.Hp = hp;
            this.CurrentHp = currentHp;
            this.Attack = atk;
            this.Defence = def;
            this.HitBox = HitBox;
            this.NormalAttackArea = NormalAttackArea;
            this.StrongAttackArea = StrongAttackArea;
            this.RenderTransform = renderTransform;
            this.Direction = Direction;

            List<Bullet> bullets = new List<Bullet>();

            Inventory = new ObservableCollection<Item>();
            Inventory.Add(ItemsList.CreateItem(1));//temp item

        }


        public Player(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;

            HitBox = new System.Windows.Shapes.Ellipse();
            NormalAttackArea = new System.Windows.Shapes.Ellipse();
            StrongAttackArea = new System.Windows.Shapes.Ellipse();
            Inventory = new ObservableCollection<Item>();
            Inventory.Add(ItemsList.CreateItem(1));//temp item
            Inventory.Add(ItemsList.CreateItem(2));

            Speed = (float)2.5; // pozniej: setter dla statów i prędkości

            List<Bullet> bullets = new List<Bullet>();

            Direction = 0;
            SetStats();
        }

        new public void Create(Canvas gameArea)
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

            ImageBrush playerSprite = new ImageBrush();
            playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/player.png"));
            Body.Fill = playerSprite;

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

            // Strong Attack Area
            gameArea.Children.Add(StrongAttackArea);
            StrongAttackArea.Width = this.Width + 30;
            StrongAttackArea.Height = this.Height + 30;
            Canvas.SetTop(StrongAttackArea, Position.Y - Height / 2);
            Canvas.SetLeft(StrongAttackArea, Position.X);
            //StrongAttackArea.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = StrongAttackArea;
        }

        new public void Draw()
        {
            double OffsetAttack = Position.Y + Height / 2 - NormalAttackArea.Height / 2;

            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);

            Canvas.SetLeft(HitBox, Position.X);
            Canvas.SetTop(HitBox, Position.Y);

            Canvas.SetLeft(NormalAttackArea, Position.X);
            Canvas.SetTop(NormalAttackArea, OffsetAttack);

            Canvas.SetLeft(StrongAttackArea, Position.Y);
            Canvas.SetTop(StrongAttackArea, OffsetAttack);
        }

        public void Update(Vector2 position, int angle)
        {
            Position.X += position.X;
            Position.Y += position.Y;
            Flip(angle);
        }

        public void Flip(int angle)
        {
            Body.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
            HitBox.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
            NormalAttackArea.RenderTransform = new RotateTransform(angle, Width / 2, NormalAttackArea.Height / 2);
            StrongAttackArea.RenderTransform = new RotateTransform(angle, Width / 2, StrongAttackArea.Height / 2);
        }


        private void SetStats()
        {
            Hp = 100;
            Attack = 200;
            Defence = 10;
            CurrentHp = Hp;
        }



        public Vector2 CheckPlayerPosition()
        {
            return this.Position;
        }

        public bool IsDead()
        {
            if (CurrentHp == 0) return true;
            return false;
        }

        public void RiseHp(int Points)
        {
            Hp += Points;
        }

        public void RiseAttack(int Points)
        {
            Attack += Points;
        }

        public void RiseDefence(int Points)
        {
            Defence += Points;
        }

        public void RiseStamina(int Points)
        {
            Stamina += Points;
        }

        public bool NormalAttack(Enemy enemy)
        {
            int AttackCost = 20;

            if (CollisionCircles(enemy.HitBox, NormalAttackArea) && Stamina >= AttackCost)
            {
                int TrueDmg = Attack - enemy.Defence;
                enemy.CurrentHp -= TrueDmg;
                Stamina -= AttackCost;
                return true;
            }
            Stamina -= AttackCost;
            return false;
        }


        public bool StrongAttack(Enemy enemy)
        {
            int AttackCost = 80;
            
            if (CollisionCircles(enemy.HitBox, StrongAttackArea) && Stamina >= AttackCost)
            {
                int TrueDmg = Attack * 3 - enemy.Defence;
                enemy.CurrentHp -= TrueDmg;
                Stamina -= AttackCost;
                return true;
            }
            Stamina -= AttackCost;
            return false;
        }


        public void RegenerateStamina()
        {
            Stamina += 1;
        }


        new public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
            gameArea.Children.Remove(HitBox);
            gameArea.Children.Remove(NormalAttackArea);
            gameArea.Children.Remove(StrongAttackArea);
        }



        public bool CollisionCircles(Ellipse o1, Ellipse o2)
        {
            double o1X = Canvas.GetLeft(o1) + o1.Width / 2;
            double o1Y = Canvas.GetTop(o1) + o1.Height / 2;
            double o1Radius = o1.Height / 2;

            double o2X = Canvas.GetLeft(o2) + o2.Width / 2;
            double o2Y = Canvas.GetTop(o2) + o2.Height / 2;
            double o2Radius = o2.Height / 2;

            double distanceBetweenCirclesSquared = (o2X - o1X) * (o2X - o1X) + (o2Y - o1Y) * (o2Y - o1Y);

            if (distanceBetweenCirclesSquared > (o1Radius + o2Radius) * (o1Radius + o2Radius))
            {
                return false;
            }
            return true;
        }
    }
}
