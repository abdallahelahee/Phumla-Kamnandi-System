using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Group38_INF2011S_Group_Project_2025.Business
{
    public class EmailService
    {
        private readonly string senderEmail = "phumla.kamnandi.group@gmail.com";
        private readonly string appPassword = "osyi clng wwaj mjpr";

        public void SendLetterAsPdf(string toEmail, string subject, Guest guest, Booking booking, Room room)
        {
            try
            {
                byte[] pdfBytes = GeneratePdf(subject, guest, booking, room);
                string letterPDF = subject.Replace(" ", "") + "Letter.pdf";

                using (MailMessage mail = new MailMessage())
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    mail.From = new MailAddress(senderEmail, "Phumla Kamnandi Hotels");
                    mail.To.Add(toEmail);
                    mail.Subject = subject;
                    if (subject.Equals("Booking Confirmation - Phumla Kamnandi Hotels"))
                    {
                        mail.Body = $"Dear {guest.FullName},\n\nPlease find attached your booking confirmation letter.\n\nKind regards,\nPhumla Kamnandi Hotels.";
                    }
                    else
                    {
                        mail.Body = $"Dear {guest.FullName},\n\nPlease find attached your booking cancellation letter.\n\nKind regards,\nPhumla Kamnandi Hotels.";
                    }
                    mail.Attachments.Add(new Attachment(new MemoryStream(pdfBytes), letterPDF));

                    smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email failed: {ex.Message}");
            }
        }

        private byte[] GeneratePdf(string bookingType, Guest guest, Booking booking, Room room)
        {
            using (var ms = new MemoryStream())
            {

                var doc = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, new BaseColor(41, 128, 185));
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.GRAY);

                try
                {
                    var logoBitmap = Group38_INF2011S_Group_Project_2025.Properties.Resources.KeyLogo;

                    if (logoBitmap != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            logoBitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] logoBytes = memoryStream.ToArray();

                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoBytes);
                            logo.ScaleToFit(120f, 60f);
                            logo.Alignment = Element.ALIGN_CENTER;
                            doc.Add(logo);
                            doc.Add(new Paragraph("\n"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading logo from resources: " + ex.Message);
                }

                var hotelName = new Paragraph("PHUMLA KAMNANDI HOTELS", titleFont) { Alignment = Element.ALIGN_CENTER };
                doc.Add(hotelName);

                var tagline = new Paragraph("Your Home Away From Home", smallFont) { Alignment = Element.ALIGN_CENTER };
                doc.Add(tagline);
                doc.Add(new Paragraph("\n"));

                var line = new LineSeparator(1f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -2);
                doc.Add(new Chunk(line));
                doc.Add(new Paragraph("\n"));

                var docTitle = new Paragraph(bookingType.ToUpper(), headerFont) { Alignment = Element.ALIGN_CENTER };
                doc.Add(docTitle);
                doc.Add(new Paragraph("\n"));

                var date = new Paragraph($"Date: {DateTime.Now:dd MMMM yyyy}", normalFont) { Alignment = Element.ALIGN_RIGHT };
                doc.Add(date);
                doc.Add(new Paragraph("\n"));


                doc.Add(new Paragraph($"Dear {guest.FullName},", normalFont));
                doc.Add(new Paragraph("\n"));

                bool isCancellation = bookingType.ToLower().Contains("cancellation");

                string openingMsg = isCancellation
                    ? "We confirm that we have processed your booking cancellation as requested."
                    : "We are delighted to confirm your reservation with us.";
                doc.Add(new Paragraph(openingMsg, normalFont));
                doc.Add(new Paragraph("\n\n"));


                var detailsHeader = new Paragraph(isCancellation ? "CANCELLED BOOKING DETAILS" : "BOOKING DETAILS", boldFont);
                doc.Add(detailsHeader);
                doc.Add(new Paragraph("\n"));

                doc.Add(new Paragraph($"Reference Number: {booking.ReferenceNumber}", normalFont));
                doc.Add(new Paragraph($"Original Check-in: {booking.CheckInDate:dddd, dd MMMM yyyy}", normalFont));
                doc.Add(new Paragraph($"Original Check-out: {booking.CheckOutDate:dddd, dd MMMM yyyy}", normalFont));
                doc.Add(new Paragraph($"Duration: {booking.NumberOfNights} night(s)", normalFont));
                doc.Add(new Paragraph($"Guests: {booking.NumberOfGuests}", normalFont));
                doc.Add(new Paragraph("\n"));

                if (isCancellation)
                {

                    var policyHeader = new Paragraph("DEPOSIT INFORMATION", boldFont);
                    doc.Add(policyHeader);
                    doc.Add(new Paragraph("\n"));

                    doc.Add(new Paragraph($"Deposit Paid: R {booking.DepositAmount:N2}", normalFont));


                    var policyNotice = new Paragraph();
                    policyNotice.Add(new Chunk("As per our booking policy, the deposit paid is ", normalFont));
                    policyNotice.Add(new Chunk("non-refundable.", boldFont));
                    doc.Add(policyNotice);
                }
                else
                {

                    var paymentHeader = new Paragraph("PAYMENT DETAILS", boldFont);
                    doc.Add(paymentHeader);
                    doc.Add(new Paragraph("\n"));

                    doc.Add(new Paragraph($"Total Amount: R {booking.TotalAmount:N2}", normalFont));
                    doc.Add(new Paragraph($"Deposit Paid: R {booking.DepositAmount:N2}", normalFont));

                    decimal balance = booking.TotalAmount - booking.DepositAmount;

                    var balanceFont = balance > 0
                        ? FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, new BaseColor(192, 57, 43))
                        : FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, new BaseColor(39, 174, 96));

                    string balanceText = balance > 0
                        ? $"Balance Due: R {balance:N2} (payable on check-in)"
                        : $"Balance Due: R {balance:N2} (Fully Paid)";

                    doc.Add(new Paragraph(balanceText, balanceFont));
                    doc.Add(new Paragraph("\n\n"));

                    doc.Add(new Paragraph("Check-in: 2:00 PM | Check-out: 11:00 AM", normalFont));
                    doc.Add(new Paragraph("Please bring a valid ID and this confirmation letter upon arrival.", normalFont));
                }


                doc.Add(new Paragraph("\n\n"));

                string closingMsg = isCancellation
                    ? "We are sorry that you will not be staying with us and hope to welcome you in the future."
                    : "We look forward to welcoming you!";
                doc.Add(new Paragraph(closingMsg, normalFont));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Warm regards,", normalFont));
                doc.Add(new Paragraph("The Phumla Kamnandi Hotels Team", boldFont));
                doc.Add(new Paragraph("\n\n"));


                doc.Add(new Chunk(line));

                var footer = new Paragraph(
                    "Contact: phumla.kamnandi.group@gmail.com",
                    smallFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingBefore = 10f
                };
                doc.Add(footer);

                doc.Close();
                return ms.ToArray();
            }
        }
    }
}
