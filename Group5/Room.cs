using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5
{
    public class Room
    {
        //Properties
        public int RoomQuantity { get; set; }
        public string RoomType { get; set; }
        public double RoomPrice { get; set; }

        //Methods
        public Room()
        {
            RoomQuantity = 0;
            RoomType = "";
            RoomPrice = 0;
        }

        public Room(int roomQuantity, string roomType, double roomPrice)
        {
            RoomQuantity = roomQuantity;
            RoomType = roomType;
            RoomPrice = roomPrice;
        }
    }
}
