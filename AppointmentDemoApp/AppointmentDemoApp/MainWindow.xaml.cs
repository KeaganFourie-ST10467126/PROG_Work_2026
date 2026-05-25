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
using AppointmentDatabase;

namespace AppointmentDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppointmentDatabase.AppointmentDatabase _database;

        public MainWindow()
        {
            InitializeComponent();
            _database = new AppointmentDatabase.AppointmentDatabase();
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            var appointments = _database.GetAllAppointments();
            lvAppointments.ItemsSource = appointments;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string reason = txt_Input.Text;
            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Please enter an appointment reason.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Default to tomorrow
            DateTime reminderDate = DateTime.Now.AddDays(1);

            // Regular expressions to detect time frames
            var inXDaysMatch = System.Text.RegularExpressions.Regex.Match(reason, @"in\s+(\d+)\s+days?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (inXDaysMatch.Success && int.TryParse(inXDaysMatch.Groups[1].Value, out int days))
            {
                reminderDate = DateTime.Now.AddDays(days);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(reason, @"\btomorrow\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                reminderDate = DateTime.Now.AddDays(1);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(reason, @"\btoday\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                reminderDate = DateTime.Now;
            }

            var appointment = new Appointment
            {
                Reason = reason,
                ReminderDate = reminderDate
            };

            try
            {
                _database.AddAppointment(appointment);
                LoadAppointments();
                txt_Input.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding appointment: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lvAppointments.SelectedItem is Appointment selectedAppointment)
            {
                try
                {
                    _database.DeleteAppointment(selectedAppointment.Id);
                    LoadAppointments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting appointment: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
