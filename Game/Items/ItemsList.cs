using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game.Items
{
    public static class ItemsList
    {
        private static List<Item> _ItemsList;
        
        static ItemsList() 
        {
            _ItemsList = new List<Item>();

            _ItemsList.Add(new Weapon(1, "wooden sword", 1, 1, 2));
            _ItemsList.Add(new Weapon(2, "silver sword", 1, 2, 3));
        }
        public static Item CreateItem(int ItemId)
        {
            Item standardItem = _ItemsList.FirstOrDefault(item => item.ItemID == ItemId);

            if (standardItem != null)
            {
                return standardItem.Clone();
            }
            return null;
        }
    }
}
