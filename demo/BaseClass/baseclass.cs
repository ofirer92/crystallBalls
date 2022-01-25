using System;
using System.Drawing;
using System.Windows.Forms;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using demo.Elements;
using demo.Helpers;
using demo.reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace demo.BaseClass
{
     class baseclass
    {
        public static IWebDriver driver;
        public ExtentTest test;
        private string buildNumber;
        //parameters
        public string userName = "setup_5.5";
        public string Password = "1234";

        //Links QA\Alpha\GA
        #region
        private static string QA = "https://afimilkcrystalballqa.z6.web.core.windows.net/";
        #endregion

        //      Selected environment
        string selected_Environment = QA;


        public string reportPath = @"C:\Webapps Report\Crystal Ball\";
        public Reporter reporter = new Reporter();


        public HelperClass help;

        [OneTimeSetUp]
        public void OneTimesetup()
        {

            

            if (Reporter.extent == null)
            {
                driver = new ChromeDriver();
                //Helpers.Help c = new Helpers.Help(driver);

                Rectangle resolution = Screen.PrimaryScreen.Bounds;
                Reporter.extent = new ExtentReports();
                Reporter.extent.AddSystemInfo("Browser", driver.ToString().Split('.')[2]);
                Reporter.extent.AddSystemInfo("Browser Version ", "96");
                Reporter.extent.AddSystemInfo("Resolution", resolution.ToString());
                Reporter.extent.AddSystemInfo("build number", resolution.ToString());
                //to check 
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10); 

                reporter.setPath(reportPath);

                driver.Navigate().GoToUrl(selected_Environment);
                LoginPage_POM login = new LoginPage_POM(driver);
                buildNumber = login.getVersion();
                reportPath = reportPath + $"{ buildNumber.ToString() +@"\"}";
                driver.Close();
            }
        }

        //לפני כל טסט
        [SetUp]
        public void openAndRun()
        {
            driver = new ChromeDriver();
            help = new HelperClass(driver);
            driver.Navigate().GoToUrl(selected_Environment);
            driver.Manage().Window.Maximize();
            test = reporter.startReporting();
        }



        //אחרי כל טסט
        [TearDown]
        public void close()
        {
            reporter.testReporting(driver);
            driver.Quit();
        }


        //אחרי כל הטסטים
        [OneTimeTearDown]
        public void thisIsTheEnd()
        {
            Reporter.extent.Flush();
        }
    }
}
