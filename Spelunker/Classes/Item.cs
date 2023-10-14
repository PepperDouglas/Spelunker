using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? CombinesWith { get; set; }
        public string? CombinesTo { get; set; }
        public bool IsDeleted { get; set; }

        public Item(string name, string description, string? combinesWith, string? combinesTo, bool isDeleted) {
            Name = name;
            Description = description;
            CombinesWith = combinesWith;
            CombinesTo = combinesTo;
            IsDeleted = isDeleted;
        }

        public Item(string name) {
            //Here we can add items created dynamically
            Dictionary<string, string[]> ItemList = new Dictionary<string, string[]>();
            string[] legiblePaper = new string[]
            {
                "Legible Paper",
                "On this paper you can see a three digit code: 3-5-8",
                "null",
                "null",
                "false"

            };
            ItemList["LEGIBLE PAPER"] = legiblePaper;
            Name = ItemList[name][0];
            Description = ItemList[name][1];
            CombinesWith = ItemList[name][2] != "null" ? ItemList[name][2] : null;
            CombinesWith = ItemList[name][3] != "null" ? ItemList[name][3] : null;
            IsDeleted = ItemList[name][4] != "false" ? true : false;




        }


    }
}
