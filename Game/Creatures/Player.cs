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
        int Hp { get; set; }
        int Atk { get; set; }
        int Def { get; set; }
        public System.Windows.Shapes.Rectangle Face { get; set; }
        public RotateTransform RenderTransform { get; internal set; }

        public Player(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;

            Face = new System.Windows.Shapes.Rectangle();
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
            Body.Fill = new SolidColorBrush(Colors.Black);
            gameArea.DataContext = Body;

            ImageBrush playerSprite = new ImageBrush();
            playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/player.png"));
            Body.Fill = playerSprite;

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


        public Vector2 CheckPlayerPosition()
        {
            return this.Position;
        }

        public bool IsDead()
        {
            if (Hp == 0) return true;
            return false;
        }
    }
}
