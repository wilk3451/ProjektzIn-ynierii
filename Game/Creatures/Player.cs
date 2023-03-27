using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        public Player(Vector2 Position, int Width, int Height, int Speed,
                     int hp, int currentHp, int atk, int def,
                     Ellipse HitBox, Ellipse NormalAttackArea, Ellipse StrongAttackArea,
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
            this.HitBox = HitBox;
            this.NormalAttackArea = NormalAttackArea;
            this.StrongAttackArea = StrongAttackArea;
            this.RenderTransform = renderTransform;
            List<Bullet> bullets = new List<Bullet>();
        }

        public Player(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;

            HitBox = new System.Windows.Shapes.Ellipse();
            NormalAttackArea = new System.Windows.Shapes.Ellipse();
            StrongAttackArea = new System.Windows.Shapes.Ellipse();

            Speed = (float)2.5; // pozniej: setter dla statów i prędkości

            List<Bullet> bullets = new List<Bullet>();
        }

        public void Draw(Canvas gameArea)
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
            StrongAttackArea.Width = this.Width + 40;
            StrongAttackArea.Height = this.Height + 40;
            Canvas.SetTop(StrongAttackArea, Position.Y - Height / 2);
            Canvas.SetLeft(StrongAttackArea, Position.X);
            HitBox.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = StrongAttackArea;
        }

        public void UpdatePlayer()
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

        public void Flip(int angle)
        {
            Body.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
            HitBox.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
            NormalAttackArea.RenderTransform = new RotateTransform(angle, Width / 2, NormalAttackArea.Height / 2);
            StrongAttackArea.RenderTransform = new RotateTransform(angle, Width / 2, StrongAttackArea.Height / 2);
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

        public async void NormalAttack(Enemy enemy)
        {
            if (CollisionCircles(enemy.HitBox, NormalAttackArea))
            {
                int TrueDmg = Attack - enemy.Defence;
                enemy.CurrentHp -= TrueDmg;
            }

            //NormalAttackArea.Stroke = new SolidColorBrush(Colors.Red);
            //NormalAttackArea.Stroke = new SolidColorBrush(Colors.White);
        }

        public void StrongAttack(Enemy enemy)
        {
            if (CollisionCircles(enemy.HitBox, StrongAttackArea))
            {
                int TrueDmg = Attack * 3 - enemy.Defence;
                enemy.CurrentHp -= TrueDmg;
            }
        }

        

        public void HandleBullets(List<Bullet> bullets, Canvas gameArea)
        {
            // dodaj nowy pocisk
            Vector2 where = new Vector2(Position.X + (Width / 2) - (Width / 2), Position.X + (Width / 2) - (Width / 2));
            Bullet bullet = new Bullet(where, 4, 4);
            bullets.Add(bullet);

            bullets.ForEach(singleBullet => 
            {
                singleBullet.Draw(gameArea, this);
                singleBullet.Update(gameArea);
                if (singleBullet.markedForDeletion) { bullets.Remove(singleBullet); }
            });

            if (bullets.Count > 5) { bullets.RemoveAt(0); }
        }

        // destruktor

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


    public class Bullet : GameSprite
    {
        public System.Windows.Shapes.Ellipse BulletBody { get; set; }
        // Body z GameSprite - Rectangle

        public bool markedForDeletion = false;

        public Bullet(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            BulletBody = new System.Windows.Shapes.Ellipse();
        }

        public void Draw(Canvas gameArea, Player player)
        {
            float positionX = player.Position.X + (player.Width / 2) - (Width / 2); // srodek gracza
            float positionY = player.Position.Y + (player.Height / 2) - (Height / 2); // srodek gracza

            //Body z GameSprite - rysowane dla sprawdzenia czy pocisk jest we właściwej pozycji
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, positionY);
            Canvas.SetLeft(Body, positionX);
            Body.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = Body;

            //Prawdziwy wygląd pocisku
            BulletBody = new Ellipse();
            gameArea.Children.Add(BulletBody);
            BulletBody.Width = this.Width;
            BulletBody.Height = this.Height;
            Canvas.SetTop(BulletBody, positionY);
            Canvas.SetLeft(BulletBody, positionX);
            BulletBody.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = BulletBody;
        }

        public void Update(Canvas gameArea)
        {
            // wyznacz kierunek drogi..? tu w zaleznoscod etego gdzie patrzy grcaz
            Position.X += Speed;

            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(BulletBody, Position.X);
            Canvas.SetTop(BulletBody, Position.Y);

            // jeżeli pocisk wyjdzie poza kanwas - musi zostać usunięty z listy pocisków
            if (Position.X < 0 - gameArea.Width) {markedForDeletion = true;}
            else if (Position.X > gameArea.Width) { markedForDeletion = true; }
            else if (Position.Y < 0 - gameArea.Height) { markedForDeletion = true; }
            else if (Position.Y > gameArea.Height) { markedForDeletion = true; }
            else { markedForDeletion = false; }
        }
    }
}
