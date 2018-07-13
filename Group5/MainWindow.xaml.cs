//Team Members: Margaret Baramuli, Brian King, Cody Richard
//Image Sources: https://thenounproject.com/, https://s-ec.bstatic.com/images/hotel/max1024x768/587/58772381.jpg

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
using System.IO;
using System.Runtime.InteropServices;

namespace Group5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Set current date and time when the window is opened
            DateTime datCurrentDate = DateTime.Now;
            DateTime datCurrentTime = DateTime.Now;
            string strCurrentDate, strCurrentTime;

            strCurrentDate = datCurrentDate.ToLongDateString();
            lblCurrentDate.Content = strCurrentDate;

            strCurrentTime = datCurrentTime.ToShortTimeString();
            lblCurrentTime.Content = strCurrentTime;


            //Greeting Messages for users
            if (DateTime.Now.Hour < 12 && DateTime.Now.Hour > 4)
            {
                lblGreeting.Content = "Good Morning!";
            }
            else if (DateTime.Now.Hour < 18)
            {
                lblGreeting.Content = "Good Afternoon!";
            }
            else
            {
                lblGreeting.Content = "Good Evening!";
            }
        }

        //Navigate between windows
        private void btnNewReservation_Click(object sender, RoutedEventArgs e)
        {
            QuoteReview newQuo = new QuoteReview();
            newQuo.Show();
            this.Close();
        }

        private void btnRoomManagement_Click(object sender, RoutedEventArgs e)
        {
            RoomManagement newRoo = new RoomManagement();
            newRoo.Show();
            this.Close();
        }

        private void btnReservationsReport_Click(object sender, RoutedEventArgs e)
        {
            ReservationReport newRep = new ReservationReport();
            newRep.Show();
            this.Close();
        }

        private void btnNearbyHoosierHotels_Click(object sender, RoutedEventArgs e)
        {
            NearbyHoosierHotels newNea = new NearbyHoosierHotels();
            newNea.Show();
            this.Close();
        }

        //Close main menu
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
