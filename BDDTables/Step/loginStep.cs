using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using BDDTables.Pages;

namespace BDDTables.Step
{
    [Binding]

    public class loginStep
    {
        private IWebDriver _driver;
        Login l;

      //  public loginStep(IWebDriver driver) => _driver = driver;

            public loginStep(IWebDriver driver)
        {
            _driver = driver;
            l = new Login(_driver);

        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            //Login login = new Login(_driver);
            l.NavigateToUrl("http://executeautomation.com/demosite/Login.html");
        }

        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
           // Login login = new Login(_driver);
            l.EnterUserNameAndPassword("admin", "Admin");
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            //Login login = new Login(_driver);
            l.ClickLogin();
        }

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            //var element = _driver.FindElement(By.XPath("//h1[contains(text(),'Execute Automation Selenium')])]"));
            //Assert.That(element.Text,, "Header text not found !!!");  
            // Login login = new Login(_driver);

            l.LoginSuccessful();
        }

    }
}
