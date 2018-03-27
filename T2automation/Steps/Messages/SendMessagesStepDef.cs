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
        private InboxPage inboxPage;


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
            driver = driverFactory.GetDriver();
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
            driver = driverFactory.GetDriver();
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
            driver = driverFactory.GetDriver();
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
        public void ThenMailShouldAppearInDepartmentMessageWithRoot(string commDept, string subject, string content)
        {
            driver = driverFactory.GetDriver();
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToMessageRoot(driver, readFromConfig.GetValue(commDept));
            Assert.IsTrue(deptMessageInboxPage.ValidateMail(driver, readFromConfig.GetValue(commDept), subject, content));
        }

        [When(@"user go to dept ""(.*)"" messages Unexported folder")]
        public void WhenUserGoToDeptMessagesUnexportedFolder(string commDept)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToMessageRoot(driver, readFromConfig.GetValue(commDept));
        }

        [When(@"user go to dept ""(.*)"" Outbox")]
        public void WhenUserGoToDeptOutbox(string Dept)
        {
            driver = driverFactory.GetDriver();
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            if (Dept.Equals("CommDepSameDep"))
            {
                deptMessageInboxPage.NavigateToCommDeptOutbox(driver, Dept);
            }
            if (Dept.Equals("qaDept"))
            {
                deptMessageInboxPage.NavigateToQADeptOutbox(driver);
            }

        }

        [When(@"user go to dept ""(.*)"" Exported")]
        public void WhenUserGoToDeptExported(string commDept)
        {
            driver = driverFactory.GetDriver();
            readFromConfig = new ReadFromConfig();
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToCommDeptExportF(driver, readFromConfig.GetValue(commDept));
        }

        [Then(@"user search and select mail in dept ""(.*)"" with subject ""(.*)""")]
        public void ThenUserSearchAndSelectMailInDeptWithSubject(string Dept, string subject)
        {
            driver = driverFactory.GetDriver();
            txtManager = new TextFileManager();
            inboxPage = new InboxPage(driver);
            if (Dept.Equals("myOutbox"))
            {
                inboxPage.NavigateToMyMessageOutbox(driver);
            }

            if (subject.Contains(","))
            {
                inboxPage.selectMailForMultipleSubjects(subject);
            }
            string refno = txtManager.readFromFile(subject);
            inboxPage.firstSearchFolderWithRefNo(refno);
            inboxPage.selectMailSearched();
        }

        [When(@"user search and select outbox mail with subject ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenUserSearchAndSelectOutboxMailWithSubject(string subject1, string subject2, string subject3 = "")
        {

            driver = driverFactory.GetDriver();
            txtManager = new TextFileManager();
            outboxPage = new OutboxPage(driver);
            outboxPage.NavigateToMyMessageOutbox(driver);
            string refno1 = txtManager.readFromFile(subject1);
            string refno2 = txtManager.readFromFile(subject2);
            string refno3 = txtManager.readFromFile(subject3);
            outboxPage.SelectOutboxMail(driver, refno1, refno2, refno3);
        }

        [Then(@"user search and open mail in dept ""(.*)"" with subject ""(.*)""")]
        [When(@"user search and open mail in dept ""(.*)"" with subject ""(.*)""")]
        public void ThenUserSearchAndOpenMailInDeptWithSubject(string commDept, string subject)
        {
            driver = driverFactory.GetDriver();
            txtManager = new TextFileManager();
            inboxPage = new InboxPage(driver);
            string refno = txtManager.readFromFile(subject);
            inboxPage.OpenMailSpecial(driver, refno, withSubject: false);
        }

        [Then(@"click on ""(.*)"" button"), When(@"click on ""(.*)"" button")]
        public void ThenClickOnButton(string btnName)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);

            if (btnName.Equals("Return"))
            {
                inboxPage.ClickOnReturnBtn();
            }
            else if (btnName.Contains("Back"))
            {
                inboxPage.clickBackBtn();
            }
            else if (btnName.Contains("Print All,Save as PDF,"))
            {
                inboxPage.ClickonPrintAllAndSaveAsButton(btnName,driver);
            }
            else if (btnName.Contains("Print,Save as PDF,"))
            {
                inboxPage.ClickOnPrintBtnAndSaveAsBtn(btnName, driver);
            }
            else if (btnName.Contains("Print Barcode,Save as PDF,"))
            {
                inboxPage.ClickOnPrintBarcodeBtnAndSaveAsBtn(btnName,driver);
            }
            else if (btnName.Contains("Print Reference Number,Save as PDF,"))
            {
                inboxPage.ClickOnPrintReferenceNumberBtnAndSaveAsBtn(btnName, driver);
            }
            else if (btnName.Contains("Print Delivery statement,Save as PDF,"))
            {
                inboxPage.ClickOnPrintDeliveryStatementBtnAndSaveAsBtn(btnName, driver);
            }
            else if (btnName.Contains("Print Document,Save as PDF,"))
            {
                inboxPage.ClickOnPrintDocumentBtnAndSaveAsBtn(btnName, driver);
            }
            else if (btnName.Equals("Retrieve"))
            {
                inboxPage.ClickOnRetrieveBtn();
                inboxPage.clickOnYesbtn();
            }
            else if (btnName.Equals("To check the Retrieve"))
            {
                Assert.IsTrue(inboxPage.CheckOnRetrieveBtn());
            }
            else if (btnName.Equals("Export"))
            {
                Thread.Sleep(1000);
                inboxPage.clickExportBtnInCommDeptUnexportedF();
            }
            else if (btnName.Equals("Undo Export"))
            {
                Thread.Sleep(1000);
                inboxPage.clickUndoExportBtnInCommDeptUnexportedF();
            }
            else if (btnName.Equals("Confirm Receiving"))
            {
                Thread.Sleep(1000);
                inboxPage.clickConfirmReceivingBtn();
            }
            else if (btnName.Equals("Reply"))
            {
                Thread.Sleep(1000);
                inboxPage.clickReplyBtnMyInbox();
            }
            
            //This button is available in Advance Search Menu
            else if (btnName.Equals("Clear"))
            {
                inboxPage.ClickOnClearBtn();
            }
            else if (btnName.Equals("Search"))
            {
                inboxPage.ClickOnSearchBtn();
            }
            //These buttons are in dept inbox opened mail
            else if (btnName.Equals("Print"))
            {
                inboxPage.ClickOnPrintBtn();
            }
            else if (btnName.Equals("Print Sticker"))
            {
                inboxPage.ClickOnPrintStickerBtn();
            }
            else if (btnName.Equals("Print Sticker,Save As PDF,"))
            {
                inboxPage.ClickOnPrintStickerBtnAndSaveAs(btnName,driver);
            }

            //These buttons are in dept outbox opened mail
            else if (btnName.Contains("Print outbox,Save as PDF,"))
            {
                inboxPage.ClickOnPrintAndSaveAsBtn(btnName,driver);
            }
            else if (btnName.Contains("Print Delivery statement outbox,Save as PDF,"))
            {
                inboxPage.ClickOnPrintDeliveryStatementAndSaveAsBtn(btnName, driver);
            }
            else if (btnName.Contains("Print Sticker outbox,Save as PDF,"))
            {
                inboxPage.ClickOnPrintStickerAndSaveAsBtn(btnName, driver);
            }

            //Extras
            else if (btnName.Equals("Reply All"))
            {
                inboxPage.ClickOnReplyAllBtn();
            }


        }
        [Then(@"write reference number of ""(.*)""")]
        public void ThenWriteReferenceNumberOf(string subject)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            txtManager = new TextFileManager();
            string refno = txtManager.readFromFile(subject: subject);
            inboxPage.writeRefNoToFieldInSearch(refno);
        }

        [Then(@"write export date from ""(.*)""")]
        public void ThenWriteExportDateFrom(string date)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.writeDateExportDateFromInSearch(date);
        }

        [Then(@"write created date from ""(.*)""")]
        public void ThenWriteCreatedDateFrom(string date)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.writeDateCreatedDateFromInSearch(date);
        }

        [Then(@"Check the advance searched results with subject ""(.*)""")]
        public void ThenCheckTheAdvanceSearchedResultsWithSubject(string subject)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            txtManager = new TextFileManager();
            string refno = txtManager.readFromFile(subject);
            refno = txtManager.refnoPure(refno);
            Assert.IsTrue(inboxPage.ValidateMailAppearInAdvanceSearch(driver,refno));
        }

        [When(@"user select and save the reference no ""(.*)"" of connected document with subject ""(.*)""")]
        public void WhenUserSelectAndSaveTheReferenceNoOfConnectedDocumentWithSubject(string type, string subject)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            txtManager = new TextFileManager();
            //string refno = txtManager.readFromFile(subject);
            string refno = inboxPage.SelectConnectedDocWithRefNoToSave(subject);
            Assert.IsTrue(txtManager.writeToFile(type,subject, refno));
        }

    }
}
