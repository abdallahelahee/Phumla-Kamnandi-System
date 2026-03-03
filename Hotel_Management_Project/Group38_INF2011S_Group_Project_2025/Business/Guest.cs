using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group38_INF2011S_Group_Project_2025.Business
{


    public class Guest
    {
        #region Properties
        public int GuestID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public string FullName { get; set; }

        #endregion

        #region Constructors
        public Guest() { } 

        public Guest(int id, string firstName, string lastName, string email, string phone, string address)
        {
            GuestID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            FullName = $"{FirstName} {LastName}";
        }
        #endregion

        #region Methods

        /* public void calculateFullName()
           {
                FullName = $"{FirstName} {LastName}";
           }
        */
        #endregion
    }
}
