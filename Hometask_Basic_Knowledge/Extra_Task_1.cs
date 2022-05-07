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
            char[] splitted_input = input.ToString().ToCharArray();
            for (int i = splitted_input.Length - 1; i >= 1; i--)
            {
                if ((int)splitted_input[i] > (int)splitted_input[i - 1])
                {
                    char helper = splitted_input[i];
                    splitted_input[i] = splitted_input[i - 1];
                    splitted_input[i - 1] = helper;
                    return int.Parse(string.Join("", splitted_input));
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