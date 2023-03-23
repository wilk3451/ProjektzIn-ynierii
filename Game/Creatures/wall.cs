using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


    namespace Game.Creatures
    {
        public class Wall : GameSprite
        {
            public Wall(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
            {
                this.Position = Position;
                this.Body.Width =this.Width = Width;
                this.Body.Height =this.Height= Height;
                this.Body.Fill = new SolidColorBrush(Colors.Brown);
                this.Speed = 0;

            }


        }
        public class wallinmap
        {
            private static List<Wall> walls = new List<Wall>();

            public static void RegisterWall(Wall wall)
            {
                walls.Add(wall);
            }

            public static void RemoveWall(Wall wall)
            {
                walls.Remove(wall);
            }
        }
    }
