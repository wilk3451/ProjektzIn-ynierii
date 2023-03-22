using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        
    }
}
