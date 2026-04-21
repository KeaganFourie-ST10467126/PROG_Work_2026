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

namespace MultiWindowDemo
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

        private void ShowNewWindow_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxEnterName.Text;
            SecondWindow secondWindow = new SecondWindow(name);
            secondWindow.Show();
        }

        private void btnShowDialog_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxEnterName.Text;
            SecondWindow secondWindow = new SecondWindow(name);
            secondWindow.ShowDialog();
        }

        private void btnShowHide_Click(object sender, RoutedEventArgs e)
        {
            // Close any currently open SecondWindow instances to prevent duplicates
            var existingWindows = Application.Current.Windows.OfType<SecondWindow>().ToList();
            foreach (var window in existingWindows)
            {
                window.Close();
            }

            this.Hide();

            string name = txtBoxEnterName.Text;
            SecondWindow secondWindow = new SecondWindow(name);
            secondWindow.Show();

            this.Show();
        }

        private void btnSendName_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxEnterName.Text;
            SecondWindow secondWindow = new SecondWindow(name);
            secondWindow.Show();
        }
    }
}
