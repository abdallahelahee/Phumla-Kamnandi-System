using Group38_INF2011S_Group_Project_2025.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group38_INF2011S_Group_Project_2025.Database
{
    /* ---Test data---
     * 
     * Test guests as per test spec:
     * 
     * guests.Add(new Guest(nextId++, "John", "Smith", "john.smith@email.com", "555-0101", "7 Main Rd, Rondebosch, 7700"));
     * guests.Add(new Guest(nextId++, "Nkosinathi", "Mthembu", "nkosinathi@email.com", "555-0102", "14 Lungelo Drive, Mtimkhulu, Durban, 4001"));
     * 
     * Additional guests:
     * 
     * guests.Add(new Guest(nextId++, "Mateo", "Montoya", "mntmat024@myuct.ac.za", "555-0103", "45 Durban Rd"));
     * guests.Add(new Guest(nextId++, "Jack", "Saunders", "SNDJAC007@myuct.ac.za", "555-0104", "22 Pitlochry Ave"));
     * guests.Add(new Guest(nextId++, "Rory", "Cupido", "CPDROR001@myuct.ac.za", "555-0105", "12 Rivertion St"));
     * guests.Add(new Guest(nextId++, "Abdallah", "Elahee", "ELHABD002@myuct.ac.za", "555-0106", "6 Maple Ln"));
     * guests.Add(new Guest(nextId++, "Jane", "Doe", "jane.doe@email.com", "555-0107", "30 Firth Rd"));
     * guests.Add(new Guest(nextId++, "Michael", "Johnson", "mjohnson@email.com", "555-0108", "67 Forth Rd"));
     * guests.Add(new Guest(nextId++, "Sarah", "Williams", "swilliams@email.com", "555-0109", "69 Fifth Rd"));
     * guests.Add(new Guest(nextId++, "David", "Brown", "dbrown@email.com", "555-0110", "21 Long St"));
    */

    public class GuestDA
    {
        public Guest SearchGuest(int guestId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Guests WHERE GuestID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", guestId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapGuestFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Guest SearchGuestByEmail(string email)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Guests WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapGuestFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Guest SearchGuestByName(string firstName, string lastName)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Guests WHERE FirstName = @FirstName AND LastName = @LastName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapGuestFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Guest CreateGuest(string firstName, string lastName, string email, string phone, string address)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Guests (FirstName, LastName, Email, Phone, Address)
                                OUTPUT INSERTED.GuestID
                                VALUES (@FirstName, @LastName, @Email, @Phone, @Address)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", address ?? (object)DBNull.Value);

                    int guestId = (int)cmd.ExecuteScalar();
                    return new Guest(guestId, firstName, lastName, email, phone, address);
                }
            }
        }

        public List<Guest> GetAllGuests()
        {
            List<Guest> guests = new List<Guest>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Guests";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guests.Add(MapGuestFromReader(reader));
                        }
                    }
                }
            }
            return guests;
        }

        private Guest MapGuestFromReader(SqlDataReader reader)
        {
            return new Guest(
                (int)reader["GuestID"],
                reader["FirstName"].ToString(),
                reader["LastName"].ToString(),
                reader["Email"].ToString(),
                reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "",
                reader["Address"] != DBNull.Value ? reader["Address"].ToString() : ""
            );
        }
    }
}

