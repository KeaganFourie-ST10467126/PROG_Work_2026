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
        //Update the room details based on the selected room in the list view and the values in the text boxes.
        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {   
            //Get the selected room object from the list view
            Room selected = lvRooms.SelectedItem as Room;

            if (selected == null)
            {
                MessageBox.Show("Please select a room to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txt_RoomNumber.Text, out int roomNum))
            {
                MessageBox.Show("Please enter a valid numeric room number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string roomType = txt_RoomType.Text;
            string status = txt_Status.Text;

            if (roomNum != selected.RoomNumber)
            {
                MessageBox.Show("Room number cannot be changed. Please enter the same room number as the selected room.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } 
            else if (string.IsNullOrWhiteSpace(roomType) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Room type and status cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Room updatedRoom = new Room
            {
                RoomNumber = roomNum,
                RoomType = roomType,
                Status = status
            };

            //Update the room in the list using the RoomManager class.
            bool updated = roomManager.UpdateRoom(updatedRoom);

            if (updated)
            {
                //Refresh the list view to show the updated room.
                lvRooms.ItemsSource = null;
                lvRooms.ItemsSource = roomManager.ReadAllRooms();
            }
            else
            {
                MessageBox.Show("Room not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected room object from the list view
            Room selected = lvRooms.SelectedItem as Room;

            if (selected == null)
            {
                MessageBox.Show("Please select a room to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Remove the room using the RoomManager class.
            bool deleted = roomManager.RemoveRoom(selected);

            if (deleted)
            {
                // Refresh the list view to show the updated list.
                lvRooms.ItemsSource = null;
                lvRooms.ItemsSource = roomManager.ReadAllRooms();

                // Clear the text boxes after deleting
                txt_RoomNumber.Clear();
                txt_RoomType.Clear();
                txt_Status.Clear();
            }
        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {

        }
        //Loaded event handler for the window to populate the ListView with the list of rooms when the application starts.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvRooms.ItemsSource = null;
            lvRooms.ItemsSource = roomManager.ReadAllRooms();
        }
        //SelectionChanged event handler for the ListView to display the selected room's details in the text boxes.
        private void lvRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room selected = lvRooms.SelectedItem as Room;

            if (selected != null)
            {
                txt_RoomNumber.Text = selected.RoomNumber.ToString();
                txt_RoomType.Text = selected.RoomType;
                txt_Status.Text = selected.Status;
            }
        }
    }
}
