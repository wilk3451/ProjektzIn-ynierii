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
    
    public class Wynik : GameSprite
    {
        public TextBlock wynik;

        public Wynik(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            wynik = new TextBlock();
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            //this.Wynik = Wynik;
            
        }

        new public void Create(int Score, Canvas gameArea)
        {
            int pkt = 0;
            //TextBlock Wynik = new TextBlock();
            gameArea.Children.Add(wynik);
            wynik.FontSize = 20;
            wynik.FontWeight = FontWeights.Bold;
            wynik.FontStyle = FontStyles.Italic;
            wynik.Text = "Score: 0"; //+ Suma(pkt);
            Canvas.SetLeft(wynik, Position.X);
            Canvas.SetTop(wynik, Position.Y);
        }

        public void Suma(int pkt, Canvas gameArea)
        {
            string Pkt = pkt.ToString();
            wynik.Text = "Score: " + Pkt;
            /*TextBlock Wynik = new TextBlock();
            Wynik.FontSize = 20;
            Wynik.FontWeight = FontWeights.Bold;
            Wynik.FontStyle = FontStyles.Italic;
            Wynik.Text = "Score: " + Pkt;
            gameArea.Children.Add(Wynik);
            Canvas.SetLeft(Wynik, Position.X);
            Canvas.SetTop(Wynik, Position.Y);*/
        }

        public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(wynik);
        }

        public void updateWynik(int Score, Vector2 Punkty, Canvas gameArea)
        {
            //Zrobic zapis gry do pliku tekstowego
            ///Position.X = Punkty.X;
            ///Position.Y = Punkty.Y;
            Vector2 New = Punkty;
            Wynik W2 = new Wynik(New, 0, 0);
            W2.Create(Score, gameArea);
            wynik.Text = "Score: " + Score.ToString();
        }
    }
}
