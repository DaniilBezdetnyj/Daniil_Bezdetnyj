using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;
using SeleniumExtras.WaitHelpers;

namespace Selenium
{
    class PurchaseElements
    {
        private readonly IWebDriver webdriver;
        
        public PurchaseElements(IWebDriver driver)
        {
            webdriver = driver;
        }

        public IWebElement GetLaptopsLabel()
        {
            Thread.Sleep(1000);
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

        public void SubmitAlert()
        {
            Thread.Sleep(1000);
            webdriver.SwitchTo().Alert().Accept();
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
            Thread.Sleep(1000);
            return webdriver.FindElement(By.LinkText("Phones"));
        }

        public IWebElement GetCurrentPhone()
        {
            return webdriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=3']"));
        }

        public IWebElement GetThanksForm()
        {
            return webdriver.FindElement(By.ClassName("sweet-alert"));
        } 
    }
}
