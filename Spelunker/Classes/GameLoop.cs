using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Spelunker.Classes.HelperFunctions;

namespace Spelunker.Classes
{
    public class GameLoop
    {
        public Player Player { get; set; }
        public List<Room> Rooms { get; set; }
        public Room? CurrentRoom { get; set; }

        public GameLoop(Player player, List<Room> rooms, int roomID) {
            Player = player;
            Rooms = rooms;
            CurrentRoom = Rooms[roomID - 1];
        }

        public void Run() {
            Console.WriteLine("You have fallen down a well in to a dark dungeon. Use your wit to find the way out!" +
                "\nType \"Help\" for available commands.");
            while (true) {
                Console.Write("\nWhat to do: ");
                string userInput = Console.ReadLine();
                ActionFromInput(userInput);
            }
        }

        public void ActionFromInput(string userInput) {
            userInput = userInput.ToLower();
            string acceptedDirections = "nwse";
            if (userInput == "look") {
                Console.WriteLine(CurrentRoom.RoomID);
                Looking();
            } else if (userInput.StartsWith("look at ")) {
                LookingAt(userInput);
            } else if (userInput == "help") {
                Help();
            } else if (userInput.StartsWith("take ")) {
                Room tempRoom = CurrentRoom;
                Player.PickUpItem(userInput, ref tempRoom);
                CurrentRoom = tempRoom; 
            } else if (userInput == "inventory") {
                ListInventory();
            } else if (userInput.StartsWith("use ") && !userInput.Contains(" on ")) {
                UseItemOrObject(userInput);
            } else if (acceptedDirections.Contains(userInput) && userInput.Length == 1) {
                RoomTransition(userInput.First<char>().ToString(), CurrentRoom.Connector);
            } else if (userInput.StartsWith("use ") && userInput.Contains(" on ")) {
                UseItemOnObject(userInput);
            } 
        }

