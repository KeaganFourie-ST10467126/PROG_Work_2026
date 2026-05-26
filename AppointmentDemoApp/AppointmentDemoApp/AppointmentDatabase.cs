using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // MySQL library for C#
using AppointmentDemoApp;

namespace AppointmentDatabase
{
    /* This class is the only place in our app that talks to MySQL
     * The Window's job is to handle the buttons and clicks
     * This class' job is to read from and write to the database
     * Keeping these jobs separate is called "separation of concerns"
     */
    public class AppointmentDatabase
    {
        // Connection string tells MySql.Data how to find and log into our database
        // Replace YourPasswordHere with the root password you set when installing MySQL
        private string connectionString =
            "Server=localhost;Port=3306;Database=appointmentdb;Uid=root;Pwd=RootPW#123!;";

        // CREATE - INSERT a new room into the database
        public void AddAppointment(Appointment appointment)
        {
            // The "using" block makes sure the connection closes properly
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                //placeholders for the real values, prevents malicious SQL code inputs
                string query = "INSERT INTO Appointment (Reason, ReminderDate) " +
                               "VALUES (@Reason, @ReminderDate);";

                MySqlCommand command = new MySqlCommand(query, connection);

                // Parameterised queries protect us from SQL injection
                // The user's text is sent SEPARATELY from the SQL command
                command.Parameters.AddWithValue("@Reason", appointment.Reason);
                command.Parameters.AddWithValue("@ReminderDate", appointment.ReminderDate);

                // ExecuteNonQuery is for INSERT, UPDATE, DELETE
                command.ExecuteNonQuery();//(does not expect any rows back)
            }
        }

        // READ - SELECT all appointments from the database
        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Reason, ReminderDate FROM Appointment;";
                MySqlCommand command = new MySqlCommand(query, connection);

                // ExecuteReader is for SELECT - gives us a reader to walk through the rows
                MySqlDataReader reader = command.ExecuteReader();

                // Read() returns true if there's another row, false when done
                while (reader.Read())
                {
                    Appointment appointment = new Appointment
                    {
                        Id = reader.GetInt32("Id"),
                        Reason = reader.GetString("Reason"),
                        ReminderDate = reader.GetDateTime("ReminderDate")
                    };
                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        // ============================================================
        // UPDATE - Change an appointment's details
        // ============================================================
        public void UpdateAppointment(Appointment appointment)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // The WHERE clause is what tells MySQL which row to update
                // Without WHERE, ALL rows would be updated - a very common bug!
                string query = "UPDATE Appointment " +
                               "SET Reason = @reason, ReminderDate = @reminderDate " +
                               "WHERE Id = @Id;";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", appointment.Id);
                command.Parameters.AddWithValue("@reason", appointment.Reason);
                command.Parameters.AddWithValue("@reminderDate", appointment.ReminderDate);

                command.ExecuteNonQuery();
            }
        }

        // ============================================================
        // DELETE - Remove an appointment from the database
        // ============================================================
        public void DeleteAppointment(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Same warning as Update - the WHERE clause is critical!
                string query = "DELETE FROM Appointment WHERE Id = @Id;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
