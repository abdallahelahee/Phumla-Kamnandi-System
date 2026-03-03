using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group38_INF2011S_Group_Project_2025.Database;

namespace Group38_INF2011S_Group_Project_2025.Business
{
    public class PaymentController
    {
        #region Attributes
        private PaymentDA paymentDA = new PaymentDA();
        #endregion

        #region Methods
        public Payment RecordPayment(Payment payment)
        {
            return paymentDA.RecordPayment(payment);
        }

        public List<Payment> GetPaymentsByBooking(int bookingId)
        {
            return paymentDA.GetPaymentsByBooking(bookingId);
        }

        public decimal GetTotalPayments(int bookingId)
        {
            return paymentDA.GetTotalPayments(bookingId);
        }
        #endregion
    }
}
