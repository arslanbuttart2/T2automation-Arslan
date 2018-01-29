using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2automation.Pages.Comm
{
    class Header : BasePage
    {
        protected readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='topNav']/div[2]/div[2]/a")]
        private IWebElement _home;

        [FindsBy(How = How.XPath, Using = ".//*[@id='topNav']/div[2]/div[3]/a")]
        private IWebElement _signOut;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Yes']")]
        private IWebElement _yesBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='topNav']/div[2]/div[1]/a/span")]
        private IWebElement _language;

        [FindsBy(How = How.XPath, Using = ".//*[@id='topNav']/div[2]/div[4]/a")]
        private IWebElement _profile;

        public Header(IWebDriver driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void Signout(IWebDriver driver) {
            Click(driver, _signOut);
            Click(driver, _yesBtn);
        }
    }
}
