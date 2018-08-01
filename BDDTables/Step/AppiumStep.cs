using BDDTables.Locators;
using BDDTables.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDDTables.Step
{
    [Binding]

    class AppiumStep
    {

        AndroidDriver<IWebElement> _driver;
        AndroidApp App;


        public AppiumStep(AndroidDriver<IWebElement> driver)
        {
            _driver = driver;
            App = new AndroidApp(_driver);
        }


        [When(@"I launch Appium App")]
        public void WhenILaunchAppiumApp()
        {
            App.getStarted();
            Console.WriteLine("Launached Android App");
        }


    }
}
