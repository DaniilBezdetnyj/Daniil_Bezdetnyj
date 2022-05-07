﻿using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Task_5
    {
        public string Sort_Guests(string guests)
        {
            guests = guests.Trim().ToUpper();
            if (guests == "")
                return guests;
            if (!guests.Contains(';') || !guests.Contains(':'))
            {
                return "";
            }
            string[] str = guests.Split(';');
            string[,] newStr = new string[str.Length, 2];
            for (int i = 0; i < str.Length; i++)
            {
                newStr[i, 0] = str[i].Split(':')[1];
                newStr[i, 1] = str[i].Split(':')[0];
                str[i] = newStr[i, 0] + ", " + newStr[i, 1];
            }
            Array.Sort<string>(str, new Comparison<string>((i1, i2) => i1.CompareTo(i2)));
            string result = "(" + string.Join(")(", str) + ")";
            return result;
        }
        [Test]
        public void Sort_Guests_Test1()
        {
            String s = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            String expected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            Assert.AreEqual(expected, Sort_Guests(s));
        }
        [Test]
        public void Sort_Guests_Test2()
        {
            String s = "            ";
            String expected = "";
            Assert.AreEqual(expected, Sort_Guests(s));
        }
        [Test]
        public void Sort_Guests_Test3()
        {
            String s = " ; ";
            String expected = "";
            Assert.AreEqual(expected, Sort_Guests(s));
        }
    }
}
