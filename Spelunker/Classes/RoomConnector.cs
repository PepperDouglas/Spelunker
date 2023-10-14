using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelunker.Classes
{
    public class RoomConnector
    {
        public int? N { get; set; }
        public int? S { get; set; }
        public int? W { get; set; }
        public int? E { get; set; }

        public RoomConnector(int? north, int? south, int? west, int? east) {
            N = north;
            S = south;
            W = west;
            E = east;
        }
        public static RoomConnector RoomOpener(Room room, string direction, int openedRoom) {
            //take old and update with new
            RoomConnector rc = new RoomConnector(room.Connector.N, room.Connector.S, room.Connector.W, room.Connector.E);
            switch(direction) {
                case "N":
                rc.N = openedRoom;
                break;
                case "W":
                rc.W = openedRoom;
                break;
                case "S":
                rc.S = openedRoom;
                break;
                case "E":
                rc.E = openedRoom;
                break;
            }
            return rc;
        }
    }

}
