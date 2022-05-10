using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Extra_Task_1
    {
        public int NextBigger(int input)
        {
            List<int> digits = new List<int>();
            while(input%10 != input)
            {
                digits.Add(input % 10);
                input /= 10;
            }
            digits.Add(input);
            for(int i = 0; i < digits.Count-1; i++)
            {
                if(digits[i] > digits[i + 1])
                {
                    int helper = digits[i];
                    digits[i] = digits[i + 1];
                    digits[i + 1] = helper;
                    digits.Reverse();
                    return int.Parse(string.Join("", digits));
                }
            }
            return -1;
        }
        [Test]
        public void NextBiggerTest1()
        {
            Assert.AreEqual(2303, NextBigger(2033));
        }
        [Test]
        public void NextBiggerTest2()
        {
            Assert.AreEqual(110, NextBigger(101));
        }
        [Test]
        public void NextBiggerTest3()
        {
            Assert.AreEqual(-1, NextBigger(54321));
        }
    }
}