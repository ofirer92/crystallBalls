using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace demo.Elements
{
    class frontPage_POM
    {
        private IWebDriver driver;

        public frontPage_POM(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Tool bar
        #region
        [FindsBy(How = How.CssSelector, Using = "body > app-root > div > app-home > app-navbar > header > div.container-fluid.afi-nav > div > div > div.d-flex.align-items-center > div:nth-child(3)")]
        public IWebElement date_String { get; set; }

        [FindsBy(How = How.Id, Using = "farmName")]
        public IWebElement farm_Name { get; set; }

        [FindsBy(How = How.Id, Using = "settingsBtn")]
        public IWebElement setting_btn { get; set; }

        [FindsBy(How = How.Id, Using = "logoutBtn")]
        public IWebElement logout_btn { get; set; }

        #endregion

        //Filter Blocks
        [FindsBy(How = How.ClassName, Using = "btn-group-toggle")]
        public IWebElement groupBy { get; set; }
                 
        [FindsBy(How = How.ClassName, Using = "card-override")]
        public IWebElement groupby_cards { get; set; }
            






        public IList<IWebElement> getGroupBy_btn_List()
        {
            return groupBy.FindElements(By.XPath("./*"));

        }


    }
}
