using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    public static class GameInit
    {
        //Here we can load in a list of rooms, and so add expansion-packs
        //But let's just mock it here before refactoring, aka reading the info from a file.
        //NOTE: we need to know which rooms leads to which
        //=============ROOM 1=====================
        public static Room GetFirstRoom() {
            string roomOneDesc = "This is the first room.";
            //ADD ITEM AND ITEM TO LIST
            //removing wooden log, as it shouldnt be available unless "use wood pile" command is used
            //Item item = new Item("Wooden Log", "This is a wooden log", "Bowl of Fire", "Coal");
            List<Item> items = new List<Item>();
            //items.Add(item);
            //ADD INTERACTABLE AND INTERACTABLE TO LIST
            //Interactable interactable = new Interactable("You see a locked chest. There is some sort of combination lock on it.", "Locked Chest");
            List<Interactable> interactables = new List<Interactable>();
            interactables.Add(new UsableInteractable("It is a chest with is some sort of combination lock on it.", "Locked Chest", "You enter the" +
                "secret code and find a key inside", "Legible Paper", new Item("Key", "A mysterious key that seems to fit in a lock", "Door", null, false)));
            interactables.Add(new UsableInteractable("You see a pile of wood. There is unburnt wood in the pile.", "Wood Pile", "You" +
                " pick up a Wooden Log", null, new Item("Wooden Log", "This is a sturdy wooden log, great for making fires", "Flame Pillar", "Coal", true)));
            
            Room room = new Room(roomOneDesc, items, interactables, new RoomConnector(2,null,null,null), 1);

            return room;

        }
        public static Room GetSecondRoom() {
            string roomTwoDesc = "This is the second room.";
            List<Item> items = new List<Item>();
            List<Interactable> interactables =new List<Interactable>();
            interactables.Add(new UsableInteractable("You see a pillar with a flame burning bright on top.", "Flame Pillar", "You burn the Wooden Log" +
                "and get Coal.", "Wooden Log", new Item("Coal", "You see a lump of coal. It leaves soot where it touches.", "Paper", "Legible Paper", false)));
            interactables.Add(new UsableInteractable("You need to find a key for this door", "Door", "You open the locked door", "Key", null));
            Room room = new Room(roomTwoDesc, items, interactables, new RoomConnector(null, 1, null, 3), 2);
            return room;
        }
        public static Room GetThirdRoom() {
            string roomThreeDesc = "This is the third room.";
            List<Item> items = new List<Item>();
            List<Interactable> interactables = new List<Interactable>();
            items.Add(new Item("Paper", "There are some scratches on this paper, but they are quite hard to see...", "Coal", "Legible Paper", false));
            interactables.Add(new Interactable("You inspect a skeleton laying in the corner of the room. You see nothing of interest.", "Skeleton"));
            Room room = new Room(roomThreeDesc, items, interactables, new RoomConnector(null, null, 2, null), 3);
            return room;
        }
        public static Room GetFourthRoom() {
            string roomFourDesc = "This is the fourth room.";
            List<Item> items = new List<Item>();
            List<Interactable> interactables = new List<Interactable>();
            interactables.Add(new Interactable("You see a Staircase with light shining down from the upper floors", "Staircase"));
            Room room = new Room(roomFourDesc, items, interactables, new RoomConnector(null, null, null, 2), 4);
            return room;
        }
        //INIT THE PLAYER
        public static Player GetPlayer() { 
            //Player starting inventory
            Inventory inventory = new Inventory();
            inventory.Items = new List<Item>();
            Item item = new Item("Treasure", "Treasure from your spelunking. You have to bring it back to the surface!", null, null, false);
            Map map = new Map("Map", "This is my useful map!", null, null, false, new bool[] {true,false,false,false});
            inventory.Items.Add(map);
            inventory.Items.Add(item);
            Player player = new Player(inventory);
            return player;
        }

        public static List<Room> GetAllRooms() {
            List<Room> list = new List<Room>();
            list.Add(GetFirstRoom());
            list.Add(GetSecondRoom());
            list.Add(GetThirdRoom());
            list.Add(GetFourthRoom());
            return list;
        }
        
    }
}
