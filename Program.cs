using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RoscaQueue rosca = new RoscaQueue();

            Console.Write("Enter number of members: ");
            int noOfMembers = int.Parse(Console.ReadLine());

            for (int i = 0; i < noOfMembers; i++)
            {
                Console.Write($"Enter name of member {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter draw number of {name} (1 to {noOfMembers}): ");
                int drawNum = int.Parse(Console.ReadLine());

                rosca.Insert(new Member(name, drawNum));
            }

            
            Console.Write("\nEnter the exact starting date (e.g., 01 July 2025): ");
            string startDateStr = Console.ReadLine();
            DateTime startDate;

            while (!DateTime.TryParseExact(startDateStr, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                Console.Write("Invalid format! Try again (e.g., 01 July 2025): ");
                startDateStr = Console.ReadLine();
            }

            rosca.SortByDrawNumber();
            rosca.SetReceiveDates(startDate);
            rosca.DisplayAll();

           
            Console.Write("\nEnter a date to check progress (e.g., 01 December 2025): ");
            string checkDateStr = Console.ReadLine();
            DateTime checkDate;

            while (!DateTime.TryParseExact(checkDateStr, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out checkDate))
            {
                Console.Write("Invalid format! Try again (e.g., 15 October 2025): ");
                checkDateStr = Console.ReadLine();
            }

            rosca.CheckMonth(checkDate);
        }
    }
}