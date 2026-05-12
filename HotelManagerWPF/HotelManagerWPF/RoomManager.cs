using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagerWPF
{
    //Responsible for managing the list of rooms, including adding, removing, and updating room information.
    class RoomManager
    {
        //The list of rooms - only this class should change it directly, other classes should interact with it through methods provided by RoomManager.
        private List<Room> rooms = new List<Room>();

        //Create method to add a room to the list of rooms.
        public bool AddRoom(Room room)
        { 
            foreach (Room r in rooms)
            {
                if (r.RoomNumber == room.RoomNumber)
                {
                    return false;
                }
            }
            rooms.Add(room);
            return true;
        }

        //Read method to get the list of rooms.
        public List<Room> ReadAllRooms()
        {
            return rooms;
        }

        //Delete method to remove a room from the list of rooms.
        public bool RemoveRoom(Room room)
        {
            foreach (Room r in rooms)
            {
                if (r.RoomNumber == room.RoomNumber)
                {
                    rooms.Remove(r);
                    MessageBox.Show("Room removed successfully.");
                    return true;
                }
            }
            MessageBox.Show("Room not found.");
            return false;
        }

        //Update method to change the information of a room in the list of rooms.
        public bool UpdateRoom(Room room)
        {
            foreach (Room r in rooms)
            {
                if (r.RoomNumber == room.RoomNumber)
                {
                    r.RoomType = room.RoomType;
                    r.Status = room.Status;
                    return true;
                }
            }
            return false;
        }

        
    }
}
