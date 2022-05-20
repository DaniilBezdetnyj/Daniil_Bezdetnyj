using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Selenium
{
    public class Tests
    {
        IWebDriver webdriver;
        ChromeOptions options;
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
        //

        public Tests()
        {
            options = new ChromeOptions();
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            webdriver = new ChromeDriver(options);
        }

        [SetUp]
        public void Setup()
        {
            //User tokens
            const string username = "DaniilBezdetnyj";
            const string password = "12345678";

            //Go to the site
            webdriver.Navigate().GoToUrl("https://www.demoblaze.com");

            //Log in button
            webdriver.FindElement(By.LinkText("Log in")).Click();
            Thread.Sleep(200);

            //Entering login data
            webdriver.FindElement(By.Id("loginusername")).SendKeys(username);
            Thread.Sleep(200);
            webdriver.FindElement(By.Id("loginpassword")).SendKeys(password);

            //Acception login
            Thread.Sleep(400);
            webdriver.FindElement(By.CssSelector("#logInModal .btn-primary")).Click();
            Thread.Sleep(300);
        }

        [Test]
        public void LaptopTest()
        {
            //Searching and clicking on "Laptops"
            Thread.Sleep(1000);
            webdriver.FindElement(By.LinkText("Laptops")).Click();
            Thread.Sleep(1000);

            //Choosing Laptop Dell
            webdriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=12']")).Click();
            Thread.Sleep(1000);

            //Clicking on Add to Cart button
            webdriver.FindElement(By.CssSelector(" .btn-success")).Click();
            Thread.Sleep(3000);

            //Accepting alert
            webdriver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);

            //Going to Cart
            webdriver.FindElement(By.CssSelector("a[href *= 'cart.html']")).Click();
            Thread.Sleep(500);

            //Click on Place Order
            webdriver.FindElement(By.CssSelector(" .btn-success")).Click();
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
            webdriver.FindElement(By.XPath("//button[contains(@onclick,'purchaseOrder')]")).Click();
            Thread.Sleep(1000);

            Assert.AreEqual(true, (webdriver.FindElements(By.Id("orderModal")).Count == 1));
            webdriver.Quit();

        }

        [Test]
        public void PhonesTest()
        {
            //Searching and clicking on "Phones"
            Thread.Sleep(1000);
            webdriver.FindElement(By.LinkText("Phones")).Click();
            Thread.Sleep(1000);

            //Choosing Nexus 6
            webdriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=3']")).Click();
            Thread.Sleep(1000);

            //Clicking on Add to Cart button
            webdriver.FindElement(By.CssSelector(" .btn-success")).Click();
            Thread.Sleep(3000);

            //Accepting alert
            webdriver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);

            //Going to Cart
            webdriver.FindElement(By.CssSelector("a[href *= 'cart.html']")).Click();
            Thread.Sleep(500);

            //Click on Place Order
            webdriver.FindElement(By.CssSelector(" .btn-success")).Click();
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
            webdriver.FindElement(By.XPath("//button[contains(@onclick,'purchaseOrder')]")).Click();
            Thread.Sleep(1000);

            Assert.AreEqual(true, (webdriver.FindElements(By.Id("orderModal")).Count == 1));
            webdriver.Quit();
        }
    }
}