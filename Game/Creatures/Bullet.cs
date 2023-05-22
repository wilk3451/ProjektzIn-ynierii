using Game.Creatures;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game.Creatures
{
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

        public void Create(Canvas gameArea, Player player)
        {
            double positionX = player.Position.X + (player.Width / 2) - (Width / 2); // srodek gracza
            double positionY = player.Position.Y + (player.Height / 2) - (Height / 2); // srodek gracza

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
            BulletBody.Fill = new SolidColorBrush(Colors.Red);
            gameArea.DataContext = BulletBody;
        }

        new public void Draw()
        {
            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(BulletBody, Position.X);
            Canvas.SetTop(BulletBody, Position.Y);
        }

        public void Update(float speed, int lastSide)
        {
            if (lastSide == 0)
            {
                Position.X += speed;
                Position.Y += 0;
            }
            else if (lastSide == 1)
            {
                Position.X -= speed;
                Position.Y += 0;
            }
            else if (lastSide == 2)
            {
                Position.X += 0;
                Position.Y -= speed;
            }
            else if (lastSide == 3)
            {
                Position.X += 0;
                Position.Y += speed;
            }
        }

        new public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
            gameArea.Children.Remove(BulletBody);
        }
    }
}

