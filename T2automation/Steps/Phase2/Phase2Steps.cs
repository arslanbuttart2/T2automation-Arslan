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


        [When(@"user click on ""(.*)"" tab")]
        public void WhenUserClickOnTab(string tabName)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);

            if (tabName.Equals("Delivery statement reports"))
            {
                Assert.IsFalse(inboxPage.CheckOnDeliveryStatementReportsTab());
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
        }

    }
}