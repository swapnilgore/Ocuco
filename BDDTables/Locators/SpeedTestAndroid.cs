using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDTables.Locators
{
        public interface SpeedTest
        {
         
        By txtLetsGo { get; }
        By txtIAgree { get; }
        By btnGotit { get; }
        By btnStarttesting { get; }
         }
        
        public class SpeedTestAndroid
        {
   
        //public By txtLetsGo = By.XPath("//*[@resource-id='meteor.test.and.grade.internet.connection.speed:id/btLetsGo']");
        public By txtLetsGo = By.Id("meteor.test.and.grade.internet.connection.speed:id/btLetsGo");
        //public By txtIAgree = By.XPath("//*[@resource-id='meteor.test.and.grade.internet.connection.speed:id/buttonAgree']");
        public By txtIAgree = By.Id("meteor.test.and.grade.internet.connection.speed:id/buttonAgree");
        public By btnGotit = By.XPath("//*[@resource-id='meteor.test.and.grade.internet.connection.speed:id/btPrimary']");
        public By btnStarttesting = By.XPath("//*[@resource-id='meteor.test.and.grade.internet.connection.speed:id/btStartTest']");

    }
}

