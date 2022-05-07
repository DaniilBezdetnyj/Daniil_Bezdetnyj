using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Task_4
    {
        public int GetPairsAmount(int[] input, int target)
        {
            int num = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] + input[j] == target)
                    {
                        num++;
                    }
                }
            }
            return num;
        }
        [Test]
        public void GetPairsAmountTest1()
        {
            Assert.AreEqual(6, GetPairsAmount(new int[]{ 0, 3, 5, 2, 2, 0, 4, 5 }, 5));
        }
        [Test]
        public void GetPairsAmountTest2()
        {
            Assert.AreEqual(0, GetPairsAmount(new int[] { 1, 3, 2, 7 }, -2));
        }
        [Test]
        public void GetPairsAmountTest4()
        {
            Assert.AreEqual(2, GetPairsAmount(new int[] { 5, -6, 4, -5, 12, -1 }, -1));
        }
    }
}
