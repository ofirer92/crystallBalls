using System;
using System.Threading;
using AventStack.ExtentReports;
using demo.BaseClass;
using demo.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace demo.TestClass
{
    [TestFixture]
    class Login_test : baseclass
    {
        LoginPage_POM logPage;
        frontPage_POM main;

        [SetUp]
        public void setup()
        {
            logPage = new LoginPage_POM(driver);
            main = new frontPage_POM(driver);
        }

        [Test]
        [TestCase("","ds2a",TestName ="wrong password", Category ="login failer", Description = "This test uses a simple input value")]
        [TestCase("abd", TestName = "wrong username", Category = "login failer", Description = "This test uses a simple input value")]
        [TestCase("abd" ,TestName = "caps", Category = "login failer", Description = "This test uses a simple input value")]
        public void TestMethod1(string username_add_optional, string Usernam_add_optional = "")
        {
            logPage.login(userName+username_add_optional,Password+ Usernam_add_optional);
            help.acceptTerms();
            logPage.login_btn.Click();
        }


        [Test]
        [TestCase(TestName = "terms", Category = "login failer", Description = "This test uses a simple input value")]
        public void t2()
        {
            string termsUrl = "https://afi.cloud/TermsAndConditions";
            Assert.AreEqual(termsUrl, logPage.getUrl(),"The url was wrong");
            help.waitToComplite();

        }

        [Test]
        [TestCase(TestName = "finish loading", Category = "login failer", Description = "This test uses a simple input value")]
        public void t3()
        {

            logPage.login(userName , Password );
            test.AddScreenCaptureFromPath("rr.png").Pass(MediaEntityBuilder.CreateScreenCaptureFromPath("rr.png").Build());
            help.acceptTerms();
            logPage.login_btn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(4));
            main.getGroupBy_btn_List()[1].Click();

            help.waitToComplite();
            help.waitToComplite();



        }
    }
}
