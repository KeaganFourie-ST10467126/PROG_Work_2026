using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesPractice
{
    internal class Vendor: IPayable
    {

        public string Name { get; set; }

        public double Invoice { get; set; }
        public double VAT { get; set; }

        public double ProcessingFee { get; set; }
        public Vendor(string name, double invoice, double vat, double fee)
        {
            Name = name;
            Invoice = invoice;
            VAT = vat;
            ProcessingFee = fee;
        }

        public virtual double calculatePay()
        {
            return Invoice + (Invoice * VAT) - ProcessingFee
            ;
        }

        public void displayVendorDetails()
        {
            Console.WriteLine("===Vendor Details===");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Invoice: {Invoice}");
            Console.WriteLine($"VAT: {VAT}");
            Console.WriteLine($"Processing Fee: {ProcessingFee}");
            Console.WriteLine($"Total Payment: {calculatePay()}");
            Console.WriteLine("====================");
        }
    }
}
