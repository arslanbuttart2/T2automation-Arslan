using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutoItX3Lib;
using System.Configuration;
using T2automation.Init;
using T2automation.Pages;
using T2automation.Pages.SystemManagement.SystemManagement;
using T2automation.Util;

namespace T2automation
{

    [Binding]
    public class PermissionsStepDef
    {
        DriverFactory driverFactory = new DriverFactory("BaseURL");
        private IWebDriver driver;
        private LoginPage loginPage;
        private UserManagerPage userManagerPage;
        private ReadFromConfig readFromConfig;
        private PermissionsPage permissionsPage;
        private Pages.MyMessages.InboxPage myMessageInboxPage;
        private Pages.DeptMessages.InboxPage deptMessageInboxPage;


        [Given("^Admin logged in \"(.*)\" \"(.*)\"$"), When("^Admin logged in \"(.*)\" \"(.*)\"$"), Then("^Admin logged in \"(.*)\" \"(.*)\"$")]
        public void AdminLoggedIn(string username, string password) {
            driver = driverFactory.GetDriver();
            loginPage = new LoginPage(driver);
            readFromConfig = new ReadFromConfig();
            Thread.Sleep(3000);
            loginPage.CheckLogin(driver);
            loginPage.SelectEnglish(driver);
            loginPage.UserName = readFromConfig.GetUserName(username);
            loginPage.Password = readFromConfig.GetPassword(password);
            loginPage.ClickLoginButton(driver);
            Thread.Sleep(3000);
        }

        [When(@"Admin set system message sending permissions for user ""(.*)"" ""(.*)""")]
        public void WhenAdminSetSystemMessageSendingPermissionsForUser(string user, string checkbox)
        {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateToUserManager(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver, userManagerPage.title));
            permissionsPage = userManagerPage.OpenPermissions(driver, new ReadFromConfig().GetValue(user));
            permissionsPage.OpenSystemMessagePermissionsTabAndChk(driver, checkbox);
        }

        [Then(@"Admin unset system message sending permissions for user ""(.*)"" ""(.*)""")]
        public void ThenAdminUnsetSystemMessageSendingPermissionsForUser(string user, string chkbox)
        {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateToUserManager(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver, userManagerPage.title));

            permissionsPage = userManagerPage.OpenPermissions(driver, new ReadFromConfig().GetValue(user));

