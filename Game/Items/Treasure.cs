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
    public class Treasure : GameSprite
    {
        public Treasure(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
        }

        public void Create(Canvas gameArea)
        {
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.Brown);
        }

        public void Draw()
        {
            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
        }

        public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
        }
    }


    public class Coin : GameSprite
    {
        public bool czyUsunac = false;
        public Coin(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
        }

        public void Create(Canvas gameArea)
        {
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.Yellow);
        }

        public void Draw()
        {
            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
        }

        public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
        }

        public Vector2 RandomSpawnPosition(Canvas gameArea, GameSprite Chest, Random rand)
        {
            int Top = rand.Next((int)Chest.Position.X - 45, (int)Chest.Position.X + 45);
            int Left = rand.Next((int)Chest.Position.Y - 45, (int)Chest.Position.Y + 45);

            while (Top > Chest.Position.Y && Top < Chest.Position.Y)
            {
                Top = rand.Next((int)Chest.Position.X - 45, (int)Chest.Position.X + 45);
            }
            while (Left > Chest.Position.X && Left < Chest.Position.X)
            {
                Left = rand.Next((int)Chest.Position.Y - 45, (int)Chest.Position.Y + 45);
            }

            return new Vector2(Top, Left);
        }
    }

    public class Emerald : GameSprite
    {
        public bool czyUsunac = false;
        public Emerald(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
        }

        public void Create(Canvas gameArea)
        {
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.Green);
        }

        public void Draw()
        {
            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
        }

        public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
        }

        public Vector2 RandomSpawnPosition(Canvas gameArea, GameSprite Chest, Random rand)
        {
            int Top = rand.Next((int)Chest.Position.X - 45, (int)Chest.Position.X + 45);
            int Left = rand.Next((int)Chest.Position.Y - 45, (int)Chest.Position.Y + 45);

            while (Top > Chest.Position.Y && Top < Chest.Position.Y)
            {
                Top = rand.Next((int)Chest.Position.X - 45, (int)Chest.Position.X + 45);
            }
            while (Left > Chest.Position.X && Left < Chest.Position.X)
            {
                Left = rand.Next((int)Chest.Position.Y - 45, (int)Chest.Position.Y + 45);
            }

            return new Vector2(Top, Left);
        }
    }

    public class Ruby : GameSprite
    {
        public bool czyUsunac = false;
        public Ruby(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
        }

        public void Create(Canvas gameArea)
        {
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.Red);
        }

        public void Draw()
        {
            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
        }

        public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
        }

        public Vector2 RandomSpawnPosition(Canvas gameArea, GameSprite Chest, Random rand)
        {
            int Top = rand.Next((int)Chest.Position.X - 45, (int)Chest.Position.X + 45);
            int Left = rand.Next((int)Chest.Position.Y - 45, (int)Chest.Position.Y + 45);

            while (Top > Chest.Position.Y && Top < Chest.Position.Y)
            {
                Top = rand.Next((int)Chest.Position.X - 45, (int)Chest.Position.X + 45);
            }
            while (Left > Chest.Position.X && Left < Chest.Position.X)
            {
                Left = rand.Next((int)Chest.Position.Y - 45, (int)Chest.Position.Y + 45);
            }

            return new Vector2(Top, Left);
        }
    }

    public class Diamond : GameSprite
    {
        public bool czyUsunac = false;
        public Diamond(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
        }

        public void Create(Canvas gameArea)
        {
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.Blue);
        }

        public void Draw()
        {
            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
        }

        public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
        }

        public Vector2 RandomSpawnPosition(Canvas gameArea, GameSprite Chest, Random rand)
        {
            int Top = rand.Next((int)Chest.Position.X - 45, (int)Chest.Position.X + 45);
            int Left = rand.Next((int)Chest.Position.Y - 45, (int)Chest.Position.Y + 45);

            while (Top > Chest.Position.Y && Top < Chest.Position.Y)
            {
                Top = rand.Next((int)Chest.Position.X - 45, (int)Chest.Position.X + 45);
            }
            while (Left > Chest.Position.X && Left < Chest.Position.X)
            {
                Left = rand.Next((int)Chest.Position.Y - 45, (int)Chest.Position.Y + 45);
            }

            return new Vector2(Top, Left);
        }
    }
}
