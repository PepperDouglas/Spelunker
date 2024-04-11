using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public bool InteractableEvent(UsableInteractable ? interactable, ref List<Interactable> roomIntractables) {
            if (interactable.Name == "Locked Chest") {
                Console.WriteLine("Please enter the code to the lock: ");
                string passkey = Console.ReadLine();
                if (passkey == "358") {
                    roomIntractables.Remove(interactable);
                    roomIntractables.Add(new Interactable("You see an opened chest. You found a key in here.", "Opened Chest"));
                    Console.WriteLine("The locked chest opens...");
                    return true;
                } else {
                    Console.WriteLine("It doesn't seem to work");
                    return false;
                }
            } else if (interactable.Name == "Door") {
                return false;
            }
            return true;
        }
    }
}
