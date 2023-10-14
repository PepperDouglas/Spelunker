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
    }
}
