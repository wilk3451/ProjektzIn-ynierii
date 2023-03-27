using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Creatures
{
    /*
     Nadrzędna do Player i Enemy, przechowuje wymiary, położenie i obrazek obiektu
     * */

    public class GameSprite
    {
        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        //public Bitmap SpriteImage { get; set; }
        //public string Directory { get; set; } // zostanie wykorzystane do bitmapy
        public System.Windows.Shapes.Rectangle Body { get; set; }


        public float Speed { get; set; }

        public GameSprite(Vector2 Position, int Width, int Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;

            //Image tmp = Image.FromFile($"Resources/player_sprite.png");
            //string fileName = "player_sprite.png";
            //string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            //Image tmp = Image.FromFile(path, true);
            //Bitmap sprite = new Bitmap(tmp, (int)this.Width, (int)this.Height);
            //SpriteImage = sprite;

            Body = new System.Windows.Shapes.Rectangle();
            Speed = 5;
        }


        public class GameSpritesList
        {
            private static List<GameSprite> gameSprites = new List<GameSprite>();

            public static void RegisterSprite(GameSprite sprite)
            {
                gameSprites.Add(sprite);
            }

            public static void RemoveSprite(GameSprite sprite)
            {
                gameSprites.Remove(sprite);
            }
        }



        public void DestroySelf()
        {

        }
    }
}
