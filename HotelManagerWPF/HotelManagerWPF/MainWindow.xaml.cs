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

        //Instantiate the RoomDatabase class to manage the list of rooms.
        RoomDatabase roomDatabase = new RoomDatabase();

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

            //Save to db first, then refresh the list view to show the new room.
            try
            {
                roomDatabase.AddRoom(room);
                lvRooms.ItemsSource = null;
                lvRooms.ItemsSource = roomDatabase.ReadAllRooms();
                MessageBox.Show($"Room {roomNum} added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not add the room. \n\n" + ex.Message);
            }
        }
        //Update the room details based on the selected room in the list view and the values in the text boxes.
        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {   
            Room selected = lvRooms.SelectedItem as Room;

            if (selected == null)
            {
                MessageBox.Show("Please select a room to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.RoomType = txt_RoomType.Text;
                selected.Status = txt_Status.Text;

                roomDatabase.UpdateRoom(selected);
                
                lvRooms.ItemsSource = null;
                lvRooms.ItemsSource = roomDatabase.ReadAllRooms();
                
                MessageBox.Show($"Room {selected.RoomNumber} updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not update the room. \n\n" + ex.Message);
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

            try
            {
                // Remove the room using the RoomDatabase class.
                bool deleted = roomDatabase.DeleteRoom(selected);

                if (deleted)
                {
                    // Refresh the list view to show the updated list.
                    lvRooms.ItemsSource = null;
                    lvRooms.ItemsSource = roomDatabase.ReadAllRooms();

                    // Clear the text boxes after deleting
                    txt_RoomNumber.Clear();
                    txt_RoomType.Clear();
                    txt_Status.Clear();
                    
                    MessageBox.Show($"Room {selected.RoomNumber} deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not delete the room. \n\n" + ex.Message);
            }
        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            lvRooms.ItemsSource = null;
            lvRooms.ItemsSource = roomDatabase.ReadAllRooms();
        }
        //Loaded event handler for the window to populate the ListView with the list of rooms when the application starts.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvRooms.ItemsSource = null;
            lvRooms.ItemsSource = roomDatabase.ReadAllRooms();
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
