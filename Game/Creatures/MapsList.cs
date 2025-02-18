using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Creatures
{
    
    class MapsList
    {
        public static string[,] map_string1 = new string[,]
            {
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","0","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",","e",",","e",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","d",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","e",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w","w","w",",",",",",","w","w","w","w",",",",",",",",",",",",",",",",",",",",","p",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",","w","w","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",","e",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},

            };
        public static string[,] map_string2 = new string[,]
            {
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","1"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",","e",",",",",",","e","e",",",",",",","e",",",",",",",",",",",",","e",",",",",",",",",",",",","w"},
                {"w","w","w",",",",","w","w","w","w","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",","w","w","w","w","w","w","w","w","w",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","d"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},

            };
        public static string[,] map_string3 = new string[,]
            {
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",","t",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",","e",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",","e",",",",","e",",",",",",","e",",",",","w",",",",",",",",",",",",",",",",","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w","w","w",",",",","w","w","w","w","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",","e",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",","e",",",",","w",",",",",",","e",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","d"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},

            };
        public static string[,] map_string4 = new string[,]
            {
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","2","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",","e",",","e",",",",",",",",",",","p",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",","e",",","e",",",",",",",",","e",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w","w","w","w","w","w","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w","w","w",",",",","w","w","w","w","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w","w","w","w","w","w","w"},
                {"w",",",",",",","e",",","e",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",","e",",",",","w","w","w","w","w","w","w","w","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","d"},
                {"w",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",",",",",",",",",",",",",","w",",",",",",",",",",",",",",",",","w",",",",",",",",",",","w"},
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w"},

            };
        static List<string[,]> _MapList;

        static MapsList()
        {
            _MapList = new List<string[,]>();
            _MapList.Add(map_string1);
            _MapList.Add(map_string2);
            _MapList.Add(map_string3);
            _MapList.Add(map_string4);
        }

        public static void Record(string[,] value)
        {
            _MapList.Add(value);
        }
        public static string[,] get(int index)
        {
            if (index < _MapList.Count())
            {
                return _MapList[index];
            }
            else return null;
        }
        public static int length()
        {
            return _MapList.Count();
        }

        
    }
}
