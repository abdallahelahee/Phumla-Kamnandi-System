using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group38_INF2011S_Group_Project_2025.Database;

namespace Group38_INF2011S_Group_Project_2025.Business
{
   
    public class RoomController
    {
        #region Attributes
        
        private RoomDA roomDA = new RoomDA();
        #endregion

        #region Methods
       
       
        public List<Room> CheckAvailability(DateTime checkIn, DateTime checkOut)
        {
            return roomDA.CheckAvailability(checkIn, checkOut);
        }

        public Room GetRoom(int roomId)
        {
            return roomDA.GetRoom(roomId);
        }

        public List<Room> GetAllRooms()
        {
            return roomDA.GetAllRooms();
        }

        public void AdjustRoomOccupancy(int roomId, bool makeAvailable)
        {
            roomDA.AdjustRoomOccupancy(roomId, makeAvailable);
        }

        #endregion
    }
}
