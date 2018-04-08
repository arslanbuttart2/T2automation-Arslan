using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Init;
using T2automation.Pages;
using T2automation.Pages.MyMessages;
using T2automation.Pages.SystemManagement.SystemManagement;
using T2automation.Util;
using TechTalk.SpecFlow;

namespace T2automation.Steps.Phase2
{
    [Binding]
    class Phase2Steps
    {
        DriverFactory driverFactory = new DriverFactory("BaseURL");
        private IWebDriver driver;
        private OutboxPage outboxPage;
        private UserManagerPage userManagerPage;
        private ReadFromConfig readFromConfig;
        private PermissionsPage permissionsPage;
        private LoginPage loginPage;
        private Pages.MyMessages.InboxPage myMessageInboxPage;
        private Pages.DeptMessages.InboxPage deptMessageInboxPage;
        private TextFileManager txtManager;
        private InboxPage inboxPage;

        [When(@"open connected document in ""(.*)"" with subject ""(.*)""")]
        public void WhenOpenConnectedDocumentInWithSubject(string dept, string subject)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);

            if (dept.Equals("my"))
            {
                inboxPage.clickOnConnectedDocument(driver, subject);
                Thread.Sleep(1000);
                inboxPage.ActionsNewWindowPrint();
            }
        }

        [When(@"user click on ""(.*)"" tab")]
        public void WhenUserClickOnTab(string tabName)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);

            if (tabName.Equals("Delivery statement reports"))
            {
                Assert.IsTrue(inboxPage.CheckOnDeliveryStatementReportsTab());
            }
            else if (tabName.Equals("Message Flow"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickOnDocFlowTab();
            }
            else if (tabName.Equals("Actions"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickOnActionTab();
            }
            else if (tabName.Equals("Document"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickOnDocumentTab();
            }

            else if (tabName.Equals("Attribute"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickOnAttributeTab();
            }
            else if (tabName.Equals("Connected Message"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickOnConnectedDocTab();
            }
            else if (tabName.Equals("Attachment"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickOnAttachmentTab();
            }
            else if (tabName.Equals("Attachment,popup"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickOnPopupAttachmentTab();
            }

        }

        [When(@"user click on ""(.*)"" upper bar button")]
        public void WhenUserClickOnUpperBarButton(string upperBarBtn)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);

            if (upperBarBtn.Equals("Change Status to Unread"))
            {
                Thread.Sleep(1000);
                inboxPage.ChangeStatustoUnread();
            }
            else if (upperBarBtn.Equals("Link,InternalDocument"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickLink(upperBarBtn, driver);
            }
            else if (upperBarBtn.Equals("Forward"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickOnForward();
            }
            else if (upperBarBtn.Equals("Print Delivery Statement"))
            {
                Thread.Sleep(1000);
                inboxPage.ClickPrintDeliveryStatement();
                Thread.Sleep(2000);
                inboxPage.CancelFunctionForNewWindowPrint();
            }
        }

        [When(@"user go to messages Delivery Statment Report folder")]
        public void WhenUserGoToMessagesDeliveryStatmentReportFolder()
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMessageDeliveryStatementReport(driver);
            inboxPage.cancelInstallation();
        }

        [Then(@"read Deliver Statment Number ""(.*)"" and Save from list")]
        public void ThenReadDeliverStatmentNumberAndSaveFromList(string type)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            txtManager = new TextFileManager();
            //string refno = txtManager.readFromFile(subject);
            string DSRno = inboxPage.SelectDeliveryStatmentReportNumberFromList();
            Assert.IsTrue(txtManager.writeToFile(type, type, DSRno));
        }

        [When(@"user search Delivery Statment Report with ""(.*)""")]
        public void WhenUserSearchDeliveryStatmentReportWith(string subject)
        {
            driver = driverFactory.GetDriver();
            txtManager = new TextFileManager();
            inboxPage = new InboxPage(driver);
            string DSRno = txtManager.readFromFile(subject);
            inboxPage.searchAndSelectTheReport(driver, DSRno);
        }

        [When(@"user search and open Delivery Statment Report with ""(.*)""")]
        public void WhenUserSearchAndOpenDeliveryStatmentReportWith(string subject)
        {
            driver = driverFactory.GetDriver();
            txtManager = new TextFileManager();
            inboxPage = new InboxPage(driver);
            string DSRno = txtManager.readFromFile(subject);
            inboxPage.searchAndSelectTheReportAndOpen(driver, DSRno);
        }

        [When(@"user select ""(.*)"" from list and click on ""(.*)"" button")]
        public void WhenUserSelectFromListAndClickOnButton(string data, string btn)
        {
            driver = driverFactory.GetDriver();
            txtManager = new TextFileManager();
            inboxPage = new InboxPage(driver);
            string DSRno = txtManager.readFromFile(data);
            inboxPage.searchFromListAndSelect(driver, DSRno);

            if (btn.Equals("Show Image"))
            {
                inboxPage.ClickShowImageBtn();
            }
        }




    }
}