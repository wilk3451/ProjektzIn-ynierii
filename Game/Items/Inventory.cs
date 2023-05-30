using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Game.Creatures;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Media3D;
using System.Security.Policy;
using System.Windows.Documents;

namespace Game.Items
{
    public class Inventory
    {
        //private List<Potion> potionList;
        // pozostale listy przedmiotow
       
        //public Inventory()
        //{
          //  potionList = new List<Potion>();
            // inicjalizacja pozostalych list
            // dodanie przedmiotow bazowych

        

        Dictionary<uint, Item> items;
        Dictionary<uint, int> itemsQuantity;
        uint length = 0; // 9 slot and max 8 items for each one if it is quantity

        Font Font { get; set; }
        //Text Text { get; set; }

        public Inventory()
        {
            items = new Dictionary<uint, Item>();
            itemsQuantity = new Dictionary<uint, int>();

        }

        /*
        public void AddPotion(Potion potion)
        {
            potionList.Add(potion);
        }*/

        public void addItem(Item entity)
        {
            if (length < 9)
            {
                length++;

                // if the same item is already added then increase the quantity of item 
                if (items.ContainsKey(entity.ID) && entity.Quantity > 0)
                {
                    itemsQuantity[entity.ID] += 1;
                }
                // if item does not exist in inventory, add this item to the dictionary of items.
                else if (!items.ContainsKey(entity.ID))
                {
                    items[entity.ID] = entity;
                    itemsQuantity[entity.ID] = 1;
                }
            }
            
        }

        public void showItem(Canvas inv)
        {
            // clear the inventory panel
            inv.Children.Clear(); 

            TextBlock text = new TextBlock();

            text.FontSize = 22;
            text.LineHeight = 30;
            text.TextWrapping = TextWrapping.Wrap;
            text.TextAlignment = TextAlignment.Center;
            string temp_string = "Item ID\tQuantity";
            text.Text = temp_string;
            text.Inlines.Add(new Run(temp_string));
            text.Foreground = System.Windows.Media.Brushes.Black;
            inv.Children.Add(text);
            Canvas.SetTop(text, 80);
            Canvas.SetLeft(text, 50);
            int line = 1;

            foreach (var item in items)
            {
                TextBlock t = new TextBlock();

                t.FontSize = 22;
                t.LineHeight = 30;
                t.TextWrapping = TextWrapping.Wrap;
                t.TextAlignment = TextAlignment.Center;
                string tring = item.Key + "\t\t\t" + itemsQuantity[item.Key];
                t.Text = tring;
                t.Inlines.Add(new Run(temp_string));
                t.Foreground = System.Windows.Media.Brushes.Black;
                inv.Children.Add(t);
                Canvas.SetTop(t, 80+t.LineHeight*line+t.LineHeight);
                Canvas.SetLeft(t, 50);
               
                line++;
                line++;
            }
        }




        public void DrawInventory(Canvas inv)
        {
            //inventory.Width = 800;
            //inventory.Height = 400;
            //inventoryWindow.Background.
            double InventoryWidth = inv.Width;
            double InventoryHeight = inv.Height;
            inv.Focusable = true;

            // Create the child Button elements
            //Button closeInventory = new Button();

            // Set Positioning attached properties on Button elements
            //Canvas.SetTop(closeInventory, 250);
            //Canvas.SetLeft(closeInventory, InventoryWidth - 50);
            //closeInventory.Content = "Trial button";

            // Add Buttons to the Canvas' Children collection
            //inventory.Children.Add(closeInventory);

            int startingPointX = 100;
            int startingPointY = 100;
            int nextSlot = 0;

            List<Slot> slots = new List<Slot>();
            //Slot slot = new Slot(new Vector2(startingPointX, startingPointY), 50, 50);

            for (int i = 0; i < 8; i++)
            {
                slots.Add(new Slot(new Vector2(startingPointX + nextSlot, startingPointY), 50, 50));
                nextSlot += 80;
            }
            
            for (int i = 0; i<8; i++)
            {
                if (i % 4 == 0)
                {
                    startingPointY += 50;
                }
               // slots[i].Create(inv);
            }

            showItem(inv);

            /*
            if (potionList != null)
            {
                foreach (Potion potion in potionList)
                {
                    if(potion.type == TypeOfPotion.HealthRegeneration)
                    {
                        Canvas.SetLeft(potion.Body, startingPointX);
                        Canvas.SetTop(potion.Body, startingPointY);
                        inventory.DataContext = potion.Body;
                        inventory.Children.Add(potion.Body);
                        nextSlot += 50;
                    }
                    else if (potion.type == TypeOfPotion.StaminaRegenerationBoost)
                    {
                        Canvas.SetLeft(potion.Body, startingPointX);
                        Canvas.SetTop(potion.Body, startingPointY);
                        inventory.DataContext = potion.Body;
                        inventory.Children.Add(potion.Body);
                        nextSlot += 50;
                    }
                    else if (potion.type == TypeOfPotion.HigherAttackValue)
                    {
                        Canvas.SetLeft(potion.Body, startingPointX);
                        Canvas.SetTop(potion.Body, startingPointY);
                        inventory.DataContext = potion.Body;
                        inventory.Children.Add(potion.Body);
                        nextSlot += 50;
                    }
                    else if (potion.type == TypeOfPotion.HigherDefenceValue)
                    {
                        Canvas.SetLeft(potion.Body, startingPointX);
                        Canvas.SetTop(potion.Body, startingPointY);
                        inventory.DataContext = potion.Body;
                        inventory.Children.Add(potion.Body);
                        nextSlot += 50;
                    }

                }
            
            }
        */
        }

        
    }

    class Slot : GameSprite
    {
        public Slot(Vector2 Position, int Width, int Height) : base(Position, Width, Height)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
        }

        new public void Create(Canvas inv)
        {
            Body = new System.Windows.Shapes.Rectangle();
            inv.Children.Add(Body);
            Body.Width = this.Width;
            Body.Height = this.Height;
            Canvas.SetTop(Body, Position.Y);
            Canvas.SetLeft(Body, Position.X);
            Body.Fill = new SolidColorBrush(Colors.DarkGray);
            inv.DataContext = Body;
        }
    }
}

