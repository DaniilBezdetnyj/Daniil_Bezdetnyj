using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Task_5
    {
        public string SortedGuests(string guests)
        {
            guests = guests.Trim().ToUpper();
            if (guests == "")
                return guests;
            if (!guests.Contains(';') || !guests.Contains(':'))
            {
                return "";
            }
            List<Tuple<string, string>> names = new List<Tuple<string, string>>();
            string[] full_names = guests.Split(';');
            foreach (string x in full_names)
            {
                names.Add(new Tuple<string, string>(x.Split(':')[1], x.Split(':')[0]));
            }
            names.Sort((x, y) =>
            {
                int result = x.Item1.CompareTo(y.Item1);
                return result == 0 ? x.Item2.CompareTo(y.Item2) : result;
            });
            string str = "";
            foreach (Tuple<string, string> x in names)
            {
                str += x.ToString();
            }
            return str;
        }
        [Test]
        public void SortedGuestsTest1()
        {
            String s = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            String expected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            Assert.AreEqual(expected, SortedGuests(s));
        }
        [Test]
        public void SortedGuestsTest2()
        {
            String s = "            ";
            String expected = "";
            Assert.AreEqual(expected, SortedGuests(s));
        }
        [Test]
        public void SortedGuestsTest3()
        {
            String s = " ; ";
            String expected = "";
            Assert.AreEqual(expected, SortedGuests(s));
        }
    }
}
