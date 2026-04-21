using ICE3.Properties;
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

namespace ICE3
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

        private void CheckRentQualification_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get user input text from the TextBoxes
                string grossIncome = txtGross.Text;
                string tax = txtTax.Text;
                string uif = txtUIF.Text;
                string pension = txtPension.Text;
                string medical = txtMedical.Text;
                string groceries = txtGroceries.Text;
                string utilities = txtUtilities.Text;
                string travel = txtTravel.Text;
                string phone = txtPhone.Text;
                string monthlyRent = textMonthlyRent.Text;

                // Add your logic for checking rent qualification here

            }
            catch
            {

            }


        }
    }
}
