using Group38_INF2011S_Group_Project_2025.Business;
using Group38_INF2011S_Group_Project_2025.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using static Group38_INF2011S_Group_Project_2025.Business.Booking;


namespace Group38_INF2011S_Group_Project_2025.Business
{
    public class BookingController
    {
        #region Attributes
        private BookingDA bookingDA = new BookingDA();
        private GuestController guestController = new GuestController();  
        private RoomController roomController = new RoomController();     
        private PaymentController paymentController = new PaymentController();  
        private LetterController letterController = new LetterController();    
        #endregion

        #region Methods
        public List<Room> CheckAvailability(DateTime checkIn, DateTime checkOut)
        {
            return roomController.CheckAvailability(checkIn, checkOut);  
        }

        public Booking CreateBooking(int guestId, int roomId, DateTime checkIn, DateTime checkOut, int numGuests, string cardNumber, string cardHolder)
        {
            var room = roomController.GetRoom(roomId);  // Use controller
            var booking = new Booking
            {
                GuestID = guestId,
                RoomID = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                NumberOfGuests = numGuests,
                BookingDate = DateTime.Now,
                Status = BookingStatus.Pending
            };

            booking.CalculateNumberOfNights();

            decimal pricePerNight = Booking.GetSeasonalRate(checkIn);
            booking.TotalAmount = pricePerNight * booking.NumberOfNights;
            booking.CalculateDeposit();

            booking = bookingDA.SaveBooking(booking);

            var payment = new Payment
            {
                BookingID = booking.BookingID,
                Amount = booking.DepositAmount,
                CardNumber = cardNumber,
                CardHolder = cardHolder
            };
            paymentController.RecordPayment(payment);  // Use controller

            booking.Status = BookingStatus.Confirmed;
            bookingDA.UpdateBooking(booking);

            GenerateConfirmationLetter(booking);

            return booking;
        }
        public List<Booking> GetAllBookings()
        {
            return bookingDA.GetAllBookings();
        }
        public Booking FindBooking(int bookingId)
        {
            return bookingDA.FindBooking(bookingId);
        }
        public Booking UpdateBooking(string referenceNumber, DateTime newCheckIn, DateTime newCheckOut, int newNumGuests)
        {
            var booking = bookingDA.FindBooking(referenceNumber);
            if (booking == null) return null;

            booking.CheckInDate = newCheckIn;
            booking.CheckOutDate = newCheckOut;
            booking.NumberOfGuests = newNumGuests;
            booking.CalculateNumberOfNights();

            decimal pricePerNight = Booking.GetSeasonalRate(newCheckIn);
            booking.TotalAmount = pricePerNight * booking.NumberOfNights;
            booking.CalculateDeposit();

            bookingDA.UpdateBooking(booking);
            return booking;
        }
        public int RegenerateAllConfirmationLetters()
        {
            int count = 0;
            try
            {
                // Get all confirmed bookings
                var allBookings = bookingDA.GetAllBookings();
                var confirmedBookings = allBookings
                    .Where(b => b.Status == BookingStatus.Confirmed)
                    .ToList();

                foreach (var booking in confirmedBookings)
                {
                    try
                    {
                        // Check if letter already exists
                        var existingLetters = letterController.GetLettersByBooking(booking.BookingID);
                        bool hasConfirmationLetter = existingLetters
                            .Any(l => l.Type == LetterType.Confirmation);

                        if (!hasConfirmationLetter)
                        {
                            // Generate and save the letter
                            GenerateConfirmationLetter(booking);
                            count++;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"Failed to generate letter for booking {booking.ReferenceNumber}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error regenerating letters: {ex.Message}");
            }

            return count;
        }
        public bool CancelBooking(string referenceNumber)
        {
            var booking = bookingDA.FindBooking(referenceNumber);
            if (booking == null) return false;

            booking.Status = BookingStatus.Cancelled;
            bookingDA.UpdateBooking(booking);

            GenerateCancellationLetter(booking);
            return true;
        }

        public Booking FindBooking(string referenceNumber)
        {
            return bookingDA.FindBooking(referenceNumber);
        }

        public Guest FindOrCreateGuest(string firstName, string lastName, string email, string phone, string address)
        {
            return guestController.FindOrCreateGuest(firstName, lastName, email, phone, address);  // Delegate
        }

        public List<Guest> GetAllGuests()
        {
            return guestController.GetAllGuests();  // Delegate
        }

        public Dictionary<DateTime, int> GetOccupancyReport(DateTime startDate, DateTime endDate)
        {
            var occupancy = new Dictionary<DateTime, int>();
            var totalRooms = roomController.GetAllRooms().Count;

            var allBookings = bookingDA.GetBookingsByDateRange(startDate, endDate);

            for (var date = startDate.Date; date < endDate.Date; date = date.AddDays(1))
            {
                int occupiedCount = allBookings.Count(b =>
                    date >= b.CheckInDate.Date &&
                    date < b.CheckOutDate.Date
                );

                occupancy[date] = occupiedCount;
            }

            return occupancy;
        }


        private void GenerateConfirmationLetter(Booking booking)
        {
            var guest = guestController.SearchGuest(booking.GuestID);  // Use controller
            var room = roomController.GetRoom(booking.RoomID);  // Use controller

            string content = $@"
PHUMLA KAMNANDI HOTELS
BOOKING CONFIRMATION

Dear {guest.FullName},

We are pleased to confirm your reservation:

Reference Number: {booking.ReferenceNumber}
Room: {room.RoomNumber}
Check-in: {booking.CheckInDate:dd MMM yyyy}
Check-out: {booking.CheckOutDate:dd MMM yyyy}
Number of Nights: {booking.NumberOfNights}
Number of Guests: {booking.NumberOfGuests}

Total Amount: R{booking.TotalAmount:N2}
Deposit Paid: R{booking.DepositAmount:N2}
Balance Due: R{(booking.TotalAmount - booking.DepositAmount):N2}

We look forward to welcoming you!

Best regards,
Phumla Kamnandi Hotels";

            var letter = new Letter
            {
                BookingID = booking.BookingID,
                Type = LetterType.Confirmation,
                Content = content
            };
            letterController.CreateLetter(letter);  // Use controller
            var emailService = new EmailService();
            emailService.SendLetterAsPdf(guest.Email, "Booking Confirmation - Phumla Kamnandi Hotels",guest, booking, room);

        }

        private void GenerateCancellationLetter(Booking booking)
        {
            var guest = guestController.SearchGuest(booking.GuestID);  // Use controller
            var room = roomController.GetRoom(booking.RoomID);  // Use controller
            string content = $@"
PHUMLA KAMNANDI HOTELS
BOOKING CANCELLATION

Dear {guest.FullName},

This confirms the cancellation of your reservation:

Reference Number: {booking.ReferenceNumber}
Original Check-in: {booking.CheckInDate:dd MMM yyyy}
Original Check-out: {booking.CheckOutDate:dd MMM yyyy}

As per our cancellation policy, your deposit may be retained.

Thank you for your understanding.

Best regards,
Phumla Kamnandi Hotels";

            var letter = new Letter
            {
                BookingID = booking.BookingID,
                Type = LetterType.Cancellation,
                Content = content
            };
            letterController.CreateLetter(letter);  // Use controller
            var emailService = new EmailService();
            emailService.SendLetterAsPdf(guest.Email, "Booking Cancellation - Phumla Kamnandi Hotels", guest, booking, room);

        }

        public string GetConfirmationLetter(int bookingId)
        {
            // First try to get existing letter
            var existingLetter = letterController.GetConfirmationLetter(bookingId);

            if (existingLetter != "No confirmation letter found.")
            {
                return existingLetter;
            }

            // If not found, generate it now
            try
            {
                var booking = bookingDA.FindBooking(bookingId);
                if (booking == null || booking.Status != Booking.BookingStatus.Confirmed)
                {
                    return "No confirmation letter available for this booking.";
                }

                var guest = guestController.SearchGuest(booking.GuestID);
                var room = roomController.GetRoom(booking.RoomID);

                string content = $@"
PHUMLA KAMNANDI HOTELS
BOOKING CONFIRMATION

Dear {guest?.FullName ?? "Guest"},

Reference Number: {booking.ReferenceNumber}
Room: {room?.RoomNumber ?? "N/A"}
Check-in: {booking.CheckInDate:dd MMM yyyy}
Check-out: {booking.CheckOutDate:dd MMM yyyy}
Nights: {booking.NumberOfNights}
Guests: {booking.NumberOfGuests}

Total: R{booking.TotalAmount:N2}
Deposit Paid: R{booking.DepositAmount:N2}
Balance: R{(booking.TotalAmount - booking.DepositAmount):N2}

Best regards,
Phumla Kamnandi Hotels";

                // Save for next time
                var letter = new Letter
                {
                    BookingID = bookingId,
                    Type = LetterType.Confirmation,
                    Content = content,
                    GeneratedDate = DateTime.Now
                };
                letterController.CreateLetter(letter);

                return content;
            }
            catch
            {
                return "Error generating confirmation letter.";
            }
        }
        #endregion
    }
}