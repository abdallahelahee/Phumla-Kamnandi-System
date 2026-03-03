using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group38_INF2011S_Group_Project_2025.Business
{
    #region Enumerators
    public enum LetterType { Confirmation, Cancellation }
    #endregion

    public class Letter
    {
        #region Properties
        public int LetterID { get; set; }
        public int BookingID { get; set; }
        public LetterType Type { get; set; }
        public string Content { get; set; }
        public DateTime GeneratedDate { get; set; }
        #endregion

        #region Constructors
        public Letter()
        {
            GeneratedDate = DateTime.Now;
        }
        #endregion

    }
}
