using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.BaseClass;
using demo.Elements;
using NUnit.Framework;

namespace demo.TestClass
{
    [TestFixture]
    class mainPage : baseclass
    {
        LoginPage_POM logPage;
        frontPage_POM main;

        [SetUp]
        public void setup()
        {
            logPage = new LoginPage_POM(driver);
            main = new frontPage_POM(driver);

            logPage.login(userName , Password );
            help.acceptTerms();
            logPage.login_btn.Click();
            Thread.Sleep(4000);
            help.waitToComplite();
        }
        

        [Test]
        [TestCase(TestName = "group By None", Category = "group By testing", Description = "This test uses a simple input value")]
        //[TestCase(TestName = "group By Animal group", Category = "group By testing", Description = "This test uses a simple input value")]
        // to add [TestCase(TestName = "group By Lactation", Category = "group By testing", Description = "This test uses a simple input value")]
        public void t2()
        {
            main.getGroupBy_btn_List()[1].Click();
            help.waitToComplite();
            main.getGroupBy_btn_List()[2].Click();
            help.waitToComplite();
            main.getGroupBy_btn_List()[0].Click();
            help.waitToComplite();
            help.waitToComplite();


        }


    }
}
