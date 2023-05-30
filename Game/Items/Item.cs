using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.Items
{
    public class Item
    {
        public uint ID { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
        public Item(uint ID,string Name,int Price)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
        }

        public Item Clone()
        {
            return new Item(this.ID, this.Name, this.Price);
        }
    }
}
