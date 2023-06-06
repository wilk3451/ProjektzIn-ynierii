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
        public int i { get; set; }
        public int j { get; set; }
        public bool czyUsunac = false;
        
        public Treasure(Vector2 Position, int Width, int Height, int i, int j) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Body.Width = this.Width = Width;
            this.Body.Height = this.Height = Height;
            //this.Body.Fill = new SolidColorBrush(Colors.Brown);

            //Karolina
            ImageBrush enemySprite = new ImageBrush();
            enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/enemy.png"));
            Body.Fill = enemySprite;
            //
            


        }

        public void Create(Canvas gameArea)
        {

            //Body = new Rectangle();
            //gameArea.Children.Add(Body);
            //Body.Width = this.Width;
            //Body.Height = this.Height;
            //Canvas.SetTop(Body, Position.Y);
            //Canvas.SetLeft(Body, Position.X);
            //Body.Fill = new SolidColorBrush(Colors.Brown);

            //Karolina
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.DarkRed);
            Body.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = Body;

            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/skrzynia.png"));
            Body.Fill = sprite;
            //
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
            //Body.Fill = new SolidColorBrush(Colors.Yellow);
            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/coin.png"));
            Body.Fill = sprite;
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
            //K - zmienna zamiast tego przesuniecia o 45 ponizej
            int positionChanger = 40;
            //
            
            int Top = rand.Next((int)Chest.Position.X - positionChanger, (int)Chest.Position.X + positionChanger);
            int Left = rand.Next((int)Chest.Position.Y - positionChanger, (int)Chest.Position.Y + positionChanger);

            while (Top > Chest.Position.Y && Top < Chest.Position.Y)
            {
                Top = rand.Next((int)Chest.Position.X - positionChanger, (int)Chest.Position.X + positionChanger);
            }
            while (Left > Chest.Position.X && Left < Chest.Position.X)
            {
                Left = rand.Next((int)Chest.Position.Y - positionChanger, (int)Chest.Position.Y + positionChanger);
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
            //Body.Fill = new SolidColorBrush(Colors.Green);
            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/emerald.png"));
            Body.Fill = sprite;
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
            //Body.Fill = new SolidColorBrush(Colors.Red);
            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/ruby.png"));
            Body.Fill = sprite;
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
            //Body.Fill = new SolidColorBrush(Colors.Blue);
            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/diamond.png"));
            Body.Fill = sprite;
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
            //wynik = new TextBlock();
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            //this.Wynik = Wynik;

        }

        public void Create(Canvas gameArea)
        {
            int pkt = 0;
            TextBlock wynik = new TextBlock();
            Rectangle temp= new System.Windows.Shapes.Rectangle();
            temp.Width = this.Width;
            temp.Height = this.Height;
            Canvas.SetTop(temp, Position.X);
            Canvas.SetLeft(temp, Position.Y);
            temp.Fill= new SolidColorBrush(Colors.Yellow);
            gameArea.Children.Add(temp);
            gameArea.Children.Add(wynik);
            wynik.FontSize = 20;
            wynik.FontWeight = FontWeights.Bold;
            wynik.FontStyle = FontStyles.Italic;
            wynik.Text = "Score: 0"; //+ Suma(pkt);

            Canvas.SetLeft(wynik, Position.X);
            Canvas.SetTop(wynik, Position.Y);
        }

        /*public void Suma(int pkt, Canvas gameArea)
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
            Canvas.SetTop(Wynik, Position.Y);
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
        }*/
    }
}
﻿using System;
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
            this.Body.Width = this.Width = Width;
            this.Body.Height = this.Height = Height;
            //this.Body.Fill = new SolidColorBrush(Colors.Brown);

            //Karolina
            ImageBrush enemySprite = new ImageBrush();
            enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/enemy.png"));
            Body.Fill = enemySprite;
            //
            


        }

        public void Create(Canvas gameArea)
        {

            //Body = new Rectangle();
            //gameArea.Children.Add(Body);
            //Body.Width = this.Width;
            //Body.Height = this.Height;
            //Canvas.SetTop(Body, Position.Y);
            //Canvas.SetLeft(Body, Position.X);
            //Body.Fill = new SolidColorBrush(Colors.Brown);

            //Karolina
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.DarkRed);
            Body.Stroke = new SolidColorBrush(Colors.White);
            gameArea.DataContext = Body;

            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/skrzynia.png"));
            Body.Fill = sprite;
            //
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
            //Body.Fill = new SolidColorBrush(Colors.Yellow);
            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/coin.png"));
            Body.Fill = sprite;
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
            //K - zmienna zamiast tego przesuniecia o 45 ponizej
            int positionChanger = 40;
            //
            
            int Top = rand.Next((int)Chest.Position.X - positionChanger, (int)Chest.Position.X + positionChanger);
            int Left = rand.Next((int)Chest.Position.Y - positionChanger, (int)Chest.Position.Y + positionChanger);

            while (Top > Chest.Position.Y && Top < Chest.Position.Y)
            {
                Top = rand.Next((int)Chest.Position.X - positionChanger, (int)Chest.Position.X + positionChanger);
            }
            while (Left > Chest.Position.X && Left < Chest.Position.X)
            {
                Left = rand.Next((int)Chest.Position.Y - positionChanger, (int)Chest.Position.Y + positionChanger);
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
            //Body.Fill = new SolidColorBrush(Colors.Green);
            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/emerald.png"));
            Body.Fill = sprite;
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
            //Body.Fill = new SolidColorBrush(Colors.Red);
            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/ruby.png"));
            Body.Fill = sprite;
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
            //Body.Fill = new SolidColorBrush(Colors.Blue);
            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/diamond.png"));
            Body.Fill = sprite;
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
            //wynik = new TextBlock();
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            //this.Wynik = Wynik;

        }

        public void Create(Canvas gameArea)
        {
            int pkt = 0;
            TextBlock wynik = new TextBlock();
            Rectangle temp= new System.Windows.Shapes.Rectangle();
            temp.Width = this.Width;
            temp.Height = this.Height;
            Canvas.SetTop(temp, Position.X);
            Canvas.SetLeft(temp, Position.Y);
            temp.Fill= new SolidColorBrush(Colors.Yellow);
            gameArea.Children.Add(temp);
            gameArea.Children.Add(wynik);
            wynik.FontSize = 20;
            wynik.FontWeight = FontWeights.Bold;
            wynik.FontStyle = FontStyles.Italic;
            wynik.Text = "Score: 0"; //+ Suma(pkt);

            Canvas.SetLeft(wynik, Position.X);
            Canvas.SetTop(wynik, Position.Y);
        }

        /*public void Suma(int pkt, Canvas gameArea)
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
            Canvas.SetTop(Wynik, Position.Y);
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
        }*/
    }
}
