using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;

namespace Selenium
{
    class UserLoginElements
    {
        private readonly IWebDriver webdriver;

        public UserLoginElements(IWebDriver driver)
        {
            webdriver = driver;
        }

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
    }
}
