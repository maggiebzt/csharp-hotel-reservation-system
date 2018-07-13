using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Group5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RoomManagement : Window
    {
        //Variable
        List<Room> roomList;

        //Constructor method
        public RoomManagement()
        {
            InitializeComponent();

            //dtgResults.Columns[2].CellStyle = "C2";

            //Creating a list for the rooms
            roomList = new List<Room>();
            dtgResults.ItemsSource = roomList;

            //Clearing out inputs
            cbxRoomType.SelectedIndex = 0;
            txtPrice.Text = "";
            txtQuantity.Text = "";

            //Loading in the JSON file
            string strFilePath = @"..\..\Data\Rooms.json";

            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();

                roomList = JsonConvert.DeserializeObject<List<Room>>(jsonData);

                dtgResults.ItemsSource = roomList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            dtgResults.Items.Refresh();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Create variables for Price, Quantity, and Room Type
            string strPrice, strQuantity, strRoomType;

            //Assigning inputs to Price/Quantity
            strPrice = txtPrice.Text;
            strQuantity = txtQuantity.Text;

            //Validating Price/Quantity
            Double dblPrice;
            int intQuantity;

            if (!Double.TryParse(txtPrice.Text, out dblPrice) || dblPrice <= 0)
            {
                MessageBox.Show("Please enter a numberic value of greater than $0 for Price.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out intQuantity) || intQuantity <= 0)
            {
                MessageBox.Show("Please enter a numberic value of greater than 0 for Quantity.");
                return;
            }
            
            //Assigning inputs to Room Type and creating validation
            if (cbxRoomType.SelectedIndex == 1)
                strRoomType = "One King";
            else if (cbxRoomType.SelectedIndex == 2)
                strRoomType = "One King Deluxe";
            else if (cbxRoomType.SelectedIndex == 3)
                strRoomType = "Two Queens";
            else if (cbxRoomType.SelectedIndex == 4)
                strRoomType = "Two Queen Deluxe";
            else if (cbxRoomType.SelectedIndex == 5)
                strRoomType = "One King Suite";
            else if (cbxRoomType.SelectedIndex == 6)
                strRoomType = "One King Presidential Suite";
            else
            {
                strRoomType = "";
                MessageBox.Show("Please select a room type.");
                return;
            }


            //ForEach Loop to edit the selected room type
            foreach (Room r in roomList)
            {
                if (r.RoomType == strRoomType)
                {
                    r.RoomPrice = dblPrice;
                    r.RoomQuantity = intQuantity;
                }

                dtgResults.Items.Refresh();
            }

            //Overwriting our file
            StreamWriter writer = new StreamWriter(@"..\..\Data\Rooms.json", false);
            string jsonData = JsonConvert.SerializeObject(roomList);
            writer.Write(jsonData);
            writer.Close();
        }

        //Clearing out inputs
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtPrice.Text = "";
            txtQuantity.Text = "";
            cbxRoomType.SelectedIndex = 0;
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
