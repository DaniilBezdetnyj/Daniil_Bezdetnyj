using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Extra_Task_1
    {
        public int nextBigger(int input)
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
        public void ToIncreaseTest1()
        {
            Assert.AreEqual(2303, nextBigger(2033));
        }
        [Test]
        public void ToIncreaseTest2()
        {
            Assert.AreEqual(110, nextBigger(101));
        }
        [Test]
        public void ToIncreaseTest3()
        {
            Assert.AreEqual(-1, nextBigger(54321));
        }
    }
}