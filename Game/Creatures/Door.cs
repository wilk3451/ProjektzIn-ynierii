using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game.Creatures
{
    public class Door : GameSprite
    {
        public int room_index;
        public Door(Vector2 Position, int Width, int Height, int room_index) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Body.Width = this.Width = Width;
            this.Body.Height = this.Height = Height;
            this.Body.Fill = new SolidColorBrush(Colors.Brown);
            this.Speed = 0;
            this.room_index = room_index;

        }


    }
    public class NextLevel : Wall
    {
        public NextLevel(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Body.Width = this.Width = Width;
            this.Body.Height = this.Height = Height;
            this.Body.Fill = new SolidColorBrush(Colors.Red);
            this.Speed = 0;

        }

    }
}
