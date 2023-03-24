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
    internal class Enemy : GameSprite
    {
        int Hp { get; set; }
        int CurrentHp { get; set; }
        int Atk { get; set; }
        int Def { get; set; }
        int Level { get; set; }

        int currentStep = 100;
        int MoveStep = 100;
        public System.Windows.Shapes.Rectangle Face { get; set; }
        public RotateTransform RenderTransform { get; internal set; }

        public Enemy(Vector2 Position, int Width, int Height, int Speed, int hp, int currentHp, int atk, int def, Rectangle face, RotateTransform renderTransform) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            this.Speed = Speed;
            this.Hp = hp;
            this.CurrentHp = currentHp;
            this.Def = def;
            this.Level = atk;
            this.Face = face;
            this.RenderTransform = renderTransform;

        }

        public Enemy(Vector2 Position, int Width, int Height, int level) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            Face = new System.Windows.Shapes.Rectangle();
            Speed = (float)2.5;
            Level = level;
            SetStats(Level);
        }

        private void SetStats(int level)
        {
            // dla kazdego rodzaju moba, na razie tylko dla jednego
            // weak mob

            Hp = 100 * level;
            Atk = 10 * level;
            Def = 10 * level;
            CurrentHp = Hp;
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
            gameArea.DataContext = Body;

            ImageBrush enemySprite = new ImageBrush();
            enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/enemy.png"));
            Body.Fill = enemySprite;

            // Face
            /*
            Face = new Rectangle();
            gameArea.Children.Add(Face);
            Face.Width = this.Width / 3;
            Face.Height = this.Height;
            Canvas.SetTop(Face, Position.Y);
            Canvas.SetLeft(Face, Position.X);
            Face.Fill = new SolidColorBrush(Colors.White);
            gameArea.DataContext = Face;
            */
        }

        public void UpdateEnemy()
        {
            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Face, Position.X);
            Canvas.SetTop(Face, Position.Y);
        }

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
                UpdateEnemy();
            }
        }

        public void Flip(int angle)
        {
            Body.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
        }


        public void Walk()
        {

        }

        public bool IsPlayerAround()
        {
            return false;
        }

        public bool IsUnderAttack()
        {
            if (CurrentHp != Hp) return true;
            return false;
        }

        public Vector2 GetPosition() { return this.Position; }

        public Vector2 CheckEnemyPosition()
        {
            return this.Position;
        }

        public void TrackPlayer(Player player)
        {

        }

        public void NormalAttack(Player player)
        {

        }

        public void StrongAttack(Player player)
        {

        }

        public bool IsDead()
        {
            if (CurrentHp == 0) return true;
            return false;
        }

        // destruktor
    }
}
