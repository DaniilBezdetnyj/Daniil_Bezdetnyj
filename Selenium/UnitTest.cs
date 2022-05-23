using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;

namespace Selenium
{
    public class Tests
    {
        IWebDriver webdriver;
        ChromeOptions options;
        Elements element;

        ////Data for fill user information
        readonly string[] user_data = 
        {
              "Daniil",
              "Ukraine",
              "Kyiv",
              "5555 4444 3232 7897",
              "May",
              "2022"
        };

        [SetUp]
        public void Setup()
        {
            //User tokens
            const string username = "DaniilBezdetnyj";
            const string password = "12345678";

            //Connecting 
            options = new ChromeOptions();
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            webdriver = new ChromeDriver(options);
            webdriver.Navigate().GoToUrl("https://www.demoblaze.com");
            element = new Elements(webdriver);

            //Log in
            UserLogin login_object = new UserLogin(webdriver);
            login_object.Login(username, password);
        }

        [Test]
        public void LaptopTest()
        {
            //Searching and clicking on "Laptops"
            Thread.Sleep(1000);
            element.GetLaptopsLabel().Click();
            Thread.Sleep(1000);

            //Choosing Laptop Dell
            element.GetCurrentLaptop().Click();
            Thread.Sleep(1000);

            //Clicking on Add to Cart button
            element.GetAddToCart().Click();
            Thread.Sleep(3000);

            //Accepting alert
            webdriver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);

            //Going to Cart
            element.GetCart().Click();
            Thread.Sleep(500);

            //Click on Place Order
            element.GetPlaceOrder().Click();
            Thread.Sleep(500);

            //Fill user data
            int i = -1;
            webdriver.FindElement(By.Id("name")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("country")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("city")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("card")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("month")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("year")).SendKeys(user_data[++i]);
            Thread.Sleep(100);

            //Clicking on Accept button
            element.GetAcceptButton().Click();
            Thread.Sleep(1000);

            Assert.AreEqual(true, (webdriver.FindElements(By.Id("orderModal")).Count == 1));
        }

        [Test]
        public void PhonesTest()
        {
            //Searching and clicking on "Phones"
            Thread.Sleep(1000);
            element.GetPhonesLabel().Click();
            Thread.Sleep(1000);

            //Choosing Nexus 6
            element.GetCurrentPhone().Click();
            Thread.Sleep(1000);

            //Clicking on Add to Cart button
            element.GetAddToCart().Click();
            Thread.Sleep(3000);

            //Accepting alert
            webdriver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);

            //Going to Cart
            element.GetCart().Click();
            Thread.Sleep(500);

            //Click on Place Order
            element.GetPlaceOrder().Click();
            Thread.Sleep(500);

            //Fill user data
            int i = -1;
            webdriver.FindElement(By.Id("name")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("country")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("city")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("card")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("month")).SendKeys(user_data[++i]);
            Thread.Sleep(100);
            webdriver.FindElement(By.Id("year")).SendKeys(user_data[++i]);
            Thread.Sleep(100);

            //Clicking on Accept button
            element.GetAcceptButton().Click();
            Thread.Sleep(1000);

            Assert.AreEqual(true, (webdriver.FindElements(By.Id("orderModal")).Count == 1));
        }

        [TearDown]
        public void Close_Browser()
        {
            webdriver.Quit();
        }
    }
    
}