using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Task_1
    {
        public List<object> GetIntegersFromList(List<object> mixedList)
        {
            for (int i = 0; i < mixedList.Count; i++)
            {
                if (mixedList[i] is string)
                {
                    mixedList.RemoveAt(i);
                    i--;
                }
                else if (!(mixedList[i] is int) || (int)mixedList[i] < 0)
                {
                    return new List<object> { ("Incorrect input") };
                }
            }
            return mixedList;
        }

        [Test]
        public void GetIntegersFromListTest1()
        {
            List<object> expected = new List<object>() { 1, 2, 0, 15 };
            List<object> actual = GetIntegersFromList(new List<object>() { 1, 2, "absc", "str", 0, 15 });
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetIntegersFromListTest2()
        {
            List<object> expected = new List<object>() { 1, 2, 231 };
            List<object> actual = GetIntegersFromList(new List<object>() { 1, 2, "a", "c", "aasf", "1", "123", 231 });
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetIntegersFromListTest3()
        {
            List<object> expected = new List<object>() { "Incorrect input" };
            List<object> actual = GetIntegersFromList(new List<object>() { 1, '0', "chair" });
            Assert.AreEqual(expected, actual);
        }
    }

}
