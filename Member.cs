using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /* 
    This program is designed to simulate a real-life savings system known 
    as ROSCA (Rotating Savings and Credit Association), commonly practiced
    in my grandpa's business community.For instance, in this system, 20 trusted
    members each agree to contribute 200,000 MMK every month for 20 months. At the
    beginning, each member is randomly assigned a draw number from 1 to 20,
    which determines the month they will receive the full pooled amount of 
    4,000,000 MMK. The first person (with draw number 1) receives the lump
    sum in the first month, followed by others in the order of their numbers,
    until everyone has had their turn. This program demonstrates the Queue
    concept specifically First In, First Out (FIFO) by managing the order in
    which members receive their money. It stores all member data, sorts them 
    by draw number, assigns payout months starting from a user-defined start
    date, and allows the user to view past, current, and upcoming recipients. 
   */
    internal class Member
    {
        public string Name { get; set; }
        public int DrawNumber { get; set; }
        public DateTime ReceiveDate { get; set; }

        public Member(string name, int drawNumber)
        {
            Name = name;
            DrawNumber = drawNumber;
        }

        public void SetReceiveDate(DateTime startDate)
        {
            ReceiveDate = startDate.AddMonths(DrawNumber - 1);
        }

        public void DisplayWithDate()
        {
            Console.WriteLine($"Name: {Name}, Draw No: {DrawNumber}, Will Receive Pot On: {ReceiveDate:dd MMMM yyyy}");
        }
    }
}