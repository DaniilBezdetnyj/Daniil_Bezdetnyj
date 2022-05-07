using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Extra_Task_2
    {
        public string IPAddress(long k)
        {
            string[] str1 = { ((k - (((k - k%256 - (((k- k % 256) / (256)))%256)/(256*256))%256) - (((k- k % 256) / (256))%256) - k%256)/(256*256*256)).ToString(),
                    (((k - k%256 - (((k- k % 256) / (256)))%256)/(256*256))%256).ToString(),
                    (((k- k % 256) / (256))%256).ToString(),
                    (k%256).ToString()};

            return string.Join('.', str1);
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
    }
}