        public void RoomTransition(string direction, RoomConnector availableDirections) {
            switch (direction) {
                case "w":
                if (availableDirections.W != null) {
                    CurrentRoom = Rooms[availableDirections.W.Value - 1];
                    Player.Inventory.Items.OfType<Map>().First<Map>().VisitedRooms[CurrentRoom.RoomID - 1] = true;
                    Console.WriteLine("You enter a new room...");
                } else {
                    Console.WriteLine("You cannot travel in that direction.");
                }
                break;
                case "n":
                if (availableDirections.N != null) {
                    CurrentRoom = Rooms[availableDirections.N.Value - 1];
                    Player.Inventory.Items.OfType<Map>().First<Map>().VisitedRooms[CurrentRoom.RoomID - 1] = true;
                    Console.WriteLine("You enter a new room...");
                } else {
                    Console.WriteLine("You cannot travel in that direction.");
                }
                break;
                case "s":
                if (availableDirections.S != null) {
                    CurrentRoom = Rooms[availableDirections.S.Value - 1];
                    Player.Inventory.Items.OfType<Map>().First<Map>().VisitedRooms[CurrentRoom.RoomID - 1] = true;
                    Console.WriteLine("You enter a new room...");
                } else {
                    Console.WriteLine("You cannot travel in that direction.");
                }
                break;
                case "e":
                if (availableDirections.E != null) {
                    CurrentRoom = Rooms[availableDirections.E.Value - 1];
                    Player.Inventory.Items.OfType<Map>().First<Map>().VisitedRooms[CurrentRoom.RoomID - 1] = true;
                    Console.WriteLine("You enter a new room...");
                } else {
                    Console.WriteLine("You cannot travel in that direction.");
                }
                break;
                default:
                break;
            }
        }
        public void UseItemOrObject(string userInput) {
            string itemToUse = userInput.Split(" ", 2)[1];

            if (itemToUse == "map") {
                Player.Inventory.Items.OfType<Map>().First<Map>().DrawMap(CurrentRoom.RoomID);
                return;
            }

            if (itemToUse == "staircase" && CurrentRoom.RoomID == 4) {
                Console.WriteLine("You have escaped the dungeon!\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            //lets just check usable items in the surrounding first ==>
            foreach (UsableInteractable usableObject in CurrentRoom.Interactables.OfType<UsableInteractable>()) {
                if (usableObject.Name.ToLower() == itemToUse.ToLower()) {
                    if (usableObject.RequiredItem != null) {
                        bool passingTest = true;
                        List<Interactable> roomInteractables = CurrentRoom.Interactables;
                        passingTest = usableObject.InteractableEvent(usableObject, ref roomInteractables);//have the function here for chest quest
                        if (passingTest) {
                            CurrentRoom.Interactables = roomInteractables;
                            if (usableObject.ReceivedItem != null) { //added
                                Player.Inventory.Add(usableObject.ReceivedItem);
                            }
                            Console.WriteLine(usableObject.PickUpMessage);
                        } else {
                            Console.WriteLine("It seems you might be missing something");
                        }
                        return;
                    } else if (Player.Inventory.Contains(usableObject.ReceivedItem)) {
                        Console.WriteLine("You have already picked up that item!");
                        return;
                    } else {
                        Player.Inventory.Add(usableObject.ReceivedItem);
                        Console.WriteLine(usableObject.PickUpMessage);
                        return;
                    }
                }
            }
            Console.WriteLine("It seems like I can't use it this way.");
        }

        public void UseItemOnObject(string userInput) {
            string item = userInput.Split("use ")[1].Split(" on")[0];
            string theObject = userInput.Split(" on ")[1];

            if (!PlayerHasRequiredItem(item, Player.Inventory)) {
                Console.WriteLine("You do not have this item.");
                return;
            }

            if(PlayerHasRequiredItem(theObject, Player.Inventory)) {
                foreach(Item inventoryItem in Player.Inventory.Items) { 
                    if(inventoryItem.CombinesWith == null && inventoryItem.Name.ToLower() == theObject) {
                        Console.WriteLine("This doesnt seem to work...");
                        return;
                    }

                    if(StringyfyNull(inventoryItem) == theObject ? true : false && inventoryItem.Name.ToLower() == item) {
                        if (Player.Inventory.Items[indexOfItemInList(item, Player)].IsDeleted) {
                            Player.Inventory.Items.RemoveAt(indexOfItemInList(item, Player));
                        }
                        if (Player.Inventory.Items[indexOfItemInList(theObject, Player)].IsDeleted) {
                            Player.Inventory.Items.RemoveAt(indexOfItemInList(theObject, Player));
                        }
                        Player.Inventory.Add(new Item(CapitalizeFirstLetter(inventoryItem.CombinesTo)));
                        Console.WriteLine("You got " + inventoryItem.CombinesTo);
                        return;       
                    }
                }
            }

            foreach (UsableInteractable usableObject in CurrentRoom.Interactables.OfType<UsableInteractable>()) {
                if (usableObject.Name.ToLower() == theObject) {
                    if (usableObject.RequiredItem == null) {
                        Console.WriteLine("You cant use that item on this.");
                        return;
                    }
                    else if (!PlayerHasRequiredItem(usableObject.RequiredItem, Player.Inventory)) {
                        Console.WriteLine("It seems you might be missing something");
                        return;
                    } else if (Player.Inventory.Items.Contains(usableObject.ReceivedItem)) {
                        Console.WriteLine("You have already picked up that item!");
                        return;
                    } else if (PlayerHasRequiredItem(usableObject.RequiredItem, Player.Inventory) && usableObject.RequiredItem.ToLower() == item) {
                        if (Player.Inventory.Items[indexOfItemInList(item, Player)].IsDeleted) {
                            Player.Inventory.Items.RemoveAt(indexOfItemInList(item, Player));
                        }

                        if (usableObject.ReceivedItem != null) {
                            Player.Inventory.Add(usableObject.ReceivedItem);
                        }
                        Console.WriteLine(usableObject.PickUpMessage);

                        if (item == "key") {
                            CurrentRoom.Connector = RoomConnector.RoomOpener(CurrentRoom, "W", 4);
                        }
                        return;
                    }
                }
            }            
            Console.WriteLine("It seems like I can't use it this way.");
        }

        public void ListInventory() {
            Player.Inventory.ShowContents();
        }
        
        public void LookingAt(string userInput) {
            string objectToLookAt = userInput.Split("look at ")[1];
            foreach (Interactable interactable in CurrentRoom.Interactables)
            {
                if (objectToLookAt == interactable.Name.ToLower()) {
                    Console.WriteLine(interactable.Description);
                    return;
                }
            }
            foreach (Item item in CurrentRoom.Items) {
                if (objectToLookAt == item.Name.ToLower()) {
                    Console.WriteLine(item.Description);
                    return;
                }
            }
            foreach (Item item in Player.Inventory.Items)
            {
                if (objectToLookAt == item.Name.ToLower()) {
                    Console.WriteLine(item.Description);
                    return;
                }
            }
            Console.WriteLine("There is no such object in this room or your inventory.");
        }

        public void Looking() {
            CurrentRoom.PrintDescription();
            CurrentRoom.PrintItems();          
        }       
    }
}
