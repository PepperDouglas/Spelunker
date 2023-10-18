using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    public class Player
    {
        public Inventory Inventory { get; set; }
        
        public Player(Inventory inventory) {
            Inventory = inventory;
        }
        public void PickUpItem(string userInput, ref Room CurrentRoom) {
            string objectToPickUp = userInput.Split("take ")[1];

            foreach (Item item in this.Inventory.Items) {
                if (item.Name.ToLower() == objectToPickUp) {
                    Console.WriteLine("You already have that item...");
                }
            }
            foreach (Item item in CurrentRoom.Items) {
                if (item.Name.ToLower() == objectToPickUp) {
                    this.Inventory.Items.Add(item);
                    Console.WriteLine($"You pick up the {item.Name}");
                    CurrentRoom.Items.Remove(item);
                    return;
                }
            }
            Console.WriteLine("You cannot pick up that.");
        }
    }
}
