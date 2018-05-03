using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Pages.SystemManagement.SystemManagement;

namespace T2automation.Pages.Comm
{
    class LeftMenu : BasePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[2]/a/label")]
        private IWebElement _home;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]")]
        private IWebElement _systemManagementMainDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/a/label")]
        private IWebElement _systemManagementMain;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]")]
        private IWebElement _systemManagementDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/a/label")]
        private IWebElement _systemManagement;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[1]/a/label")]
        private IWebElement _userManager;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[2]/a/label")]
        private IWebElement _roles;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[3]/a/label")]
        private IWebElement _departmentSharedRoles;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[4]/a/label")]
        private IWebElement _hierarchyManagement;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[5]/a/label")]
        private IWebElement _notificationManagment;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[6]/a/label")]
        private IWebElement _loginUsers;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[7]/a/label")]
        private IWebElement _regulatoryReporting;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[8]/a/label")]
        private IWebElement _systemLog;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[9]/a/label")]
        private IWebElement _loginEvents;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[10]/a/label")]
        private IWebElement _announcementGroup;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-c80eed64-3638-4901-99ed-491e98d32411']/div[1]")]
        private IWebElement _expandFolder111;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[2]/a/label")]
        private IWebElement _lookUps;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/a/label")]
        private IWebElement _messages;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[1]/a/label")]
        private IWebElement _messageReports;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[2]/a/label")]
        private IWebElement _forbidReceive;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[3]/a/label")]
        private IWebElement _deliveryStatementReports;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[4]/a/label")]
        private IWebElement _documentTemplate;

        [FindsBy(How = How.XPath, Using = ".//*[@id='myDocumentsDiv']")]
        private IWebElement _myMessagesMenuDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='myDocumentsDiv']/a/label")]
        private IWebElement _myMessages;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0']/a/label")]
        private IWebElement _myMessageInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-5']/a/label")]
        private IWebElement _myMessageOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-2']/a/label")]
        private IWebElement _myMessageDrafts;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3']/a/label")]
        private IWebElement _myMessageArchived;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-4']/a/label")]
        private IWebElement _myMessageDeleted;

        [FindsBy(How = How.XPath, Using = ".//*[@id='myDocumentsDiv']/div[6]/a/label")]
        private IWebElement _myMessageNotifications;

        [FindsBy(How = How.XPath, Using = ".//*[@id='myDocumentsDiv']/div[7]/a/label")]
        private IWebElement _myMessageReports;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDiv']")]
        private IWebElement _departmentMessagesMenuDiv;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]")]
        private IWebElement _MessagesMenuDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub3c76399d-2a03-4b67-9459-8a0925263d2e']")]
        private IWebElement _departmentQAMenuDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub3c76399d-2a03-4b67-9459-8a0925263d2e']/div[@id='folder-0-3c76399d-2a03-4b67-9459-8a0925263d2e']")]
        private IWebElement _departmentInboxMenuDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub644dc7d2-f626-4abf-851f-8395d8a79674']")]
        private IWebElement _departmentAccountMenuDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSubdf82bbee-44d8-4d77-9b5b-92763d4362e9']")]
        private IWebElement _departmentAuditMenuDiv;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub8cd8b29d-b115-4e18-a313-6d31a661bce1']")]
        private IWebElement _departmentSaudiAffairsMenuDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[6]")]
        private IWebElement _searchMenuDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDiv']/a/label")]
        private IWebElement _departmentMessages;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/a/label")]
        private IWebElement _MessagesTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[6]/a/lable")]
        private IWebElement _Search;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub3c76399d-2a03-4b67-9459-8a0925263d2e']")]
        private IWebElement _qaDeptMenuDiv;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSubdd8ca884-0b05-4de6-900d-af5fc9623558']")]
        private IWebElement _commDeptMenuDiv;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSubdd8ca884-0b05-4de6-900d-af5fc9623558']/a/label")]
        private IWebElement _commDept;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub644dc7d2-f626-4abf-851f-8395d8a79674']/a")]
        private IWebElement _accountingDept;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSubdf82bbee-44d8-4d77-9b5b-92763d4362e9']/a")]
        private IWebElement _auditDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub8cd8b29d-b115-4e18-a313-6d31a661bce1']/a")]
        private IWebElement _saudiAffairDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-644dc7d2-f626-4abf-851f-8395d8a79674']/a/label")]
        private IWebElement _accountingDeptInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-df82bbee-44d8-4d77-9b5b-92763d4362e9']/a/label")]
        private IWebElement _auditDeptInbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='folder-0-8cd8b29d-b115-4e18-a313-6d31a661bce1']/a/label")]
        private IWebElement _saudiAffairstDeptInbox;

        [FindsBy(How = How.XPath, Using = "//*/a[@data-folder-flag='0'][@class='o-folder'][@data-orgid='3c76399d-2a03-4b67-9459-8a0925263d2e']/label[contains(text(),'Automation 111')]")]
        private IWebElement _automation111DeptInbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSub3c76399d-2a03-4b67-9459-8a0925263d2e']/div[contains(@id,'folder-0-3c76399d-2a03-4b67-9459-8a0925263d2e')]/div/div[@class='folder-toggler']")]
        private IWebElement _automation111Dropdown;

        [FindsBy(How = How.XPath, Using = "//*/a[@data-folder-flag='0'][@class='o-folder'][@data-orgid='3c76399d-2a03-4b67-9459-8a0925263d2e']/label[contains(text(),'Automation 222')]")]
        private IWebElement _automation222DeptInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-644dc7d2-f626-4abf-851f-8395d8a79674']/a/label")]
        private IWebElement _accountingDeptOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-df82bbee-44d8-4d77-9b5b-92763d4362e9']/a[@class='o-folder'][@data-folder-flag='5']")]
        private IWebElement _auditDeptOutbox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-8cd8b29d-b115-4e18-a313-6d31a661bce1']/a[@data-folder-flag='5']")]
        private IWebElement _saudiAffairstDeptOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a/label")]
        private IWebElement _accountingDeptDeletedF;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label")]
        private IWebElement _qaDept;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[3]/a/label")]
        private IWebElement _DeliveryStatementReportTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label")]
        private IWebElement _qaDeptInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label/i[@class='fa fa-trash-o']")]
        private IWebElement _qaDeptDeletedF;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3c76399d-2a03-4b67-9459-8a0925263d2e']/a[@data-folder-flag='3']")]
        private IWebElement _qaDeptArchivedF;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label")]
        private IWebElement _qaDeptOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@data-folder-flag='0']")]
        private IWebElement _inboxMessageWithRoot;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@class='o-folder'][@data-folder-flag='5']")]
        private IWebElement _commDeptOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@class='o-folder'][@data-folder-flag='9']")]
        private IWebElement _commDeptExported;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@data-folder-flag='3']")]
        private IWebElement _commDeptArchivedF;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@data-folder-flag='4']")]
        private IWebElement _commDeptDeleteF;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='aSearch']/label")]
        private IWebElement _advanceSearch;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[6]/div[2]/a/label")]
        private IWebElement _inquerySearch;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[7]/a/label")]
        private IWebElement _search;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[7]/div[1]/a/label")]
        private IWebElement _advancedSearch;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[7]/div[2]/a/label")]
        private IWebElement _inquiry;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[8]/a/label")]
        private IWebElement _tools;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[8]/div/a/label")]
        private IWebElement _worldTimes;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[9]/a/label")]
        private IWebElement _management;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[9]/div[1]/a/label")]
        private IWebElement _configuration;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[9]/div[2]/a/label")]
        private IWebElement _news;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[9]/div[3]/a/label")]
        private IWebElement _changeMasterHash;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[10]/a/label")]
        private IWebElement _userSettings;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[10]/div[1]/a/label")]
        private IWebElement _autoForwarding;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[10]/div[2]/a/label")]
        private IWebElement _userGroups;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[10]/div[3]/a/label")]
        private IWebElement _templates;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[11]/a/label")]
        private IWebElement _signOut;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Yes']")]
        private IWebElement _yesBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'No']")]
        private IWebElement _noBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div/div[2]/a")]
        private IWebElement _lookups;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div/div[2]/div[2]/a")]
        private IWebElement _departmentSettings;

        public IList<IWebElement> _deptNames() {
            return _driver.FindElements(By.XPath(".//*[@id='organizationDocumentsDiv']/div/a/label"));
        }

        public LeftMenu(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void Signout(IWebDriver driver)
        {
            Click(driver, _signOut);
            Click(driver, _yesBtn);
        }

        public void NavigateToUserManager(IWebDriver driver)
        {
            if (!GetAttribute(driver, _systemManagementMainDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _systemManagementMain);
                ClickForNavigation(driver, _systemManagement);
            }
            ClickForNavigation(driver, _userManager);
            Thread.Sleep(1000);
        }

        public void NavigateToMyMessage(IWebDriver driver) {
            if (!GetAttribute(driver, _myMessagesMenuDiv, "class").Contains("active")) {
                ClickForNavigation(driver, _myMessages);
                Thread.Sleep(1000);
            }
        }

        public void NavigateToMyMessageInbox(IWebDriver driver)
        {
            NavigateToMyMessage(driver);
            ClickForNavigation(driver, _myMessageInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToMyMessageDeletedF(IWebDriver driver)
        {
            NavigateToMyMessage(driver);
            ClickForNavigation(driver, _myMessageDeleted);
            Thread.Sleep(1000);
        }

        public void NavigateToMyMessageArchiveF(IWebDriver driver)
        {
            NavigateToMyMessage(driver);
            ClickForNavigation(driver, _myMessageArchived);
            Thread.Sleep(1000);
        }

        public void NavigateToMyMessageOutbox(IWebDriver driver)
        {
            NavigateToMyMessage(driver);
            ClickForNavigation(driver, _myMessageOutbox);
            Thread.Sleep(1000);
        }

        public void NavigateToQAAutomation111DeptInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                Thread.Sleep(2000);
                ClickForNavigation(driver, _departmentMessages);
            }
            Thread.Sleep(2000);
            if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDept);
            }
            Thread.Sleep(2000);
            ClickForNavigation(driver, _automation111DeptInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToQAAutomation222DeptInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDept);
            }
            if (!GetAttribute(driver, _departmentInboxMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _expandFolder111);
                ClickForNavigation(driver, _automation111Dropdown);
            }
            ClickForNavigation(driver, _automation222DeptInbox);
            Thread.Sleep(1000);
        }
        
        public void NavigateToAuditDeptInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAuditMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _auditDept);
            }
            ClickForNavigation(driver, _auditDeptInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToAuditDeptOutbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAuditMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _auditDept);
            }
            ClickForNavigation(driver, _auditDeptOutbox);
            Thread.Sleep(1000);
        }
        
        public void NavigateToSaudiAffairsDeptInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentSaudiAffairsMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _saudiAffairDept);
            }
            ClickForNavigation(driver, _saudiAffairstDeptInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToSaudiAffairsDeptOutbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentSaudiAffairsMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _saudiAffairDept);
            }
            ClickForNavigation(driver, _saudiAffairstDeptOutbox);
            Thread.Sleep(1000);
        }

        public void NavigateToAccountingDeptInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAccountMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _accountingDept);
            }
            ClickForNavigation(driver, _accountingDeptInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToAccountingDeptOutbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAccountMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _accountingDept);
            }
            ClickForNavigation(driver, _accountingDeptOutbox);
            Thread.Sleep(1000);
        }

        public void NavigateToMessageDeliveryStatementReport(IWebDriver driver)
        {
            if (!GetAttribute(driver, _MessagesMenuDiv, "class").Contains("active"))
            {
                Thread.Sleep(2000);
                ClickForNavigation(driver, _MessagesTab);
            }
            Thread.Sleep(2000);
            ClickForNavigation(driver, _DeliveryStatementReportTab);
            Thread.Sleep(2000);
        }

        public void NavigateToQADeptInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDept);
            }
            ClickForNavigation(driver, _qaDeptInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToQADeptDeletedFolder(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDept);
            }
            ClickForNavigation(driver, _qaDeptDeletedF);
            Thread.Sleep(1000);
        }

        public void NavigateToQADeptArchiveFolder(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDept);
            }
            ClickForNavigation(driver, _qaDeptArchivedF);
            Thread.Sleep(1000);
        }

        public void NavigateToQADeptOutbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _qaDeptMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDept);
            }
            ClickForNavigation(driver, _qaDeptOutbox);
            Thread.Sleep(1000);
        }

        public void NavigateToMessageRoot(IWebDriver driver, string CommDept="")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDept);
            }
            ClickForNavigation(driver, _inboxMessageWithRoot);
            Thread.Sleep(1000);
        }

        public void NavigateToCommDeptOutbox(IWebDriver driver, string CommDept="")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDept);
            }
            Thread.Sleep(1500);
            ClickForNavigation(driver, _commDeptOutbox);
            Thread.Sleep(1000);
        }


        public void NavigateToCommDeptExportF(IWebDriver driver, string CommDept="")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDept);
            }
            Thread.Sleep(3000);
            ClickForNavigation(driver, _commDeptExported);
            Thread.Sleep(1000);
        }

        public void NavigateToCommDeptArchiveF(IWebDriver driver, string CommDept="")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDept);
            }
            ClickForNavigation(driver, _commDeptArchivedF);
            Thread.Sleep(1000);
        }

        public void NavigateToCommDeptDeleteF(IWebDriver driver, string CommDept="")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDept);
            }
            ClickForNavigation(driver, _commDeptDeleteF);
            Thread.Sleep(1000);
        }

        public void NavigateToSearchAdvance(IWebDriver driver)
        {
            if (GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _searchMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _Search);
            }
            Thread.Sleep(1000);
            ClickForNavigation(driver, _advanceSearch);
            Thread.Sleep(1000);
        }

        public void NavigateToSearchInquiry(IWebDriver driver)
        {
            if (GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _searchMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _Search);
            }
            Thread.Sleep(1000);
            ClickForNavigation(driver, _inquerySearch);
            Thread.Sleep(1000);
        }

        public void NavigateToDepartmentSettings(IWebDriver driver)
        {
            if (!GetAttribute(driver, _systemManagementMainDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _systemManagementMain);
                ClickForNavigation(driver, _lookups);
            }
            ClickForNavigation(driver, _departmentSettings);
            Thread.Sleep(1000);
        }
    }
}
