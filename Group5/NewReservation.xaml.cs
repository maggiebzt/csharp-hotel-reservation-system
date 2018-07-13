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
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;

namespace Group5
{
    /// <summary>
    /// Interaction logic for NewReservation.xaml
    /// </summary>
    public partial class NewReservation : Window
    {
        #region Properties and Variables
        //Properties
        public Reservation CurReservation { get; set; }

        //Global variables
        bool bolValidCreditCard = false;
        List<Reservation> reservationList = new List<Reservation>();
        #endregion

        #region Constructor Methods
        public NewReservation()
        {
            InitializeComponent();
            imgCreditCardLogo.Visibility = Visibility.Hidden;
            LoadFile();
        }

        public NewReservation(Reservation reservation)
        {
            InitializeComponent();
            imgCreditCardLogo.Visibility = Visibility.Hidden;
            LoadFile();
            CurReservation = reservation;
            lblRoomQuantityResult.Content = CurReservation.NumberOfRooms.ToString();
            lblRoomRatesResult.Content = CurReservation.RoomPrice.ToString("C2") + " x " + CurReservation.NumberOfNights.ToString() + " night(s)";
            lblSubtotalResult.Content = CurReservation.SubTotal.ToString("C2");
            lblTaxResult.Content = CurReservation.Tax.ToString("C2");
            lblConvenienceFeeResult.Content = CurReservation.ConvenienceFee.ToString("C2");
            lblTotalResult.Content = CurReservation.Total.ToString("C2");
        }
        #endregion  

        private void btnCreateReservation_Click(object sender, RoutedEventArgs e)
        {
            #region User Input Validation
            //Validate all entries (except email) is filled
            if (txtFirstName.Text == "" ||
                txtLastName.Text == "" ||
                txtCreditCardNumber.Text == "" ||
                txtPhone.Text == "")
            {
                MessageBox.Show("Please enter the required information (marked by *).");
                return;
            }

            //Validate phone number
            string strPhoneNumber, strEmail;
            strPhoneNumber = txtPhone.Text;
            if (strPhoneNumber.Length != 10 || !strPhoneNumber.All(Char.IsDigit))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }

            //Validate email address
            strEmail = txtEmail.Text;
            if (!IsValidEmailAddress(strEmail))
            {
                MessageBox.Show("Please enter a valid email address or leave it blank.");
                return;
            }

            //Validate credit card
            if (!bolValidCreditCard || lblCreditCardType.ContentStringFormat == "")
            {
                MessageBox.Show("Please enter a valid credit card information.");
                return;
            }
            #endregion

            //Set customer details for the reservation
            CurReservation.setCustomerDetails(txtFirstName.Text, txtLastName.Text, lblCreditCardTypeResult.ContentStringFormat,
                                              txtCreditCardNumber.Text, txtPhone.Text, txtEmail.Text);

            //Show a message box displaying all information for confirmation
            MessageBoxResult messageBoxResult = MessageBox.Show("Please confirm reservation details"
                + Environment.NewLine + Environment.NewLine + CurReservation.ToString()
                , "Reserve"
                , MessageBoxButton.YesNo);

