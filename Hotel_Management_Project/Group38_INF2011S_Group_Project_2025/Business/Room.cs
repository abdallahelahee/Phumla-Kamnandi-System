using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group38_INF2011S_Group_Project_2025.Business
{
    #region Enumurators
    public enum RoomType { Single, Double, Suite, Deluxe }
    #endregion

    public class Room
        {
        #region Properties
        public int RoomID { get; set; }
            public string RoomNumber { get; set; }
            public RoomType Type { get; set; }
            public decimal PricePerNight { get; set; }
            public bool IsAvailable { get; set; }
            public int MaxOccupancy { get; set; }
        #endregion

        #region Constructors
        public Room() { }       

            public Room(int id, string number, RoomType type, decimal price, int maxOccupancy)
            {
                RoomID = id;
                RoomNumber = number;
                Type = type;
                PricePerNight = price;
                IsAvailable = true;
                MaxOccupancy = maxOccupancy;
            }
        #endregion
    }
}
