using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Selenium
{
    public class Tests
    {
        IWebDriver webdriver;
        ChromeOptions options;
        PurchaseElements purchase_element;
        UserDataElements user_data_element;

        //Data for fill user information
        readonly string[] user_data = 
        {
              "Daniil",
              "Ukraine",
              "Kyiv",
              "5555 4444 3232 7897",
              "May",
              "2022",
              "helper"
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
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webdriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            webdriver.Navigate().GoToUrl("https://www.demoblaze.com");
            
            purchase_element = new PurchaseElements(webdriver);
            user_data_element = new UserDataElements(webdriver);

            //Log in
            UserLogin login_object = new UserLogin(webdriver);
            login_object.Login(username, password);
        }

        [Test]
        public void LaptopTest()
        {
            //Searching and clicking on "Laptops"
            purchase_element.GetLaptopsLabel().Click();

            //Choosing Laptop Dell
            purchase_element.GetCurrentLaptop().Click();

            //Clicking on Add to Cart button
            purchase_element.GetAddToCart().Click();

            //Accepting alert
            purchase_element.SubmitAlert();

            //Going to Cart
            purchase_element.GetCart().Click();

            //Click on Place Order
            purchase_element.GetPlaceOrder().Click();

            //Fill user data
            int i = -1;
            user_data_element.GetNameField().SendKeys(user_data[++i]);
            user_data_element.GetCountryField().SendKeys(user_data[++i]);
            user_data_element.GetCityField().SendKeys(user_data[++i]);
            user_data_element.GetCardField().SendKeys(user_data[++i]);
            user_data_element.GetMonthField().SendKeys(user_data[++i]);
            user_data_element.GetYearField().SendKeys(user_data[++i]);

            //Clicking on Accept button
            purchase_element.GetAcceptButton().Click();

            string checker = purchase_element.GetThanksForm().Text;
            Assert.AreEqual(true, checker.Contains("Thank you for your purchase!"));
        }
       
        [Test]
        public void PhonesTest()
        {
            //Searching and clicking on "Phones"
            purchase_element.GetPhonesLabel().Click();

            //Choosing Nexus 6
            purchase_element.GetCurrentPhone().Click();

            //Clicking on Add to Cart button
            purchase_element.GetAddToCart().Click();

            //Accepting alert
            purchase_element.SubmitAlert();

            //Going to Cart
            purchase_element.GetCart().Click();

            //Click on Place Order
            purchase_element.GetPlaceOrder().Click();

            //Fill user data
            int i = -1;
            user_data_element.GetNameField().SendKeys(user_data[++i]);
            user_data_element.GetCountryField().SendKeys(user_data[++i]);
            user_data_element.GetCityField().SendKeys(user_data[++i]);
            user_data_element.GetCardField().SendKeys(user_data[++i]);
            user_data_element.GetMonthField().SendKeys(user_data[++i]);
            user_data_element.GetYearField().SendKeys(user_data[++i]);

            //Clicking on Accept button
            purchase_element.GetAcceptButton().Click();

            string checker = purchase_element.GetThanksForm().Text;
            Assert.AreEqual(true, checker.Contains("Thank you for your purchase!"));
        }

        [TearDown]
        public void Close_Browser()
        {
            webdriver.Quit();
        }
    }
    
}