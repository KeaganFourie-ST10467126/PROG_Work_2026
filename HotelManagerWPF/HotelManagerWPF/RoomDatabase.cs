using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace HotelManagerWPF
{
    //This class is the only part of the project that talks to the MySQL workbench.
    //Windows job is to handle the button clicks.
    //This classes job is to perfom Create, Read, Update, and Delete tasks for the MySQL database.
    public class RoomDatabase
    {
        //We only want this class to talk to the database, so we will make the connection string private and only use it in this class.
        private string connectionString = "Server=localhost ;Port=3306 ;Database=hotelwpfdb ;Uid=root ;Pwd=RootPW#123!"; //Just add a connection string here to connect to your MySQL database.

        //Create - Insert the Room in the DB.
        public void AddRoom(Room room)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                //Placeholders for the real values to prevent SQL injection attacks.
                string query = "INSERT INTO Rooms (RoomNumber, RoomType, Status) VALUES (@roomNumber, @roomType, @status)";

                MySqlCommand command = new MySqlCommand(query, connection);

                //Parameterised queries to prevent SQL injection attacks.
                //The users text is seperate from the SQL command.
                command.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
                command.Parameters.AddWithValue("@roomType", room.RoomType);
                command.Parameters.AddWithValue("@status", room.Status);
                
                //When you do not expect rows back from the DB
                command.ExecuteNonQuery(); //Insert, delete and update commands use ExecuteNonQuery because they do not return any rows, they just perform an action on the database.
            } 
        }

        //Read Method to get the list of rooms from the DB.
        public List<Room> ReadAllRooms()
        {
            List<Room> rooms = new List<Room>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //Open the connection to the database.
                connection.Open();
                string query = "SELECT RoomNumber, RoomType, Status FROM Rooms";
                
                MySqlCommand command = new MySqlCommand(query, connection);

                //ExecuteReader is for SELECT queries - give us a reader to walk through the rows in the DB.
                MySqlDataReader reader = command.ExecuteReader();

                //Read() returns true if there is another row to read, and false if there are no more rows. So we can use it in a while loop to read through all the rows in the result set.
                while (reader.Read())
                {
                    Room room = new Room()
                    {
                        RoomNumber = reader.GetInt32("RoomNumber"),
                        RoomType = reader.GetString("RoomType"),
                        Status = reader.GetString("Status")
                    };
                    rooms.Add(room);
                }
                return rooms;
            }
        }

        public bool UpdateRoom(Room room)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Rooms SET RoomType = @roomType, Status = @status WHERE RoomNumber = @roomNumber";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
                command.Parameters.AddWithValue("@roomType", room.RoomType);
                command.Parameters.AddWithValue("@status", room.Status);
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteRoom(Room room)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Rooms WHERE RoomNumber = @roomNumber";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
                command.ExecuteNonQuery();
            }
            return true;
        }
    }
}
