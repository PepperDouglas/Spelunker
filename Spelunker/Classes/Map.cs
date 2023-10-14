using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    public class Map : Item
    {
        public bool[] VisitedRooms { get; set; }
        public Map(string name, string description, string? combinesWith, string? combinesTo, bool isDeleted, bool[] visitedRooms) : base(name, description, combinesWith, combinesTo, isDeleted) {
            VisitedRooms = visitedRooms;
        }

        public void DrawMap(int roomNumber) {
            //█
            string[,] map = UpdateMap(roomNumber);
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);

            for (int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    Console.Write(map[i, j]);
                }
                Console.Write("\n");
            }
            Console.WriteLine("===LEGEND===\nP: Player, O: Object, I: Item, D: Door\nS: Staircase to freedom!");
        }
        private string[,] UpdateMap(int roomNumber) {
            string[,] map = DefaultMap();
            if (VisitedRooms[1]) {
                for(int i = 1; i < 6; i++) {
                    map[i, 6] = "| ";
                    map[i, 12] = "| ";
                }
                map[1, 9] = "O ";
                map[3, 6] = "D ";
            }
            if (VisitedRooms[2]) { 
                for (int i = 12; i < 18; i++) {
                    map[6, i] = "--";
                }
                map[1, 17] = "O ";
                //Update to remove Item from map, perhaps a method here that checks for each specific item on the map and removes it
                map[4, 16] = "I ";
            }
            if (VisitedRooms[3]) {
                for (int i = 1; i < 6; i++) {
                    map[6, i] = "--";
                }
                map[3, 1] = "S ";
            }
            //Draw the player position
            map[3, 3] = "  ";
            map[3, 9] = "  ";
            map[3, 12] = "  ";
            map[9, 9] = "  ";
            switch (roomNumber) {
                case 1:
                map[9, 9] = "P ";
                break;
                case 2:
                map[3, 9] = "P ";
                break;
                case 3:
                map[3, 15] = "P ";
                break;
                case 4:
                map[3, 3] = "P ";
                break;
            }

            return map;
        }
        private string[,] DefaultMap() {
            string[,] map =
            {
                { "_", "__", "__", "__", "__", "__", "__", "__", "__", "__", "__", "__", "__", "__", "__", "__", "__", "__", "_" },
                { "|", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "--", "--", "--", "  ", "--", "--", "- ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "| ", "  ", "  ", "  ", "  ", "  ", "| ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "| ", "O ", "  ", "  ", "  ", "  ", "| ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "| ", "  ", "  ", "P ", "  ", "  ", "| ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "| ", "  ", "  ", "  ", "  ", "O ", "| ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "|", "  ", "  ", "  ", "  ", "  ", "| ", "  ", "  ", "  ", "  ", "  ", "| ", "  ", "  ", "  ", "  ", "  ", "|" },
                { "-", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "-" }
            };
            return map;
        }
    }
}
