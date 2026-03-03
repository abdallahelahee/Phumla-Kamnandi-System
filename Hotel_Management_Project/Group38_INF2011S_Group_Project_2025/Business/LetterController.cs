using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group38_INF2011S_Group_Project_2025.Database;


namespace Group38_INF2011S_Group_Project_2025.Business
{
    public class LetterController
    {
        #region Attributes
        private LetterDA letterDA = new LetterDA();
        #endregion

        #region Methods
        public Letter CreateLetter(Letter letter)
        {
            return letterDA.CreateLetter(letter);
        }

        public List<Letter> GetLettersByBooking(int bookingId)
        {
            return letterDA.GetLettersByBooking(bookingId);
        }

        public string GetConfirmationLetter(int bookingId)
        {
            var letters = letterDA.GetLettersByBooking(bookingId);
            foreach (var letter in letters)
            {
                if (letter.Type == LetterType.Confirmation)
                {
                    return letter.Content;
                }
            }
            return "No confirmation letter found.";
        }

        #endregion
    }
}
