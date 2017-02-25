using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BayviewHouse.Models
{
    public class Room_Model
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int MaxCapacity { get; set; }
        public decimal PricePerNight { get; set; }

        public Room_Model() { }

        public Room_Model(int roomID, string roomName, string roomType, int maxCapacity, decimal pricePerNight)
        {
            RoomID = roomID;
            RoomName = roomName;
            RoomType = roomType;
            MaxCapacity = maxCapacity;
            PricePerNight = pricePerNight;
        }
    }
}