using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group38_INF2011S_Group_Project_2025.Database;

namespace Group38_INF2011S_Group_Project_2025.Business
{
    

    public class GuestController
    {
        #region Attributes
       
        private GuestDA guestDA = new GuestDA();
        #endregion

        #region Methods
         
   

        public Guest FindOrCreateGuest(string firstName, string lastName, string email, string phone, string address)
        {

            var guest = guestDA.SearchGuestByEmail(email);   
          
            if (guest == null)
            {
                guest = guestDA.SearchGuestByName(firstName, lastName);  
            }
            
            if (guest == null)
            {
                guest = guestDA.CreateGuest(firstName, lastName, email, phone, address); 
            }
            return guest;
        }

       
        public Guest SearchGuest(int guestId)
        {
            return guestDA.SearchGuest(guestId);
        }

       
  
        public Guest SearchGuestByEmail(string email)
        {
            return guestDA.SearchGuestByEmail(email);
        }

       
        public List<Guest> GetAllGuests()
        {
            return guestDA.GetAllGuests();
        }

        #endregion
    }
}
