using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using T2automation.Pages.Comm;

namespace T2automation.Pages.SystemManagement.LookUps
{
    class DepartmentSettingsPage : LeftMenu
    {
        protected readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "searchTextOrganization")]
        private IWebElement _searchOrganization;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationListGrid']/tbody/tr/td[2]/a")]
        private IWebElement _organizationSettings;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[8]/a")]
        private IWebElement _userGroup;
        
        [FindsBy(How = How.Id, Using = "AddbuttondivUserGroup")]
        private IWebElement _addNewUserGroup;

        [FindsBy(How = How.Id, Using = "txtSrchGrp")]
        private IWebElement _searchUserGroup;

        [FindsBy(How = How.Id, Using = "txtName")]
        private IWebElement _nameUserGroup;

        [FindsBy(How = How.XPath, Using = "html/body/div/div/div/div/div/button[1]")]
        private IWebElement _saveUserGroup;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divUserGroup']/tbody/tr/td/a")]
        private IWebElement _membersIcon;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divUserGroup']/tbody/tr/td/a")]
        private IList<IWebElement> _membersIcon2;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divUserGroup']/tbody/tr/td[2]")]
        private IList<IWebElement> _groupsNamesList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divUserGroup']/tbody/tr/td[1]/input")]
        private IList<IWebElement> _groupsNamesListCB;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='buttondivUserGroup']")]
        private IWebElement _userGroupDeleteBtn;

        [FindsBy(How = How.Id, Using = "AddbuttondivUsersGrid")]
        private IWebElement _addNewMember;

        [FindsBy(How = How.XPath, Using = "html/body/div/div/div/div/div/button[2]")]
        private IWebElement _closeMemberDialogue;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationListGrid']/tbody/tr/td[2]/a")]
        private IList<IWebElement> _organizationSettingsList;

        private IWebElement _processing(IWebDriver driver)
        {
            return driver.FindElement(By.Id("userDepartmentTable_processing"));
        }

        private IList<IWebElement> _organizationNameList()
        {
            return _driver.FindElements(By.XPath(".//*[@id='organizationListGrid']/tbody/tr/td[1]/a"));
        }

        private IWebElement _okBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Ok']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Ok']"));
        }

        private IWebElement _yesBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Yes']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Yes']"));
        }

        public DepartmentSettingsPage(IWebDriver driver) : base(driver)
        {
            {
                _driver = driver;
                PageFactory.InitElements(_driver, this);
            }
        }

        public void SearchOrganizationAndClickSettings(IWebDriver driver, string text)
        {
            SendKeys(driver, _searchOrganization, text);
            Thread.Sleep(5000);
            //Click(driver, _organizationSettings);

            for (int index = 0; index <= _organizationNameList().Count; index++)
            {
                string temp = GetText(driver, _organizationNameList().ElementAt(index));
                string[] aftersplit;
                if (temp.Contains("\\"))
                {
                    aftersplit = temp.Split('\\');
                }
                else
                {
                    string temp2 = temp.Trim();
                    aftersplit = temp2.Split('\\');
                }

                if (aftersplit[aftersplit.Count() - 1].Trim().Equals(text))
                {
                    Click(driver, _organizationSettingsList.ElementAt(index));
                    return;
                }

            }

        }

        public void ClickUserGroupTab(IWebDriver driver)
        {
            Click(driver, _userGroup);
        }
        

        public void AddNewUserGroup(IWebDriver driver, string text)
        {
            Click(driver, _addNewUserGroup);
            Thread.Sleep(2000);
            SendKeys(driver, _nameUserGroup, text);
            Click(driver, _saveUserGroup);
        }

        public void SearchUserGroupAndOpenMembersDialogue(IWebDriver driver, string text)
        {
            int temp;
            SearchUserGroup(driver, text);
            //Click(driver, _membersIcon);
            Thread.Sleep(9000);
            for (int i = 0; i < _groupsNamesList.Count; i++)
            {
                temp = _groupsNamesList.Count();
                if (GetText(driver, _groupsNamesList.ElementAt(i)).Equals(text))
                {
                    Click(driver, _membersIcon2.ElementAt(i));
                    Thread.Sleep(2000);
                    return;
                }
            }
        }

        public void SearchUserGroup(IWebDriver driver, string text)
        {
            Click(driver, _searchUserGroup);
            SendKeys(driver, _searchUserGroup, text);
            Thread.Sleep(5000);
        }

        public void SearchAndDeleteUserGroup(IWebDriver driver, string text)
        {
            for (int i = 0; i< _groupsNamesList.Count; i++ )
            {
                if (GetText(driver, _groupsNamesList.ElementAt(i)).Equals(text))
                {
                    Click(driver, _groupsNamesListCB.ElementAt(i));
                    Click(driver, _userGroupDeleteBtn);
                    Thread.Sleep(2000);
                    //Click(driver, _okBtn());
                    Click(driver, _yesBtn());
                }
            }
        }


        public void ClickAddNewMember(IWebDriver driver)
        {
            Click(driver, _addNewMember);
        }

        public void WaitTillProcessing()
        {
            int tries = 0;
            try
            {
                while (ElementIsDisplayed(_driver, _processing(_driver)) && tries < 1000)
                {
                    tries++;
                    continue;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
