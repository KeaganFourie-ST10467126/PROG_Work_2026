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

namespace HotelManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Responsible for handling button clicks and UI messages.
        public MainWindow()
        {
            InitializeComponent();
        }

        //Instantiate the RoomManager class to manage the list of rooms.
        RoomManager roomManager = new RoomManager();

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //Get the room number, room type, and status from the text boxes.
            int roomNum = int.Parse(txt_RoomNumber.Text);
            string roomType = txt_RoomType.Text;
            string status = txt_Status.Text;

            //Store the values in a room object
            Room room = new Room
            {
                RoomNumber = roomNum,
                RoomType = roomType,
                Status = status
            };

            //Add the room to the list of rooms using the RoomManager class.
            bool added = roomManager.AddRoom(room);

            if (added == true)
            {
                //Refresh the list view to show the new room.
                lvRooms.ItemsSource = null;
                lvRooms.ItemsSource = roomManager.ReadAllRooms();
            }
            else
            {
                //Show an error message if the room number already exists.
                MessageBox.Show("Room number already exists. Please enter a unique room number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvRooms.ItemsSource = null;
            lvRooms.ItemsSource = roomManager.ReadAllRooms();
        }
    }
}