            //Add reservation to the reservation file and redirect user to quote review
            //window to prepare for a new reservation
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                reservationList.Add(CurReservation);
                AppendToFile(CurReservation);
                ClearUserInput();
                MessageBox.Show("New reservation created!");
                QuoteReview quoRev = new QuoteReview();
                quoRev.Show();
                this.Close();
            }
        }

        //Validate credit card number to only allow valid credit card numbers
        private void txtCreditCardNumber_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //Declare variables
            string strCardNum = txtCreditCardNumber.Text.Trim().Replace(" ", ""), strCardType;
            long lngOut;
            int intCheckDigit, intCheckSum = 0;

            //Validate entry is all numbers
            if (!Int64.TryParse(strCardNum, out lngOut))
            {
                MessageBox.Show("Invalid credit card number. Please enter numbers only.");
                txtCreditCardNumber.Background = new SolidColorBrush(Color.FromRgb(255, 200, 200));
                txtCreditCardNumber.Text = "";
                return;
            }

            //Validate there are 13, 15, 16 digits entered
            if (strCardNum.Length != 13 && strCardNum.Length != 15 && strCardNum.Length != 16)
            {
                MessageBox.Show("Credit card numbers must contain 13, 15, or 16 digits.");
                txtCreditCardNumber.Background = new SolidColorBrush(Color.FromRgb(255, 200, 200));
                txtCreditCardNumber.Text = "";
                return;
            }

            //Determine the card type from the prefix and set the card type variable
            if (strCardNum.StartsWith("34") || strCardNum.StartsWith("37"))
                strCardType = "American Express";
            else if (strCardNum.StartsWith("6011"))
                strCardType = "Discover";
            else if (strCardNum.StartsWith("51") || strCardNum.StartsWith("52") || strCardNum.StartsWith("53") || strCardNum.StartsWith("54") || strCardNum.StartsWith("55"))
                strCardType = "MasterCard";
            else if (strCardNum.StartsWith("4"))
                strCardType = "VISA";
            else
            {
                MessageBox.Show("Credit card not accepted. Please provide a different payment method.");
                txtCreditCardNumber.Text = "";
                return;
            }

            //Validate card number
            strCardNum = ReverseString(strCardNum);
            for (int i = 0; i < strCardNum.Length; i++)
            {
                intCheckDigit = Convert.ToInt32(strCardNum.Substring(i, 1));
                if ((i + 1) % 2 == 0)
                {
                    intCheckDigit *= 2;
                    if (intCheckDigit > 9)
                        intCheckDigit -= 9;
                }
                intCheckSum += intCheckDigit;
            }
            if (intCheckSum % 10 == 0)
                bolValidCreditCard = true;

            //Show appropriate result
            if (bolValidCreditCard)
            {
                switch (strCardType)
                {
                    case "American Express":
                        imgCreditCardLogo.Source = new BitmapImage(new Uri(@"/Images/american_express_logo.png", UriKind.Relative));
                        imgCreditCardLogo.Width = 22;
                        imgCreditCardLogo.Height = 22;
                        break;
                    case "Discover":
                        imgCreditCardLogo.Source = new BitmapImage(new Uri(@"/Images/discover_logo.png", UriKind.Relative));
                        imgCreditCardLogo.Width = 32;
                        imgCreditCardLogo.Height = 22;
                        break;
                    case "MasterCard":
                        imgCreditCardLogo.Source = new BitmapImage(new Uri(@"/Images/mastercard_logo.png", UriKind.Relative));
                        imgCreditCardLogo.Width = 37;
                        imgCreditCardLogo.Height = 22;
                        break;
                    case "VISA":
                        imgCreditCardLogo.Source = new BitmapImage(new Uri(@"/Images/visa_logo.png", UriKind.Relative));
                        imgCreditCardLogo.Width = 35;
                        imgCreditCardLogo.Height = 22;
                        break;
                }
                imgCreditCardLogo.Visibility = Visibility.Visible;
                txtCreditCardNumber.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lblCreditCardTypeResult.Content = strCardType;
            }
            else
            {
                MessageBox.Show("Please enter a valid credit card number.");
                txtCreditCardNumber.Background = new SolidColorBrush(Color.FromRgb(255, 200, 200));
                txtCreditCardNumber.Text = "";
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

        //Clear all input fields
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearUserInput();
        }

        //Redirect user to quote review window and allow user to adjust reservation details
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            QuoteReview quoRev = new QuoteReview();
            quoRev.Show();
            this.Close();
        }

        #region Helper Functions
        //DONEValidate if email address is valid
        private bool IsValidEmailAddress(string emailaddress)
        {
            Regex rx = new Regex(
            @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(emailaddress);
        }

        //DONEReturns a reversed version of the given string s 
        private string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        //DONEClear user input
        private void ClearUserInput()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCreditCardNumber.Text = "";
            txtPhone.Text = "";
            lblCreditCardTypeResult.Content = "";
            txtEmail.Text = "";
        }

        //DONEAppend new reservation to the database
        private void AppendToFile(Reservation reservation)
        {
            string strFilePath = @"..\..\Data\Reservations.json";

            try
            {
                string jsonData = JsonConvert.SerializeObject(reservationList);
                File.WriteAllText(strFilePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in append file: " + ex.Message);
                return;
            }
        }

        //DONELoading in the JSON file
        private void LoadFile()
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
        #endregion
    }
}