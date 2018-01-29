using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading.Tasks;
using T2automation.Pages.Comm;

namespace T2automation.Pages
{
    class LoginPage : Header
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "username-txt")]
        private IWebElement _userName;

        [FindsBy(How = How.Id, Using = "password-txt")]
        private IWebElement _password;

        [FindsBy(How = How.LinkText, Using = "English")]
        private IWebElement _english;

        [FindsBy(How = How.Id, Using = "submitBtn")]
        private IWebElement _loginBtn;

        public string title = "Login";

        public LoginPage(IWebDriver driver) : base(driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string UserName
        {
            set
            {
                SendKeys(_driver, _userName, value);
            }
        }

        public string Password
        {
            set
            {
                SendKeys(_driver, _password, value);
            }
        }

        public void ClickLoginButton(IWebDriver driver) {
            Click(driver, _loginBtn);
        }

        public void SelectEnglish(IWebDriver driver) {
            Click(driver, _english);
        }
    }
}
