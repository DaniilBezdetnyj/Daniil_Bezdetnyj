using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;

namespace Selenium
{
    class Elements
    {
        private readonly IWebDriver webdriver;
        
        public Elements(IWebDriver driver)
        {
            webdriver = driver;
        }

        //Login elements
        public IWebElement GetLogin()
        {
            return webdriver.FindElement(By.LinkText("Log in"));
        }

        public IWebElement GetLoginUserName()
        {
            return webdriver.FindElement(By.Id("loginusername"));
        }

        public IWebElement GetLoginPassword()
        {
            return webdriver.FindElement(By.Id("loginpassword"));
        }

        public IWebElement GetLoginSubmit()
        {
            return webdriver.FindElement(By.CssSelector("#logInModal .btn-primary"));
        }

        //
        public IWebElement GetLaptopsLabel()
        {
            return webdriver.FindElement(By.LinkText("Laptops"));
        }

        public IWebElement GetCurrentLaptop()
        {
            return webdriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=12']"));
        }

        public IWebElement GetAddToCart()
        {
            return webdriver.FindElement(By.CssSelector(" .btn-success"));
        }

        public IWebElement GetCart()
        {
            return webdriver.FindElement(By.CssSelector("a[href *= 'cart.html']"));
        }

        public IWebElement GetPlaceOrder()
        {
            return webdriver.FindElement(By.CssSelector(" .btn-success"));
        }

        public IWebElement GetAcceptButton()
        {
            return webdriver.FindElement(By.XPath("//button[contains(@onclick,'purchaseOrder')]"));
        }

        public IWebElement GetPhonesLabel()
        {
            return webdriver.FindElement(By.LinkText("Phones"));
        }

        public IWebElement GetCurrentPhone()
        {
            return webdriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=3']"));
        }

    }
}
