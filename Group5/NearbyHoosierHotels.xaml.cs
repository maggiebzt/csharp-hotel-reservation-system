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

namespace Group5
{
    /// <summary>
    /// Interaction logic for NearbyHoosierHotels.xaml
    /// </summary>
    public partial class NearbyHoosierHotels : Window
    {
        public NearbyHoosierHotels()
        {
            InitializeComponent();
        }

        //Redirect users to the main menu
        private void btnReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newMai = new MainWindow();
            newMai.Show();
            this.Close();
        }

        //Reservations based on zip code entered and validation
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            if (cboZipCode.SelectedIndex == 1)
            {
                txtOutput.Text = "==================================================================" + Environment.NewLine + "======================== HOOSIER HOTELS =========================="
                + Environment.NewLine + "==================================================================" + Environment.NewLine + "Address".PadRight(22) + "Zip Code".PadRight(12) + "Phone Number".PadRight(20)
                + "Miles Away".PadRight(16) + Environment.NewLine + "618 Apple Road".PadRight(22) + "41125".PadRight(12) + "317-789-8989".PadRight(20)
                    + "4".PadRight(16) + Environment.NewLine + "314 Sample Street".PadRight(22) + "41125".PadRight(12) + "317-456-2154".PadRight(20)
                    + "8".PadRight(16) + Environment.NewLine + "216 Woodlawn Avenue".PadRight(22) + "42214".PadRight(12) + "812-617-2200".PadRight(20)
                    + "31".PadRight(16) + Environment.NewLine + "123 North Street".PadRight(22) + "43125".PadRight(12) + "812-541-7100".PadRight(20)
                    + "58".PadRight(16) + Environment.NewLine;
            }
            else if (cboZipCode.SelectedIndex == 2)
            {
                txtOutput.Text = "==================================================================" + Environment.NewLine + "======================== HOOSIER HOTELS =========================="
                + Environment.NewLine + "==================================================================" + Environment.NewLine + "Address".PadRight(22) + "Zip Code".PadRight(12) + "Phone Number".PadRight(20)
                + "Miles Away".PadRight(16) + Environment.NewLine + "216 Woodlawn Avenue".PadRight(22) + "42214".PadRight(12) + "812-617-2200".PadRight(20)
                    + "2".PadRight(16) + Environment.NewLine + "123 North Street".PadRight(22) + "43125".PadRight(12) + "812-541-7100".PadRight(20)
                    + "29".PadRight(16) + Environment.NewLine + "618 Apple Road".PadRight(22) + "41125".PadRight(12) + "317-789-8989".PadRight(20)
                    + "51".PadRight(16) + Environment.NewLine + "314 Sample Street".PadRight(22) + "41125".PadRight(12) + "317-456-2154".PadRight(20)
                    + "53".PadRight(16) + Environment.NewLine;
            }
            else if (cboZipCode.SelectedIndex == 3)
            {
                txtOutput.Text = "==================================================================" + Environment.NewLine + "======================== HOOSIER HOTELS =========================="
                + Environment.NewLine + "==================================================================" + Environment.NewLine + "Address".PadRight(22) + "Zip Code".PadRight(12) + "Phone Number".PadRight(20)
                + "Miles Away".PadRight(16) + Environment.NewLine + "123 North Street".PadRight(22) + "43125".PadRight(12) + "812-541-7100".PadRight(20)
                    + "5".PadRight(16) + Environment.NewLine + "618 Apple Road".PadRight(22) + "41125".PadRight(12) + "317-789-8989".PadRight(20)
                    + "27".PadRight(16) + Environment.NewLine + "314 Sample Street".PadRight(22) + "41125".PadRight(12) + "317-456-2154".PadRight(20)
                    + "29".PadRight(16) + Environment.NewLine + "216 Woodlawn Avenue".PadRight(22) + "42214".PadRight(12) + "812-617-2200".PadRight(20)
                    + "32".PadRight(16) + Environment.NewLine;
            }
            else
            {
                MessageBox.Show("Please select a zip code.");
            }
        }

        //Clear user input and report
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cboZipCode.SelectedIndex = 0;
            txtOutput.Text = "";
        }
    }
}
