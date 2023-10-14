using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    //OBSERVE: we might have to make the same properties as for the parent class!
    public class UsableInteractable : Interactable
    {
        public string PickUpMessage { get; set; }
        public string RequiredItem { get; set; }
        public Item? ReceivedItem { get; set; }

        public UsableInteractable(string description, string name, string pickUpMessage, string requiredItem, Item? receivedItem) : base(description, name) {
            PickUpMessage = pickUpMessage;
            RequiredItem = requiredItem;
            ReceivedItem = receivedItem;
        }
    }
}
