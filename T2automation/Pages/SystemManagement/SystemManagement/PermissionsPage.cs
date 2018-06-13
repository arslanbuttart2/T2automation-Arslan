using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Pages.Comm;

namespace T2automation.Pages.SystemManagement.SystemManagement
{
    class PermissionsPage : LeftMenu
    {
        protected readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[1]/a")]
        private IWebElement _userPermissionOnSystem;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[2]/a")]
        private IWebElement _userPermissionOnDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[3]/a")]
        private IWebElement _sendingPermissions;

        [FindsBy(How = How.Id, Using = "btnIncludeException")]
        private IWebElement _systemIncludeList;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div[2]/div[2]/div[4]/div[1]/div[3]/a")]
        private IWebElement _systemUserSendingPermisionTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'System Settings']/../span[1]")]
        private IWebElement _expandSystemSettings;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'System Management']/../span[1]")]
        private IWebElement _expandSystemManagement;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'Message Permission']/../span[1]")]
        private IWebElement _expandMessagePermission;

        [FindsBy(How = How.XPath, Using = "//*[@id='chkbxSendAllDepartments']")]
        private IWebElement _SendAllDeptPermissionChkbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSave']")]
        private IWebElement _saveBtnForPermissionTab;

        [FindsBy(How = How.XPath, Using = "//*[@id='chkbxSendAllUsers']")]
        private IWebElement _SendAllUserPermissionChkbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']//a[text() = 'View Related Messages']/../span[1]")]
        private IWebElement _expandViewRelatedMessagePermission;

        [FindsBy(How = How.XPath, Using = "//*[@id='divPermTree']/ul/li[3]/ul/li[20]/span/span[1]")]
        private IWebElement _expandViewRelatedPersonPermission;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']//a[text() = 'Add Related Message']/../span[1]")]
        private IWebElement _expandAddRelatedMessagePermission;
                                            
        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']//a[text() = 'Add Related Message']/../span[1]")]
        private IWebElement _expandDeptAddRelatedMessagePermission;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[16]/span/span[1]")]
        private IWebElement _expandDeptRetreiveMessagePermission;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[17]/span/span[1]")]
        private IWebElement _expandDeptViewPersonMessagePermission;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span")]
        private IList<IWebElement> _systemMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span/a")]
        private IList<IWebElement> _systemMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span/span[2]")]
        private IList<IWebElement> _selectSystemMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/span")]
        private IList<IWebElement> _viewRelatedMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = "//*[@id='divPermTree']/ul/li[3]/ul/li[20]/ul/li/span")]
        private IList<IWebElement> _viewRelatedPersonPermissionsClass;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/span/a")]
        private IList<IWebElement> _viewRelatedMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/span/span[2]")]
        private IList<IWebElement> _viewRelatedMessagePermissionsCheckbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[1]/ul/li/span")]
        private IList<IWebElement> _deptViewRelatedMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[1]/ul/li/span/span[2]")]
        private IList<IWebElement> _deptViewRelatedMessagePermissionsCheckbox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/ul/li/span")]
        private IList<IWebElement> _addRelatedMessagePermissionsClass;
        
        [FindsBy(How = How.XPath, Using = ".//div[@id = 'divPermTree']/ul/li/ul/li/ul/li/ul/li/ul/li/span")]
        private IList<IWebElement> _deptAddRelatedMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[16]/ul/li/span")]
        private IList<IWebElement> _deptRetreiveMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[17]/ul/li/span")]
        private IList<IWebElement> _deptAddPersonMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/ul/li/span/a")]
        private IList<IWebElement> _addRelatedMessagePermissions;

        [FindsBy(How = How.XPath, Using = "//*[@id='divPermTree']/ul/li[3]/ul/li[20]/ul/li/span/a")]
        private IList<IWebElement> _viewRelatedPersonPermission; 

        [FindsBy(How = How.XPath, Using = ".//div[@id = 'divPermTree']/ul/li/ul/li/ul/li/ul/li/ul/li/span/a")]
        private IList<IWebElement> _deptAddRelatedMessagePermissions;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[16]/ul/li/span/a")]
        private IList<IWebElement> _deptRetreiveMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[17]/ul/li/span/a")]
        private IList<IWebElement> _deptAddPersonMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/ul/li/span/span[2]")]
        private IList<IWebElement> _addRelatedMessagePermissionsCheckbox;
       
        [FindsBy(How = How.XPath, Using = " //*[@id='divPermTree']/ul/li[3]/ul/li[20]/ul/li/span/span[2]")]
        private IList<IWebElement> _viewRelatedPersonPermissionsCheckbox;

        [FindsBy(How = How.XPath, Using = ".//div[@id = 'divPermTree']/ul/li/ul/li/ul/li/ul/li/ul/li/span/span[2]")]
        private IList<IWebElement> _deptAddRelatedMessagePermissionsCheckbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[16]/ul/li/span/span[2]")]
        private IList<IWebElement> _deptRetreiveMessagePermissionsCheckbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[17]/ul/li/span/span[2]")]
        private IList<IWebElement> _deptAddpersonMessagePermissionsCheckbox;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Ok']")]
        private IWebElement _okBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Cancel']")]
        private IWebElement _cancelBtn;

        [FindsBy(How = How.XPath, Using = "html/body/div/div/div/div/button[3]")]
        private IWebElement _crossBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Yes']")]
        private IWebElement _yesBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'No']")]
        private IWebElement _noBtn;

        [FindsBy(How = How.Id, Using = "btnExcludeException")]
        private IWebElement _systemExcludeList;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='txtSearchFavGroup']")]
        private IWebElement _userGroupSearchTab;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='searchTextOrganization']")]
        private IWebElement _organizationSearchTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divAddFavGroupGrid']/tbody/tr/td[2]")]
        private IList<IWebElement> _userGroupSearchResult;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationListGrid']/tbody/tr/td[2]")]
        private IList<IWebElement> _organizationSearchResult;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divAddFavGroupGrid']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _userGroupSearchResultChkBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationListGrid']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _organizationSearchResultChkBox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='selectedOrganizationDivBtn']/input")]
        private IWebElement _organizationAddBtnSearchResult;

        [FindsBy(How = How.XPath, Using = ".//*[@id='favGroupList']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _sendndingPermissionAllPermissionListChkBox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='departmentsExcludeList']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _sendndingPermissionAllOrgExceptListChkBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtSearchGroup']")]
        private IWebElement _announcementGroupsSearchTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divAddGroupGrid']/tbody/tr/td[2]")]
        private IList<IWebElement> _announcementGroupsSearchResult;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divAddGroupGrid']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _announcementGroupsSearchResultChkBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnDeleteSendFavGroup']")]
        private IWebElement _sendndingPermissionAllPermissionListDeleteBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnDeleteExcludedDepartments']")]
        private IWebElement _sendndingPermissionAllOrgExceptListDeleteBtn;

        [FindsBy(How = How.Id, Using = "btnViewResult")]
        private IWebElement _viewSystemPermissionResult;

        [FindsBy(How = How.Id, Using = "txtUserRoleSearch")]
        private IWebElement _systemSearch;

        [FindsBy(How = How.Id, Using = "AddbuttondivUserRoleGrid")]
        private IWebElement _addNewBtn;

        [FindsBy(How = How.Id, Using = "buttondivUserRoleGrid")]
        private IWebElement _deleteBtn;

        [FindsBy(How = How.Id, Using = "btnUopViewResult")]
        private IWebElement _viewDeptPermissionResult;

        [FindsBy(How = How.Id, Using = "txtUserOrganizationRoleSearch")]
        private IWebElement _deptSearch;

        [FindsBy(How = How.XPath, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[1]")]
        private IList<IWebElement> _deptName;

        [FindsBy(How = How.Id, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[2]")]
        private IList<IWebElement> _deptPriSec;

        [FindsBy(How = How.Id, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[3]")]
        private IList<IWebElement> _deptRoleName;

        //[FindsBy(How = How.Id, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[4]")]
        //private IList<IWebElement> _deptIncludeList;

        [FindsBy(How = How.Id, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[5]")]
        private IList<IWebElement> _deptExcludeList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/span")]
        private IWebElement _expandDepartmant;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li/span/a[text() = 'Department Messaging Permissions']/../span")]
        private IWebElement _expandDeptMessagingPermissions;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='chkbxSendFavGroup']")]
        private IWebElement _userGroupsDeptSendingPermissionsChkbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='chkbxSendExceptDepartments']")]
        private IWebElement _allOrgExceptDeptSendingPermissionsChkbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnAddSendFavGroup']")]
        private IWebElement _userGroupsAddBtnDeptSendingPermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='chkbxSendAnnounGroup']")]
        private IWebElement _announcementGroupsDeptSendingPermissionsChkbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnExcludeDepartment']")]
        private IWebElement _allOrgExceptAddBtnDeptSendingPermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='chkbxSendAllDepartments']")]
        private IWebElement _sendAllDeptSendingPermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnSave']")]
        private IWebElement _saveBtnDeptSendingPermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li/span")]
        private IList<IWebElement> _deptMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li/span/a")]
        private IList<IWebElement> _deptMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li/span/span[2]")]
        private IList<IWebElement> _selectDeptMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnAddSendAnnounGroup']")]
        private IWebElement _announcementGroupsAddBtnDeptSendingPermissions;

        public string title = "Permissions - Ole5.1";

        public PermissionsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        
        private IList<IWebElement> _deptSendingMessagePermissions()
        {
            return _driver.FindElements(By.XPath(".//*[@id='divSpMain']/div[1]/div/div/div/div/label"));
        }

        private IList<IWebElement> _deptViewRelatedMessagePermissions()
        {
            return _driver.FindElements(By.XPath(".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[1]/ul/li/span/a"));
        }

        private IList<IWebElement> _deptIncludeList(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='userDepartmentTable']/tbody/tr/td[4]"));
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[6]/a")]
        private IList<IWebElement> _deptSendingPermissions2;

        private IList<IWebElement> _deptSendingPermissions(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='userDepartmentTable']/tbody/tr/td[6]/a"));
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='announGroupList']/tbody/tr/td[1]/label")]
        private IWebElement _announcementGroupsPermissionsChkbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnDeleteSendAnnounGroup']")]
        private IWebElement _deleteSendAnnounGroup;

        [FindsBy(How = How.XPath, Using = "//*[@id='chkbxSendAnnounGroup']")]
        private IWebElement _AnnouncementGroupsChkbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='announGroupList']/tbody/tr/td[2]")]
        private IWebElement _announcementGroupsSendingPermissions;

        private IWebElement _saveBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Save']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Save']"));
        }

        public void chkAnnouncementGroupsBox(IWebDriver driver)
        {
            if (!_AnnouncementGroupsChkbox.Selected)
            {
                Click(driver, _AnnouncementGroupsChkbox);
            }
        }

        public void unChkAnnouncementGroupsBox(IWebDriver driver)
        {
            if (_AnnouncementGroupsChkbox.Selected)
            {
                Click(driver, _AnnouncementGroupsChkbox);
            }
        }

        public void _ifOkBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Ok']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    elem.Click();
                }
            }
        }

        public void _ifSaveBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Save']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    elem.Click();
                }
            }
        }

        public void SearchDept(IWebDriver driver, string text) {
            SendKeys(driver, _deptSearch, text);
            Thread.Sleep(5000);
        }

        public void IncludeSystemMessagePermissions(IWebDriver driver, string permissionName, bool value)
        {
            Click(driver, _systemIncludeList);
            Click(driver, _expandMessagePermission);
            if (permissionName.Equals("Add Related Message") || permissionName.Equals("Remove Related Messages") || permissionName.Equals("Open Related Messages"))
            {
                Click(driver, _expandViewRelatedMessagePermission);
                for (int index = 0; index < _viewRelatedMessagePermissions.Count; index++)
                {
                    if (GetText(driver, _viewRelatedMessagePermissions.ElementAt(index)).Equals(permissionName))
                    {
                        if (GetAttribute(driver, _viewRelatedMessagePermissionsClass.ElementAt(index), "class").Contains("selected") != value)
                        {
                            Click(driver, _viewRelatedMessagePermissionsCheckbox.ElementAt(index));
                            Click(driver, _okBtn);
                            Click(driver, _yesBtn);
                            return;
                        }
                        Click(driver, _cancelBtn);
                        return;
                    }
                }
            }
            else if (permissionName.Contains("Can Link"))
            {
                Click(driver, _expandViewRelatedMessagePermission);
                Click(driver, _expandAddRelatedMessagePermission);

                for (int index = 0; index < _addRelatedMessagePermissions.Count; index++)
                {
                    if (GetText(driver, _addRelatedMessagePermissions.ElementAt(index)).Equals(permissionName))
                    {
                        if (GetAttribute(driver, _addRelatedMessagePermissionsClass.ElementAt(index), "class").Contains("selected") != value)
                        {
                            Click(driver, _addRelatedMessagePermissionsCheckbox.ElementAt(index));
                            Click(driver, _okBtn);
                            Click(driver, _yesBtn);
                            return;
                        }
                        Click(driver, _cancelBtn);
                        return;
                    }
                }
            }
            else if (permissionName.Contains("Add Related Person"))
            {
                Click(driver, _expandViewRelatedPersonPermission);
                for (int index = 0; index < _viewRelatedPersonPermission.Count; index++)
                {
                    if (GetText(driver, _viewRelatedPersonPermission.ElementAt(index)).Equals(permissionName))
                    {
                        if (GetAttribute(driver, _viewRelatedPersonPermissionsClass.ElementAt(index), "class").Contains("selected") != value)
                        {
                            Click(driver, _viewRelatedPersonPermissionsCheckbox.ElementAt(index));
                            Click(driver, _okBtn);
                            Click(driver, _yesBtn);
                            return;
                        }
                        Click(driver, _cancelBtn);
                        return;
                    }
                }
            }
            else
            {
                for (int index = 0; index < _systemMessagePermissions.Count; index++)
                {
                    if (GetText(driver, _systemMessagePermissions.ElementAt(index)).Equals(permissionName))
                    {
                        if (GetAttribute(driver, _systemMessagePermissionsClass.ElementAt(index), "class").Contains("selected") != value)
                        {
                            Click(driver, _selectSystemMessagePermissions.ElementAt(index));
                            Click(driver, _okBtn);
                            Click(driver, _yesBtn);
                            break;
                        }
                        Click(driver, _cancelBtn);
                        return;
                    }
                }
            }
        }

        public void OpenSystemMessagePermissionsTabAndChk(IWebDriver driver, string chkbox)
        {
            Click(driver, _systemUserSendingPermisionTab);
            if (chkbox.Equals("Send All Users"))
            {
                chkSendAllUserBox(driver);
            }
            else if (chkbox.Equals("Send All Departments"))
            {
                chkSendAllDeptBox(driver);
            }
            Click(driver, _saveBtnForPermissionTab);

        }

        public void OpenSystemMessagePermissionsTabAndUnchk(IWebDriver driver, string chkbox)
        {
            Click(driver, _systemUserSendingPermisionTab);

            if (chkbox.Equals("Send All Users"))
            {
                unChkSendAllUserBox(driver);
            }
            else if (chkbox.Equals("Send All Departments"))
            {
                unChkSendAllDeptBox(driver);
            }

            Click(driver, _saveBtnForPermissionTab);

        }

        public void chkSendAllUserBox(IWebDriver driver)
        {
            if (!_SendAllUserPermissionChkbox.Selected)
            {
                Click(driver, _SendAllUserPermissionChkbox);
            }
        }
        public void unChkSendAllUserBox(IWebDriver driver)
        {
            if (_SendAllUserPermissionChkbox.Selected)
            {
                Click(driver, _SendAllUserPermissionChkbox);
            }
        }

        public void chkSendAllDeptBox(IWebDriver driver)
        {
            if (!_SendAllDeptPermissionChkbox.Selected)
            {
                Click(driver, _SendAllDeptPermissionChkbox);
            }
        }
        public void unChkSendAllDeptBox(IWebDriver driver)
        {
            if (_SendAllDeptPermissionChkbox.Selected)
            {
                Click(driver, _SendAllDeptPermissionChkbox);
            }
        }

        public void OpenSystemMessagePermissionsTab(IWebDriver driver, string chkbox, string permission)
        {
            Click(driver, _systemUserSendingPermisionTab);

            if (chkbox.Equals("Send To Announcement Groups") && permission.Equals("True"))
            {
                chkAnnouncementGroupsBox(driver);
                Thread.Sleep(2000);
            }

            else if (chkbox.Equals("Send To Announcement Groups") && permission.Equals("False"))
            {
                unChkAnnouncementGroupsBox(driver);
                Thread.Sleep(2000);
            }

            Click(driver, _saveBtnForPermissionTab);
        }

        public void IncludeDeptSendingMessagePermissions2(IWebDriver driver, string dept, string permissionName, bool value)
        {
            Click(driver, _userPermissionOnDept);
            SearchDept(driver, dept);
            for (int index = 0; index < _deptName.Count; index++)
            {
                if (GetText(driver, _deptName.ElementAt(index)).Equals(dept))
                {
                    //var _sendingPermission = _deptSendingPermissions(driver);
                    //Click(driver, _sendingPermission.ElementAt(index));

                    //I added this and commented above 2, because it was not clicking on sending permission. Xpath is same but approach is different                    
                    Click(driver, _deptSendingPermissions2.ElementAt(index));
                    Thread.Sleep(5000);

                    if (permissionName.Equals("Announcement Group 1"))
                    {
                        if (value == false)
                        {
                            try
                            {
                                Click(driver, _AnnouncementGroupsChkbox);
                                Thread.Sleep(2000);
                                Click(driver, _saveBtnForPermissionTab);
                                Thread.Sleep(3000);
                                return;


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);
                            }
                        }
                    }

                }
            }
        }

        public void IncludeDeptSendingMessagePermissions(IWebDriver driver, string dept, string permissionName, bool value)
        {
            Click(driver, _userPermissionOnDept);
            SearchDept(driver, dept);
            for (int index = 0; index < _deptName.Count; index++)
            {
                if (GetText(driver, _deptName.ElementAt(index)).Equals(dept))
                {
                    //Old not working!
                    //var _sendingPermission = _deptSendingPermissions(driver);
                    //Click(driver, _sendingPermission.ElementAt(index));
                    //New Working
                    Click(driver, _deptSendingPermissions2.ElementAt(index));
                    Thread.Sleep(5000);
                    
                    if(permissionName.Equals("User Groups"))
                    {
                        if (value == true)
                        {
                            try
                            {
                                if (_userGroupsAddBtnDeptSendingPermissions.Displayed)
                                {
                                    return;
                                }
                                else
                                {
                                    Click(driver, _userGroupsDeptSendingPermissionsChkbox);
                                    return;
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);
                            }
                        }
                        else if (value == false)
                        {
                            try
                            {
                                if (_userGroupsAddBtnDeptSendingPermissions.Displayed)
                                {
                                    Click(driver, _userGroupsDeptSendingPermissionsChkbox);
                                    return;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);
                            }
                        }
                    }

                    if (permissionName.Equals("Send All Departments"))
                    {
                        if (value == true)
                        {
                            try
                            {
                                if (_sendAllDeptSendingPermissions.Displayed)
                                {
                                    Click(driver, _sendAllDeptSendingPermissions);
                                    Click(_driver, _saveBtnDeptSendingPermissions);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Send All Department Is not visible");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);
                            }
                        }
                        else if (value == false)
                        {
                            try
                            {
                                if (_sendAllDeptSendingPermissions.Displayed)
                                {
                                    Click(driver, _sendAllDeptSendingPermissions);
                                    Click(_driver, _saveBtnDeptSendingPermissions);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Send All Department is not visible");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);
                            }
                        }
                    }

                    if (permissionName.Equals("Send to all organizations except"))
                    {
                        if (value == true)
                        {
                            try
                            {
                                if (_allOrgExceptAddBtnDeptSendingPermissions.Displayed)
                                {
                                    return;
                                }
                                else
                                {
                                    Click(driver, _allOrgExceptDeptSendingPermissionsChkbox);
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);
                            }
                        }
                        else if (value == false)
                        {
                            try
                            {
                                if (_allOrgExceptAddBtnDeptSendingPermissions.Displayed)
                                {
                                    Click(driver, _allOrgExceptDeptSendingPermissionsChkbox);
                                    return;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);
                            }
                        }
                    }

                    if (permissionName.Equals("Announcement Group 1"))
                    {
                        if (value == true)
                        {

                            try
                            {
                                if (_userGroupsAddBtnDeptSendingPermissions.Displayed)
                                {
                                    return;
                                }
                                else
                                {
                                    Click(driver, _announcementGroupsDeptSendingPermissionsChkbox);
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);
                            }
                        }
                        else if (value == false)
                        {
                            try
                            {
                                if (_announcementGroupsSendingPermissions.Displayed)
                                {
                                    Click(driver, _announcementGroupsPermissionsChkbox);
                                    Thread.Sleep(2000);
                                    Click(driver, _deleteSendAnnounGroup);
                                    Thread.Sleep(2000);
                                    Click(driver, _saveBtn());
                                    Thread.Sleep(2000);
                                    Click(driver, _AnnouncementGroupsChkbox);
                                    Thread.Sleep(2000);
                                    Click(driver, _saveBtnForPermissionTab);
                                    Thread.Sleep(3000);
                                    return;
                                }

                                else
                                {
                                    Click(driver, _AnnouncementGroupsChkbox);
                                    Thread.Sleep(2000);
                                    Click(driver, _saveBtnForPermissionTab);
                                    Thread.Sleep(3000);
                                    return;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception ouccers: " + e);

                            }
                        }
                    }
                }
            }
        }


        public void SearchDataForAnnouncementGroups(string data)
        {
            if (data.Equals(""))
            {
                Console.WriteLine("No Data To search!!!");
            }

            else if (!data.Equals(""))
            {
                Thread.Sleep(3000);
                //for (int i = 0; i < _sendndingPermissionAllPermissionListChkBox.Count; i++)
                //{
                //    Click(_driver, _sendndingPermissionAllPermissionListChkBox.ElementAt(i));
                //}
                //Thread.Sleep(2000);
                //Click(_driver, _sendndingPermissionAllPermissionListDeleteBtn);
                //Thread.Sleep(2000);
                //_ifOkBtn();//here I added this because an alert apperar
                //Thread.Sleep(2000);
                //_ifSaveBtn();
                //Thread.Sleep(3000);
                Click(_driver, _announcementGroupsAddBtnDeptSendingPermissions);
                Thread.Sleep(4000);
                SendKeys(_driver, _announcementGroupsSearchTab, data);
                Thread.Sleep(9000);
                if (_announcementGroupsSearchResult.Count >= 1)
                {
                    for (int i = 0; i < _announcementGroupsSearchResult.Count; i++)
                    {
                        if (GetText(_driver, _announcementGroupsSearchResult.ElementAt(i)).Equals(data))
                        {
                            Click(_driver, _announcementGroupsSearchResultChkBox.ElementAt(i));
                            break;
                        }
                    }
                    _ifOkBtn();
                    Thread.Sleep(2500);
                    Click(_driver, _saveBtnDeptSendingPermissions);
                }
                else
                {
                    Console.WriteLine("No data Found For User Group");
                }
            }

        }

        public void SearchDataForUserGroup(string data)
        {
            if (data.Equals(""))
            {
                Console.WriteLine("No Data To search!!!");
            }
            else if(!data.Equals(""))
            {
                Thread.Sleep(3000);
                for (int i = 0; i < _sendndingPermissionAllPermissionListChkBox.Count; i++)
                {
                    Click(_driver, _sendndingPermissionAllPermissionListChkBox.ElementAt(i));
                }
                Thread.Sleep(2000);
                Click(_driver, _sendndingPermissionAllPermissionListDeleteBtn);
                Thread.Sleep(2000);
                _ifSaveBtn();
                Thread.Sleep(3000);
                Click(_driver,_userGroupsAddBtnDeptSendingPermissions);
                Thread.Sleep(4000);
                SendKeys(_driver, _userGroupSearchTab, data);
                Thread.Sleep(9000);
                if(_userGroupSearchResult.Count >= 1)
                {
                    for (int i = 0; i < _userGroupSearchResult.Count;i++)
                    {
                        if(GetText(_driver, _userGroupSearchResult.ElementAt(i)).Equals(data))
                        {
                            Click(_driver, _userGroupSearchResultChkBox.ElementAt(i));
                            break;
                        }
                    }
                    _ifOkBtn();
                    Thread.Sleep(2500);
                    Click(_driver, _saveBtnDeptSendingPermissions);
                }
                else
                {
                    Console.WriteLine("No data Found For User Group");
                }
            }
        }

        public void SearchDataForAllOrgExcept(string data)
        {
            if (data.Equals(""))
            {
                Console.WriteLine("No Data To search!!!");
            }
            else if (!data.Equals(""))
            {
                Thread.Sleep(3000);
                for (int i = 0; i < _sendndingPermissionAllOrgExceptListChkBox.Count; i++)
                {
                    Click(_driver, _sendndingPermissionAllOrgExceptListChkBox.ElementAt(i));
                }
                Thread.Sleep(2000);
                Click(_driver, _sendndingPermissionAllOrgExceptListDeleteBtn);
                Thread.Sleep(2000);
                _ifOkBtn();
                Thread.Sleep(3000);
                Click(_driver, _allOrgExceptAddBtnDeptSendingPermissions);
                
                Thread.Sleep(4000);
                SendKeys(_driver, _organizationSearchTab, data);
                Thread.Sleep(9000);
                if (_organizationSearchResult.Count >= 1)
                {
                    for (int i = 0; i < _organizationSearchResult.Count; i++)
                    {
                        if (GetText(_driver, _organizationSearchResult.ElementAt(i)).Contains(data))
                        {
                            Click(_driver, _organizationSearchResultChkBox.ElementAt(i));
                            Click(_driver, _organizationAddBtnSearchResult);
                            break;
                        }
                    }
                    Click(_driver, _okBtn);
                    Thread.Sleep(2500);
                    Click(_driver, _saveBtnDeptSendingPermissions);
                }
                else
                {
                    Console.WriteLine("No data Found For User Group");
                }
            }
        }

        public void IncludeDeptMessagePermissions(IWebDriver driver, string dept, string permissionName, bool value)
        {
            Click(driver, _userPermissionOnDept);
            SearchDept(driver, dept);
            for (int index = 0; index < _deptName.Count; index++) {
                if (GetText(driver, _deptName.ElementAt(index)).Equals(dept)) {
                    var _includeList = _deptIncludeList(driver);
                    Click(driver, _includeList.ElementAt(index));
                    Click(driver, _expandDepartmant);
                    Click(driver, _expandDeptMessagingPermissions);

                    if (permissionName.Equals("Add Related Message") || permissionName.Equals("Remove Related Messages") || permissionName.Equals("Open Related Messages"))
                    {
                        Click(driver, _expandViewRelatedMessagePermission);
                        var elem = _deptViewRelatedMessagePermissions();
                        for (int index1 = 0; index1 < elem.Count; index1++)
                        {
                            if (GetText(driver, elem.ElementAt(index1)).Equals(permissionName))
                            {
                                if (GetAttribute(driver, _deptViewRelatedMessagePermissionsClass.ElementAt(index1), "class").Contains("selected") != value)
                                {
                                    Click(driver, _deptViewRelatedMessagePermissionsCheckbox.ElementAt(index1));
                                    Click(driver, _okBtn);
                                    Click(driver, _yesBtn);
                                    return;
                                }
                                Click(driver, _cancelBtn);
                                return;
                            }
                        }
                    }
                    else if (permissionName.Contains("Can Link"))
                    {
                        Click(driver, _expandViewRelatedMessagePermission);
                        Click(driver, _expandDeptAddRelatedMessagePermission);

                        for (int index1 = 0; index1 < _deptAddRelatedMessagePermissions.Count; index1++)
                        {
                            if (GetText(driver, _deptAddRelatedMessagePermissions.ElementAt(index1)).Equals(permissionName))
                            {
                                if (GetAttribute(driver, _deptAddRelatedMessagePermissionsClass.ElementAt(index1), "class").Contains("selected") != value)
                                {
                                    Click(driver, _deptAddRelatedMessagePermissionsCheckbox.ElementAt(index1));
                                    Click(driver, _okBtn);
                                    Click(driver, _yesBtn);
                                    return;
                                }
                                Click(driver, _cancelBtn);
                                return;
                            }
                        }
                    }
                    else if (permissionName.Contains("Retreive Message after Reading"))
                    {
                        Click(driver, _expandDeptRetreiveMessagePermission);

                        for (int index1 = 0; index1 < _deptRetreiveMessagePermissions.Count; index1++)
                        {
                            if (GetText(driver, _deptRetreiveMessagePermissions.ElementAt(index1)).Equals(permissionName))
                            {
                                if (GetAttribute(driver, _deptRetreiveMessagePermissionsClass.ElementAt(index1), "class").Contains("selected") != value)
                                {
                                    Click(driver, _deptRetreiveMessagePermissionsCheckbox.ElementAt(index1));
                                    Click(driver, _okBtn);
                                    Click(driver, _yesBtn);
                                    return;
                                }
                                Click(driver, _cancelBtn);
                                return;
                            }
                        }
                    }
                    else if (permissionName.Contains("Add Related Person"))
                    {
                        Click(driver, _expandDeptViewPersonMessagePermission);

                        for (int index1 = 0; index1 < _deptAddPersonMessagePermissions.Count; index1++)
                        {
                            if (GetText(driver, _deptAddPersonMessagePermissions.ElementAt(index1)).Equals(permissionName))
                            {
                                if (GetAttribute(driver, _deptAddPersonMessagePermissionsClass.ElementAt(index1), "class").Contains("selected") != value)
                                {
                                    Click(driver, _deptAddpersonMessagePermissionsCheckbox.ElementAt(index1));
                                    Click(driver, _okBtn);
                                    Click(driver, _yesBtn);
                                    return;
                                }
                                Click(driver, _cancelBtn);
                                return;
                            }
                        }
                    }
                    else
                    {
                        for (int index1 = 0; index1 < _deptMessagePermissions.Count; index1++)
                        {
                            if (GetText(driver, _deptMessagePermissions.ElementAt(index1)).Equals(permissionName))
                            {
                                if (GetAttribute(driver, _deptMessagePermissionsClass.ElementAt(index1), "class").Contains("selected") != value)
                                {
                                    Click(driver, _selectDeptMessagePermissions.ElementAt(index1));
                                    Click(driver, _okBtn);
                                    Click(driver, _yesBtn);
                                    return;
                                }
                                Click(driver, _cancelBtn);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
