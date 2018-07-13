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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;

namespace Group5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ReservationReport : Window
    {
        //Variables
        List<Reservation> ReservationList;
        private TimeSpan tspNumberOfNights;

        //Constructor Method
        public ReservationReport()
        {
            InitializeComponent();
            dtpStartDate.DisplayDate = DateTime.Today;
            dtpEndDate.DisplayDate = DateTime.Today;
            LoadFile();
        }
        //Loading the JSON file
        private void LoadFile()
        {
            string jsonData = File.ReadAllText(@"..\..\Data\Reservations.json");
            ReservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Making a new List for the search results
            List<Reservation> reservationSearch = new List<Reservation>();
            reservationSearch.Clear();
            dtgResults.Items.Refresh();

            //Creating LastName string
            string strLastName;
            strLastName = txtLastName.Text.Trim().ToLower();
            strLastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strLastName);

            //Validating a text entry for Last Name
            double dblNum;
            if (Double.TryParse(strLastName, out dblNum))
            {
                MessageBox.Show("Please enter a text value for Last Name.");
                return;
            }

            //Creating date for CheckInDate
            DateTime dtpStart = new DateTime();
            DateTime dtpEnd = new DateTime();

            //Validate user inputs
            if (dtpStartDate.SelectedDate == null && dtpEndDate.SelectedDate == null && strLastName == "")
            {
                MessageBox.Show("Please enter either a name or a date range in the correct entry box.");
                return;
            }
            else if (dtpStartDate.SelectedDate != null && dtpEndDate.SelectedDate == null && strLastName == "")
            {
                MessageBox.Show("Please enter an end date to complete the date range.");
                return;
            }
            else if (dtpStartDate.SelectedDate == null && dtpEndDate.SelectedDate != null && strLastName == "")
            {
                MessageBox.Show("Please enter a start date to complete the date range.");
                return;
            }

            //Assigning results to the datagrid based on search criteria:

            //When the Start/End Dates are selected and last name is blank
            if (dtpStartDate.SelectedDate != null && dtpEndDate.SelectedDate != null && strLastName == "")
            {
                dtpStart = dtpStartDate.SelectedDate.Value.Date;
                dtpEnd = dtpEndDate.SelectedDate.Value.Date;
                tspNumberOfNights = dtpEnd - dtpStart;
                if (tspNumberOfNights.Days <= 0)
                {
                    MessageBox.Show("Please enter an end date that is later than the start date");
                    return;
                }

                //Assigning results to datagrid
                dtgResults.ItemsSource = reservationSearch;
                dtgResults.Items.Refresh();

                reservationSearch = ReservationList.Where(r =>
                    r.CheckInDate >= dtpStart &&
                    r.CheckInDate <= dtpEnd).ToList();

                dtgResults.Items.Refresh();
                dtgResults.ItemsSource = reservationSearch;
            }
            //When the Start/End Dates are blank but last name is not
            else if (dtpStartDate.SelectedDate == null && dtpEndDate.SelectedDate == null && strLastName != "")
            {
                //Assigning results to datagrid
                dtgResults.ItemsSource = reservationSearch;
                dtgResults.Items.Refresh();

                reservationSearch = ReservationList.Where(r =>
                    r.LastName.StartsWith(strLastName)).ToList();

                dtgResults.Items.Refresh();
                dtgResults.ItemsSource = reservationSearch;
            }
            //When all of the inputs are not blank
            else if (dtpStartDate.SelectedDate != null && dtpEndDate.SelectedDate != null && strLastName != "")
            {
                dtpStart = dtpStartDate.SelectedDate.Value.Date;
                dtpEnd = dtpEndDate.SelectedDate.Value.Date;
                tspNumberOfNights = dtpEnd - dtpStart;
                if (tspNumberOfNights.Days <= 0)
                {
                    MessageBox.Show("Please enter an end date that is later than the start date");
                    return;
                }

                //Assigning results to datagrid
                dtgResults.ItemsSource = reservationSearch;
                dtgResults.Items.Refresh();

                reservationSearch = ReservationList.Where(r =>
                    r.LastName.StartsWith(strLastName) &&
                    r.CheckInDate >= dtpStart &&
                    r.CheckInDate <= dtpEnd).ToList();

                dtgResults.Items.Refresh();
                dtgResults.ItemsSource = reservationSearch;
            }
        }

        //Clear out the inputs and datagrid
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            dtgResults.ItemsSource = "";
            dtpStartDate.Text = "";
            dtpEndDate.Text = "";
            txtLastName.Text = "";
        }

        //Redirect users to the main menu
        private void btnReturntoMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newMai = new MainWindow();
            newMai.Show();
            this.Close();
        }
    }
}
