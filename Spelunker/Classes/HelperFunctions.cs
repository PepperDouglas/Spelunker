using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    public static class HelperFunctions
    {
        public static bool IsAVowel(char character) {
            string vowels = "aeyuio";
            return vowels.Contains(character);
        }
        public static string StringyfyNull(Item item) {
            return item.CombinesWith == null ? "" : item.CombinesWith.ToLower();
        }
        public static int indexOfItemInList(string itemName, Player player) {
            return player.Inventory.Items.FindIndex(i => i.Name.ToLower() == itemName);
        }
        public static bool PlayerHasRequiredItem(string usable, Inventory inventory) {
            foreach (Item item in inventory.Items) {
                if (item.Name.ToLower() == usable.ToLower()) {
                    return true;
                }
            }
            return false;
        }
        public static string CapitalizeFirstLetter(string str) {
            string[] words = str.Split(' ');
            string[] newWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++) {
                string[] splitWord = words[i].Split("");
                splitWord[0] = splitWord[0].ToString().ToUpper();
                string newWord = string.Join("", splitWord);
                newWords[i] = newWord;
            }
            return string.Join(" ", newWords);
        }
        public static void Help() {
            Console.WriteLine("Use one of the following commands:\n" +
                "N / S / W / E : Move North, South, West or East in the dungeon\n" +
                "Look : Observe your surroundings\n" +
                "Look at X: Inspect an object named X\n" +
                "Take X : Pick up an item X and put it in your inventory\n" +
                "Use X : Use an item X from your inventory, or interact with an object X in the room\n" +
                "Use X on Y : Use an item X from your inventory on an item or object Y in the inventory or room\n" +
                "Inventory : List the items in your inventory");
        }
    }
}
