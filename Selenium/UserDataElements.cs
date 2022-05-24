using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;

namespace Selenium
{
    class UserDataElements
    {
        private readonly IWebDriver webdriver;

        public UserDataElements(IWebDriver driver)
        {
            webdriver = driver;
        }

        public IWebElement GetNameField()
        {
            return webdriver.FindElement(By.Id("name"));
        }

        public IWebElement GetCountryField()
        {
            return webdriver.FindElement(By.Id("country"));
        }

        public IWebElement GetCityField()
        {
            return webdriver.FindElement(By.Id("city"));
        }

        public IWebElement GetCardField()
        {
            return webdriver.FindElement(By.Id("card"));
        }

        public IWebElement GetMonthField()
        {
            return webdriver.FindElement(By.Id("month"));
        }

        public IWebElement GetYearField()
        {
            return webdriver.FindElement(By.Id("year"));
        }
    }
}
