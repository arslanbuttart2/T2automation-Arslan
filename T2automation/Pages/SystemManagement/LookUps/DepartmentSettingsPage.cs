﻿using System;
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

        [FindsBy(How = How.Id, Using = "AddbuttondivUsersGrid")]
        private IWebElement _addNewMember;

        [FindsBy(How = How.XPath, Using = "html/body/div/div/div/div/div/button[2]")]
        private IWebElement _closeMemberDialogue;

        private IWebElement _processing(IWebDriver driver)
        {
            return driver.FindElement(By.Id("userDepartmentTable_processing"));
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
            Click(driver, _organizationSettings);
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
            SearchUserGroup(driver, text);
            Click(driver, _membersIcon);
        }

        private void SearchUserGroup(IWebDriver driver, string text)
        {
            Click(driver, _searchUserGroup);
            SendKeys(driver, _searchUserGroup, text);
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