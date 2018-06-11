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
    class AnnouncementsGroupPage : LeftMenu
    {
        protected readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='AddbuttondivUserGroup']")]
        private IWebElement _addNewBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtName']")]
        private IWebElement _arabicName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtGroupNameEn']")]
        private IWebElement _englishName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='cbGActive']")]
        private IWebElement _activeChk;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtSrchGrp']")]
        private IWebElement _searchGroupName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divUserGroup']/tbody/tr/td[7]/a[contains(@title,'Members')]")]
        private IList<IWebElement> _membersIcon;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divUserGroup']/tbody/tr/td[3]")]
        private IList<IWebElement> _groupsNamesList;

        private SelectElement _groupLevel(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.XPath(".//*[@id='slctGroupLevel']")));
        }

        public AnnouncementsGroupPage(IWebDriver driver) : base(driver)
        {
            {
                _driver = driver;
                PageFactory.InitElements(_driver, this);
            }
        }

        private IWebElement _saveBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Save']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Save']"));
        }


        public void SelectGroupLevel(IWebDriver driver, string level)
        {
            Thread.Sleep(2000);
            DropdownSelectByText(driver, _groupLevel(driver), level);
            Thread.Sleep(1000);
        }

        public void addNewGroup(IWebDriver driver, string a_name, string e_name, string text)
        {
            Click(driver, _addNewBtn);
            Thread.Sleep(2000);
            SendKeys(driver, _arabicName, a_name);
            Thread.Sleep(2000);
            SendKeys(driver, _englishName, e_name);
            Thread.Sleep(2000);
            SelectGroupLevel(driver, text);
            Click(_driver, _activeChk);
            Thread.Sleep(1000);
            Click(_driver, _saveBtn());
        }

        public void SearchAndClickIcon(IWebDriver driver, string text)
        {
            int temp;
            SendKeys(driver, _searchGroupName, text);
            Thread.Sleep(9000);
            for (int i = 0; i < _groupsNamesList.Count; i++)
            {
                temp = _groupsNamesList.Count();
                if (GetText(driver, _groupsNamesList.ElementAt(i)).Equals(text))
                {
                    Click(driver, _membersIcon.ElementAt(i));
                    Thread.Sleep(2000);
                    return;
                }
            }

        }
    }
}
