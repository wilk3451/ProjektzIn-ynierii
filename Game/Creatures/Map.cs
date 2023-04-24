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
        public List<NextLevel> nextleveldoors;
        public List<Door> doors;

        int wall_counter = 0;
        int nextleveldoors_counter = 0;
        int door_counter = 0;
        public Map(string[,] map)
        {
            this.map = map;

            
            wallsinmap = new List<Wall>();
            nextleveldoors = new List<NextLevel>();
            doors = new List<Door>();
            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {


                    if (map[i, j] == "w")
                    {


                        Wall sciana = new Wall(new Vector2(j * 20, i * 20), 20, 20);
                        sciana.Body = new System.Windows.Shapes.Rectangle();

                        sciana.Body.Width = 20;
                        sciana.Body.Height = 20;

                        wallsinmap.Add(sciana);
                        
                        wall_counter++;

                    }
                    if (map[i, j] == "d")
                    {


                        NextLevel next_lvl_door = new NextLevel(new Vector2(j * 20, i * 20), 20, 20);
                        next_lvl_door.Body = new System.Windows.Shapes.Rectangle();

                        next_lvl_door.Body.Width = 20;
                        next_lvl_door.Body.Height = 20;

                        nextleveldoors.Add(next_lvl_door);

                        nextleveldoors_counter++;

                    }
                    char temp = char.Parse(map[i, j]);
                    if (Char.IsDigit(temp))
                    {
                        Door door = new Door(new Vector2(j * 20, i * 20), 20, 20, temp-'0');
                        door.Body.Width = 20;
                        door.Body.Height = 20;

                        doors.Add(door);
                        door_counter++;
                    }
                }
            }
        }

        public void changeMap(string[,] map)
        {
            this.map = map;

            wall_counter = 0;
            nextleveldoors_counter = 0;

            wallsinmap.Clear();
            nextleveldoors.Clear();
            doors.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {


                    if (map[i, j] == "w")
                    {


                        Wall sciana = new Wall(new Vector2(j * 20, i * 20), 20, 20);
                        sciana.Body = new System.Windows.Shapes.Rectangle();

                        sciana.Body.Width = 20;
                        sciana.Body.Height = 20;

                        wallsinmap.Add(sciana);

                        wall_counter++;

                    }
                    if (map[i, j] == "d")
                    {


                        NextLevel door = new NextLevel(new Vector2(j * 20, i * 20), 20, 20);
                        door.Body = new System.Windows.Shapes.Rectangle();

                        door.Body.Width = 20;
                        door.Body.Height = 20;

                        nextleveldoors.Add(door);
                        nextleveldoors_counter++;
                        //wallsinmap.Add(door);

                        //wall_counter++;

                    }
                    char temp = char.Parse(map[i, j]);
                    if (Char.IsDigit(temp))
                    {
                        Door door = new Door(new Vector2(j * 20, i * 20), 20, 20, temp - '0');
                        door.Body = new System.Windows.Shapes.Rectangle();

                        door.Body.Width = 20;
                        door.Body.Height = 20;

                        doors.Add(door);
                        door_counter++;
                    }
                }
            }
        }
    }
}
