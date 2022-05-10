using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Extra_Task_2
    {
        public string IPAddress(uint input)
        {
            string[] ip = new string[4];
            const int denominator = 256;
            for (int i = 3; i >= 0; i--)
            {
                ip[i] = (input % denominator).ToString();
                input /= denominator;
            }
            return string.Join('.', ip);
        }
        [Test]
        public void TestIP1()
        {
            Assert.AreEqual("128.32.10.1", IPAddress(2149583361));
        }
        [Test]
        public void TestIP2()
        {
            Assert.AreEqual("0.0.0.32", IPAddress(32));
        }
        [Test]
        public void TestIP3()
        {
            Assert.AreEqual("0.0.0.0", IPAddress(0));
        }
        [Test]
        public void TestIP4()
        {
            Assert.AreEqual("255.255.255.255", IPAddress(4294967295));
        }
    }
}
