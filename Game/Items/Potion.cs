using Game.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

/*

Types of potions:
- health regeneration
- stamina regeneration boost (timed)
- higher attack value (timed)
- higher defence value (timed)

*/

public enum TypeOfPotion
{
    HealthRegeneration,
    StaminaRegenerationBoost,
    HigherAttackValue,
    HigherDefenceValue
}


namespace Game.Items
{
    public class Potion : GameSprite
    {
        public bool markedForDeletion = false;
        public bool interactable = true; // interakcja na planszy
        public TypeOfPotion type;
        public int i { get; set; }
        public int j { get; set; }
        public bool czyUsunac = false;

        public Potion(Vector2 Position, int Width, int Height, TypeOfPotion type, int i, int j) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            this.type = type;
            this.i = i;
            this.j = j;
            Body.Width = Width;
            Body.Height = Height;
        }

        public new void Create(Canvas gameArea)
        {
            Body = new Rectangle();
            gameArea.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);

            Body.Fill = new SolidColorBrush(Colors.White);

            ImageBrush sprite = new ImageBrush();
            sprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/enemy.png"));
            Body.Fill = sprite;

            gameArea.DataContext = Body;
        }

        // Kiedy gracz zbiera eliksir - usuniecie przedmiotu z planszy i dodanie go do Inventory
        new public void Update()
        {
            Canvas.SetLeft(Body, Position.X);
            Canvas.SetTop(Body, Position.Y);
        }

        // Kiedy gracz uzyje eliksiru - usuniecie eliksiru z Inventory i zmiana statystyk gracza
        public void Use()
        {
            
        }

        new public void Delete(Canvas gameArea)
        {
            gameArea.Children.Remove(Body);
        }
    }
}
﻿