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
        private TextFileManager txtManager;

        [When(@"user send incoming message to ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendIncomingMessageTo(string level, string receiverType, string to)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver,readFromConfig.GetValue(level));
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = readFromConfig.GetValue(to);
            inboxPage.SelectToUser(driver,readFromConfig.GetValue(to), receiverType);
            inboxPage.ClickOkBtn();
        }

        [When(@"user sends an internal message with attachment to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnInternalMessageWithAttachmentTo(string level, string receiverType, string to, string subject, string content, int multipleAttachementNo, string multipleAttachmentType)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver,readFromConfig.GetValue(level));
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode =readFromConfig.GetValue(to);
            inboxPage.SelectToUser(driver,readFromConfig.GetValue(to), receiverType);
            inboxPage.ClickOkBtn();
            inboxPage.SendMail(subject, content, multipleAttachementNo: multipleAttachementNo, multipleAttachmentType: multipleAttachmentType);
        }
        
        [Then(@"save reference number from ""(.*)"" in txt with subject ""(.*)""")]
        public void ThenSaveReferenceNumberFromInTxtWithSubject(string type, string subject)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            outboxPage = new OutboxPage(driver);
            txtManager = new TextFileManager();
            if (type.Equals("my"))
            {
                outboxPage.NavigateToMyMessageOutbox(driver);
            }
            else if (type.Equals("dept"))
            {
                outboxPage.NavigateToQADeptOutbox(driver);
            }
            else if (type.Equals("deptAcc"))
            {
                outboxPage.NavigateToAccountingDeptOutbox(driver);
            }
            outboxPage.OpenMailSpecialForTxtFile(driver, subject,withSubject: false);
            string refno = outboxPage.readRefNoFromMail(driver,subject);
            Assert.IsTrue(txtManager.writeToFile(type,subject, refno), " this must be written in the txt file!!");
        }
        
        [When(@"user sends an departmental internal message with attachment to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnDepartmentalInternalMessageWithAttachmentTo(string level, string receiverType, string to, string subject, string content, int multipleAttachementNo, string multipleAttachmentType, string dept)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            readFromConfig = new ReadFromConfig();
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            deptMessageInboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, readFromConfig.GetValue(level));
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode =readFromConfig.GetValue(to);
            inboxPage.SelectToUser(driver,readFromConfig.GetValue(to), receiverType);
            inboxPage.ClickOkBtn();
            inboxPage.SendMail(subject, content, multipleAttachementNo:multipleAttachementNo, multipleAttachmentType: multipleAttachmentType);
        }

        [Then(@"mail should appear in department message out box ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInDepartmentMessageOutBox(string to, string subject, string content, int attachmentNo, string attachmentType, string dept)
        {
            driver = driverFactory.GetDriver();
            outboxPage = new OutboxPage(driver);
            readFromConfig = new ReadFromConfig();
            outboxPage.NavigateToQADeptOutbox(driver);
            Assert.IsTrue(outboxPage.ValidateMail(driver,readFromConfig.GetValue(to), subject, content, attachmentNo: attachmentNo, attachment: attachmentType));
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
            inboxPage.SelectLevel(driver,readFromConfig.GetValue( level));
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = readFromConfig.GetValue(to);
            inboxPage.SelectToUser(driver, readFromConfig.GetValue(to), receiverType);
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
            inboxPage.SelectLevel(driver,readFromConfig.GetValue( level));
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = readFromConfig.GetValue(to);
            inboxPage.SelectToUser(driver, readFromConfig.GetValue(to), receiverType);
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
            inboxPage.WaitTillProcessing();
            inboxPage.SelectToUser(driver, readFromConfig.GetValue(to), receiverType);
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

        [Then(@"mail should appear in the inbox ""(.*)"" ""(.*)"" ""(.*)"""), When(@"mail should appear in the inbox ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInTheInbox(string to, string subject, string content)
        {
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            Assert.IsTrue(inboxPage.ValidateMail(driver, readFromConfig.GetValue(to), subject, content));
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
        
        [When(@"user read connected document reference with subject ""(.*)"" add (.*)")]
        public void WhenUserReadConnectedDocumentReferenceWithSubjectAdd(string subject, int add)
        {
            driver = driverFactory.GetDriver();
            string refNo = inboxPage.ReadReferenceNoOfConnectedDoc(driver,subject);
            Assert.IsTrue(inboxPage.validateConnectedDocWithRefNoFoundOrNot(driver, refNo, ""), refNo + " should be visible");
            string newRefNo = inboxPage.addNumberInString(refNo,add);
            Assert.IsFalse(inboxPage.validateConnectedDocWithRefNoFoundOrNot(driver,newRefNo,""), newRefNo + " should not be visible");
        }

        [When(@"user select document type as ""(.*)"" with subject ""(.*)""")]
        public void WhenUserSelectDocumentTypeAsWithSubject(string docType, string subject)
        {
            driver = driverFactory.GetDriver();
            string refNo = inboxPage.ReadReferenceNoOfConnectedDoc(driver, subject);
            Assert.IsTrue(inboxPage.selectConnectedDocWithRefNoAndDocType(driver, refNo, docType), docType + " Document must be saved!");
        }

        [When(@"user select delivery type as ""(.*)"" with subject ""(.*)""")]
        public void WhenUserSelectDeliveryTypeAsWithSubject(string deliveryType, string subject)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            string refNo = inboxPage.ReadReferenceNoOfConnectedDoc(driver, subject);
            Assert.IsTrue(inboxPage.selectConnectedDocWithRefNoAndDeliveryType(driver, refNo,readFromConfig.GetValue(deliveryType)), deliveryType + " Document must be saved!");
        }

        
        [When(@"user select connected document without saving it with subject ""(.*)"" ""(.*)""")]
        public void WhenUserSelectConnectedDocumentWithoutSavingItWithSubject(string subject, bool saveStatus)
        {
            inboxPage.SelectConnectedDoc(subject, saveStatus);
        }
        
        [When(@"user select connected document with subject ""(.*)""")]
        public void WhenUserSelectConnectedDocumentWithSubject(string subject)
        {
            txtManager = new TextFileManager();
            string refno = txtManager.readFromFile(subject);
            inboxPage.SelectConnectedDoc(subject);   
        }

        [When(@"user set connected person ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSetConnectedPerson(string personName, string email, string mbl, string idNum, string idIssue, string issueDate, string idType, string saveStatus)
        {
            inboxPage.SelectConnectedPerson(driver,personName,email,mbl,idNum,idIssue,issueDate,idType,saveStatus);
        }


        [When(@"user opens inbox email with subject ""(.*)""")]
        public void WhenUserOpensInboxEmailWithSubject(string subject)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            Thread.Sleep(3000);
            inboxPage.WaitTillProcessing();
            inboxPage.OpenMail(driver, subject);
        }

        [Then(@"the visibilty of button ""(.*)"" should be ""(.*)"" on connected person tab")]
        public void ThenTheVisibiltyOfButtonShouldBeOnConnectedPersonTab(string buttonName, bool value)
        {
            Assert.IsTrue(inboxPage.CheckVisibiltyOnConnectedPerson(buttonName, value), buttonName + " should not be visible");
        }

        [Then(@"the visibilty of button ""(.*)"" should be ""(.*)"" on connected doc tab")]
        public void ThenTheVisibiltyOfButtonShouldBeOnConnectedDocTab(string buttonName, bool value)
        {
            Assert.IsTrue(inboxPage.CheckVisibiltyOnConnectedDoc(buttonName, value), buttonName + " should not be visible");
        }
        
        [When(@"user update person with name ""(.*)"" from the list to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserUpdatePersonWithNameFromTheListTo(string nameold, string personName, string email, string mbl, string idNum, string idIssue, string issueDate, string idType, string saveStatus)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.EditPersonFromTheList(driver, nameold, personName, email, mbl, idNum, idIssue, issueDate, idType, saveStatus);
        }

        [When(@"user delete the person with name ""(.*)"" from the list")]
        public void WhenUserDeleteThePersonWithNameFromTheList(string name)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.DeletePersonFromTheList(driver, name);
        }

        [When(@"user delete the document with subject ""(.*)"" from the list")]
        public void WhenUserDeleteTheDocumentWithSunjectFromTheList(string subject)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.DeleteDocumetFromTheList(driver,subject);
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
            txtManager = new TextFileManager();
            string refno = txtManager.readFromFile(subject);
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
            inboxPage.ClickOkBtn();
        }
        

        [When(@"user open connected document with subject ""(.*)""")]
        public void WhenUserOpenConnectedDocumentWithSubject(string subject)
        {
            driver = driverFactory.GetDriver();
            inboxPage.ClickConnectedDocTab(driver);
            inboxPage.clickOnConnectedDocumentList(driver, subject);
        }

        [Then(@"Verify tab ""(.*)"" on connected document detail")]
        public void ThenVerifyTabOnConnectedDocumentDetail(string tab)
        {
            driver = driverFactory.GetDriver();
            inboxPage.connectedDocListPopupsTab(driver,tab);
        }

        [Then(@"verify to detail open ""(.*)""")]
        public void ThenVerifyToDetailOpen(string data)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            inboxPage.ClickConnectedDocTab(driver);
            inboxPage.connectedDocListPopupsTab(driver, "Document");
            inboxPage.connectedDocListPopupTabTo(driver,readFromConfig.GetValue(data));
        }

        [Then(@"verify from detail open ""(.*)""")]
        public void ThenVerifyFromDetailOpen(string data)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            inboxPage.ClickConnectedDocTab(driver);
            inboxPage.connectedDocListPopupsTab(driver, "Document");
            inboxPage.connectedDocListPopupTabFrom(driver,readFromConfig.GetValue(data));
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

        [Then(@"verify the connected person with name ""(.*)"" should not appear in the list")]
        public void ThenVerifyTheConnectedPersonWithNameShouldNotAppearInTheList(string name)
        {
            Assert.False(inboxPage.ValidateConnectedPersonList(name), name + "In verify should not appear in the Connected Person List // my line");
        }


        [Then(@"the connected person with name ""(.*)"" should appear in the list")]
        public void ThenTheConnectedPersonWithNameShouldAppearInTheList(string name)
        {
            Assert.IsTrue(inboxPage.ValidateConnectedPersonList(name), name + " should appear in the Connected Person List");
        }

        [Then(@"the connected document with subject ""(.*)"" should appear in the list")]
        public void ThenTheConnectedDocumentWithSubjectShouldAppearInTheList(string subject)
        {
            Assert.IsTrue(inboxPage.ValidateConnectedDocumentList(subject), subject + " should appear in the connected document");
        }

        [Then(@"the connected document with subject ""(.*)"" should not appear in the list")]
        public void ThenTheConnectedDocumentWithSubjectShouldNotAppearInTheList(string subject)
        {
            Assert.IsFalse(inboxPage.ValidateConnectedDocumentList(subject), subject + " should not appear in the connected document");
        }
        
        [When(@"user go to dept messages Incoming Document")]
        public void WhenUserGoToDeptMessagesIncomingDocument()
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Incoming Document");
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

        [When(@"user go to dept ""(.*)"" messages Internal Document")]
        public void WhenUserGoToDeptMessagesInternalDocument(string deptName)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToAccountingDeptInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
        }

        [When(@"user go to dept ""(.*)"" messages Incoming Document")]
        public void WhenUserGoToDeptMessagesIncomingDocument(string p0)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToAccountingDeptInbox(driver);
            inboxPage.CheckButtonClickable(driver,"Incoming Document");
        }

        [When(@"user go to dept messages Outgoing Document")]
        public void WhenUserGoToDeptMessagesOutgoingDocument()
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Outgoing Document");
        }

        [Then(@"verify that connected document with subject ""(.*)"" should not appear in while adding new")]
        public void ThenVerifyThatConnectedDocumentWithSubjectShouldNotAppearInWhileAddingNew(string subject)
        {
            Assert.True (inboxPage.SelectConnectedDoc(subject) == 0, "Document with subject " + subject + " should not appear in search while adding new connected document");
        }

        [When(@"user close the connected documented")]
        public void WhenUserCloseTheConnectedDocumented()
        {
            inboxPage.CloseConnectedTabPopup(driver);
        }

        [Then(@"Error is shown as ""(.*)"" ""(.*)""")]
        public void ThenErrorIsShownAs(string errorMessage, string field)
        {
            Assert.IsTrue(inboxPage.FindError(driver, errorMessage, field) == 1, "Error Message " + errorMessage + " should appear when invalid" + field + " is entered.");
        }
    }
}
