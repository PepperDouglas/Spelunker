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
        //public Room CurrentRoom { get; set; }
        

        public Player(Inventory inventory) {
            Inventory = inventory;
        }
    }
}
