using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2automation.Init;
using T2automation.Pages;
using T2automation.Pages.MyMessages;
using T2automation.Pages.SystemManagement.SystemManagement;
using T2automation.Util;
using TechTalk.SpecFlow;

namespace T2automation.Steps.Messages
{
    [Binding]
    class MessageActionsSteps
    {
        DriverFactory driverFactory = new DriverFactory("BaseURL");
        private IWebDriver driver;
        private OutboxPage outboxPage;
        private UserManagerPage userManagerPage;
        private ReadFromConfig readFromConfig;
        private PermissionsPage permissionsPage;
        private LoginPage loginPage;
        private Pages.MyMessages.InboxPage inboxPage;
        private Pages.DeptMessages.InboxPage deptMessageInboxPage;

        [When(@"user sends an internal message with attachment to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnInternalMessageWithAttachmentTo(string level, string receiverType, string to, string subject, string content, int multipleAttachementNo, string multipleAttachmentType)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, level);
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = to;
            inboxPage.SelectToUser(driver, to);
            inboxPage.ClickOkBtn();
            inboxPage.SendMail(subject, content, multipleAttachementNo: multipleAttachementNo, multipleAttachmentType: multipleAttachmentType);
        }

        [When(@"user sends an departmental internal message with attachment to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnDepartmentalInternalMessageWithAttachmentTo(string level, string receiverType, string to, string subject, string content, int multipleAttachementNo, string multipleAttachmentType, string dept)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            deptMessageInboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, level);
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = to;
            inboxPage.SelectToUser(driver, to);
            inboxPage.ClickOkBtn();
            inboxPage.SendMail(subject, content, multipleAttachementNo:multipleAttachementNo, multipleAttachmentType: multipleAttachmentType);
        }

        [Then(@"mail should appear in department message out box ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInDepartmentMessageOutBox(string to, string subject, string content, int attachmentNo, string attachmentType, string dept)
        {
            driver = driverFactory.GetDriver();
            outboxPage = new OutboxPage(driver);
            outboxPage.NavigateToQADeptOutbox(driver);
            Assert.IsTrue(outboxPage.ValidateMail(driver, to, subject, content, attachmentNo: attachmentNo, attachment: attachmentType));
        }

        [When(@"user attach attachment to internal message ""(.*)"" ""(.*)""")]
        public void WhenUserAttachAnAttachment(string attachmentType, int attachmentNo)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.AddAttachments(attachmentType, attachmentNo);

        }

        [When(@"user attach attachment to department internal message ""(.*)"" ""(.*)""")]
        public void WhenUserAttachAnAttachmentToDept(string attachmentType, int attachmentNo)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            deptMessageInboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.AddAttachments(attachmentType, attachmentNo);
        }

        [When(@"user delete the attachment ""(.*)"" ""(.*)""")]
        public void WhenUserDeleteTheAttachment(string deleteAttachmentTypes, int deleteAttachmentNo)
        {
            inboxPage.DeleteAttachments(deleteAttachmentTypes, deleteAttachmentNo);
        }

        [Then(@"attachment should not appear ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenAttachmentShouldNotAppear(string attachmentType, int attachmentNo, int deleteAttachmentNo)
        {
            Assert.IsTrue(inboxPage.ValidateAttachments(driver, attachmentNo, attachmentType, deleteAttachmentNo: deleteAttachmentNo));
        }

        [When(@"user download the attachment from inbox mail ""(.*)"" ""(.*)"" ""(.*)""")]
        public void GivenUserDownloadTheAttachmentFromInboxMail(string subject, string downloadFileName, int downloadFileNo)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.DownloadFile(subject, downloadFileName, downloadFileNo);
        }

        [When(@"user download the attachment from department inbox mail ""(.*)"" ""(.*)"" ""(.*)""")]
        public void GivenUserDownloadTheAttachmentFromDepartmentInboxMail(string subject, string downloadFileName, int downloadFileNo)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToQADeptInbox(driver);
            inboxPage.DownloadFile(subject, downloadFileName, downloadFileNo);
        }

        [Then(@"the file should appear in downloads ""(.*)"" ""(.*)""")]
        public void ThenTheFileShouldAppearInDownloads(string downloadFileName, int downloadFileNo)
        {
            Assert.IsTrue(new GetDownloadFiles().ValidateFilesNos(downloadFileNo));
        }

        [When(@"user sends an internal message with properties with attachments ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnInternalMessageWithProperties(string level, string receiverType, string to, string subject, string content, string securityLevel, int attachmentNo, string attachmentType)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, level);
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = readFromConfig.GetValue(to);
            inboxPage.SelectToUser(driver, readFromConfig.GetValue(to));
            inboxPage.ClickOkBtn();
            inboxPage.SendMail(subject, content, multipleAttachementNo: attachmentNo, multipleAttachmentType: attachmentType, securityLevel: readFromConfig.GetValue(securityLevel));
        }

        [When(@"user sends an deparment internal message with properties with attachments ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnDeparmentInternalMessageWithPropertiesWithAttachments(string level, string receiverType, string to, string subject, string content, string securityLevel, int attachmentNo, string attachmentType, string dept)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, level);
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = readFromConfig.GetValue(to);
            inboxPage.SelectToUser(driver, readFromConfig.GetValue(to));
            inboxPage.ClickOkBtn();
            inboxPage.SendMail(subject, content, multipleAttachementNo: attachmentNo, multipleAttachmentType: attachmentType, securityLevel: readFromConfig.GetValue(securityLevel));
        }

        [When(@"user go to my messages Internal Document")]
        public void WhenUserGoToInternalDocument()
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
        }

        [When(@"search ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenSearch(string to, string level, string receiverType)
        {
            readFromConfig = new ReadFromConfig();
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, readFromConfig.GetValue(level));
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = readFromConfig.GetValue(to);
            inboxPage.SelectToUser(driver, readFromConfig.GetValue(to));
            inboxPage.ClickOkBtn();
        }

        [When(@"user compose mail ""(.*)"" ""(.*)""")]
        public void WhenUserComposeMail(string subject, string content)
        {
            inboxPage.ComposeMail(subject, content);
        }

        [When(@"user attach attachments (.*) ""(.*)""")]
        public void WhenUserAttachAttachments(int attachmentNo, string attachmentTypes)
        {
            inboxPage.AddAttachments(attachmentTypes, attachmentNo);
        }

        [When(@"user send the email")]
        public void WhenUserSendTheEmail()
        {
            inboxPage.clickOnSendBtn();
            Assert.IsTrue(inboxPage.WaitTillMailSent(), "Unable to send mail");
        }

        [When(@"user go to my messages Incomming Document")]
        public void WhenUserGoToMyMessagesIncommingDocument()
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Incoming Document");
        }

        [When(@"select the external department ""(.*)""")]
        public void WhenSelectTheExternalDepartment(string to)
        {
            readFromConfig = new ReadFromConfig();
            inboxPage.SelectExternalDeptTo(deptName: readFromConfig.GetValue(to));
        }

        [When(@"user send the email and click on Cancel button")]
        public void WhenUserSendTheEmailAndClickOnCancelButton()
        {
            inboxPage.clickOnSendBtn(true);
            Assert.IsTrue(inboxPage.WaitTillMailSent(), "Unable to send mail");
        }

        [When(@"user enters incomming message no ""(.*)"" and incomming message Gregorian date ""(.*)""")]
        public void WhenUserEntersIncommingMessageNoAndIncommingMessageGregorianDate(string messageNo, string messageGreorianDate)
        {
            inboxPage.SetProperties(messageNo: messageNo, messageGreorianDate: messageGreorianDate);
        }

        [When(@"user go to my messages Outgoing Document")]
        public void WhenUserGoToMyMessagesOutgoingDocument()
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Outgoing Document");
        }

        [When(@"select delivery type ""(.*)""")]
        public void WhenSelectDeliveryType(string deliveryType)
        {
            inboxPage.SetProperties(deliveryType: deliveryType);
        }

        [When(@"user select connected document with subject ""(.*)""")]
        public void WhenUserSelectConnectedDocumentWithSubject(string subject)
        {
            inboxPage.SelectConnectedDoc(subject);
        }

        [When(@"user opens inbox email with subject ""(.*)""")]
        public void WhenUserOpensInboxEmailWithSubject(string subject)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.OpenMail(driver, subject);
        }

        [Then(@"the visibilty of button ""(.*)"" should be ""(.*)"" on connected doc tab")]
        public void ThenTheVisibiltyOfButtonShouldBeOnConnectedDocTab(string buttonName, bool value)
        {
            Assert.IsTrue(inboxPage.CheckVisibiltyOnConnectedDoc(buttonName, value), buttonName + " should not be visible");
        }

        [Then(@"the visibilty of tab ""(.*)"" should be ""(.*)"" on connected doc tab")]
        public void ThenTheVisibiltyOfTabShouldBeOnConnectedDocTab(string tab, bool value)
        {
            Assert.True(inboxPage.CheckVisibiltyOfTab(tab, value), tab + " visibilty should be " + value.ToString());
        }

        [When(@"user opens department ""(.*)"" mail with subject ""(.*)""")]
        public void WhenUserOpensDepartmentMailWithSubject(string dept, string subject)
        {
            driver = driverFactory.GetDriver();
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            inboxPage = new InboxPage(driver);
            inboxPage.OpenMail(driver, subject);
        }

        [When(@"user go to department ""(.*)"" inbox")]
        public void WhenUserGoToDepartmentInbox(string dept)
        {
            driver = driverFactory.GetDriver();
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            inboxPage = new InboxPage(driver);
        }


        [When(@"user click on reply button")]
        public void WhenUserClickOnReplyButton()
        {
            inboxPage.ClickOnReply();
        }

        [When(@"user deletes the draft"), Then(@"user deletes the draft")]
        public void WhenUserDeletesTheDraft()
        {
            inboxPage.DeleteDraft();
        }

        [When(@"user click on forward button")]
        public void WhenUserClickOnForwardButton()
        {
            inboxPage.ClickOnForward();
        }

        [When(@"user clicks on save draft")]
        public void WhenUserClicksOnSaveDraft()
        {
            inboxPage.SaveDraft();
        }

        [Then(@"the connected document with subject ""(.*)"" should appear in the list")]
        public void ThenTheConnectedDocumentWithSubjectShouldAppearInTheList(string subject)
        {
            Assert.IsTrue(inboxPage.ValidateConnectedDocumentList(subject), subject + " should appear in the connected document");
        }

        [When(@"user go to dept messages Internal Document")]
        public void WhenUserGoToDeptMessagesInternalDocument()
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
        }

        [Then(@"verify that connected document with subject ""(.*)"" should not appear in while adding new")]
        public void ThenVerifyThatConnectedDocumentWithSubjectShouldNotAppearInWhileAddingNew(string subject)
        {
            Assert.True (inboxPage.SelectConnectedDoc(subject) == 0, "Document with subject " + subject + " should not appear in search while adding new connected document");
        }

    }
}
