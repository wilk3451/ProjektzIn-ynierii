using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Creatures
{
    public class Map
    {
        public string[,] map;
        public List<Wall> wallsinmap;
        public Map(string[,] map)
        {
            this.map = map;

            int wall_counter = 0;
            wallsinmap = new List<Wall>();
            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {


                    if (map[i, j] == "w")
                    {


                        Wall sciana = new Wall(new Vector2(j * 40, i * 40), 40, 40);
                        sciana.Body = new System.Windows.Shapes.Rectangle();

                        sciana.Body.Width = 40;
                        sciana.Body.Height = 40;

                        wallsinmap.Add(sciana);
                        
                        wall_counter++;

                    }
                }
            }
        }
    }
}
