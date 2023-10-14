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
    }
}
