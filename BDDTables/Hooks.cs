using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Reflection;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace SpecflowParallelTest
{
    [Binding]
    public class Hooks
    {
        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static KlovReporter klov;

        private readonly IObjectContainer _objectContainer;

        protected IWebDriver _driver;
        AndroidDriver<IWebElement> driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"C:\Swapnil\Frameworks\VisualStudio_Selenium_C#\BDDTables\BDDTables\ExtentReport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new ExtentReports();
            // klov = new KlovReporter();
            //  klov.InitMongoDbConnection("localhost", 27017);
            // klov.ProjectName = "ExecuteAutomation Test";
            // URL of the KLOV server
            //  klov.KlovUrl = "http://localhost:5689";
            //  klov.ReportName = "Karthik KK" + DateTime.Now.ToString();

            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title); 
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            Console.WriteLine("Step Type: ", stepType);

            //PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }

           // Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }

        }


        [BeforeScenario]
        public void Initialize()
        {
            SelectBrowser(BrowserType.AndroidApp);
            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void CleanUp()
        {
            if (driver != null)
            {
                if (BrowserType.AndroidApp.ToString().Trim().Contains("Android"))
                {
                    driver.Quit();
                }
                else
                {
                    _driver.Quit();
                }
            }
        }


        internal void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions option = new ChromeOptions();
                    //option.AddArgument("--headless");
                    _driver = new ChromeDriver(option);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
                case BrowserType.AndroidApp:

                    DesiredCapabilities cap = new DesiredCapabilities();
                    cap.SetCapability("platformName", "Android");
                    cap.SetCapability("deviceName", "donatello");
                   // cap.SetCapability("appPackage", "com.sabithpkcmnr.admobintegration");
                    cap.SetCapability("appPackage", "meteor.test.and.grade.internet.connection.speed");
                   // cap.SetCapability("appActivity", "com.sabithpkcmnr.admobintegration.MainActivity");
                    cap.SetCapability("appActivity", "meteor.test.and.grade.internet.connection.speed.activities.WelcomeActivity");
                    cap.SetCapability("automationName", "Appium");
                    cap.SetCapability(MobileCapabilityType.App, "C:\\Users\\E003755\\Downloads\\Metero.apk");

                    driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
                    
                    break;

                case BrowserType.Firefox:
                    var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;
                    _driver = new FirefoxDriver(service);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
                case BrowserType.IE:
                    break;
                default:
                    break;
            }
        }

    }

    enum BrowserType
    {
        Chrome,
        Firefox,
        IE,
        AndroidApp
    }
}
