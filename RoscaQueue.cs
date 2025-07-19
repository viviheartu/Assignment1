using System;
using System.Collections.Generic;

namespace Assignment1
{
    internal class RoscaQueue
    {
        private List<Member> members;

        public RoscaQueue()
        {
            members = new List<Member>();
        }

        public void Insert(Member member)
        {
            members.Add(member);
        }

        public void SetReceiveDates(DateTime startDate)
        {
            foreach (var member in members)
            {
                member.SetReceiveDate(startDate);
            }
        }

        public void DisplayAll()
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No members in the ROSCA.");
                return;
            }

            Console.WriteLine("\nROSCA Members:");
            foreach (var member in members)
            {
                member.DisplayWithDate();
            }
        }

        public void CheckMonth(DateTime inputMonth)
        {
            List<Member> alreadyReceived = new List<Member>();
            List<Member> thisMonth = new List<Member>();
            List<Member> yetToReceive = new List<Member>();

            DateTime inputMonthStart = new DateTime(inputMonth.Year, inputMonth.Month, 1);

            foreach (var member in members)
            {
                DateTime memberMonthStart = new DateTime(member.ReceiveDate.Year, member.ReceiveDate.Month, 1);

                if (memberMonthStart < inputMonthStart)
                    alreadyReceived.Add(member);

                else if (memberMonthStart == inputMonthStart)
                    thisMonth.Add(member);

                else
                    yetToReceive.Add(member);
            }

            Console.WriteLine($"\nStatus for {inputMonth:dd MMMM yyyy}:");

            Console.WriteLine("\nAlready Received:");
            if (alreadyReceived.Count == 0)
                Console.WriteLine("- None");
            else
                foreach (var member in alreadyReceived)
                    Console.WriteLine($"- {member.Name} (Draw No: {member.DrawNumber})");

            Console.WriteLine("\nReceiving This Month:");
            if (thisMonth.Count == 0)
                Console.WriteLine("- None");
            else
                foreach (var member in thisMonth)
                    Console.WriteLine($"- {member.Name} (Draw No: {member.DrawNumber})");

            Console.WriteLine("\nYet to Receive:");
            if (yetToReceive.Count == 0)
                Console.WriteLine("- None");
            else
                foreach (var member in yetToReceive)
                    Console.WriteLine($"- {member.Name} (Draw No: {member.DrawNumber})");

            members = new List<Member>();
            members.AddRange(thisMonth);
            members.AddRange(yetToReceive);
        }

        public void SortByDrawNumber()
        {
            members.Sort((a, b) => a.DrawNumber.CompareTo(b.DrawNumber));
        }
    }
}
