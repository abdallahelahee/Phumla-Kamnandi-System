using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group38_INF2011S_Group_Project_2025.Business
{
    public class Payment
    {
        #region Properties
        public int PaymentID { get; set; }
        public int BookingID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string PaymentReference { get; set; }

        #endregion

        #region Constructors
        public Payment()
        {
            PaymentDate = DateTime.Now;
            PaymentReference = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }
        #endregion
    }
}
