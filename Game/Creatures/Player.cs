using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Creatures
{
    public class Player : GameSprite
    {
        int Hp { get; set; }
        int Atk { get; set; }
        int Def { get; set; }

        public Player(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            //System.Windows.Shapes.Rectangle Body = new System.Windows.Shapes.Rectangle();    
        }
    }
}
