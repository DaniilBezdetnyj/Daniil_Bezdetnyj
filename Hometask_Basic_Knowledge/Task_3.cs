using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Task_3
    {
        public int digital_root(int input)
        {
            if (input < 0)
                return 0;
            else if (input < 10)
                return input;
            char[] splitted_input = (input.ToString()).ToCharArray();
            int sum = 0;
            for (int i = 0; i < splitted_input.Length; i++)
            {
                sum += int.Parse(splitted_input[i].ToString());
            }
            return digital_root(sum);
        }
        [Test]
        public void digital_root_Test1()
        {
            Assert.AreEqual(7, digital_root(16));
        }
        [Test]
        public void digital_root_Test2()
        {
            Assert.AreEqual(6, digital_root(942));
        }
        [Test]
        public void digital_root_Test3()
        {
            Assert.AreEqual(0, digital_root(-13));
        }
        [Test]
        public void digital_root_Test4()
        {
            Assert.AreEqual(2, digital_root(493193));
        }
    }
}
