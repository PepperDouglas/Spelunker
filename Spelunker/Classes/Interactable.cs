using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    //This should have subclasses!
    public class Interactable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Interactable(string description, string name) {
            Description = description;
            Name = name;
        }
    }
}
