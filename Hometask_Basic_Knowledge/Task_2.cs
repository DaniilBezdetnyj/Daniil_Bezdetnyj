using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace Hometask_Basic_Knowledge
{
    [TestFixture]
    public class Task_2
    {
        public char first_non_repeating_letter(string str)
        {
            string helper = str;
            helper = helper.ToLower();
            for (int i = 0; i < helper.Length - 1; i++)
            {
                if (!((helper.Substring(0, i) + helper.Substring(i + 1)).Contains(helper[i])) && char.IsLetter(str[i]))
                {
                    return str[i];
                }
            }
            return ' ';
        }
        [Test]
        public void first_non_repeating_letter_Test1()
        {
            Assert.AreEqual('t', first_non_repeating_letter("stress"));
        }
        [Test]
        public void first_non_repeating_letter_Test2()
        {
            Assert.AreEqual(' ', first_non_repeating_letter("poTopt"));
        }
        [Test]
        public void first_non_repeating_letter_Test3()
        {
            Assert.AreEqual('c', first_non_repeating_letter("88 cases "));
        }
    }
}

