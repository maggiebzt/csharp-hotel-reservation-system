using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5
{
    public class Reservation
    {
        //Properties
        public DateTime CheckInDate { get; set; }
        public int NumberOfNights { get; set; }
        public string RoomType { get; set; }
        public int NumberOfRooms { get; set; }
        public double RoomPrice { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double ConvenienceFee { get; set; }
        public double Total { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //Methods
        public Reservation()
        {
            //initialize default values for the properties
            CheckInDate = DateTime.Today;
            NumberOfNights = 0;
            RoomType = "One King";
            NumberOfRooms = 0;
            RoomPrice = 179.00;
            SubTotal = 0;
            Tax = 0;
            ConvenienceFee = 0;
            Total = 0;
            FirstName = "";
            LastName = "";
            CreditCardType = "";
            CreditCardNumber = "";
            Phone = "";
            Email = "";
        }

        public Reservation(DateTime checkInDate, int nights, string type,
                           int rooms, double rates, double subTotal, double tax,
                           double convenienceFee, double total)
        {
            CheckInDate = checkInDate;
            NumberOfNights = nights;
            RoomType = type;
            NumberOfRooms = rooms;
            RoomPrice = rates;
            SubTotal = subTotal;
            Tax = tax;
            ConvenienceFee = convenienceFee;
            Total = total;
        }

        public Reservation(DateTime checkInDate, int nights, string type,
                           int rooms, double rates, double subTotal, double tax,
                           double convenienceFee, double total, string firstName,
                           string lastName, string ccType, string ccNumber,
                           string phone, string email)
        {
            CheckInDate = checkInDate;
            NumberOfNights = nights;
            RoomType = type;
            NumberOfRooms = rooms;
            RoomPrice = rates;
            SubTotal = subTotal;
            Tax = tax;
            ConvenienceFee = convenienceFee;
            Total = total;
            FirstName = firstName;
            LastName = lastName;
            CreditCardType = ccType;
            CreditCardNumber = ccNumber;
            Phone = phone;
            Email = email;
        }

        public void setCustomerDetails(string firstName, string lastName, 
                                       string ccType, string ccNumber,
                                       string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            CreditCardType = ccType;
            CreditCardNumber = ccNumber;
            Phone = phone;
            Email = email;
        }

        //Returns a string that displays a customer's properties
        public override string ToString()
        {
            string strOutput = "";

            strOutput += "RESERVATION DETAILS" + Environment.NewLine +
                         "Check in date: " + CheckInDate.ToLongDateString() + Environment.NewLine +
                         "Number of nights: " + NumberOfNights.ToString() + Environment.NewLine +
                         "Room type: " + RoomType + Environment.NewLine +
                         "Number of rooms: " + NumberOfRooms.ToString() + Environment.NewLine +
                         "Room price: " + RoomPrice.ToString("C2") + Environment.NewLine +
                         "Subtotal: " + SubTotal.ToString("C2") + Environment.NewLine +
                         "Tax (7%): " + Tax.ToString("C2") + Environment.NewLine +
                         "Convenience Fee: " + ConvenienceFee.ToString("C2") + Environment.NewLine +
                         "Total: " + Total.ToString("C2") + Environment.NewLine +
                          Environment.NewLine +
                         "CUSTOMER DETAILS" + Environment.NewLine +
                         "First Name: " + FirstName + Environment.NewLine +
                         "Last Name: " + LastName + Environment.NewLine +
                         "Credit Card Number: " + CreditCardNumber + Environment.NewLine +
                         "Credit Card Type: " + CreditCardType + Environment.NewLine +
                         "Phone: " + Phone + Environment.NewLine +
                         "Email: " + Email + Environment.NewLine;

            return strOutput;
        }

    }
}
