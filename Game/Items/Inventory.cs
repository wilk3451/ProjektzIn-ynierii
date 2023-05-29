using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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




        public void DrawInventory(Canvas inventory)
        {
            //inventory.Width = 800;
            //inventory.Height = 400;
            //inventoryWindow.Background.
            double InventoryWidth = inventory.Width;
            double InventoryHeight = inventory.Height;
            inventory.Focusable = true;

            // Create the child Button elements
            Button closeInventory = new Button();

            // Set Positioning attached properties on Button elements
            Canvas.SetTop(closeInventory, 250);
            Canvas.SetLeft(closeInventory, InventoryWidth - 50);
            closeInventory.Content = "Trial button";

            // Add Buttons to the Canvas' Children collection
            inventory.Children.Add(closeInventory);
        }

        
    }
}

