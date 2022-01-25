using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace demo.Elements
{
    internal class LoginPage_POM
    {
        private IWebDriver driver;

        public LoginPage_POM(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input")]
        public IWebElement username_Field { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input")]
        public IWebElement password_Field { get; set; }

        [FindsBy(How = How.ClassName, Using = "form-control")]
        private IList<IWebElement> UserAndPass_Field {get;set;}

        [FindsBy(How = How.ClassName, Using = "version-number")]
        public IWebElement build_number { get; set; }


        [FindsBy(How = How.ClassName, Using = "btn-login")]
        public IWebElement login_btn { get; set; }


        [FindsBy(How = How.ClassName, Using = "terms-link")]
        public IWebElement terms_and_conditions_btn { get; set; }


        [FindsBy(How = How.CssSelector, Using = "body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input")]
        public IWebElement forgot_password_btn { get; set; }

        //get the version to create report folder
        public string getVersion()
        {
            return build_number.Text;
        }


        public void login(string username, string password,string Usernam_add ="", string Password_add = "")
        {
            UserAndPass_Field[0].SendKeys(username + Usernam_add);
            UserAndPass_Field[1].SendKeys(password + Password_add);
        }

        public string getUrl()
        {
            terms_and_conditions_btn.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string currentURL = driver.Url;
            return currentURL;
        }

    }
}
