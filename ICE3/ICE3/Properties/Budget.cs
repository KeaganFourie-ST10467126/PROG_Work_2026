using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICE3.Properties
{
    internal abstract class Budget
    {
        public double GrossIncome { get; set; }
        public List<double> Expenses { get; set; } = new List<double>();
        public double Savings { get; protected set; }
        public string SummaryMessage { get; protected set; }

        public Budget(double grossIncome, List<double> expenses) 
        {
            GrossIncome = grossIncome;
            Expenses = expenses;
        }

        /* Every budget class needs to calculate savings but in different ways
         * Another budget class can be Buy Property Budget class
         * Where the user checks if they can afford the mortgage loan or not
         * The savings calculation will be different in that class */

        public abstract void CalculateSavings();

        public void ShowResults()
        {
            
        }

    }
}
