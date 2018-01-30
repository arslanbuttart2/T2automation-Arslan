using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using T2automation.Pages.Comm;
using System.Threading;

namespace T2automation.Pages.SystemManagement.SystemManagement
{
    class UserManagerPage : LeftMenu
    {
        protected readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "OrganizationSearch")]
        private IWebElement _departmentDropdown;

        [FindsBy(How = How.Id, Using = "JobTitleSearch")]
        private IWebElement _jobTitleDropdown;

        [FindsBy(How = How.Id, Using = "txtOrganizationPageUserSearch")]
        private IWebElement _search;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[5]/div/div[1]/div[4]/a")]
        private IWebElement _searchBtn;

        [FindsBy(How = How.Id, Using = "container_processing")]
        private IWebElement _processing;

        [FindsBy(How = How.Id, Using = "Addbuttoncontainer")]
        private IWebElement _addNewBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[1]")]
        private IList<IWebElement> _userNames;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[2]")]
        private IList<IWebElement> _names;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[3]")]
        private IList<IWebElement> _mainDepartments;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[4]")]
        private IList<IWebElement> _createDate;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[5]")]
        private IList<IWebElement> _Status;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[6]")]
        private IList<IWebElement> _loginStatus;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[7]/a[1]")]
        private IList<IWebElement> _edits;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[7]/a[2]")]
        private IList<IWebElement> _permissionBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[7]/a[3]")]
        private IList<IWebElement> _userDept;
     
        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[7]/a[4]")]
        private IList<IWebElement> _regulatoryReporting;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[7]/a[5]")]
        private IList<IWebElement> _loginEvents;

        public string title = "User Manager - Ole5.1";

        public UserManagerPage(IWebDriver driver) : base(driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void Search(IWebDriver driver, string text) {
            SendKeys(driver, _search, text);
            Click(driver, _searchBtn);
            WaitTillProcessing();
        }

        public PermissionsPage OpenPermissions(IWebDriver driver, string user) {
            Search(driver, user);
            Thread.Sleep(1000);
            for (int index = 0; index < _userNames.Count - 1; index++) {
                if (GetText(driver, _userNames.ElementAt(index)).Equals(user)) {
                    Click(driver, _permissionBtn.ElementAt(index));
                    return new PermissionsPage(driver);
                }
            }
            return new PermissionsPage(driver);
        }

        public void WaitTillProcessing() {
            while (ElementIsDisplayed(_driver, _processing)) {
                continue;
            }
        }
    }
}
