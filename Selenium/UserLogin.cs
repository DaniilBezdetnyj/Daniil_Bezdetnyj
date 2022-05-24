using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Selenium
{
    public class UserLogin
    {
        UserLoginElements element;
        private readonly IWebDriver webDriver;

        public UserLogin(IWebDriver driver)
        {
            webDriver = driver;
            element = new UserLoginElements(driver);
        }
        public void GoToLogin()
        {
            element.GetLogin().Click();
        }

        public UserLogin EnterUsername(string username)
        {
            element.GetLoginUserName().SendKeys(username);
            return this;
        }

        public UserLogin EnterPassword(string password)
        {
            element.GetLoginPassword().SendKeys(password);
            return this;
        }

        public UserLogin SumbitLogin()
        {
            element.GetLoginSubmit().Click();
            return new UserLogin(webDriver);
        }

        public UserLogin Login(string username, string password)
        {
            GoToLogin();
            EnterUsername(username);
            EnterPassword(password);
            return SumbitLogin();
        }
    }
}
