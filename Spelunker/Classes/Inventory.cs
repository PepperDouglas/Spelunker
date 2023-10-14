using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    public class Inventory
    {
        public List<Item> Items { get; set; }
        public Inventory() { 
        }

        public Inventory(List<Item> items) {
            Items = items;
        }

        public void Add(Item item) {
            Items.Add(item);
        }

        public void Remove(Item item) {
            Items.Remove(item);
        }

        public bool Contains(Item item) {
            return Items.Contains(item) ? true : false;
        }

        public void ShowContents() {
            Console.WriteLine("===YOUR ITEMS===");
            foreach (Item item in this.Items) {
                Console.WriteLine("* " + item.Name);
            }
        }
    }
}
