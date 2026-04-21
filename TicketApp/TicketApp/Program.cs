namespace TicketApp
{
    internal class Program
    {
        //Create delegate
        public delegate int TicketDelegate();

        static int Adult()
        {
            return 50;
        }

        static int Child()
        {
            return Adult() / 2;
        }

        static int VIP()
        {
            return Adult() + 50;
        }

        static void Process(TicketDelegate ticket)
        {
            Console.WriteLine("Price: R" + ticket());
        }
        static void Main(string[] args)
        {
            Process(Adult);
            Process(Child);
            Process(VIP);

            TicketDelegate ticket = Adult;
            Process(ticket);

            ticket = Child;
            Process(ticket);

            ticket = VIP;
            Process(ticket);
        }
    }
}
