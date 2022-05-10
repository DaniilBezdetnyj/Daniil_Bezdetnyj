using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Task_3
    {
        public int DigitalRoot(int input)
        {
            if (input < 0)
                return 0;
            else if (input < 10)
                return input;
            while(input >= 10)
            {
                int itterated_input = 0;
                while (input != 0)
                {
                    itterated_input += input % 10;
                    input /= 10;
                }
                input = itterated_input;
            }
            return input;
        }
        [Test]
        public void DigitalRootTest1()
        {
            Assert.AreEqual(7, DigitalRoot(16));
        }
        [Test]
        public void DigitalRootTest2()
        {
            Assert.AreEqual(6, DigitalRoot(942));
        }
        [Test]
        public void DigitalRootTest3()
        {
            Assert.AreEqual(0, DigitalRoot(-13));
        }
        [Test]
        public void DigitalRootTest4()
        {
            Assert.AreEqual(2, DigitalRoot(493193));
        }
    }
}
