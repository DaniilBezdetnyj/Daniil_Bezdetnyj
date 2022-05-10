using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Task_2
    {
        public char FirstNonRepeatingLetter(string str)
        {
            string helper = str;
            helper = helper.ToLower();
            for (int i = 0; i < helper.Length - 1; i++)
            {
                if (helper.IndexOf(helper[i]) == helper.LastIndexOf(helper[i]) && char.IsLetter(str[i]))
                {
                    return str[i];
                }
            }
            return ' ';
        }
        [Test]
        public void FirstNonRepeatingLetterTest1()
        {
            Assert.AreEqual('t', FirstNonRepeatingLetter("stress"));
        }
        [Test]
        public void FirstNonRepeatingLetterTest2()
        {
            Assert.AreEqual(' ', FirstNonRepeatingLetter("poTopt"));
        }
        [Test]
        public void FirstNonRepeatingLetterTest3()
        {
            Assert.AreEqual('c', FirstNonRepeatingLetter("8 cases"));
        }
    }
}

