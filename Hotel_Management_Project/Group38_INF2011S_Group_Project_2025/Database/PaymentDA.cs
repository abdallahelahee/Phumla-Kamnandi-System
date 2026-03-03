using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Group38_INF2011S_Group_Project_2025.Business;

namespace Group38_INF2011S_Group_Project_2025.Database
{
    public class PaymentDA
    {
        public Payment RecordPayment(Payment payment)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Payments (BookingID, Amount, PaymentDate, CardNumber, CardHolder, PaymentReference)
                                OUTPUT INSERTED.PaymentID
                                VALUES (@BookingID, @Amount, @PaymentDate, @CardNumber, @CardHolder, @PaymentRef)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", payment.BookingID);
                    cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                    cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    cmd.Parameters.AddWithValue("@CardNumber", payment.CardNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CardHolder", payment.CardHolder ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PaymentRef", payment.PaymentReference);

                    payment.PaymentID = (int)cmd.ExecuteScalar();
                }
            }
            return payment;
        }

        public List<Payment> GetPaymentsByBooking(int bookingId)
        {
            List<Payment> payments = new List<Payment>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Payments WHERE BookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(MapPaymentFromReader(reader));
                        }
                    }
                }
            }
            return payments;
        }

        public decimal GetTotalPayments(int bookingId)
        {
            decimal total = 0;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT SUM(Amount) FROM Payments WHERE BookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        total = (decimal)result;
                    }
                }
            }
            return total;
        }

        private Payment MapPaymentFromReader(SqlDataReader reader)
        {
            return new Payment
            {
                PaymentID = (int)reader["PaymentID"],
                BookingID = (int)reader["BookingID"],
                Amount = (decimal)reader["Amount"],
                PaymentDate = (DateTime)reader["PaymentDate"],
                CardNumber = reader["CardNumber"] != DBNull.Value ? reader["CardNumber"].ToString() : null,
                CardHolder = reader["CardHolder"] != DBNull.Value ? reader["CardHolder"].ToString() : null,
                PaymentReference = reader["PaymentReference"].ToString()
            };
        }
    }
}
