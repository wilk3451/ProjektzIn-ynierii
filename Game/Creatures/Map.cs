using Game.Items;
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
        public List<Treasure> treasures;
        public List<Potion> potions;
        public List<Enemy> enemies;
        public bool Contact = false;
        Player P;

        int wall_counter = 0;
        int nextleveldoors_counter = 0;
        int door_counter = 0;
        int treasures_counter = 0;
        int potions_counter = 0;
        public int enemies_counter = 0;

        
        public Map(string[,] map)
        {
            this.map = map;

            
            wallsinmap = new List<Wall>();
            nextleveldoors = new List<NextLevel>();
            doors = new List<Door>();
            treasures = new List<Treasure>();
            potions = new List<Potion>();
            enemies = new List<Enemy>();



            //K
            int mlply1 = 560 / map.GetLength(0);
            int mlply2 = 1240 / map.GetLength(1);
            int przes = 16;
            //

            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {


                    if (map[i, j] == "w")
                    {


                        Wall sciana = new Wall(new Vector2(j * mlply2 + przes, i * mlply1), mlply2, mlply2);
                        sciana.Body = new System.Windows.Shapes.Rectangle();

                        sciana.Body.Width = mlply2;
                        sciana.Body.Height = mlply1;

                        wallsinmap.Add(sciana);
                        
                        wall_counter++;

                    }
                    if (map[i, j] == "d")
                    {


                        NextLevel next_lvl_door = new NextLevel(new Vector2(j * mlply2 + przes, i * mlply1), mlply2, mlply2);
                        next_lvl_door.Body = new System.Windows.Shapes.Rectangle();

                        next_lvl_door.Body.Width = mlply2;
                        next_lvl_door.Body.Height = mlply1;

                        nextleveldoors.Add(next_lvl_door);

                        nextleveldoors_counter++;

                    }
                    if (map[i, j] == "t")
                    {


                        Treasure treasure = new Treasure(new Vector2(j * mlply2 + przes, i * mlply1), 60, 60/*mlply2, mlply2*/, i, j);
                        treasure.Body = new System.Windows.Shapes.Rectangle();

                        //treasure.Body.Width = 20;
                        //treasure.Body.Height = 20;
                        treasure.Body.Width = 60;
                        treasure.Body.Height = 60;

                        treasures.Add(treasure);

                        treasures_counter++;

                        //map[i, j] = ",";

                    }
                    char temp = char.Parse(map[i, j]);
                    if (Char.IsDigit(temp))
                    {
                        Door door = new Door(new Vector2(j * mlply2 + przes, i * mlply1), mlply2, mlply2, temp-'0');
                        door.Body.Width = mlply2;
                        door.Body.Height = mlply1;

                        doors.Add(door);
                        door_counter++;
                    }

                    //K - start
                    if (map[i, j] == "p")
                    {
                        Potion potion;
                        Random random = new Random();
                        int Type = random.Next(0, 4);
                        int width = 40, height = 50;

                        if (Type == 0)
                        { 
                            potion = new Potion(new Vector2(j * mlply2 + przes, i * mlply1), width, height, TypeOfPotion.HealthRegeneration, i, j);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 1)
                        { 
                            potion = new Potion(new Vector2(j * mlply2 + przes, i * mlply1), width, height, TypeOfPotion.StaminaRegenerationBoost, i, j);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 2) 
                        { 
                            potion = new Potion(new Vector2(j * mlply2 + przes, i * mlply1), width, height, TypeOfPotion.HigherAttackValue, i, j);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 3) 
                        { 
                            potion = new Potion(new Vector2(j * mlply2 + przes, i * mlply1), width, height, TypeOfPotion.HigherDefenceValue, i, j);
                            potions.Add(potion);
                            potions_counter++;
                        }
                    }
                    if (map[i, j] == "e")
                    {


                        Enemy enemy = new Enemy(new Vector2(j * mlply2 + przes, i * mlply1), 70, 70,i,j);
                        enemy.Body = new System.Windows.Shapes.Rectangle();

                        enemy.Body.Width = 70;
                        enemy.Body.Height = mlply1;

                        enemies.Add(enemy);

                        enemies_counter++;

                    }
                    // - end
                }
            }
        }

        public void changeMap(string[,] map)
        {
            this.map = map;

            wall_counter = 0;
            nextleveldoors_counter = 0;
            door_counter = 0;
            potions_counter = 0;
            enemies_counter = 0;

            wallsinmap.Clear();
            nextleveldoors.Clear();
            doors.Clear();
            treasures.Clear();
            potions.Clear();
            enemies.Clear();

            //K
            //K
            int mlply1 = 560 / map.GetLength(0);
            int mlply2 = 1240 / map.GetLength(1);
            int przes = 16;
            //
            //
            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {


                    if (map[i, j] == "w")
                    {


                        Wall sciana = new Wall(new Vector2(j * mlply2, i * mlply1), mlply2, mlply2);
                        sciana.Body = new System.Windows.Shapes.Rectangle();

                        sciana.Body.Width = mlply2;
                        sciana.Body.Height = mlply1;

                        wallsinmap.Add(sciana);

                        wall_counter++;

                    }
                    if (map[i, j] == "d")
                    {


                        NextLevel door = new NextLevel(new Vector2(j * mlply2, i * mlply1), mlply2, mlply2);
                        door.Body = new System.Windows.Shapes.Rectangle();

                        door.Body.Width = mlply2;
                        door.Body.Height = mlply1;

                        nextleveldoors.Add(door);
                        nextleveldoors_counter++;
                        //wallsinmap.Add(door);

                        //wall_counter++;

                    }
                    if (map[i, j] == "t")
                    {


                        Treasure treasure = new Treasure(new Vector2(j * mlply2, i * mlply1), 60, 60, i, j);
                        
                        //treasure.Body = new System.Windows.Shapes.Rectangle();
                     

                        treasure.Body.Width = 60;
                        treasure.Body.Height = 60;

                        treasures.Add(treasure);

                        treasures_counter++;

                        //map[i, j] = ",";

                    }
                    string temp2 = map[i, j];
                    char[] temp1 = temp2.ToCharArray();
                    char temp = temp1[0];
                    if (Char.IsDigit(temp))
                    {
                        Door door = new Door(new Vector2(j * mlply2, i * mlply1), mlply2, mlply2, temp - '0');
                        door.Body = new System.Windows.Shapes.Rectangle();

                        door.Body.Width = mlply2;
                        door.Body.Height = mlply1;

                        doors.Add(door);
                        door_counter++;
                    }


                    //K - start
                    if (map[i, j] == "p")
                    {
                        Potion potion;
                        Random random = new Random();
                        int Type = random.Next(0, 4);
                        int width = 40, height = 50;

                        if (Type == 0)
                        {
                            potion = new Potion(new Vector2(j * mlply2 + przes, i * mlply1), width, height, TypeOfPotion.HealthRegeneration, i, j);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 1)
                        {
                            potion = new Potion(new Vector2(j * mlply2 + przes, i * mlply1), width, height, TypeOfPotion.StaminaRegenerationBoost, i, j);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 2)
                        {
                            potion = new Potion(new Vector2(j * mlply2 + przes, i * mlply1), width, height, TypeOfPotion.HigherAttackValue, i, j);
                            potions.Add(potion);
                            potions_counter++;
                        }
                        else if (Type == 3)
                        {
                            potion = new Potion(new Vector2(j * mlply2 + przes, i * mlply1), width, height, TypeOfPotion.HigherDefenceValue, i, j);
                            potions.Add(potion);
                            potions_counter++;
                        }
                    }
                    if (map[i, j] == "e")
                    {


                        Enemy enemy = new Enemy(new Vector2(j * mlply2 + przes, i * mlply1), 70, 70,i,j);
                        enemy.Body = new System.Windows.Shapes.Rectangle();

                        enemy.Body.Width = 70;
                        enemy.Body.Height = 70;

                        enemies.Add(enemy);

                        enemies_counter++;

                    }
                    // - end
                }
            }
        }
        public void removeEnemy(int i)
        {
            this.map[enemies[i].i, enemies[i].j] = ",";
            enemies.RemoveAt(i);
            enemies_counter--;
            
        }

        public void removeTreasure(int i)
        {
            this.map[treasures[i].i, treasures[i].j] = ",";
            treasures.RemoveAt(i);
            treasures_counter--;

        }

        public void removePotion(int i)
        {
            this.map[potions[i].i, potions[i].j] = ",";
            potions.RemoveAt(i);
            potions_counter--;

        }
    }
}
