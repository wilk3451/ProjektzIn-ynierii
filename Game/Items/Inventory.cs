using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    public class Inventory
    {
        private List<Potion> potionList;
        // pozostale listy przedmiotow
       
        public Inventory()
        {
            potionList = new List<Potion>();
            // inicjalizacja pozostalych list
            // dodanie przedmiotow bazowych

        }

        // wyswietlenie okna inventory

        // update

        // dodanie i usuniecie przedmiotu z danej listy
        public void AddPotion(Potion potion)
        {
            potionList.Add(potion);
        }

        // pozbycie sie calego inventory
    }
}

