using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    public class Weapon : Item
    {
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        
        public Weapon(uint ID, string Name, int Price, int MinDmg, int maxDmg) : base(ID, Name, Price)
        {
            this.MinDmg = MinDmg;
            this.MaxDmg = MaxDmg;
        }

        public new Weapon Clone()
        {
            return new Weapon(this.ID, this.Name, this.Price, this.MinDmg, this.MaxDmg);
        }
        
    }
}