            permissionsPage.OpenSystemMessagePermissionsTabAndUnchk(driver, chkbox);
        }

        [Given("^Admin set system message permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$"), When("^Admin set system message permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$"), Then("^Admin set system message permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$")]
        public void AdminSetSystemMessagePermissionsForUser(string permissionName, bool value, string user) {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateToUserManager(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver, userManagerPage.title));

            permissionsPage = userManagerPage.OpenPermissions(driver, new ReadFromConfig().GetValue(user));
            permissionsPage.IncludeSystemMessagePermissions(driver, permissionName, value);
        }

        [Given("^User logs in \"(.*)\" \"(.*)\"$"), When("^User logs in \"(.*)\" \"(.*)\"$"), Then("^User logs in \"(.*)\" \"(.*)\"$")]
        public void UserLogsIn(string username, string password) {
            loginPage.CheckLogin(driver);
            loginPage.SelectEnglish(driver);
            loginPage.UserName = readFromConfig.GetUserName(username);
            loginPage.Password = readFromConfig.GetPassword(password);
            loginPage.ClickLoginButton(driver);
            Thread.Sleep(5000);
        }

        [Then(@"""(.*)"" visibility should be on My Messages inbox ""(.*)""")]
        public void ThenVisibilityShouldBeOnMyMessagesInbox(string buttonName, bool value)
        {
            myMessageInboxPage = new Pages.MyMessages.InboxPage(driver);
            myMessageInboxPage.NavigateToMyMessageInbox(driver);
            Assert.IsTrue(myMessageInboxPage.IsAt(driver, myMessageInboxPage.title));
            Assert.IsTrue(myMessageInboxPage.CheckButtonAvailbility(driver, buttonName, value));
            if (value)
            {
                Assert.IsTrue(myMessageInboxPage.CheckButtonClickable(driver, buttonName));
            }
        }

        [When(@"Admin set department message permissions for user ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenAdminSetDepartmentMessagePermissionsForUser(string permissionName, bool value, string user, string dept)
        {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateToUserManager(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver, userManagerPage.title));
            permissionsPage = userManagerPage.OpenPermissions(driver, new ReadFromConfig().GetValue(user));
            permissionsPage.IncludeDeptMessagePermissions(driver, readFromConfig.GetDeptName(dept), permissionName, value);
        }

        [When(@"Admin set department sending message permissions for user ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenAdminSetDepartmentSendingMessagePermissionsForUser(string permissionName, bool value, string user, string dept)
        {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateToUserManager(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver, userManagerPage.title));
            permissionsPage = userManagerPage.OpenPermissions(driver, new ReadFromConfig().GetValue(user));
            permissionsPage.IncludeDeptSendingMessagePermissions(driver, readFromConfig.GetDeptName(dept), permissionName, value);
        }

        [Then(@"click on ""(.*)"" button and select ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenClickOnButtonAndSelect(string btnName, string p1="" , string p2="", string p3="")
        {
            driver = driverFactory.GetDriver();
            myMessageInboxPage = new Pages.MyMessages.InboxPage(driver);

            if (btnName.Equals("Follow-up Button"))
            {
                myMessageInboxPage.ClickOnFollowUpBtn();
                if (!p1.Equals(""))
                {
                    myMessageInboxPage.clickFormateOption(p1);
                }
                if (!p2.Equals(""))
                {
                    myMessageInboxPage.clickFormateOption(p2);
                }
                myMessageInboxPage.ClickCloseBtn();
            }
            else if (btnName.Equals("Actions And Movements"))
            {
                myMessageInboxPage.ClickOnActionsAndMovementsBtn();
                if (p1.Contains("Print this page,Save as PDF,"))
                {
                    //Click is not working here
                    //myMessageInboxPage.ClickOnPrintThisPageAndSaveAsBtn(p1,driver);
                }
                if (p2.Contains("Print All,Save as PDF,"))
                {
                    //Not Visible!!!
                    //myMessageInboxPage.ClickOnPrintAllAndSaveAsBtn(p2,driver);
                }
                if(p3.Contains("Print Flow,Save as PDF,"))
                {
                    myMessageInboxPage.ClickOnPrintFlowAndSaveAsBtn(p3, driver);
                }
                if (p3.Equals("Just open Messaage Flow Tab"))
                {
                    myMessageInboxPage.ClickOnMessageFlowTab(driver);
                }
                myMessageInboxPage.clickBackBtn();
            }
            else if (btnName.Equals("Barcode Mail Print"))
            {
                if (p1.Contains("Print Barcode unexported,Save as PDF,"))
                {
                    myMessageInboxPage.ClickOnPrintBarcodePageInboxAndSaveAsBtn(p1,driver);
                }
            }
            else if (btnName.Equals("Print Selective"))
            {
                if (!(p1.Equals("") && p2.Equals("")))
                {
                    myMessageInboxPage.ClickOnPrintSelectiveAndSaveAsBtn(p1, p2, driver);
                }
            }
            else if (btnName.Equals("Print Formal Radio btn"))
            {
                if (!p1.Equals(""))
                {
                    myMessageInboxPage.ClickOnPrintFormalAndSaveAsBtn(p1, driver);
                }
            }
            else if (btnName.Equals("Open Attachment Tab,Select_All"))
            {
                if (!p1.Equals(""))
                {
                    myMessageInboxPage.ClickOnAttachmentTabInMailAndPrintAllAndSaveAsBtn(p1, driver, p2);
                }
            }
            else if (btnName.Equals("Open Attachment Tab,Select_Selective"))
            {
                if (!p1.Equals(""))
                {
                    myMessageInboxPage.ClickOnAttachmentTabInMailAndClickPrintAndSaveAsBtn(p1, driver);
                }
            }
            else if (btnName.Contains("Open Attachment Tab,Show All"))
            {
                if (!p1.Equals(""))
                {
                    myMessageInboxPage.ClickOnAttachmentTabInMailAndClickShowAllAndSaveAsBtn(p1, driver);
                }
            }
            else if (btnName.Contains("Delivery Statment button"))
            {
                if (!p1.Equals(""))
                {
                    myMessageInboxPage.ClickOnDeleveryStatmentBtnAndSaveAsBtn(p1, driver);
                    return;
                }
            }
            myMessageInboxPage._ifCancelBtn();
        }

        [Then(@"""(.*)"" visibility should be ""(.*)"" on Department Messages inbox")]
        public void ThenVisibilityShouldBeOnDepartmentMessagesInbox(string buttonName, bool value)
        {
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            Assert.IsTrue(deptMessageInboxPage.IsAt(driver, deptMessageInboxPage.title));
            Assert.IsTrue(deptMessageInboxPage.CheckButtonAvailbility(driver, buttonName, value));
            if (value)
            {
                Assert.IsTrue(deptMessageInboxPage.CheckButtonClickable(driver, buttonName));
            }
        }

    }
}