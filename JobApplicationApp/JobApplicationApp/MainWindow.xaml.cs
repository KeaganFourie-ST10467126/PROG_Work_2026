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

namespace JobApplicationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your full name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Please enter the position you are applying for.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExpSalary.Text) || !decimal.TryParse(txtExpSalary.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric value for the expected salary.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(PreferenceCanvas.Text))
            {
                MessageBox.Show("Please select your availability.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (radioRemote.IsChecked != true && radioOnSite.IsChecked != true)
            {
                MessageBox.Show("Please select your preferred work type.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var skills = new List<string>();
            if (chkCSharp.IsChecked == true) skills.Add("C#");
            if (chkJava.IsChecked == true) skills.Add("Java");
            if (chkPython.IsChecked == true) skills.Add("Python");

            txtOutput.Text = $"Name: {txtName.Text}\nPosition: {txtPosition.Text}\nExpected Salary (R): {txtExpSalary.Text}" +
                $"\nAvailability: {PreferenceCanvas.Text}\nPreferred Work Type: {(radioRemote.IsChecked == true ? "Remote" : "On-site")}" +
                $"\nSkills: {string.Join(", ", skills)}";

            string output = txtOutput.Text;
            OutputWindow outputWindow = new OutputWindow(output);
            outputWindow.Show();
        }
    }
}
