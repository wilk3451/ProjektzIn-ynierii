using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.Items
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Item(int ItemID,string Name,int Price)
        {
            this.ItemID = ItemID;
            this.Name = Name;
            this.Price = Price;
        }

        public Item Clone()
        {
            return new Item(this.ItemID, this.Name, this.Price);
        }
    }
}
