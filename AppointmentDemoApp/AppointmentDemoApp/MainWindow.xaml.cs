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
            lvAppointments.SelectionChanged += LvAppointments_SelectionChanged;
            LoadAppointments();
        }

        private void LvAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvAppointments.SelectedItem is Appointment selectedAppointment)
            {
                txt_Input.Text = selectedAppointment.Reason;
            }
        }

        private void LoadAppointments()
        {
            var appointments = _database.GetAllAppointments();
            lvAppointments.ItemsSource = appointments;
        }

        private DateTime CheckReminderDate(string reason)
        {
            DateTime reminderDate = DateTime.Now.AddDays(1); // Default to tomorrow
            DateTime baseDate = reminderDate;
            bool dateDetermined = false;

            // 1. Determine the Date
            var inXDaysMatch = System.Text.RegularExpressions.Regex.Match(reason, @"in\s+(\d+)\s+days?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (inXDaysMatch.Success && int.TryParse(inXDaysMatch.Groups[1].Value, out int days))
            {
                baseDate = DateTime.Now.AddDays(days);
                dateDetermined = true;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(reason, @"\btomorrow\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                baseDate = DateTime.Now.AddDays(1);
                dateDetermined = true;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(reason, @"\btoday\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                baseDate = DateTime.Now;
                dateDetermined = true;
            }

            // 2. Determine the Time
            // Match phrases like "at 2 o'clock", "at 14:00", "at 2 PM", "at 2", etc.
            var timeMatch = System.Text.RegularExpressions.Regex.Match(reason, @"at\s+(\d{1,2})(?:\:(\d{2}))?\s*(am|pm|o'clock)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (timeMatch.Success)
            {
                if (int.TryParse(timeMatch.Groups[1].Value, out int hour))
                {
                    int minute = 0;
                    if (timeMatch.Groups[2].Success)
                    {
                        int.TryParse(timeMatch.Groups[2].Value, out minute);
                    }

                    string amPmOrOclock = timeMatch.Groups[3].Value.ToLower();

                    if (amPmOrOclock == "pm" && hour < 12)
                    {
                        hour += 12;
                    }
                    else if (amPmOrOclock == "am" && hour == 12)
                    {
                        hour = 0; // Midnight
                    }
                    // If "o'clock" or no modifier is passed, assume it's AM if < 12, PM if >= 12, or just accept the 24-hour style format provided. For simplicity, we just use the raw hour if it's 24h format, or 9 AM to 5 PM logic could be applied here if desired.

                    // If time is strictly "o'clock" or not specified, standard 24hr format logic applies (e.g. 14 -> 14:00, 2 -> 2:00)

                    // Construct final date with time
                    reminderDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, hour, minute, 0);
                }
            }
            else if (dateDetermined)
            {
                // If a date was found but no time, keep the current time on that date or set to a default like midnight or current time. 
                // Using current time.
                reminderDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            }

            return reminderDate;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string reason = txt_Input.Text;
            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Please enter an appointment reason.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime reminderDate = CheckReminderDate(reason);

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

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (lvAppointments.SelectedItem is Appointment selectedAppointment)
            {
                string newReason = txt_Input.Text;
                if (string.IsNullOrWhiteSpace(newReason))
                {
                    MessageBox.Show("Please enter a new appointment reason.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                selectedAppointment.Reason = newReason;
                selectedAppointment.ReminderDate = CheckReminderDate(newReason);

                try
                {
                    _database.UpdateAppointment(selectedAppointment);
                    LoadAppointments();
                    txt_Input.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating appointment: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
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
