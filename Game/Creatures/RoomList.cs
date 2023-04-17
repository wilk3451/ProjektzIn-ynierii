using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Creatures
{
    class RoomList
    {
        static List<string[,]> _RoomList;

        static RoomList()
        {
            _RoomList = new List<string[,]>();
            
        }

        public static void Record(string[,] value)
        {
            _RoomList.Add(value);
        }
        public static string[,] get(int index)
        {
            if (index < _RoomList.Count())
            {
                return _RoomList[index];
            }
            else return null;
        }
        public static int length()
        {
            return _RoomList.Count();
        }
    }
}
