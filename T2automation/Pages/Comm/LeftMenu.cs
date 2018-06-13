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
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub63635a60-776d-467d-9189-7997294e747f']")]
        private IWebElement _departmentQAMenuDivNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub3c76399d-2a03-4b67-9459-8a0925263d2e']/div[@id='folder-0-3c76399d-2a03-4b67-9459-8a0925263d2e']")]
        private IWebElement _departmentInboxMenuDiv;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub644dc7d2-f626-4abf-851f-8395d8a79674']")]
        private IWebElement _departmentAccountMenuDiv;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub2738404b-d625-4dfa-af82-419a13e27d0e']")]
        private IWebElement _departmentAccountMenuDivNew;

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
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub3b54cf4b-9926-4370-9e98-c36265908c38']")]
        private IWebElement _commDeptMenuDivNew;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSubdd8ca884-0b05-4de6-900d-af5fc9623558']/a/label")]
        private IWebElement _commDept;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub3b54cf4b-9926-4370-9e98-c36265908c38']/a/label")]
        private IWebElement _commDeptNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub644dc7d2-f626-4abf-851f-8395d8a79674']/a")]
        private IWebElement _accountingDept;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub2738404b-d625-4dfa-af82-419a13e27d0e']/a")]
        private IWebElement _accountingDeptNew;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSubdf82bbee-44d8-4d77-9b5b-92763d4362e9']/a")]
        private IWebElement _auditDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub8cd8b29d-b115-4e18-a313-6d31a661bce1']/a")]
        private IWebElement _saudiAffairDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-644dc7d2-f626-4abf-851f-8395d8a79674']/a/label")]
        private IWebElement _accountingDeptInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-2738404b-d625-4dfa-af82-419a13e27d0e']/a/label")]
        private IWebElement _accountingDeptInboxNew;

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

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-2738404b-d625-4dfa-af82-419a13e27d0e']/a[@data-folder-flag='5']/label")]
        private IWebElement _accountingDeptOutboxNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-df82bbee-44d8-4d77-9b5b-92763d4362e9']/a[@class='o-folder'][@data-folder-flag='5']")]
        private IWebElement _auditDeptOutbox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-8cd8b29d-b115-4e18-a313-6d31a661bce1']/a[@data-folder-flag='5']")]
        private IWebElement _saudiAffairstDeptOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a/label")]
        private IWebElement _accountingDeptDeletedF;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label")]
        private IWebElement _qaDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub63635a60-776d-467d-9189-7997294e747f']/a/label")]
        private IWebElement _qaDeptNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[3]/a/label")]
        private IWebElement _DeliveryStatementReportTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label")]
        private IWebElement _qaDeptInbox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-63635a60-776d-467d-9189-7997294e747f']/a/label")]
        private IWebElement _qaDeptInboxNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label/i[@class='fa fa-trash-o']")]
        private IWebElement _qaDeptDeletedF;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-63635a60-776d-467d-9189-7997294e747f']/a/label/i[@class='fa fa-trash-o']")]
        private IWebElement _qaDeptDeletedFNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3c76399d-2a03-4b67-9459-8a0925263d2e']/a[@data-folder-flag='3']")]
        private IWebElement _qaDeptArchivedF;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-63635a60-776d-467d-9189-7997294e747f']/a/label/i[@class='fa fa-archive']")]
        private IWebElement _qaDeptArchivedFNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label")]
        private IWebElement _qaDeptOutbox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-63635a60-776d-467d-9189-7997294e747f']/a[@data-folder-flag='5']/label")]
        private IWebElement _qaDeptOutboxNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@data-folder-flag='0']")]
        private IWebElement _inboxMessageWithRoot;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3b54cf4b-9926-4370-9e98-c36265908c38']/a[@data-folder-flag='0']/label")]
        private IWebElement _inboxMessageWithRootNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@class='o-folder'][@data-folder-flag='5']")]
        private IWebElement _commDeptOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3b54cf4b-9926-4370-9e98-c36265908c38']/a[@data-folder-flag='5']/label")]
        private IWebElement _commDeptOutboxNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@class='o-folder'][@data-folder-flag='9']")]
        private IWebElement _commDeptExported;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3b54cf4b-9926-4370-9e98-c36265908c38']/a[@data-folder-flag='9']/label")]
        private IWebElement _commDeptExportedNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@data-folder-flag='3']")]
        private IWebElement _commDeptArchivedF;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3b54cf4b-9926-4370-9e98-c36265908c38']/a[@data-folder-flag='3']/label")]
        private IWebElement _commDeptArchivedFNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-dd8ca884-0b05-4de6-900d-af5fc9623558']/a[@data-folder-flag='4']")]
        private IWebElement _commDeptDeleteF;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3b54cf4b-9926-4370-9e98-c36265908c38']/a[@data-folder-flag='4']/label")]
        private IWebElement _commDeptDeleteFNew;

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

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div/a/label/i[contains(@class,'fa fa-users')]")]
        private IWebElement _announcementsGroup;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub63635a60-776d-467d-9189-7997294e747f']")]
        private IWebElement _departmentAutoInternalMenuDiv;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSub63635a60-776d-467d-9189-7997294e747f']/a")]
        private IWebElement _autoInternalDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-63635a60-776d-467d-9189-7997294e747f']/a")]
        private IWebElement _autoInternalInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-63635a60-776d-467d-9189-7997294e747f']/a[@class='o-folder'][@data-folder-flag=5]")]
        private IWebElement _autoInternalDeptOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSubbfbb40b4-d039-422f-acc5-66c7515db372']")]
        private IWebElement _departmentAutoChildOutsideMenuDiv;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSubbfbb40b4-d039-422f-acc5-66c7515db372']/a")]
        private IWebElement _autoChildOutsideDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-bfbb40b4-d039-422f-acc5-66c7515db372']/a/label")]
        private IWebElement _autoChildOutsideInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSubb8dd1ab5-679f-426a-a678-fba4222c7d61']")]
        private IWebElement _departmentAutoInternalOutsideMenuDiv;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSubb8dd1ab5-679f-426a-a678-fba4222c7d61']/a")]
        private IWebElement _autoInternalOutsideDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-b8dd1ab5-679f-426a-a678-fba4222c7d61']/a")]
        private IWebElement _autoInternalOutsideInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSubbfbb40b4-d039-422f-acc5-66c7515db372']")]
        private IWebElement _departmentAutoChildMenuDiv;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSubbfbb40b4-d039-422f-acc5-66c7515db372']/a")]
        private IWebElement _autoChildDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-bfbb40b4-d039-422f-acc5-66c7515db372']/a/label")]
        private IWebElement _autoChildInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDivSub8230198f-7d27-4d2b-ad0a-f3dd10dd51fc']")]
        private IWebElement _departmentForbiddenMenuDiv;

        [FindsBy(How = How.XPath, Using = "//*[@id='organizationDocumentsDivSub8230198f-7d27-4d2b-ad0a-f3dd10dd51fc']/a")]
        private IWebElement _forbiddenDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-8230198f-7d27-4d2b-ad0a-f3dd10dd51fc']/a/label")]
        private IWebElement _forbiddenDeptInbox;


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

        public void NavigateToMyMessage(IWebDriver driver)
        {
            if (!GetAttribute(driver, _myMessagesMenuDiv, "class").Contains("active"))
            {
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
            if (!GetAttribute(driver, _departmentAccountMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _accountingDeptNew);
            }
            ClickForNavigation(driver, _accountingDeptInboxNew);
            Thread.Sleep(1000);
        }

        public void NavigateToAccountingDeptOutbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAccountMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _accountingDeptNew);
            }
            ClickForNavigation(driver, _accountingDeptOutboxNew);
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
            Thread.Sleep(2000);
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentQAMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDeptNew);
            }
            ClickForNavigation(driver, _qaDeptInboxNew);
            Thread.Sleep(1000);
        }

        public void NavigateToQADeptDeletedFolder(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentQAMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDeptNew);
            }
            ClickForNavigation(driver, _qaDeptDeletedFNew);
            Thread.Sleep(1000);
        }

        public void NavigateToQADeptArchiveFolder(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentQAMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDeptNew);
            }
            ClickForNavigation(driver, _qaDeptArchivedFNew);
            Thread.Sleep(1000);
        }

        public void NavigateToQADeptOutbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _departmentQAMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _qaDeptNew);
            }
            ClickForNavigation(driver, _qaDeptOutboxNew);
            Thread.Sleep(1000);
        }

        public void NavigateToMessageRoot(IWebDriver driver, string CommDept = "")
        {
            Thread.Sleep(2000);
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDeptNew);
            }
            Thread.Sleep(2000);
            ClickForNavigation(driver, _inboxMessageWithRootNew);
            Thread.Sleep(1000);
        }

        public void NavigateToCommDeptOutbox(IWebDriver driver, string CommDept = "")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDeptNew);
            }
            Thread.Sleep(1500);
            ClickForNavigation(driver, _commDeptOutboxNew);
            Thread.Sleep(1000);
        }


        public void NavigateToCommDeptExportF(IWebDriver driver, string CommDept = "")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDeptNew);
            }
            Thread.Sleep(3000);
            ClickForNavigation(driver, _commDeptExportedNew);
            Thread.Sleep(1000);
        }

        public void NavigateToCommDeptArchiveF(IWebDriver driver, string CommDept = "")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDeptNew);
            }
            ClickForNavigation(driver, _commDeptArchivedFNew);
            Thread.Sleep(1000);
        }

        public void NavigateToCommDeptDeleteF(IWebDriver driver, string CommDept = "")
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }

            if (!GetAttribute(driver, _commDeptMenuDivNew, "class").Contains("active"))
            {
                ClickForNavigation(driver, _commDeptNew);
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

        public void NavigateToAnnouncementGroup(IWebDriver driver)
        {
            if (!GetAttribute(driver, _systemManagementMainDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _systemManagementMain);
                ClickForNavigation(driver, _systemManagement);
            }
            ClickForNavigation(driver, _announcementsGroup);
            Thread.Sleep(1000);
        }

        public void NavigateToAutoInternalDeptOutbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAutoInternalMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _autoInternalDept);
            }
            ClickForNavigation(driver, _autoInternalDeptOutbox);
            Thread.Sleep(1000);
        }

        public void NavigateToAutoChildOutsideInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAutoChildOutsideMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _autoChildOutsideDept);
            }
            ClickForNavigation(driver, _autoChildOutsideInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToAutoInternalOutsideInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAutoInternalOutsideMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _autoInternalOutsideDept);
            }
            ClickForNavigation(driver, _autoInternalOutsideInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToAutoChildInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAutoChildMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _autoChildDept);
            }
            ClickForNavigation(driver, _autoChildInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToAutoInternalDeptInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentAutoInternalMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _autoInternalDept);
            }
            ClickForNavigation(driver, _autoInternalInbox);
            Thread.Sleep(1000);
        }

        public void NavigateToForbiddenDeptInbox(IWebDriver driver)
        {
            if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _departmentMessages);
            }
            if (!GetAttribute(driver, _departmentForbiddenMenuDiv, "class").Contains("active"))
            {
                ClickForNavigation(driver, _forbiddenDept);
            }
            ClickForNavigation(driver, _forbiddenDeptInbox);
            Thread.Sleep(1000);
        }

        //public void NavigateToUserManager(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _systemManagementMainDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _systemManagementMain);
        //        ClickForNavigation(driver, _systemManagement);
        //    }
        //    ClickForNavigation(driver, _userManager);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToMyMessage(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _myMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _myMessages);
        //        Thread.Sleep(1000);
        //    }
        //}

        //public void NavigateToMyMessageInbox(IWebDriver driver)
        //{
        //    NavigateToMyMessage(driver);
        //    ClickForNavigation(driver, _myMessageInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToMyMessageDeletedF(IWebDriver driver)
        //{
        //    NavigateToMyMessage(driver);
        //    ClickForNavigation(driver, _myMessageDeleted);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToMyMessageArchiveF(IWebDriver driver)
        //{
        //    NavigateToMyMessage(driver);
        //    ClickForNavigation(driver, _myMessageArchived);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToMyMessageOutbox(IWebDriver driver)
        //{
        //    NavigateToMyMessage(driver);
        //    ClickForNavigation(driver, _myMessageOutbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToQAAutomation111DeptInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        Thread.Sleep(2000);
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    Thread.Sleep(2000);
        //    if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _qaDept);
        //    }
        //    Thread.Sleep(2000);
        //    ClickForNavigation(driver, _automation111DeptInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToQAAutomation222DeptInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _qaDept);
        //    }
        //    if (!GetAttribute(driver, _departmentInboxMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _expandFolder111);
        //        ClickForNavigation(driver, _automation111Dropdown);
        //    }
        //    ClickForNavigation(driver, _automation222DeptInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAuditDeptInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAuditMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _auditDept);
        //    }
        //    ClickForNavigation(driver, _auditDeptInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAuditDeptOutbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAuditMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _auditDept);
        //    }
        //    ClickForNavigation(driver, _auditDeptOutbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToSaudiAffairsDeptInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentSaudiAffairsMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _saudiAffairDept);
        //    }
        //    ClickForNavigation(driver, _saudiAffairstDeptInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToSaudiAffairsDeptOutbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentSaudiAffairsMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _saudiAffairDept);
        //    }
        //    ClickForNavigation(driver, _saudiAffairstDeptOutbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAccountingDeptInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAccountMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _accountingDept);
        //    }
        //    ClickForNavigation(driver, _accountingDeptInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAccountingDeptOutbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAccountMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _accountingDept);
        //    }
        //    ClickForNavigation(driver, _accountingDeptOutbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToMessageDeliveryStatementReport(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _MessagesMenuDiv, "class").Contains("active"))
        //    {
        //        Thread.Sleep(2000);
        //        ClickForNavigation(driver, _MessagesTab);
        //    }
        //    Thread.Sleep(2000);
        //    ClickForNavigation(driver, _DeliveryStatementReportTab);
        //    Thread.Sleep(2000);
        //}

        //public void NavigateToQADeptInbox(IWebDriver driver)
        //{
        //    Thread.Sleep(2000);
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _qaDept);
        //    }
        //    ClickForNavigation(driver, _qaDeptInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToQADeptDeletedFolder(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _qaDept);
        //    }
        //    ClickForNavigation(driver, _qaDeptDeletedF);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToQADeptArchiveFolder(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentQAMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _qaDept);
        //    }
        //    ClickForNavigation(driver, _qaDeptArchivedF);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToQADeptOutbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }

        //    if (!GetAttribute(driver, _qaDeptMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _qaDept);
        //    }
        //    ClickForNavigation(driver, _qaDeptOutbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToMessageRoot(IWebDriver driver, string CommDept = "")
        //{
        //    Thread.Sleep(2000);
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }

        //    if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _commDept);
        //    }
        //    Thread.Sleep(2000);
        //    ClickForNavigation(driver, _inboxMessageWithRoot);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToCommDeptOutbox(IWebDriver driver, string CommDept = "")
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }

        //    if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _commDept);
        //    }
        //    Thread.Sleep(1500);
        //    ClickForNavigation(driver, _commDeptOutbox);
        //    Thread.Sleep(1000);
        //}


        //public void NavigateToCommDeptExportF(IWebDriver driver, string CommDept = "")
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }

        //    if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _commDept);
        //    }
        //    Thread.Sleep(3000);
        //    ClickForNavigation(driver, _commDeptExported);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToCommDeptArchiveF(IWebDriver driver, string CommDept = "")
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }

        //    if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _commDept);
        //    }
        //    ClickForNavigation(driver, _commDeptArchivedF);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToCommDeptDeleteF(IWebDriver driver, string CommDept = "")
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }

        //    if (!GetAttribute(driver, _commDeptMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _commDept);
        //    }
        //    ClickForNavigation(driver, _commDeptDeleteF);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToSearchAdvance(IWebDriver driver)
        //{
        //    if (GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _searchMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _Search);
        //    }
        //    Thread.Sleep(1000);
        //    ClickForNavigation(driver, _advanceSearch);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToSearchInquiry(IWebDriver driver)
        //{
        //    if (GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _searchMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _Search);
        //    }
        //    Thread.Sleep(1000);
        //    ClickForNavigation(driver, _inquerySearch);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToDepartmentSettings(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _systemManagementMainDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _systemManagementMain);
        //        ClickForNavigation(driver, _lookups);
        //    }
        //    ClickForNavigation(driver, _departmentSettings);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAnnouncementGroup(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _systemManagementMainDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _systemManagementMain);
        //        ClickForNavigation(driver, _systemManagement);
        //    }
        //    ClickForNavigation(driver, _announcementsGroup);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAutoInternalDeptOutbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAutoInternalMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _autoInternalDept);
        //    }
        //    ClickForNavigation(driver, _autoInternalDeptOutbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAutoChildOutsideInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAutoChildOutsideMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _autoChildOutsideDept);
        //    }
        //    ClickForNavigation(driver, _autoChildOutsideInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAutoInternalOutsideInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAutoInternalOutsideMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _autoInternalOutsideDept);
        //    }
        //    ClickForNavigation(driver, _autoInternalOutsideInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAutoChildInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAutoChildMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _autoChildDept);
        //    }
        //    ClickForNavigation(driver, _autoChildInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToAutoInternalDeptInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentAutoInternalMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _autoInternalDept);
        //    }
        //    ClickForNavigation(driver, _autoInternalInbox);
        //    Thread.Sleep(1000);
        //}

        //public void NavigateToForbiddenDeptInbox(IWebDriver driver)
        //{
        //    if (!GetAttribute(driver, _departmentMessagesMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _departmentMessages);
        //    }
        //    if (!GetAttribute(driver, _departmentForbiddenMenuDiv, "class").Contains("active"))
        //    {
        //        ClickForNavigation(driver, _forbiddenDept);
        //    }
        //    ClickForNavigation(driver, _forbiddenDeptInbox);
        //    Thread.Sleep(1000);
        //}

    }
}
