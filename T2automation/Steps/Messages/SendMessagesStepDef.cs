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
using T2automation.Pages.MyMessages;
using T2automation.Pages.Comm;

namespace T2automation.Steps.My_Messages
{
    [Binding]
    public class SendMessagesStepDef
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


        [When(@"user sends an internal message to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnInternalMessageTo(string level, string receiverType, string to, string subject, string content)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            myMessageInboxPage = new InboxPage(driver);
            myMessageInboxPage.NavigateToMyMessageInbox(driver);
            myMessageInboxPage.CheckButtonClickable(driver, "Internal Document");
            myMessageInboxPage.ClickToButton(driver);
            myMessageInboxPage.SelectLevel(driver, readFromConfig.GetValue(level));
            myMessageInboxPage.SelectReceiverType(driver, receiverType);
            myMessageInboxPage.SearchNameCode = readFromConfig.GetValue(to);
            myMessageInboxPage.SelectToUser(driver, readFromConfig.GetValue(to),receiverType);
            myMessageInboxPage.ClickOkBtn();
            myMessageInboxPage.SendMail(subject, content);
        }
        

        [Then(@"mail should appear in my message out box ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInMyMessageOutBox(string to, string subject, string content, int attachmentNo ,string attachmentType)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            outboxPage = new OutboxPage(driver);
            outboxPage.NavigateToMyMessageOutbox(driver);
            Assert.IsTrue(outboxPage.ValidateMail(driver, readFromConfig.GetValue(to), subject, content, attachmentNo: attachmentNo, attachment:attachmentType));
        }

        [When(@"user click CC button ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserClickCCButton(string cclevel, string receiverType, string ccTo)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            myMessageInboxPage = new InboxPage(driver);
            myMessageInboxPage.ClickCCbutton(driver);
            myMessageInboxPage.SelectLevel(driver, readFromConfig.GetValue(cclevel));
            myMessageInboxPage.SelectReceiverType(driver, receiverType);
            myMessageInboxPage.SearchNameCode = readFromConfig.GetValue(ccTo);
            myMessageInboxPage.SelectCcUser(driver, readFromConfig.GetValue(ccTo), receiverType);
            myMessageInboxPage.ClickOkBtn();
        }

        [When(@"user sends an internal message to and cc ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"""), Then(@"user sends an internal message to and cc ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnInternalMessageToAndCc(string level, string receiverType, string to, string subject, string content, string cclevel, string ccReciverType, string ccTo)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            myMessageInboxPage = new InboxPage(driver);
            myMessageInboxPage.NavigateToMyMessageInbox(driver);
            myMessageInboxPage.CheckButtonClickable(driver, "Internal Document");
            myMessageInboxPage.ClickToButton(driver);
            myMessageInboxPage.SelectLevel(driver, readFromConfig.GetValue(level));
            myMessageInboxPage.SelectReceiverType(driver, receiverType);
            myMessageInboxPage.SearchNameCode = readFromConfig.GetValue(to);
            myMessageInboxPage.SelectToUser(driver, readFromConfig.GetValue(to),receiverType);
            myMessageInboxPage.ClickOkBtn();
            myMessageInboxPage.ClickCCbutton(driver);
            myMessageInboxPage.SelectLevel(driver, readFromConfig.GetValue(cclevel));
            myMessageInboxPage.SelectReceiverType(driver, receiverType);
            myMessageInboxPage.SearchNameCode = readFromConfig.GetValue(ccTo);
            myMessageInboxPage.SelectCcUser(driver, readFromConfig.GetValue(ccTo), receiverType);
            myMessageInboxPage.ClickOkBtn();
            myMessageInboxPage.SendMail(subject, content);
        }

        [Then(@"mail should appear in the inbox read CC too ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInTheInboxReadCCToo(string to, string subject, string content, string ccStatus = "False")
        {
            myMessageInboxPage = new InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            myMessageInboxPage.NavigateToMyMessageInbox(driver);
            Assert.IsTrue(myMessageInboxPage.ValidateMail(driver, readFromConfig.GetValue(to), subject, content, ccStatus));
        }

        [When(@"user set properties ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSetProperties(string messageType="", string tengibleNo="", string tengibleDesc="", string messageNo="", string messageGreoianDate="", string messageHijriDate="", string exportMethod="")
        {
            driver = driverFactory.GetDriver();
            myMessageInboxPage = new InboxPage(driver);
            myMessageInboxPage.SetProperties(messageType: messageType, tengibleNo: tengibleNo, tengibleDesc: tengibleDesc,messageNo: messageNo,messageGreorianDate: messageGreoianDate, messageHijriDate: messageHijriDate, exportMethod: exportMethod);
        }


        [When(@"user go to ""(.*)"" encrypted message")]
        public void WhenUserGoToEncryptedMessage(string dept)
        {
            driver = driverFactory.GetDriver();
            myMessageInboxPage = new InboxPage(driver);
            if (dept.Equals("my"))
            {
                myMessageInboxPage.NavigateToMyMessageInbox(driver);
            }
            else if (dept.Equals("dept"))
            {
                myMessageInboxPage.NavigateToQADeptInbox(driver);
            }
            myMessageInboxPage.CheckButtonClickable(driver, "Encrypted internal message");
        }

        [When(@"user sends an encrypted message to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnEncryptedMessageTo(string level, string receiverType, string to, string subject, string content, string encryptPassword)
        {
            driver = driverFactory.GetDriver();
            myMessageInboxPage = new InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            myMessageInboxPage.NavigateToMyMessageInbox(driver);
            myMessageInboxPage.CheckButtonClickable(driver, "Encrypted internal message");
            myMessageInboxPage.ClickToButton(driver);
            myMessageInboxPage.SelectLevel(driver, readFromConfig.GetValue(level));
            myMessageInboxPage.SelectReceiverType(driver, receiverType);
            myMessageInboxPage.SearchNameCode = readFromConfig.GetValue(to);
            myMessageInboxPage.SelectToUser(driver, readFromConfig.GetValue(to),receiverType);
            myMessageInboxPage.ClickOkBtn();
            myMessageInboxPage.SendMail(subject, content);
        }

        [Then(@"encrypted mail should appear in the out box ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenEncryptedMailShouldAppearInTheOutBox(string to, string subject, string content, string listSubject, string encryptedPass)
        {
            outboxPage = new OutboxPage(driver);
            outboxPage.NavigateToMyMessageOutbox(driver);
            readFromConfig = new ReadFromConfig();
            Assert.IsTrue(outboxPage.ValidateMail(driver, readFromConfig.GetValue(to), subject, content, listSubject, readFromConfig.GetValue(encryptedPass)));
        }

        [Then(@"mail should appear in dept inbox ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInDeptInbox(string to, string subject, string content)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            myMessageInboxPage = new InboxPage(driver);
            myMessageInboxPage.NavigateToQADeptInbox(driver);
            txtManager = new TextFileManager();
            string refno = txtManager.readFromFile(subject:subject);
            if (subject.Contains("Encrypted message"))
            {
                Assert.IsTrue(myMessageInboxPage.ValidateMailEncrypted(driver, readFromConfig.GetValue(to), subject, content, refno: refno,encryptPass:"P@ssw0rd!@#"));
            }
            else if(subject.Contains("Outgoing"))
            {
                Assert.IsTrue(myMessageInboxPage.ValidateMail(driver, readFromConfig.GetValue(to), subject, content, refno: refno, ccStatus:"True"));
            }
            else
            {
                Assert.IsTrue(myMessageInboxPage.ValidateMail(driver, readFromConfig.GetValue(to), subject, content, refno: refno));
            }
        }

        [Then(@"encrypted mail should appear in the inbox ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenEncryptedMailShouldAppearInTheInbox(string to, string subject, string content, string listSubject, string encryptedPass)
        {
            myMessageInboxPage = new InboxPage(driver);
            myMessageInboxPage.NavigateToMyMessageInbox(driver);
            readFromConfig = new ReadFromConfig();
            Assert.IsTrue(myMessageInboxPage.ValidateMail(driver, readFromConfig.GetValue(to), subject, content, listSubject, readFromConfig.GetValue(encryptedPass)));
        }

        [When(@"user sends an incoming message to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnIncomingMessageTo(string level, string receiverType, string to, string subject, string content)
        {
            driver = driverFactory.GetDriver();
            myMessageInboxPage = new InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            myMessageInboxPage.NavigateToMyMessageInbox(driver);
            myMessageInboxPage.CheckButtonClickable(driver, "Incoming Document");
            myMessageInboxPage.ClickToButton(driver);
            myMessageInboxPage.SelectLevel(driver, readFromConfig.GetValue(level));
            myMessageInboxPage.SelectReceiverType(driver, receiverType);
            myMessageInboxPage.SearchNameCode = readFromConfig.GetValue(to);
            myMessageInboxPage.SelectToUser(driver, readFromConfig.GetValue(to),receiverType);
            myMessageInboxPage.ClickOkBtn();
            myMessageInboxPage.SendMail(subject, content);
        }

        [When(@"user sends an outgoing message to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnOutgoingMessageTo(string name, string subject, string content, string deliveryType)
        {
            driver = driverFactory.GetDriver();
            myMessageInboxPage = new InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            myMessageInboxPage.SendOutgoingMessage(subject, content, deliveryType: readFromConfig.GetValue(deliveryType), deptName: readFromConfig.GetValue(name));
        }

        [Then(@"mail should appear in Department Message with Root ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInDepartmentMessageWithRoot(string CommDept, string subject, string content)
        {
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToMessageRoot(driver, readFromConfig.GetValue(CommDept));
            Assert.IsTrue(deptMessageInboxPage.ValidateMail(driver, readFromConfig.GetValue(CommDept), subject, content));
        }


    }
}
