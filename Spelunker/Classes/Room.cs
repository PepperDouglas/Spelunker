using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    public class Room {
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public List<Interactable> Interactables { get; set; }
        public RoomConnector Connector { get; set; }
        public int RoomID { get; set; }

        public Room(string description, List<Item> items, List<Interactable> interactables, RoomConnector connector, int roomID) {
            Description = description;
            Items = items;
            Interactables = interactables;
            Connector = connector;
            RoomID = roomID;
        }

        public void PrintDescription() {
            Console.WriteLine(Description);
        }

        public void PrintItems() {
            if (this.Interactables.Count > 0) {
                string interactables = "";
                interactables += "In the room you also see";
                for (int i = 0; i < this.Interactables.Count; i++) {
                    string prefix = HelperFunctions.IsAVowel(Char.ToLower(this.Interactables[i].Name[0])) == true ? " an " : " a ";
                    string needAnd = i == this.Interactables.Count - 2 ? " and" : "";
                    interactables += prefix + this.Interactables[i].Name;
                    interactables += i != this.Interactables.Count - 1 ? "," + needAnd : ".";
                }
                Console.WriteLine(interactables);
            }
            if (this.Items.Count > 0) {
                string items = "";
                items += "There is also the following items:";
                for (int i = 0; i < this.Items.Count; i++) {
                    string prefix = HelperFunctions.IsAVowel(Char.ToLower(this.Items[i].Name[0])) == true ? " an " : " a ";
                    string needAnd = i == this.Items.Count - 2 ? " and" : "";
                    items += prefix + this.Items[i].Name;
                    items += i != this.Items.Count - 1 ? "," + needAnd : ".";
                }
                Console.WriteLine(items);
            }
        }
    }
}
