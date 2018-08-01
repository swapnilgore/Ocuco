using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;

namespace BDDTables.Pages
{
   
    public class Login
    {
        private readonly IWebDriver _driver;


        public Login(IWebDriver driver) => _driver = driver;

       
        Locators.loginLoc l = new Locators.loginLoc();

        IWebElement txtUserName => _driver.FindElement(l.txtUserName);
        IWebElement txtPassword => _driver.FindElement(l.txtPassword);
        IWebElement btnLogin => _driver.FindElement(l.btnLogin);
        IWebElement VerifyTitle => _driver.FindElement(l.VerifyTitle);


        public void NavigateToUrl(String url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void EnterUserNameAndPassword(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            btnLogin.Click();
        }

        public void LoginSuccessful()
        {
            Console.WriteLine("Title is " + VerifyTitle.Text);
        }

    }
}
