using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDTables.Locators
{
    public interface login
    {
        By txtUserName { get; }
        By txtPassword { get; }
        By btnLogin { get; }
        By VerifyTitle { get; }
    }

    public class loginLoc
    {
   
        public By txtUserName = By.XPath("//input[@name='UserName']");
        public By txtPassword = By.XPath("//input[@name='Password']");
        public By btnLogin = By.XPath("//input[@value='Login']");
        public By VerifyTitle = By.XPath("//h1[contains(text(),'Execute Automation Selenium Test Site')]");

    }
    
}
