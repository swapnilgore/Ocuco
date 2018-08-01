using BDDTables.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDTables.Pages
{
    class AndroidApp
    {
        AndroidDriver<IWebElement> _driver;

        public AndroidApp(AndroidDriver <IWebElement> driver) => _driver = driver;

        SpeedTestAndroid s = new SpeedTestAndroid();

        IWebElement txtLetsGo =>  _driver.FindElement(s.txtLetsGo);
        IWebElement txtIAgree => _driver.FindElement(s.txtIAgree);
        IWebElement btnGotit => _driver.FindElement(s.btnGotit);
        IWebElement btnStarttesting => _driver.FindElement(s.btnStarttesting);

        public void getStarted()
        {
            txtLetsGo.Click();
            System.Threading.Thread.Sleep(1000);
            txtIAgree.Click();
            System.Threading.Thread.Sleep(4000);
            btnGotit.Click();
            System.Threading.Thread.Sleep(4000);
            btnStarttesting.Click();
            System.Threading.Thread.Sleep(6000);
        }
    }
}
