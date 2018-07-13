using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace Group5
{
    /// <summary>
    /// Interaction logic for QuoteReview.xaml
    /// </summary>
    public partial class QuoteReview : Window
    {
        //Properties
        public Reservation CurReservation { get; set; }

        //Global variables
        List<Room> roomList;
        List<Reservation> reservationList;
        Boolean bolRoomAvailable;

        //Constructor method
        public QuoteReview()
        {
            InitializeComponent();
            roomList = new List<Room>();
            reservationList = new List<Reservation>();
            bolRoomAvailable = false;
            LoadReservations();
            LoadRooms();            
        }

        //Clear all user inputs
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cbbRoomType.SelectedIndex = -1;
            txtNumberOfRooms.Text = "";
            dtpCheckInDate.Text = "";
            dtpCheckOutDate.Text = "";
            bolRoomAvailable = false;
            lblRoomQuantity.Visibility = Visibility.Hidden;
            lblRoomRates.Visibility = Visibility.Hidden;
            lblRoomAvailability.Visibility = Visibility.Hidden;
            lblSubtotal.Visibility = Visibility.Hidden;
            lblTax.Visibility = Visibility.Hidden;
            lblConvenienceFee.Visibility = Visibility.Hidden;
            lblTotal.Visibility = Visibility.Hidden;
            lblRoomQuantityResult.Content = "";
            lblRoomRatesResult.Content = "";
            lblRoomAvailabilityResult.Content = "";
            lblSubtotalResult.Content = "";
            lblTaxResult.Content = "";
            lblConvenienceFeeResult.Content = "";
            lblTotalResult.Content = "";
        }

        //Calculate quote
        private void btnCalculateQuote_Click(object sender, RoutedEventArgs e)
        {
            #region Declare variables
            string strRoomAvailable = "Not Available", strRoomType;
            DateTime datCheckInDate, datCheckOutDate;
            TimeSpan tspNumberOfNights;
            int intAvailableRoomQuantity, intNumberOfNights = 0, intNumberOfRooms;
            double dblRoomPrice = 0, dblSubtotal, dblTax, dblConvenienceFee, dblTotal;
            bolRoomAvailable = false;

            #endregion

            #region User Input Validation
            //Validate a room type is selected
            if (cbbRoomType.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a room type.");
                return;
            }

            //Validate number of rooms
            if (!int.TryParse(txtNumberOfRooms.Text, out intNumberOfRooms) || intNumberOfRooms <= 0)
            {
                MessageBox.Show("Please enter a valid number of rooms.");
                return;
            }

            //Validate date entry
            if (dtpCheckInDate.SelectedDate == null)
            {
                MessageBox.Show("Please enter a check in date.");
                return;
            }
            if (dtpCheckOutDate.SelectedDate == null)
            {
                MessageBox.Show("Please enter a check out date.");
                return;
            }

            //Validate check in date is in the future
            if (((DateTime)dtpCheckInDate.SelectedDate - DateTime.Today).Days < 0)
            {
                MessageBox.Show("Please enter a check in date in the future.");
                return;
            }

            //Validate check out date is after check in date
            if (dtpCheckInDate.SelectedDate >= dtpCheckOutDate.SelectedDate)
            {
                MessageBox.Show("Please enter a check out date after the check in date.");
                return;
            }
            #endregion

            //Check room availability and assign rate per night
            ComboBoxItem cbiSelectedItem = (ComboBoxItem)cbbRoomType.SelectedItem;
            strRoomType = cbiSelectedItem.Content.ToString();

            //Validate if there's any room available during desired date
            bolRoomAvailable = CheckRoomAvailability(strRoomType, intNumberOfRooms);

            if (bolRoomAvailable)
            { 
                strRoomAvailable = "Available";
                lblRoomAvailabilityResult.Foreground = new SolidColorBrush(Color.FromRgb(9, 210, 97));
            }
            else
            {
                strRoomAvailable = "Not Available";
                lblRoomAvailabilityResult.Foreground = new SolidColorBrush(Color.FromRgb(248, 167, 149));
            }
            
            //Get room price                
            foreach (Room room in roomList)
            {
                if (room.RoomType == strRoomType)
                {
                    dblRoomPrice = room.RoomPrice;
                    intAvailableRoomQuantity = room.RoomQuantity;
                }
            }

            //Calculate number of nights
            datCheckInDate = (DateTime)dtpCheckInDate.SelectedDate;
            datCheckOutDate = (DateTime)dtpCheckOutDate.SelectedDate;
            tspNumberOfNights = datCheckOutDate - datCheckInDate;
            intNumberOfNights = tspNumberOfNights.Days;

            //Calculate subtotal
            dblSubtotal = dblRoomPrice * intNumberOfNights * intNumberOfRooms;

            //Calculate tax
            dblTax = dblSubtotal * 0.07;

            //Calculate convenience fee
            dblConvenienceFee = 10 * intNumberOfNights;

            //Calculate total
            dblTotal = dblSubtotal + dblTax + dblConvenienceFee;

            //Display result to users
            lblRoomQuantity.Visibility = Visibility.Visible;
            lblRoomRates.Visibility = Visibility.Visible;
            lblRoomAvailability.Visibility = Visibility.Visible;
            lblSubtotal.Visibility = Visibility.Visible;
            lblTax.Visibility = Visibility.Visible;
            lblConvenienceFee.Visibility = Visibility.Visible;
            lblTotal.Visibility = Visibility.Visible;

            lblRoomQuantityResult.Content = txtNumberOfRooms.Text;
            lblRoomRatesResult.Content = dblRoomPrice.ToString("C2") + " x " + intNumberOfNights.ToString() + " night(s)";
            lblRoomAvailabilityResult.Content = strRoomAvailable;
            lblSubtotalResult.Content = dblSubtotal.ToString("C2");
            lblTaxResult.Content = dblTax.ToString("C2");
            lblConvenienceFeeResult.Content = dblConvenienceFee.ToString("C2");
            lblTotalResult.Content = dblTotal.ToString("C2");

            CurReservation = new Reservation((DateTime)dtpCheckInDate.SelectedDate, intNumberOfNights, strRoomType, intNumberOfRooms,
                                             dblRoomPrice, dblSubtotal, dblTax, dblConvenienceFee, dblTotal);
        }

        //Redirect users to the new reservation window to proceed with their booking
        private void btnMakeReservation_Click(object sender, RoutedEventArgs e)
        {
            if (bolRoomAvailable)
            {
                NewReservation newRes = new NewReservation(CurReservation);
                newRes.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The room is not available. Please enter another room quote to review. Must review quote before creating room reservation.");
                return;
            }
        }

        //Redirect users to the main menu
        private void btnReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newMai = new MainWindow();
            newMai.Show();
            this.Close();
        }

        //Validate check in date
        private void dtpCheckInDate_SelectedDateChange(object sender, SelectionChangedEventArgs e)
        {
            if (dtpCheckInDate.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please input a check-in date in the future.");
                dtpCheckInDate.SelectedDate = null;
                return;
            }
        }

        //Validate check out date
        private void dtpCheckOutDate_SelectedDateChange(object sender, SelectionChangedEventArgs e)
        {
            if (dtpCheckOutDate.SelectedDate <= DateTime.Today)
            {
                MessageBox.Show("Please input a check-out date in the future.");
                dtpCheckOutDate.SelectedDate = null;
                return;
            }

            if (dtpCheckOutDate.SelectedDate < dtpCheckInDate.SelectedDate)
            {
                MessageBox.Show("Please input a check-out date later than the check-in date.");
                dtpCheckOutDate.SelectedDate = null;
                return;
            }
        }

        #region Helper Functions
        //Loading in the JSON file for list of rooms
        private void LoadRooms()
        {
            string strFilePath = @"..\..\Data\Rooms.json";

            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();
                roomList = JsonConvert.DeserializeObject<List<Room>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }
        }

        //Loading in the JSON file for list of reservations
        private void LoadReservations()
        {
            string strFilePath = @"..\..\Data\Reservations.json";

            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();
                reservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }
        }

        //Check if there's room available within the date range
        private bool CheckRoomAvailability(string strRoomType, int intNumberOfRooms)
        {
            //Declare variables
            int roomQuantity = 0;
            DateTime datNewCheckInDate, datNewCheckOutDate, datReservationCheckOutDate;
            datNewCheckInDate = (DateTime)dtpCheckInDate.SelectedDate;
            datNewCheckOutDate = (DateTime)dtpCheckOutDate.SelectedDate;

            foreach (Room room in roomList)
            {
                //Get the total number of selected rooms in the hotel
                if (room.RoomType == strRoomType)
                    roomQuantity = room.RoomQuantity;
            }

            //Calculate remaining room left
            foreach (Reservation reservation in reservationList)
            {
                datReservationCheckOutDate = reservation.CheckInDate.AddDays(reservation.NumberOfNights);
                if (reservation.RoomType == strRoomType &&
                    (datNewCheckInDate >= reservation.CheckInDate && datNewCheckInDate < datReservationCheckOutDate) ||
                    (datNewCheckOutDate > reservation.CheckInDate && datNewCheckOutDate <= datReservationCheckOutDate))
                {
                    roomQuantity--;
                }
            }

            if (roomQuantity - intNumberOfRooms >= 0)
                return true;
            return false;
        }
        #endregion
    }
}
