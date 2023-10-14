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
    }
}
