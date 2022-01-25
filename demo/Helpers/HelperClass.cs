using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace demo.Helpers
{
    class HelperClass
    {
        private IWebDriver driver;


        public HelperClass(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void MainloadingWait()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementExists((By.ClassName("sh-download-icon"))));
            Thread.Sleep(500);
        }
        public void acceptTerms()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("document.querySelector('.acceptTerms').click()");
        }

        public void waitToComplite()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(50)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
