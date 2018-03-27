using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Pages.Comm;
using T2automation.Util;
using T2automation.Init;
using AutoItX3Lib;

namespace T2automation.Pages.MyMessages
{
    class InboxPage : LeftMenu
    {
        private readonly IWebDriver _driver;
        private ReadFromConfig readFromConfig;
        private TextFileManager fileManager;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtSubject']")]
        private IWebElement _inboxSearchField;

        [FindsBy(How = How.XPath, Using = ".//div/div/span[@class='error-msg']/p")]
        private IList<IWebElement> _errorMessage;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/*//a/i[@class='fa fa-eraser']")]
        private IWebElement _inboxPageEraseButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[21]/div/a[@title='Search']")]
        private IWebElement _inboxSearchButton;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr[1]/td[1]/label")]
        private IWebElement _SearchedCheckBox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Internal Document']")]
        private IWebElement _internalDocument;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Encrypted internal message']")]
        private IWebElement _encryptInernalMessage;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Incoming Document']")]
        private IWebElement _incomingDocument;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Outgoing Document']")]
        private IWebElement _outgoingDocument;

        [FindsBy(How = How.XPath, Using = ".//div[@class = 'ajs-content']/input")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[@class='alertify  ajs-movable ajs-resizable ajs-closable ajs-pinnable ajs-pulse']/div[@class='ajs-modal']/div[@class='ajs-dialog']/div[@class='ajs-footer']/div[@class='ajs-primary ajs-buttons']/button[2]")]
        private IWebElement _cancelBtnForIncomingMail;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Cancel']")]
        private IList<IWebElement> _cancelBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Yes']")]
        private IWebElement _yesBtn;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[18]/div[2]/div/div[4]/div[2]/button[1]")]
        private IWebElement yesBtnForCreatingMyDraft;

        [FindsBy(How = How.XPath, Using = "/html/body/div[20]/div[2]/div/div[4]/div[2]/button[1]")]
        private IWebElement yesBtnForDraftDelete;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div/a/label[contains(text(),'Print All')]")]
        private IWebElement _printAllBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div/a/label[contains(text(),'Print')]")]
        private IWebElement _printBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='ViewAllDocument']/label")] 
        private IWebElement _showAllBtn;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectTo']")]
        private IWebElement _toButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtSearch2Temp']")]
        private IWebElement _searchNameCode;

        [FindsBy(How = How.XPath, Using = ".//tbody/tr/td[1]/label")]
        private IList<IWebElement> _selectToCheck;
        //*[@id="searchGrid2Temp"]/tbody/tr/td[1]/label
        [FindsBy(How = How.XPath, Using = ".//*[@id='searchGrid2Temp']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _selectToCheckForUser;
        //*[@id='organizationSearchGridTemp']/tbody/tr/td[1]/label
        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationSearchGridTemp']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _selectToCheckForStructuralHierarchy;

        //[FindsBy(How = How.XPath, Using = ".//tbody/tr/td[2]")]
        //private IList<IWebElement> _selectToName;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectToTemp']")]
        private IWebElement _selectToFrameToBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectCCTemp']")]
        private IWebElement _selectToFrameCCBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectCc']")]
        private IWebElement _selectMainCcFramBtn;

        [FindsBy(How = How.XPath, Using = "/html/body/div[21]/div[2]/div/div[4]/div[2]/button[2]")]
        private IWebElement _cancelBtnInMyInboxMailCreating;

        [FindsBy(How = How.XPath, Using = "/html/body/div[20]/div[2]/div/div[4]/div[2]/button[2]")]
        private IWebElement _cancelBtnInMyInboxMail;

        [FindsBy(How = How.XPath, Using = "/html/body/div[19]/div[2]/div/div[4]/div[2]/button[2]")]
        private IWebElement _cancelBtnInOutgoingMail;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[7]/a/label")]
        private IWebElement _exportBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div/div/div/div/div[8]/a/label/i[@class='fa fa-save']")]
        private IWebElement _saveEditBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='retriveLable']/i")]
        private IWebElement _undoExportBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[1]/a/label")]
        private IWebElement _myInboxReplyBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='confirmReceivingDocumentDiv']/a/label")]
        private IWebElement _confirmReceivingBtn;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[5]/a/label")]
        private IWebElement _exportBtnInUnexportFolder;

        [FindsBy(How = How.XPath, Using = ".//*[@id='contentBodyItemDiv']/div/div[1]/input")]
        private IWebElement _chk1;

        [FindsBy(How = How.XPath, Using = ".//*[@id='AttachmentItemDiv']/div/div[1]/input")]
        private IWebElement _chk2;

        [FindsBy(How = How.XPath, Using = ".//*[@id='destinationsDiv']/input[1]")]
        private IWebElement _chkDep1;

        [FindsBy(How = How.XPath, Using = ".//*[@id='destinationsDiv']/input[2]")]
        private IWebElement _chkDep2;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[6]/a/label")]
        private IWebElement _returnBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr[1]/td[7]/a[1]/i")]
        private IWebElement _followUpBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr[1]/td[7]/a[2]/i")]
        private IWebElement _ActionAndMovementBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[6]/a/label/i")]
        private IWebElement _exportBtn2;

        [FindsBy(How = How.XPath, Using = ".//*[@id='cancel-a']")]
        private IWebElement _closeBtn;

        [FindsBy(How = How.XPath, Using = ". //*[@id='main-parent']/div/div/div/div/div/div[9]/a/label/i[@class='fa fa-folder']")]
        private IWebElement _movFoldBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div/div/div/a/label[contains(text(),'Archive')]")]
        private IWebElement _archieveBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='rb-normal-view']")]
        private IWebElement _NormalViewBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='rb-formal-view']")]
        private IWebElement _ViewUsingFormalTemplateBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchDiv']/div[2]/input[2]")]
        private IWebElement _clearBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnSearch']")]
        private IWebElement _searchBtn;

        [FindsBy(How = How.XPath, Using = "./html/body/div[23]/div[2]/div/div[4]/div[2]/button[2]")]
        private IWebElement _cancelBtnForIncomingMail2;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[7]/a/label")]
        private IWebElement _editBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[9]/a/label")]
        private IWebElement _processEditBtn;

        [FindsBy(How = How.Id, Using = "externalDepartmentToBtn")]
        private IWebElement _externalDeptToBtnInRoot;

        [FindsBy(How = How.Id, Using = "externalDepartmentCCBtn")]
        private IWebElement _externalDeptCCBtnInRoot;

        private IList<IWebElement> _deptCcCheckBox(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentGrid']/tbody/tr/td[1]/label"));
        }

        private IWebElement _print()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Print']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Print']"));
        }

        private IWebElement _cancel()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Cancel']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Cancel']"));
        }

        private IWebElement _close()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Close']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Close']"));
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-parent']/div/div/div/div/div/div/a/label[contains(text(),'Reply All')]")]
        private IWebElement _replyAllBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='back-button-a']")]
        private IWebElement _backBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='retriveLable']")]
        private IWebElement _retriveBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[2]/a/label")]
        private IWebElement _rollBackBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[contains(text(),'Pring Delivery')]")]
        private IWebElement _printDeliveryBtn;

        [FindsBy(How = How.XPath, Using = "./html/body/div/div/div/div/div/div/div/div[2]/button[contains(text(),'To')]")]
        private IWebElement _toBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='DestinationToDeliveryTable']/thead/tr/th[1]/label")]
        private IWebElement _selectAll;

        [FindsBy(How = How.XPath, Using = ".//*[@id='print-header']/div/button[2]")]
        private IWebElement _cancelBtnPrintPreview;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='destination-settings']/div[2]/button")]
        private IWebElement _changeBtnPrintPreview;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='destination-search']/div/div[2]/div/input")]
        private IWebElement _searchBtnPrintPreview;

        [FindsBy(How = How.XPath, Using = ".//*[@id='destination-search']/div/div[3]/div[2]/div/ul/li/span/span[1][@class='destination-list-item-name']")]
        private IList<IWebElement> _searchListPrintPreview;
        //*[@id='destination-search']/div/div/div/div/ul/li/span/span/span[text()='Save as PDF']
        [FindsBy(How = How.XPath, Using = ".//*[@id='destination-search']/div/div/div/div/ul/li/span/span/span[text()='Save as PDF']")]
        private IWebElement _searchedDataPrintPreview;

        [FindsBy(How = How.XPath, Using = ".//*[@id='print-header']/div/button[1]")]
        private IWebElement _saveBtnPrintPreview;

        [FindsBy(How = How.XPath, Using = ".//*[@id='print-docment-div']/div[1]/label[1]")]
        private IWebElement _selectAllCheck;

        [FindsBy(How = How.XPath, Using = ".//*[@id='print-attachment']/a/label")] //*[@id="att-head-menu"]/div[3]/a/label
        private IWebElement _printBtnInboxCreatingMail;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='divSendPrintParent']/div[1]/div[2]/input")]
        private IWebElement _printDelieveryStatmentFromPopup;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divSendPrintParent']/div[2]/div[2]/input")]
        private IWebElement _printBarcodeBtnFromPopup;

        [FindsBy(How = How.XPath, Using = "//*[@id='divSendPrintParent']/div[3]/div[2]/input")]
        private IWebElement _printRefNoBtnFromPopup;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divSendPrintParent']/div[4]/div[2]/input")]
        private IWebElement _printDeliveryStatementBtnFromPopup;

        [FindsBy(How = How.XPath, Using = ".//*[@id='print-delivery-statement-div']/div[2]/label[1]")]
        private IWebElement _printDeliveryStatementChk1;

        [FindsBy(How = How.XPath, Using = ".//*[@id='print-delivery-statement-div']/div[3]/label[1]")]
        private IWebElement _printDeliveryStatementChk2;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divSendPrintParent']/div[5]/div[2]/input")]
        private IWebElement _printDocumentBtnFromPopup;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[4]/a/label")]
        private IWebElement _printBtndept;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[1]/a/label")]
        private IWebElement _printBtnDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div/div/div/div/div/a[contains(@href,'javascript:documentsPrint()')]/label[contains(text(),'Print')]")]
        private IWebElement _printBtnOutbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='rb-formal-print']")]
        private IWebElement _printFormalBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='rb-normal-print']")]
        private IWebElement _printNormalBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[2]/a/label")]
        private IWebElement _printDeliveryStatmentBtnDept;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[3]/a/label")]
        private IWebElement _printStickerBtnDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divOutgoingSticker']/div[2]/input[@value='Print Sticker']")]
        private IWebElement _printStickerPopUpBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td/a[3]")]
        private IWebElement _printBarcodeMailBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='printPageBtn']")]
        private IWebElement _printThisPageBtn;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='printAllBtn']")]
        private IWebElement _printAllBtnUnExported;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[2]/a")]
        private IWebElement _printDocFlowTabUnExported;

        [FindsBy(How = How.XPath, Using = ".//*[@id='df-part']/div[1]/div/div/button")]
        private IWebElement _printDocFlowBtnUnExported;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[5]/a/label")]
        private IWebElement _printStickerBtndept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtRefNo']")]
        private IWebElement _refNoFieldInSearch;

        [FindsBy(How = How.XPath, Using = ".//*[@id='retriveLable']")]
        private IWebElement _retrieveBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtSubject']")]
        private IWebElement _subject;

        [FindsBy(How = How.XPath, Using = ".//*[@id='cke_1_contents']/iframe")]
        private IWebElement _contentBodyIFrame;

        [FindsBy(How = How.XPath, Using = "//*[@id='doc-tabs']/div[2]/a")]
        private IWebElement _connectedTabAttribute;

        [FindsBy(How = How.XPath, Using = "/html/body/div[12]/div[2]/div/div[4]/div[2]/button[2]")]
        private IWebElement _connectedTabToCloseBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-tabs']/div[3]/a")]
        private IWebElement _connectedTabDocFlow;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-tabs']/div/a[@data-target='doc']")]
        private IWebElement _connectedTabConnentedDocument;

        [FindsBy(How = How.XPath, Using = "/html/body/div[10]/div[1]/div[3]/a[@title='Show User Information']")]
        private IWebElement _connectedTabFrom;

        [FindsBy(How = How.XPath, Using = "html/body/div[15]/div[2]/div/div[4]/div[2]/button[2]")]
        private IWebElement _connectedTabPopupCancelBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='tabActions']")]
        private IWebElement _connectedTabAction;

        [FindsBy(How = How.Id, Using = "OutInA")]
        private IWebElement _outgoingIncomingDateTab;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-tabs']/div/a[@data-target='doc']")]
        private IWebElement _connectedTabDoc;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/div[1]/div[2]/ul/li")]
        private IList<IWebElement> _connectedTabTo;

        [FindsBy(How = How.XPath, Using = "./html/body/div[22]/div[2]/div/div[4]/div[2]/button[1]")]
        private IWebElement _okBtnForIncomingMail;

        [FindsBy(How = How.XPath, Using = "html/body")]
        private IWebElement _contentBody;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[4]/div[1]/div[1]/a/label")]
        private IWebElement _sendBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td/label")]
        private IList<IWebElement> _checkboxList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[3]")]
        private IList<IWebElement> _senderList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[4]")]
        private IList<IWebElement> _subjectList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchResultGrid']/tbody/tr/td[4]")]
        private IList<IWebElement> _advanceSearchRefNoList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[5]")]
        private IList<IWebElement> _referenceNoList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[6]")]
        private IList<IWebElement> _receiveDateList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/div[1]/div[2]/ul")]
        private IWebElement _mailTo;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/div[3]/div[1]/div[2]/ul/li")]
        private IWebElement _subjectInboxWithCC;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/*//div[2]/ul/li[@class='normal-text']")]
        private IWebElement _subjectInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='contentBody']/div/div[@class = 'contentBodyHtml']")]
        private IWebElement _contentBodyInbox;

        [FindsBy(How = How.Id, Using = "txtPass")]
        private IWebElement _encryptedPassword;

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        private IWebElement _encryptedPasswordOkBtn;

        [FindsBy(How = How.Id, Using = "btnDepartmentTo")]
        private IWebElement _externalDeptToBtn;

        [FindsBy(How = How.Id, Using = "btnDepartmentCc")]
        private IWebElement _externalDeptCcBtn;

        [FindsBy(How = How.Id, Using = "txtSearchTo3")]
        private IWebElement _searchDeptName;

        [FindsBy(How = How.Id, Using = "txtSearch3")]
        private IWebElement _searchCcDeptName;

        [FindsBy(How = How.Id, Using = "txtSearchExtDepToCode")]
        private IWebElement _searchDeptCodeName;

        [FindsBy(How = How.Id, Using = "tabDoc")]
        private IWebElement _documentTab;

        [FindsBy(How = How.Id, Using = "docContentDiv")]
        private IWebElement _contentTab;

        [FindsBy(How = How.Id, Using = "docPropertyDiv")]
        private IWebElement _propertiesTab;

        [FindsBy(How = How.Id, Using = "tabAttache")]
        private IWebElement _attachmentTab;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='Name']")]
        private IWebElement _personTabName;

        [FindsBy(How = How.XPath, Using = "//*[@id='Email_Persion']")]
        private IWebElement _personTabEmail;

        [FindsBy(How = How.XPath, Using = "//*[@id='Mobile_Persion']")]
        private IWebElement _personTabMobile;

        [FindsBy(How = How.XPath, Using = "//*[@id='IdNumber']")]
        private IWebElement _personTabIdNumber;

        [FindsBy(How = How.XPath, Using = "//*[@id='IdIssuer']")]
        private IWebElement _personTabIdIssuer;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtExportDate2']")]
        private IWebElement _searchTabExportedDateFrom;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtCreateDate2']")]
        private IWebElement _searchTabCreatedDateFrom;

        //*[@id="IssueDate2"] 2 is in the case of old server remove '2' for new server
        [FindsBy(How = How.XPath, Using = "//*[@id='IssueDate2']")]
        private IWebElement _personTabIssueDate;

        [FindsBy(How = How.XPath, Using = ".//*[@id='archiveAttachment']")]
        private IWebElement _archiveAttacheBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div[1]/a/label")]
        private IWebElement _attacheBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='attachmentDelete']/a")]
        private IWebElement _deleteBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div/a/label[text()=' Download']")]
        private IWebElement _downloadBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div/a/label[text()=' Download All']")]
        private IWebElement _downloadAllBtn;

        [FindsBy(How = How.Id, Using = "txtIncomingMessageNumber")]
        private IWebElement _incommingMessageNo;

        [FindsBy(How = How.XPath, Using = "//*[@id='docProperty-part']/*//div[@class='divNeedReplyRadio']/input[@class='narrowRadio'][@value='1']")]
        private IWebElement _directExportMethod;

        [FindsBy(How = How.XPath, Using = "//*[@id='docProperty-part']/*//div[@class='divNeedReplyRadio']/input[@class='narrowRadio'][@value='0']")]
        private IWebElement _indirectExportMethod;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtTangAttachNum']")]
        private IWebElement _tengibleNo;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtTangAttachDesc']")]
        private IWebElement _tengibleDesc;
        //its 1 in old server and 2 in new server
        [FindsBy(How = How.Id, Using = "txtSendDate")]
        private IWebElement _incommingHijriMessageDate;

        //*[@id="txtSendDate2"] for georgia calander in old server but for new server remove the '2' from the end of the id -.-
        [FindsBy(How = How.Id, Using = "txtSendDate2")]
        private IWebElement _incommingGregorianMessageDate;

        [FindsBy(How = How.Id, Using = "relatedDocumentCount")]
        private IWebElement _connectedDocTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[3]/a[@id='conDocumentA']")]
        private IWebElement _connectedDocTabChk;

        [FindsBy(How = How.XPath, Using = "//*[@id='buttontbl_documentPerson']")]
        private IWebElement _connectedPersonDeleteBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='Addbuttontbl_documentPerson']")]
        private IWebElement _addNewBtnPersonTab;

        [FindsBy(How = How.XPath, Using = "//*[@id='Editbuttontbl_documentPerson']")]
        private IWebElement _editBtnPersonTab;

        [FindsBy(How = How.Id, Using = "Addbuttontbl_documentDocument")]
        private IWebElement _addNewBtn;

        [FindsBy(How = How.Id, Using = "buttontbl_documentDocument")]
        private IWebElement _connectedDocDeleteBtn;

        [FindsBy(How = How.Id, Using = "Subject")]
        private IWebElement _connectedDocSubject;

        [FindsBy(How = How.Id, Using = "btnDocumentSearch")]
        private IWebElement _connectedDocSearchBtn;

        private SelectElement _connectedDocDocType(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.XPath("//*[@id='DocumentTypeId']")));
        }

        private SelectElement _connectedDocDeliveryType(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.XPath("//*[@id='DeliveryTypeId']")));
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ReferenceSendOutgoing']")]
        private IWebElement _PopupRefnoLable;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Save']")]
        private IList<IWebElement> _connectedDocSaveBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Save']")]
        private IList<IWebElement> _connectedPersonSaveBtn;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='tbl_documentDocument']/tbody/tr/td[2]")]
        private IList<IWebElement> _connectedDocList;

        [FindsBy(How = How.XPath, Using = "//*[@id='ReferenceNo']")]
        private IWebElement _connectedDocRefNoField;
        
        [FindsBy(How = How.XPath, Using = "./html/body/div[15]/div[2]/div/div[4]/div[2]/button[2]")]
        private IWebElement _exportCancelBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Cancel']")]
        private IList<IWebElement> _connectedDocCancelBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Cancel']")]
        private IList<IWebElement> _connectedPersonCancelBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div/div/div/div/div/a/label[contains(text(),'Undo export')]")]
        private IWebElement _undoexportBtnInUnexportFolder;

        [FindsBy(How = How.XPath, Using = "//*[@id='print-docment-div']/div/label[1]")]
        private IList<IWebElement> _SelectiveCheckboxesForPrintPopup;

        [FindsBy(How = How.XPath, Using = "//*[@id='print-docment-div']/div/label[2][contains(text(),'')]")]
        private IList<IWebElement> _SelectiveLablesForPrintPopup;

        [FindsBy(How = How.XPath, Using = "//*[@id='tbl_documentDocument']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _connectedDocSubjectListCheckBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='tbl_documentPerson']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _connectedPersonListCheckBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-tabs']/div/a[contains(text(),'ConnectedPersons')]")]
        private IWebElement _connectedPersonTab;

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-mail-reply")]
        private IWebElement _replyBtn;

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-forward")]
        private IWebElement _forwardBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtRefernceNumber']")]
        private IWebElement _inboxRefNoSearchField;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[14]/div[2]/div/div[4]/div[2]/button[1]")]
        private IWebElement _okArchiveBtn;
        //*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[8]/a/label
        //*[@id='main-parent']/*//a/label/i[@class='fa fa-remove']
        [FindsBy(How = How.XPath, Using = "//*[@id='main-parent']/div/*//a/label/i[@class='fa fa-remove']")]
        private IWebElement _deleteMailBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div/div/div/div/div/a/label[contains(text(),'Archive')]")]
        private IWebElement _inboxArchiveBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[4]/a/label")]
        private IWebElement _inboxDeptArchiveBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[1]/div[2]/a/label")]
        private IWebElement _inboxDeptOutgoingArchiveBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='retreiveDiv']/a/label")]
        private IWebElement _commDeptExportArchiveBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='archiveComment']")]
        private IWebElement _inboxArchiveComment;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[4]/div[1]/div[3]/a/label")]
        private IWebElement _deleteDraftBtn;

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-save")]
        private IWebElement _saveDraftBtn;

        [FindsBy(How = How.Id, Using = "o-m-loader")]
        private IWebElement _createDocumentScreenLoader;

        private IList<IWebElement> _connectedDocSearchedSubjects()
        {
            return _driver.FindElements(By.XPath(".//*[@id='tbl_documentFilter']/tbody/tr/td[3]"));
        }

        private IList<IWebElement> _selectToName()
        {
            return _driver.FindElements(By.XPath(".//table/tbody/tr/td[2]"));
        }

        private IList<IWebElement> _selectToNameForUsers()
        {
            return _driver.FindElements(By.XPath(".//*[@id='searchGrid2Temp']/tbody/tr/td[2]"));
        }

        private IList<IWebElement> _selectToNameForStructuralHierarchy()
        {
            return _driver.FindElements(By.XPath(".//*[@id='organizationSearchGridTemp']/tbody/tr/td[2]"));
        }

        private IList<IWebElement> _connectedDocSearchedCheckBoxes()
        {
            return _driver.FindElements(By.XPath(".//*[@id='tbl_documentFilter']/tbody/tr/td[1]/label"));
        }

        private IList<IWebElement> _connectedDocSearchedReferenceNo()
        {
            return _driver.FindElements(By.XPath(".//*[@id='tbl_documentFilter']/tbody/tr/td[2]"));
        }

        private IList<IWebElement> _progressbar(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//div[@class = 'pParent']"));
        }

        private IWebElement _notificationContent(IWebDriver driver)
        {
            return driver.FindElement(By.Id("not-content0"));
        }

        private IWebElement _processing(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("dataTables_processing"));
        }

        private IWebElement _mailLoading(IWebDriver driver)
        {
            return driver.FindElement(By.Id("container_processing"));
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='conDocumentA']")]
        private IWebElement _unexportedconnectedDocTab;

        [FindsBy(How = How.XPath, Using = "//*/a[@data-folder-flag='0'][@class='o-folder'][@data-orgid='3c76399d-2a03-4b67-9459-8a0925263d2e']/label[contains(text(),'Automation 111')]")]
        private IWebElement _automation111DeptInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0-3c76399d-2a03-4b67-9459-8a0925263d2e']/a/label/i")]
        private IWebElement _inboxBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='context-menu']/ul/li[1]")]
        private IWebElement _createFolder;

        [FindsBy(How = How.XPath, Using = "./html/body/div[8]/div[2]/div/div[3]/div/input")]
        private IWebElement _folderName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div/div/div/div/div[7]/a/label[contains(text(),'Return')]")]
        private IWebElement _unexportedreturnBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtAdoptionComment']")]
        private IWebElement _unexportedComment;

        private IWebElement _okBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Ok']"));
            foreach (IWebElement elem in elements) {
                if (elem.Displayed) {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Ok']"));
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

        public void _ifCancelBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Cancel']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    elem.Click();
                }
            }
        }

        public void _ifYesBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Yes']"));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    elem.Click();
                }
            }
        }
        private SelectElement _receiverType(IWebDriver driver) {
            return new SelectElement(driver.FindElement(By.Id("slctRecieverTypeTemp")));
        }

        private SelectElement _personTabIdType(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.XPath("//*[@id='IdType']")));
        }

        private SelectElement _levelSelect(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.Id("slctLevel0Temp")));
        }

        private SelectElement _deptType(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.Id("slcTypeToSearch")));
        }

        private SelectElement _deliveryType()
        {
            return new SelectElement(_driver.FindElement(By.Id("slctDeliveryType")));
        }

        private SelectElement _messageType()
        {
            return new SelectElement(_driver.FindElement(By.XPath("//*[@id='slctMessageType']")));
        }

        private SelectElement _securityLevel()
        {
            return new SelectElement(_driver.FindElement(By.Id("slctSecurityLevels")));
        }

        private IList<IWebElement> _deptCcRadioBtn(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentGrid']/tbody/tr/td[1]/label"));
        }

        private IList<IWebElement> _deptRadioBtn(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentToGrid']/tbody/tr/td[1]/input"));
        }

        private IList<IWebElement> _deptNames(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentToGrid']/tbody/tr/td[2]"));
        }

        private IList<IWebElement> _deptCcNames(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentGrid']/tbody/tr/td[2]"));
        }

        private IList<IWebElement> _attachedFileNames(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='files-parent']/div/div[2]"));
        }

        private IList<IWebElement> _attachedFilesCheckboxes(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='files-parent']/div/div[1]/label"));
        }

        //If its not working try this!!!!
        /*
private IList<IWebElement> _daysOnCal() {
        while (_driver.FindElements(By.XPath("html/body/div/div/div[2]/div/table/tbody/tr/td/a[text()=.]")).Count == 0) {
                _incommingHijriMessageDate.SendKeys(Keys.Enter);
            }
            return _driver.FindElements(By.XPath("html/body/div/div/div[2]/div/table/tbody/tr/td/a[text()=.]"));
           }
           */
        private IList<IWebElement> _daysOnCal() {
            return _driver.FindElements(By.XPath("html/body/div/div/div[2]/div/table/tbody/tr/td/a[text()=.]"));
        }

        private IList<IWebElement> _connectedDocSubjectList()
        {
            return _driver.FindElements(By.XPath(".//table[@id = 'tbl_documentDocument']/tbody/tr/td[3]"));
        }

        private IList<IWebElement> _connectedDocRefNoList()
        {
            return _driver.FindElements(By.XPath(".//*[@id='tbl_documentDocument']/tbody/tr/td[1]"));
        }

        private IWebElement _UpperHeadMenuTabBtns(IWebDriver driver, string btnTxt)
        {
            return driver.FindElement(By.XPath(".//*[@id='head-menu']/*//a/label[text()=' " + btnTxt + "']"));
        }

        private IList<IWebElement> _connectedPersonNameList()
        {
            return _driver.FindElements(By.XPath("//*[@id='tbl_documentPerson']/tbody/tr/td[2]"));
        }

        public string title = "Inbox - Ole5.1";

        public InboxPage(IWebDriver driver) : base(driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string SearchNameCode
        {
            set
            {
                SendKeys(_driver, _searchNameCode, value);
            }
        }

        public string Subject
        {
            set
            {
                SendKeys(_driver, _subject, value);
            }
        }

        public string EncryptedPassword
        {
            set
            {
                SendKeys(_driver, _encryptedPassword, value);
            }
        }


        public void firstSearchInbox(string subject)
        {
            Click(_driver, _inboxPageEraseButton);
            WaitTillProcessing();
            SendKeys(_driver, _inboxSearchField, subject);
            Click(_driver, _inboxSearchButton);
            WaitTillProcessing();
        }

        public bool CheckButtonAvailbility(IWebDriver driver, string buttonName, bool value) {
            IWebElement element = null;

            switch (buttonName) {
                case "Internal Document":
                    element = _internalDocument;
                    break;
                case "Encrypted internal message":
                    element = _encryptInernalMessage;
                    break;
                case "Incoming Document":
                    element = _incomingDocument;
                    break;
                case "Outgoing Document":
                    element = _outgoingDocument;
                    break;
            }

            return ElementIsDisplayed(driver, element) == value;
        }

        public void clickUndoExportBtnInCommDeptUnexportedF(bool checkPopup = false)
        {
            Thread.Sleep(1000);
            Click(_driver, _undoexportBtnInUnexportFolder);
            Thread.Sleep(1000);
        }

        public bool CheckButtonClickable(IWebDriver driver, string buttonName)
        {
            IWebElement element = null;

            switch (buttonName)
            {
                case "Internal Document":
                    element = _internalDocument;
                    break;
                case "Encrypted internal message":
                    element = _encryptInernalMessage;
                    break;
                case "Incoming Document":
                    element = _incomingDocument;
                    break;
                case "Outgoing Document":
                    element = _outgoingDocument;
                    break;
            }

            Click(driver, element);
            Thread.Sleep(2000);
            if (buttonName.Equals("Encrypted internal message"))
            {
                EnterPassword(driver, "P@ssw0rd!@#");
                Thread.Sleep(2000);
            }
            bool flag = false;
            for (int i = 0; i < 5 && flag == false; i++)
            {
                if (!IsAt(driver, "Create document - Ole5.1"))
                {
                    Console.WriteLine("Loading Page....");
                    Thread.Sleep(1000);
                }
                else if (IsAt(driver, "Create document - Ole5.1"))
                {
                    flag = true;
                    break;
                }
            }

            /*
            while (!IsAt(driver, "Create document - Ole5.1")) {
                Console.WriteLine("Loading Page....");
                Thread.Sleep(1000);
            }*/
            return IsAt(driver, "Create document - Ole5.1");
        }

        public void WaitTillCreatePageLoad()
        {
            while (GetAttribute(_driver, _createDocumentScreenLoader, "class").Equals("")) {
                continue;
            }
        }

        public void EnterPassword(IWebDriver driver, string password)
        {
            SendKeys(driver, _passwordInput, password);
            Click(driver, _okBtn());
        }

        public void ClickToButton(IWebDriver driver)
        {
            Thread.Sleep(1000);
            Click(driver, _toButton);
            Thread.Sleep(2000);
        }

        public void SelectLevel(IWebDriver driver, string level) {
            DropdownSelectByText(driver, _levelSelect(driver), level);
            Thread.Sleep(1000);
        }

        public void SelectReceiverType(IWebDriver driver, string type)
        {
            DropdownSelectByText(driver, _receiverType(driver), type);
            Thread.Sleep(1000);
        }

        public void SelectToUser(IWebDriver driver, string user, string receiverType) {
            WaitTillProcessing();
            Thread.Sleep(2000);

            if (receiverType.Equals("Users"))
            {
                Thread.Sleep(4000);
                for (int index = 0; index < _selectToNameForUsers().Count; index++)
                {
                    if (GetText(driver, _selectToNameForUsers().ElementAt(index)).Contains(user))
                    {
                        Click(driver, _selectToCheckForUser.ElementAt(index));
                        Click(driver, _selectToFrameToBtn);
                        Thread.Sleep(1000);
                        return;
                    }
                }
            }
            else if (receiverType.Equals("Structural Hierarchy"))
            {
                Thread.Sleep(4000);
                for (int index = 0; index < _selectToNameForStructuralHierarchy().Count; index++)
                {
                    if (GetText(driver, _selectToNameForStructuralHierarchy().ElementAt(index)).Contains(user))
                    {
                        Click(driver, _selectToCheckForStructuralHierarchy.ElementAt(index));
                        Click(driver, _selectToFrameToBtn);
                        Thread.Sleep(1000);
                        return;
                    }
                }
            }
        }

        public void selectSpecificFileTypeAttachmentInMail(string fileType, int size)
        {
            Click(_driver, _attachmentTab);
            //Unselected the previous selected!!! Can't apply attribute validation cause no such attribute to apply on
            for (int index = 0; index < size; index++)
            {
                _driver.FindElement(By.XPath("//*[@id='file-cont" + index + "']/div[1]/label")).Click();
            }

            for (int index = 0; index < size; index++)
            {
                if(GetText(_driver, _driver.FindElement(By.XPath("//*[@id='dlink" + index + "']"))).Contains(fileType))
                {
                    _driver.FindElement(By.XPath("//*[@id='file-cont" + index + "']/div[1]/label")).Click();
                    return;
                }
            }
        }

        public void selectAllAttachmentInMail(int size)
        {
            Click(_driver, _attachmentTab);
            
            for(int index = 0; index < size; index++)
            {
                _driver.FindElement(By.XPath("//*[@id='file-cont"+index+"']/div[1]/label")).Click();
            }
        }

        public void ClickOkBtn() {
            Click(_driver, _okBtn());
            Thread.Sleep(1000);
        }

        public void EnterContentBody(string body) {
            //_driver.SwitchTo().Frame(_contentBodyIFrame);
            //SendKeys(_driver, _contentBody, body);
            //_driver.SwitchTo().DefaultContent();
            //Thread.Sleep(1000);
            //updated for content click reasons!
            Click(_driver, _contentTab);
            _driver.SwitchTo().Frame(_contentBodyIFrame);
            SendKeys(_driver, _contentBody, body);
            _driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);
            Click(_driver, _propertiesTab);
            Thread.Sleep(3000);
        }

        public void clickOnSendBtnAndCancelForOutgoingMail()
        {
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            WaitForElement(_driver, _cancelBtnInOutgoingMail);
            Click(_driver, _cancelBtnInOutgoingMail);
        }

        public void clickOnSendBtnAndCancelForMyInboxMail()
        {
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            WaitForElement(_driver, _cancelBtnInMyInboxMail);
            Click(_driver, _cancelBtnInMyInboxMail);
        }
        
        public void clickOnSendBtnAndCancelBtnForIncomingMail(bool checkPopup = false)
        {
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            if (checkPopup)
            {
                Click(_driver, _okBtn());
            }
            ChkIfPopupThenOK();
            WaitForElement(_driver, _cancelBtnForIncomingMail);
            if (_cancelBtnForIncomingMail.Displayed)
            {
                Click(_driver, _cancelBtnForIncomingMail);
            }
        }

        public void clickOnSendBtn(bool checkPopup = false) {
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            if (checkPopup)
            {
                foreach (IWebElement cancelBtn in _cancelBtn)
                {
                    WaitForElement(_driver, cancelBtn);
                    if (cancelBtn.Displayed)
                    {
                        Click(_driver, cancelBtn);
                        return;
                    }
                }
            }
        }

        public void SendMail(string subject, string contentBody, bool checkPopup = false, int multipleAttachementNo = 1, string multipleAttachmentType = "", string securityLevel = "") {
            ComposeMail(subject, contentBody);
            AddAttachments(multipleAttachmentType, multipleAttachementNo);
            SetProperties(securityLevel: securityLevel);
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            if (checkPopup) {
                foreach (IWebElement cancelBtn in _cancelBtn) {
                    if (cancelBtn.Displayed) {
                        Click(_driver, cancelBtn);
                        break;
                    }
                }
            }
            WaitTillMailSent();
        }

        public void firstSearchFolderWithRefNo(string refno)
        {
            Click(_driver, _inboxPageEraseButton);
            SendKeys(_driver, _inboxRefNoSearchField, refno);
            Click(_driver, _inboxSearchButton);
            WaitTillProcessing();
        }

        public void firstSearchinbox(string subject)
        {
            Click(_driver, _inboxPageEraseButton);
            WaitTillProcessing();
            SendKeys(_driver, _inboxSearchField, subject);
            Click(_driver, _inboxSearchButton);
            WaitTillProcessing();
        }

        public void selectMailSearched()
        {
            Thread.Sleep(2000);
            Click(_driver, _SearchedCheckBox);
        }

        public void selectMailForMultipleSubjects(string subject)
        {
            fileManager = new TextFileManager();
            string[] subjectlists = subject.Split(',');
            int s = subjectlists.Length;
            for (int i = 0; i < subjectlists.Length; i++)
            {
                string temp = fileManager.readFromFile(subjectlists[i]);
                IWebElement tempEl = _referenceNoList.ElementAt(i);
                if (GetText(_driver,tempEl).Contains(temp))
                {
                    Click(_driver, _checkboxList.ElementAt(i));
                    Thread.Sleep(1000);
                }
            }
        }

        public void clickPrintDeliveryBtn()
        {
            Click(_driver, _printDeliveryBtn);
            Thread.Sleep(1000);
            Click(_driver, _toBtn);
            Thread.Sleep(1000);
            Click(_driver, _selectAll);
        }

        public void SetPrintType(string typeName = "")
        {
            if (!typeName.Equals(""))
            {
                if (typeName.Equals("ALL In One Dleveray State"))
                {
                    var chk1 = _driver.FindElement(By.XPath("//*[@id='PrintTypeOptions1']"));
                    chk1.Click();
                }
            }

            if (!typeName.Equals(""))
            {
                if (typeName.Equals("Every document in one  delivery statement"))
                {
                    var chk2 = _driver.FindElement(By.XPath("//*[@id='PrintTypeOptions2']"));
                    chk2.Click();
                }
            }

            if (!typeName.Equals(""))
            {
                if (typeName.Equals("Every destination in one delivery statement"))
                {
                    var chk3 = _driver.FindElement(By.XPath("//*[@id='PrintTypeOptions3']"));
                    chk3.Click();
                }
            }

        }

        public void ClickPrintBtn()
        {
            Click(_driver, _print());
            Thread.Sleep(1000);
        }

        public void clickOnSendBtnAndOkBtnForIncomingMail(bool checkPopup = false)
        {
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            Click(_driver, _okBtnForIncomingMail);

        }

        public void clickCancelBtnForIncomingMail(bool checkPopup = false)
        {
            Thread.Sleep(2000);
            Click(_driver, _cancelBtnForIncomingMail2);

        }

        public void clickEditBtn()
        {
            Click(_driver, _editBtn);
        }

        public bool SelectExternalDeptToButton(string deptName = "", string deptCode = "", string type = "")
        {
            Thread.Sleep(5000);
            Click(_driver, _externalDeptToBtnInRoot);
            int index = SearchDept(deptName, deptCode, type);
            if (index != -1)
            {
                Thread.Sleep(5000);
                Click(_driver, _deptRadioBtn(_driver).ElementAt(index));
                Thread.Sleep(2000);
                Click(_driver, _okBtn());
                Thread.Sleep(2000);
                return true;
            }
            Click(_driver, _okBtn());
            return false;
        }

        public bool SelectExternalDeptCCButton(string deptName = "", string deptCode = "", string type = "")
        {
            Thread.Sleep(5000);
            Click(_driver, _externalDeptCCBtnInRoot);

            int index = SearchCcDept(deptName, deptCode, type);
            if (index != -1)
            {
                Click(_driver, _deptCcCheckBox(_driver).ElementAt(index));
                Thread.Sleep(2000);
                Click(_driver, _okBtn());
                Thread.Sleep(2000);
                return true;
            }
            Click(_driver, _okBtn());
            return false;
        }

        public void ClickOnUnexportedReturnBtn(string comment)
        {
            WaitTillProcessing();
            Click(_driver, _unexportedreturnBtn);
            Thread.Sleep(2000);
            SendKeys(_driver, _unexportedComment, comment);
            Thread.Sleep(2000);
            ClickOkBtn();
        }

        public void ClickUnexportedConnectedDocTab(IWebDriver driver)
        {
            Click(driver, _unexportedconnectedDocTab);
        }

        public void clickOnUnexportedConnectedDocumentList(IWebDriver driver, string subject)
        {
            for (int index = 0; index < _connectedDocSubjectList().Count(); index++)
            {
                Click(driver, _connectedDocSubjectList().ElementAt(index));
                Thread.Sleep(2000);

            }
            //Click(driver, _attributeTab);
            //Click(driver, _documentFlowTab);
            //Click(driver, _actionTab);
        }

        public void clickBackBtn()
        {
            Click(_driver, _backBtn);
        }

        public void clickProcessEditBtn()
        {
            Click(_driver, _processEditBtn);
            ChkIfPopupThenOK();
            _ifCancelBtn();
        }

        public void ClickCancelBtn()
        {
            Click(_driver, _cancel());
            Thread.Sleep(1000);
        }

        public void ClickCloseBtn()
        {
            Click(_driver, _close());
            Thread.Sleep(1000);
        }

        public void clickRetriveBtn()
        {
            Click(_driver, _retriveBtn);
            Click(_driver, _yesBtn);
        }

        public void clickRollbackBtn()
        {
            Click(_driver, _rollBackBtn);
        }
        

        public bool OpenMailSpecialForTxtFile(IWebDriver driver, string strData, string encryptPass = "", bool withSubject = true)
        {
            if (withSubject == false)
            {
                firstSearchFolderWithRefNo(strData);
                WaitTillMailsGetLoad();
            }
            else if (withSubject == true)
            {
                firstSearchInbox(strData);
                WaitTillMailsGetLoad();
            }

            int searchResult = _subjectList.Count();

            if (searchResult >= 1 && withSubject == true)
            {
                Click(driver, _subjectList.ElementAt(0));
                return true;
            }
            else if (searchResult >= 1 && withSubject == false)
            {
                Click(driver, _referenceNoList.ElementAt(0));
                return true;
            }
            Console.WriteLine("No such mail found!!!");
            return false;
        }

        public void writeRefNoToFieldInSearch(string refno)
        {
            Thread.Sleep(1000);
            SendKeys(_driver, _refNoFieldInSearch, refno);
        }

        public void writeDateCreatedDateFromInSearch(string date)
        {
            if (!date.Equals(""))
            {
                SendKeys(_driver, _searchTabCreatedDateFrom, new DateTimeHelper().GetDate(date));
                var result = _daysOnCal();
                Click(_driver, _daysOnCal().ElementAt(new DateTimeHelper().GetDay(date) - 1));
            }
        }

        public void writeDateExportDateFromInSearch(string date)
        {
            if (!date.Equals(""))
            {
                SendKeys(_driver, _searchTabExportedDateFrom, new DateTimeHelper().GetDate(date));
                var result = _daysOnCal();
                Click(_driver, _daysOnCal().ElementAt(new DateTimeHelper().GetDay(date) - 1));
            }
        }

        public void CancelFunctionForNewWindowPrint()
        {
            // Choosing the second window which is the print dialog.
            // Switching to opened window of print dialog.
            _driver.SwitchTo().Window(_driver.WindowHandles.ToArray()[1].ToString());
            // Runs code for cancelling print operation.
            // This code only executes for Chrome browsers.
            //_driver.FindElement(By.XPath(".//*[@id='print-header']/div/button[2]")).Click();
            Click(_driver, _cancelBtnPrintPreview);
            // Switches to main window after print dialog operation.
            _driver.SwitchTo().Window(_driver.WindowHandles.ToArray()[0].ToString());
        }

        public void SaveAsFunctionForNewWindowPrint(string name, IWebDriver driver)
        {
            Thread.Sleep(4000);
            // Choosing the second window which is the print dialog.
            // Switching to opened window of print dialog.
            driver.SwitchTo().Window(driver.WindowHandles.ToArray()[1].ToString());
            // Runs code for cancelling print operation.
            // This code only executes for Chrome browsers.
            //_driver.FindElement(By.XPath(".//*[@id='print-header']/div/button[2]")).Click();
            WaitForElement(driver, _changeBtnPrintPreview);
            Click(driver, _changeBtnPrintPreview);
            SendKeys(driver, _searchBtnPrintPreview , "save as pdf");
            WaitForElement(driver, _searchedDataPrintPreview);
            //for (int i = 0; i < _searchListPrintPreview.Count(); i++)
            //{
            //    if (_searchListPrintPreview.ElementAt(i).Displayed)
            //    {
            //        _searchListPrintPreview.ElementAt(i).Click();
            //    }
            //}

            Click(driver, _searchedDataPrintPreview);

            Click(driver,_saveBtnPrintPreview);
            
            string[] nameOfFile = name.Split(',');
            try
            {
                readFromConfig = new ReadFromConfig();
                fileManager = new TextFileManager();
                string refno = fileManager.readFromFileForCD(nameOfFile[3], nameOfFile[2]);
                refno = fileManager.refnoPure(refno);
                var filePath = readFromConfig.GetValue("DownloadFolder") + nameOfFile[4] + refno + ".pdf";
                Thread.Sleep(1000);
                AutoItX3 autoIt = new AutoItX3();
                autoIt.WinActivate("Save As");
                autoIt.Send(filePath);
                autoIt.Send("{ENTER}");
            }catch
            {
                Console.WriteLine("Error while send data to window!!!");
            }
            // Switches to main window after print dialog operation.
            driver.SwitchTo().Window(driver.WindowHandles.ToArray()[0].ToString());
        }

        public void ClickOnPrintFlowAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printDocFlowTabUnExported);
            Click(_driver, _printDocFlowBtnUnExported);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintAllAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printAllBtnUnExported);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintThisPageAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printThisPageBtn);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintBarcodePageInboxAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printBarcodeMailBtn);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }
        
        public void ClickOnDeleveryStatmentBtnAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printDelieveryStatmentFromPopup);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintStickerAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printStickerBtnDept);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data,driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintBarcodeBtnAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printBarcodeBtnFromPopup);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintDocumentBtnAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printDocumentBtnFromPopup);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintDeliveryStatementBtnAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printDeliveryStatementBtnFromPopup);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        private void clickOnPopupRefbtnJIC()
        {
            Click(_driver, _printRefNoBtnFromPopup);
        }

        public void ClickOnPrintReferenceNumberBtnAndSaveAsBtn(string data, IWebDriver driver)
        {
            Thread.Sleep(1500);
            Click(driver, _printRefNoBtnFromPopup);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintBtnAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printBtnInboxCreatingMail);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintDeliveryStatementAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printDeliveryStatmentBtnDept);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data,driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintAndSaveAsBtn(string data, IWebDriver driver)
        {
            //Click(_driver, _printBtnInboxCreatingMail);
            //
            Click(driver, _printBtnDept);
            Thread.Sleep(2000);
            Click(_driver, _selectAllCheck);
            //okarchivebtn act as print btn here! 
            Click(_driver, _okArchiveBtn);
            SaveAsFunctionForNewWindowPrint(data,driver);
            Thread.Sleep(1000);
        }


        public void SelectivePopupCheckes(string opt)
        {
            string[] optData = opt.Split(',');
            for(int i = 0; i < optData.Count(); i++)
            {
                for (int j = 0; j < _SelectiveLablesForPrintPopup.Count(); j++)
                {
                    if (GetText(_driver, _SelectiveLablesForPrintPopup.ElementAt(j)).Contains(optData[i]))
                    {
                        Click(_driver, _SelectiveCheckboxesForPrintPopup.ElementAt(j));
                    }
                }
            }
        }

        public void ClickOnAttachmentTabInMailAndClickShowAllAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _showAllBtn);
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles[2]).Close(); // close the tab 2
            driver.SwitchTo().Window(driver.WindowHandles[1]).Close(); // close the tab 1
            driver.SwitchTo().Window(driver.WindowHandles[0]); // back to previouse tab Main
            Thread.Sleep(3000);
        }

        public void ClickOutboxPrintStickerBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printStickerBtnDept);
            Thread.Sleep(2000);
            Click(_driver, _chkDep1);
            Click(_driver, _chkDep2);
            Thread.Sleep(2000);
            Click(_driver, _okBtn());
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
            Click(_driver, _closeBtn);
            Thread.Sleep(1000);
            Click(_driver, _inboxPageEraseButton);

        }

        public void ClickOnAttachmentTabInMailAndClickPrintAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printBtn);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnAttachmentTabInMailAndPrintAllAndSaveAsBtn(string data, IWebDriver driver,string size="")
        {
            if (!size.Equals(""))
            {
                int sizeIn = Int16.Parse(size);
                selectAllAttachmentInMail(sizeIn);
            }
            Thread.Sleep(3000);
            Click(driver, _printAllBtn);
            Thread.Sleep(2000);
            _ifOkBtn();
            //okarchivebtn act as print btn here! 
            //Click(_driver, _okArchiveBtn);
            Thread.Sleep(3000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintFormalAndSaveAsBtn(string data, IWebDriver driver)
        {
            Click(driver, _printBtnDept);
            Thread.Sleep(3000);
            Click(driver, _printFormalBtn);
            Thread.Sleep(2000);
            //okarchivebtn act as print btn here! 
            Click(_driver, _okArchiveBtn);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintSelectiveAndSaveAsBtn(string data,string opt, IWebDriver driver)
        {
            Click(driver, _printBtnDept);
            Thread.Sleep(2000);
            SelectivePopupCheckes(opt);
            //okarchivebtn act as print btn here! 
            Click(_driver, _okArchiveBtn);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOutboxPrintBtn(string data, IWebDriver driver)
        {
            Click(_driver, _printBtnOutbox);
            Thread.Sleep(2000);
            Click(_driver, _selectAllCheck);
            //okarchivebtn act as print btn here! 
            Click(_driver, _okArchiveBtn);
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickPrintStickerPopUp(string data, IWebDriver driver)
        {
            Click(_driver, _printStickerPopUpBtn);
            Thread.Sleep(2000);
            Click(_driver, _chkDep1);
            Click(_driver, _chkDep2);
            Thread.Sleep(2000);
            Click(_driver, _okBtn());
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintDeliveryStatementBtnAndSaveAsBtn2(string data, IWebDriver driver)
        {
            Click(_driver, _printDeliveryStatementBtnFromPopup);
            Thread.Sleep(2000);
            Click(_driver, _printDeliveryStatementChk1);
            Click(_driver, _printDeliveryStatementChk2);
            Thread.Sleep(2000);
            Click(_driver, _okBtn());
            SaveAsFunctionForNewWindowPrint(data, driver);
            Thread.Sleep(1000);
        }

        public void ClickOnPrintBtn()
        {
            Click(_driver, _printBtndept);
            Thread.Sleep(2000);
            Click(_driver, _selectAllCheck);
            //okarchivebtn act as print btn here! 
            Click(_driver, _okArchiveBtn);
            Thread.Sleep(2000);
            CancelFunctionForNewWindowPrint();
            Thread.Sleep(1000);
        }

        public void ClickOnPrintStickerBtn()
        {
            Click(_driver, _printStickerBtndept);
            Thread.Sleep(2000);
            CancelFunctionForNewWindowPrint();
            Thread.Sleep(1000);
        }

        public void ClickOnClearBtn()
        {
            WaitTillProcessing();
            Click(_driver, _clearBtn);
            Thread.Sleep(2000);
        }

        public void ClickOnSearchBtn()
        {
            Click(_driver, _searchBtn);
            Thread.Sleep(2000);
        }

        public void ClickOnRetrieveBtn()
        {
            WaitTillProcessing();
            Click(_driver, _retrieveBtn);
            Thread.Sleep(2000);
        }

        public bool CheckOnRetrieveBtn()
        {
            WaitTillProcessing();
            if (_retrieveBtn.Displayed)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Retrieve button is not visible!!!");
                return false;
            }
            Thread.Sleep(2000);
        }

        public void ClickOnReplyAllBtn()
        {
            Thread.Sleep(1600);
            Click(_driver, _replyAllBtn);
            Thread.Sleep(2000);
        }

        public void ClickonPrintAllAndSaveAsButton(string data, IWebDriver driver)
        {
            Click(_driver, _printAllBtn);
            Thread.Sleep(2000);
            //Click(_driver, _yesBtn);
            //Click(_driver, yesBtnForCreatingMyDraft);
            Click(_driver, _okBtn());
            Thread.Sleep(2000);
            SaveAsFunctionForNewWindowPrint(data, driver);
        }

        public void clickFormateOption(string opt)
        {
            WaitTillProcessing();
            if (opt.Equals("Normal View"))
            {
                Click(_driver, _NormalViewBtn);
                Thread.Sleep(2000);
            }
            else if (opt.Equals("Formal View"))
            {
                Click(_driver, _ViewUsingFormalTemplateBtn);
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("No such option Found to Click on!!!");
            }

            Thread.Sleep(2000);
        }

        public void ClickOnExportBtn2()
        {
            WaitTillProcessing();
            Click(_driver, _exportBtn2);
            Thread.Sleep(2000);
        }

        public void ClickOnCloseBtn()
        {
            WaitTillProcessing();
            Click(_driver, _closeBtn);
            Thread.Sleep(2000);
        }

        public void clickArchieveBtn()
        {
            Click(_driver, _archieveBtn);
            Thread.Sleep(1000);
            Click(_driver, _okBtn());
            Thread.Sleep(1000);
        }
        public void SelectFolder(IWebDriver driver, String folderName)
        {
            Click(_driver, _movFoldBtn);
            Thread.Sleep(2000);
            var option = driver.FindElement(By.Id("select-folder"));
            var selectElement = new SelectElement(option);
            selectElement.SelectByIndex(2);
            Thread.Sleep(3000);
        }

        public void ClickOnActionsAndMovementsBtn()
        {
            WaitTillProcessing();
            Click(_driver, _ActionAndMovementBtn);
            Thread.Sleep(2000);
        }

        public void ClickOnFollowUpBtn()
        {
            WaitTillProcessing();
            Click(_driver, _followUpBtn);
            Thread.Sleep(2000);
        }

        public void ClickOnReturnBtn()
        {
            WaitTillProcessing();
            Click(_driver, _returnBtn);
            Thread.Sleep(2000);
        }

        public bool OpenMailSpecial(IWebDriver driver, string strData, string encryptPass = "", bool withSubject = true)
        {
            if (withSubject == false)
            {
                firstSearchFolderWithRefNo(strData);
                WaitTillMailsGetLoad();
                Thread.Sleep(2000);
            }
            else if (withSubject == true)
            {
                firstSearchInbox(strData);
                WaitTillMailsGetLoad();
            }

            int searchResult = _subjectList.Count();

            if (searchResult >= 1 && withSubject == true)
            {
                Click(driver, _subjectList.ElementAt(0));
                if (!encryptPass.Equals(""))
                {
                    EncryptedPassword = encryptPass;
                    Click(driver, _encryptedPasswordOkBtn);
                    Thread.Sleep(5000);
                }
                return true;
            }
            else if (searchResult >= 1 && withSubject == false)
            {
                Click(driver, _referenceNoList.ElementAt(0));
                if (!encryptPass.Equals(""))
                {
                    EncryptedPassword = encryptPass;
                    Click(driver, _encryptedPasswordOkBtn);
                    Thread.Sleep(5000);
                }
                return true;
            }
            Console.WriteLine("No such mail found!!!");
            return false;
        }

        public bool OpenMailForSameRefNos(IWebDriver driver, string strData, string subject, bool withSubject = true)
        {
            string e1;
            if (withSubject == true)
            {
                firstSearchFolderWithRefNo(strData);
                WaitTillMailsGetLoad();
            }
            int searchResult = _subjectList.Count();
            if (searchResult >= 1 && withSubject == true)
            {
                foreach (IWebElement elem in _subjectList)
                {
                    e1 = GetText(driver, elem);
                    if (e1.Equals(subject))
                    {
                        Click(driver, elem);
                        Thread.Sleep(1000);
                        return true;
                    }
                }
            }
            Console.WriteLine("No such mail found!!!");
            return false;
        }

        public void clickSaveEditBtn()
        {
            WaitTillProcessing();
            Click(_driver, _saveEditBtn);
            Thread.Sleep(2000);
        }

        public void clickUndoExportBtn()
        {
            WaitTillProcessing();
            Click(_driver, _undoExportBtn);
            Thread.Sleep(1000);
        }

        public void clickExportBtn(bool checkPopup = false)
        {
            Click(_driver, _exportBtn);
            Thread.Sleep(2000);
            Click(_driver, _chk1);
            Click(_driver, _chk2);
            Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
            WaitTillProcessing();
        }
        
        public void clickReplyBtnMyInbox()
        {
            Click(_driver, _myInboxReplyBtn);
            Thread.Sleep(2000);
        }


        public void clickConfirmReceivingBtn()
        {
            Click(_driver, _confirmReceivingBtn);
            Thread.Sleep(1000);
            Click(_driver, _okArchiveBtn);
            Thread.Sleep(2000);
        }

        public void clickExportBtnInCommDeptUnexportedF(bool checkPopup = false)
        {
            Click(_driver, _exportBtnInUnexportFolder);
            Thread.Sleep(1000);
            Click(_driver, _exportCancelBtn);
            //_ifCancelBtn();
            Thread.Sleep(2000);
        }

        public bool OpenMail(IWebDriver driver, string strData, string encryptPass = "", bool withSubject = true)
        {
            firstSearchInbox(strData);
            WaitTillMailsGetLoad();
            int searchResult = _subjectList.Count();
            if (searchResult >= 1 && withSubject == true)
            {
                foreach (IWebElement elem in _subjectList)
                {
                    if (GetText(driver, elem).Equals(strData))
                    {
                        Click(driver, elem);
                        Thread.Sleep(1000);
                        if (!encryptPass.Equals(""))
                        {
                            EncryptedPassword = encryptPass;
                            Click(driver, _encryptedPasswordOkBtn);
                            Thread.Sleep(5000);
                        }
                        return true;
                    }
                }
            }
            else if (searchResult >= 1 && withSubject == false)
            {
                foreach (IWebElement elem in _referenceNoList)
                {
                    if (GetText(driver, elem).Equals(strData))
                    {
                        Click(driver, elem);
                        Thread.Sleep(1000);
                        if (!encryptPass.Equals(""))
                        {
                            EncryptedPassword = encryptPass;
                            Click(driver, _encryptedPasswordOkBtn);
                            Thread.Sleep(5000);
                        }
                        return true;
                    }
                }
            }
            Console.WriteLine("No such mail found!!!");
            return false;
        }

        public bool ValidateTo(IWebDriver driver, string to)
        {
            return GetText(driver, _mailTo).Contains(to);
        }

        public bool ValidateSubject(IWebDriver driver, string subject, string ccStatus = "False")
        {
            if (ccStatus.Equals("False")) {
                return GetText(driver, _subjectInbox).Equals(subject);
            }
            return GetText(driver, _subjectInboxWithCC).Equals(subject);
        }

        public bool ValidateContentBody(IWebDriver driver, string contentBody)
        {
            return GetText(driver, _contentBodyInbox).Equals(contentBody);
        }

        public bool ValidateMailEncrypted(IWebDriver driver, string to, string subject, string body, string ccStatus = "False", string refno = "", bool aviKaParameterToDifferentiateWithBelowFunction = true, string encryptPass = "")
        {
            if (OpenMailSpecial(driver, refno, encryptPass, withSubject: false))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject) && ValidateContentBody(driver, body));
            }
            return false;
        }

        public bool ValidateMail(IWebDriver driver, string to, string subject, string body, string ccStatus = "False", string refno = "", bool aviKaParameterToDifferentiateWithBelowFunction = true)
        {
            if (OpenMailSpecial(driver, refno, withSubject: false))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject, ccStatus) && ValidateContentBody(driver, body));
            }
            return false;
        }

        public bool ValidateMail(IWebDriver driver, string to, string subject, string body, string listSubject, string encryptPass)
        {
            if (OpenMail(driver, listSubject, encryptPass))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject) && ValidateContentBody(driver, body));
            }
            return false;
        }

        public bool WaitTillMailSent()
        {
            try {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                wait.Until(drv => ElementIsDisplayed(_driver, _notificationContent(_driver)));
                return true;
            }
            catch (Exception) {
                Console.WriteLine("Notification on sending email does not appear");
                return false;
            }
        }

        public void WaitTillProcessing()
        {
            int tries = 0;
            try
            {
                while (ElementIsDisplayed(_driver, _processing(_driver)) && tries < 1000)
                {
                    tries++;
                    continue;
                }
            }
            catch (Exception) {
                return;
            }
        }

        public void WaitTillMailsGetLoad()
        {
            while (ElementIsDisplayed(_driver, _mailLoading(_driver)))
            {
                continue;
            }
        }

        public int SearchDept(string deptName = "", string deptCode = "", string type = "") {
            if (!deptName.Equals(""))
            {
                SendKeys(_driver, _searchDeptName, deptName);
            }
            if (!deptCode.Equals(""))
            {
                SendKeys(_driver, _searchDeptCodeName, deptName);
            }
            if (!type.Equals(""))
            {
                DropdownSelectByText(_driver, _deptType(_driver), type);
            }
            Thread.Sleep(5000);
            WaitForElement(_driver, _deptNames(_driver).ElementAt(0));
            var deptNames = _deptNames(_driver);
            for (int index = 0; index < deptNames.Count; index++) {
                if (GetText(_driver, deptNames.ElementAt(index)).Equals(deptName)) {
                    return index;
                }
            }
            return -1;
        }

        public bool SelectExternalDeptTo(string deptName = "", string deptCode = "", string type = "")
        {
            Thread.Sleep(4000);
            Click(_driver, _externalDeptToBtn);
            int index = SearchDept(deptName, deptCode, type);
            if (index != -1) {
                Thread.Sleep(5000);
                Click(_driver, _deptRadioBtn(_driver).ElementAt(index));
                Thread.Sleep(2000);
                Click(_driver, _okBtn());
                Thread.Sleep(2000);
                return true;
            }
            Click(_driver, _okBtn());
            return false;
        }


        public bool SelectExternalDeptCc(string deptName = "", string deptCode = "", string type = "")
        {
            Thread.Sleep(4000);
            Click(_driver, _externalDeptCcBtn);
            int index = SearchCcDept(deptName, deptCode, type);
            if (index != -1)
            {
                Thread.Sleep(5000);
                Click(_driver, _deptCcRadioBtn(_driver).ElementAt(index));
                Thread.Sleep(2000);
                Click(_driver, _okBtn());
                Thread.Sleep(2000);
                return true;
            }
            Click(_driver, _okBtn());
            return false;
        }


        public int SearchCcDept(string deptName = "", string deptCode = "", string type = "")
        {
            if (!deptName.Equals(""))
            {
                SendKeys(_driver, _searchCcDeptName, deptName);
            }
            if (!deptCode.Equals(""))
            {
                SendKeys(_driver, _searchDeptCodeName, deptName);
            }
            if (!type.Equals(""))
            {
                DropdownSelectByText(_driver, _deptType(_driver), type);
            }
            Thread.Sleep(5000);
            var deptNames = _deptCcNames(_driver);
            for (int index = 0; index < deptNames.Count; index++)
            {
                if (GetText(_driver, deptNames.ElementAt(index)).Equals(deptName))
                {
                    return index;
                }
            }
            return -1;
        }

        public void ComposeMail(string subject, string contentBody, string multipleAttachementNo = "No", string multipleAttachmentType = "png") {
            if (subject != "")
            {
                Subject = subject;
            }
            EnterContentBody(contentBody);
        }

        public void SetProperties(string deliveryType = "", string securityLevel = "", string messageNo = "", string messageHijriDate = "", string messageGreorianDate = "", string messageType = "", string tengibleNo = "", string tengibleDesc = "", string exportMethod = "")
        {
            Click(_driver, _documentTab);
            Click(_driver, _propertiesTab);
            if (!messageType.Equals(""))
            {
                DropdownSelectByText(_driver, _messageType(), messageType);
            }

            if (!tengibleNo.Equals(""))
            {
                SendKeys(_driver, _tengibleNo, tengibleNo);
            }

            if (!tengibleDesc.Equals(""))
            {
                SendKeys(_driver, _tengibleDesc, tengibleDesc);
            }

            if (!deliveryType.Equals(""))
            {
                DropdownSelectByText(_driver, _deliveryType(), deliveryType);
            }

            if (!securityLevel.Equals("")) {
                DropdownSelectByText(_driver, _securityLevel(), securityLevel);
            }

            if (!messageNo.Equals(""))
            {
                messageNo = getRandomNo();
                SendKeys(_driver, _incommingMessageNo, messageNo);
            }

            if (!exportMethod.Equals(""))
            {
                if (exportMethod.Equals("Indirect Export Method"))
                {
                    var btn = _driver.FindElement(By.XPath("//*[@id='docProperty-part']/*//div[@class='divNeedReplyRadio']/input[@class='narrowRadio'][@value='0']"));
                    btn.Click();
                    //Click(_driver, _indirectExportMethod);
                }
                else if (exportMethod.Equals("Direct Export Method"))
                {
                    var btn = _driver.FindElement(By.XPath("//*[@id='docProperty-part']/*//div[@class='divNeedReplyRadio']/input[@class='narrowRadio'][@value='1']"));
                    btn.Click();
                    //Click(_driver, _directExportMethod);
                }
            }

            if (!messageGreorianDate.Equals(""))
            {
                SendKeys(_driver, _incommingGregorianMessageDate, new DateTimeHelper().GetDate(messageGreorianDate));
                var result = _daysOnCal();
                Click(_driver, _daysOnCal().ElementAt(new DateTimeHelper().GetDay(messageGreorianDate) - 1));
                _incommingGregorianMessageDate.SendKeys(Keys.Enter);
                Click(_driver, _incommingHijriMessageDate);
                _incommingHijriMessageDate.SendKeys(Keys.Tab);
            }

            if (!messageHijriDate.Equals(""))
            {
                SendKeys(_driver, _incommingHijriMessageDate, new DateTimeHelper().GetDateHijri(messageHijriDate));
                _incommingHijriMessageDate.SendKeys(Keys.Enter);
                //var result = _daysOnCal();
                //Click(_driver, _daysOnCal().ElementAt(new DateTimeHelper().GetDayHijri(messageHijriDate)-1));
                //Click(_driver, _incommingHijriMessageDate);
                //_incommingHijriMessageDate.SendKeys(Keys.Tab);
            }
        }

        public string getRandomNo()
        {
            Random r = new Random();
            var x = r.Next(0, 1000000);
            string s = x.ToString("000000");
            return s;
        }

        public void SendOutgoingMessage(string subject, string contentBody, string deliveryType = "", string deptName = "", string deptCode = "", string type = "") {
            NavigateToMyMessageInbox(_driver);
            CheckButtonClickable(_driver, "Outgoing Document");
            SelectExternalDeptTo(deptName, deptCode, type);
            SetProperties(deliveryType);
            Click(_driver, _contentTab);
            SendMail(subject, contentBody, checkPopup: true);
        }

        public void WaitForUploading()
        {
            Thread.Sleep(1000);
            while (_progressbar(_driver).Count != 0)
            {
                bool stillUploading = false;
                var progress = _progressbar(_driver);
                foreach (IWebElement progressbar in progress) {
                    if (ElementIsDisplayed(_driver, progressbar)) {
                        stillUploading = true;
                        break;
                    }
                }
                if (!stillUploading) {
                    return;
                }
            }
        }

        public void AddAttachments(string multipleAttachmentType, int multipleAttachementNo) {
            if (!multipleAttachmentType.Equals(""))
            {
                if (multipleAttachmentType.Contains(","))
                {
                    string[] types = multipleAttachmentType.Split(',');
                    foreach (string type in types)
                    {
                        Click(_driver, _attachmentTab);
                        Click(_driver, _attacheBtn);
                        AutoItX3 autoIt = new AutoItX3();
                        autoIt.WinActivate("Open");
                        readFromConfig = new ReadFromConfig();
                        Thread.Sleep(2000);
                        var filePath = readFromConfig.GetValue("AttachementFolder") + type;
                        Thread.Sleep(2000);
                        autoIt.Send(filePath);
                        autoIt.Send("{ENTER}");
                        WaitForUploading();
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    for (int i = 0; i < multipleAttachementNo; i++)
                    {
                        Click(_driver, _attachmentTab);
                        Click(_driver, _attacheBtn);
                        AutoItX3 autoIt = new AutoItX3();
                        autoIt.WinActivate("Open");
                        readFromConfig = new ReadFromConfig();
                        var filePath = readFromConfig.GetValue("AttachementFolder") + multipleAttachmentType;
                        autoIt.Send(filePath);
                        autoIt.Send("{ENTER}");

                        WaitForUploading();
                    }
                }
            }
        }

        public void DeleteAttachments(string deleteAttachmentTypes, int deleteAttachmentNo)
        {
            Click(_driver, _attachmentTab);
            if (!deleteAttachmentTypes.Equals(""))
            {
                var fileNames = _attachedFileNames(_driver);
                var checkBoxes = _attachedFilesCheckboxes(_driver);
                if (deleteAttachmentTypes.Contains(","))
                {
                    string[] types = deleteAttachmentTypes.Split(',');
                    foreach (string type in types)
                    {
                        for (int index = 0; index < fileNames.Count; index++) {
                            if (GetAttribute(_driver, fileNames.ElementAt(index), "title").Equals(type)) {
                                Click(_driver, checkBoxes.ElementAt(index));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < deleteAttachmentNo; i++)
                    {
                        if (GetAttribute(_driver, fileNames.ElementAt(i), "title").Equals(deleteAttachmentTypes))
                        {
                            Click(_driver, checkBoxes.ElementAt(i));
                        }
                    }
                }
                Click(_driver, _deleteBtn);
            }
        }

        public bool ValidateAttachments(IWebDriver driver, int attachmentNo, string attachment, int deleteAttachmentNo = 0)
        {
            var fileNames = _attachedFileNames(_driver);
            if (fileNames.Count == attachmentNo - deleteAttachmentNo)
            {
                for (int index = 0; index < attachmentNo - deleteAttachmentNo; index++)
                {
                    if (!attachment.Contains(GetAttribute(driver, fileNames.ElementAt(index), "title")))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void DownloadFile(string subject, string downloadFileName, int downloadFileNo)
        {
            OpenMail(_driver, subject);
            Click(_driver, _attachmentTab);
            if (!(downloadFileName.Equals("All") && downloadFileName.Equals("")))
            {
                var fileNames = _attachedFileNames(_driver);
                var checkBoxes = _attachedFilesCheckboxes(_driver);
                if (downloadFileName.Contains(","))
                {
                    string[] types = downloadFileName.Split(',');
                    foreach (string type in types)
                    {
                        for (int index = 0; index < fileNames.Count; index++)
                        {
                            if (GetAttribute(_driver, fileNames.ElementAt(index), "title").Equals(type))
                            {
                                Click(_driver, checkBoxes.ElementAt(index));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < downloadFileNo; i++)
                    {
                        if (GetAttribute(_driver, fileNames.ElementAt(i), "title").Equals(downloadFileName))
                        {
                            Click(_driver, checkBoxes.ElementAt(i));
                        }
                    }
                }
                Click(_driver, _downloadBtn);
            }
            else if (downloadFileName.Equals("All")) {
                Click(_driver, _downloadAllBtn);
            }
        }

        public void ClickConnectedDocTab(IWebDriver driver)
        {
            Click(driver, _connectedDocTab);
        }

        public void SearchConnectedDoc(string subject)
        {
            Click(_driver, _connectedDocTab);
            Click(_driver, _addNewBtn);
            Thread.Sleep(1000);
            SendKeys(_driver, _connectedDocSubject, subject);
            Click(_driver, _connectedDocSearchBtn);
            Thread.Sleep(2000);
        }

        public void SearchConnectedDocForAnyDoc()
        {
            Click(_driver, _connectedDocTab);
            Click(_driver, _addNewBtn);
            Thread.Sleep(1000);
        }

        public string addNumberInString(string refno, int add)
        {
            string[] strArray = refno.Split('-');
            for (int i = 0; i < strArray.Length; i++)
            {
                Console.WriteLine("I am in for loop index at " + i + " : " + strArray[i]);
            }
            int numValOld = Int16.Parse(strArray[2]);
            int numValNew = numValOld + add;
            string numValOldStr = numValOld.ToString();
            string numValNewStr = numValNew.ToString();
            strArray[2] = strArray[2].Replace(numValOldStr, numValNewStr);

            string newRefNo = strArray[0] + "-" + strArray[1] + "-" + strArray[2];
            return newRefNo;
        }

        public bool validateConnectedDocWithRefNoFoundOrNot(IWebDriver driver, string refno, string docType)
        {
            SearchConnectedDocWithRefrenceNo(refno, docType);
            int searchResults = _connectedDocSearchedReferenceNo().Count;
            for (int i = 0; i <= searchResults && searchResults >= 1; i++)
            {
                if (GetText(driver, _connectedDocSearchedReferenceNo().ElementAt(i)).Equals(refno))
                {
                    Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                    return true;
                }
            }
            Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
            return false;
        }

        public bool selectConnectedDocWithRefNoAndDocType(IWebDriver driver, string refno, string docType)
        {
            SearchConnectedDocWithRefrenceNo(refno, docType);
            int searchResults = _connectedDocSearchedReferenceNo().Count;
            for (int i = 0; i <= searchResults; i++)
            {
                if (GetText(driver, _connectedDocSearchedReferenceNo().ElementAt(i)).Equals(refno))
                {
                    if (searchResults >= 1)
                    {
                        Click(_driver, _connectedDocSearchedCheckBoxes().ElementAt(i));
                        Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                        return true;
                    }
                }
            }
            Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
            return false;
        }

        public bool selectConnectedDocWithRefNoAndDeliveryType(IWebDriver driver, string refno, string deliveryType)
        {
            SearchConnectedDocWithRefrenceNo(refno, deliveryType: deliveryType);
            int searchResults = _connectedDocSearchedReferenceNo().Count;
            for (int i = 0; i <= searchResults; i++)
            {
                if (GetText(driver, _connectedDocSearchedReferenceNo().ElementAt(i)).Equals(refno))
                {
                    if (searchResults >= 1)
                    {
                        Click(_driver, _connectedDocSearchedCheckBoxes().ElementAt(i));
                        Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                        return true;
                    }
                }
            }
            Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
            return false;
        }

        public void SearchConnectedDocWithRefrenceNo(string refno, string docType = "", string deliveryType = "")
        {
            Click(_driver, _connectedDocTab);
            Click(_driver, _addNewBtn);
            WaitTillProcessing();
            if (docType != "")
            {
                DropdownSelectByText(_driver, _connectedDocDocType(_driver), docType);
            }
            if (deliveryType != "")
            {
                DropdownSelectByText(_driver, _connectedDocDeliveryType(_driver), docType);
            }
            SendKeys(_driver, _connectedDocRefNoField, refno);
            Click(_driver, _connectedDocSearchBtn);
            WaitTillProcessing();
        }

        public string ReadReferenceNoOfConnectedDoc(IWebDriver driver, string subject)
        {
            SearchConnectedDoc(subject);
            for (int index = 0; index <= _connectedDocSearchedReferenceNo().Count(); index++)
            {
                if (GetText(driver, _connectedDocSearchedSubjects().ElementAt(index)).Equals(subject))
                {
                    WaitTillProcessing();
                    string refno = GetText(driver, _connectedDocSearchedReferenceNo().ElementAt(index));
                    Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                    return refno;
                }
            }
            Console.WriteLine("Error searched document does not exists");
            return null;
        }

        public void SelectConnectedPerson(IWebDriver driver, string personName = "", string email = "", string mbl = "", string idNum = "", string idIssue = "", string issueDate = "", string idType = "", string saveStatus = "True")
        {
            Click(driver, _connectedPersonTab);
            Click(driver, _addNewBtnPersonTab);
            WaitTillProcessing();
            if (!personName.Equals(""))
            {
                Thread.Sleep(1000);
                SendKeys(driver, _personTabName, personName);
            }
            if (!email.Equals(""))
            {
                Thread.Sleep(1000);
                SendKeys(driver, _personTabEmail, email);
            }
            if (!mbl.Equals(""))
            {
                Thread.Sleep(1000);
                SendKeys(driver, _personTabMobile, mbl);
            }
            if (!idNum.Equals(""))
            {
                Thread.Sleep(1000);
                SendKeys(driver, _personTabIdNumber, idNum);
            }
            if (!idIssue.Equals(""))
            {
                Thread.Sleep(1000);
                SendKeys(driver, _personTabIdIssuer, idIssue);
            }
            if (!issueDate.Equals(""))
            {
                SendKeys(driver, _personTabIssueDate, new DateTimeHelper().GetDate(issueDate));
                var result = _daysOnCal();
                Click(driver, _daysOnCal().ElementAt(new DateTimeHelper().GetDay(issueDate) - 1));
            }
            if (!idType.Equals(""))
            {
                Thread.Sleep(1000);
                DropdownSelectByText(driver, _personTabIdType(driver), idType);
            }
            if (saveStatus.Equals("True"))
            {
                Click(_driver, _connectedPersonSaveBtn.ElementAt(_connectedPersonSaveBtn.Count - 1));
                Thread.Sleep(1000);
            }
            if (saveStatus.Equals("False"))
            {
                Click(_driver, _connectedPersonCancelBtn.ElementAt(_connectedPersonSaveBtn.Count - 1));
                Thread.Sleep(1000);
            }
        }

        public bool ValidateMailAppearInAdvanceSearch(IWebDriver driver, string refno)
        {
            int searchResult = _advanceSearchRefNoList.Count();

            if (searchResult >= 1)
            {
                for(int i = 0; i < searchResult;i++)
                {
                    string temp = GetText(driver, _advanceSearchRefNoList.ElementAt(i));
                    if (GetText(driver,_advanceSearchRefNoList.ElementAt(i)).Equals(refno))
                    {
                        Thread.Sleep(1000);
                        return true;
                    }
                }
            }
            return false;
        }

        public void SelectCcUser(IWebDriver driver, string user, string receiverType)
        {
            WaitTillProcessing();
            Thread.Sleep(2000);

            if (receiverType.Equals("Users"))
            {
                for (int index = 0; index < _selectToNameForUsers().Count; index++)
                {
                    if (GetText(driver, _selectToNameForUsers().ElementAt(index)).Contains(user))
                    {
                        Click(driver, _selectToCheckForUser.ElementAt(index));
                        Click(driver, _selectToFrameCCBtn);
                        Thread.Sleep(1000);
                        return;
                    }
                }
            }
            else if (receiverType.Equals("Structural Hierarchy"))
            {
                for (int index = 0; index < _selectToNameForStructuralHierarchy().Count; index++)
                {
                    if (GetText(driver, _selectToNameForStructuralHierarchy().ElementAt(index)).Contains(user))
                    {
                        Click(driver, _selectToCheckForStructuralHierarchy.ElementAt(index));
                        Click(driver, _selectToFrameCCBtn);
                        Thread.Sleep(1000);
                        return;
                    }
                }
            }
        }

        /*public void SelectCcUser(IWebDriver driver, string user)
        {
            WaitTillProcessing();
            for (int index = 0; index < _selectToName().Count; index++)
            {
                if (GetText(driver, _selectToName().ElementAt(index)).Contains(user))
                {
                    Click(driver, _selectToCheck.ElementAt(index));
                    Click(driver, _selectToFrameCCBtn);
                    Thread.Sleep(1000);
                    return;
                }
            }
        }*/

        public void ClickCCbutton(IWebDriver driver)
        {
            Click(driver, _selectMainCcFramBtn);
        }

        public int SelectConnectedDocWithRefno(string refno, bool statusSave = true)
        {
            SearchConnectedDocWithRefrenceNo(refno);
            Thread.Sleep(3000);
            int searchResults = _connectedDocSearchedReferenceNo().Count;
            if (searchResults >= 1)
            {
                Click(_driver, _connectedDocSearchedCheckBoxes().ElementAt(0));
                if (statusSave == true)
                {
                    Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                    return searchResults;
                }
                else if (statusSave == false)
                {
                    Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                    return searchResults;
                }
            }
            Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
            return searchResults;
        }

        public void readRefNoFromPopupAndSaveItInTxtFile(string type, string subject)
        {
            Thread.Sleep(3000);
            String refno = GetText(_driver, _PopupRefnoLable);
            fileManager = new TextFileManager();
            fileManager.writeToFile(type, subject, refno);
        }

        public string readRefNoFromList(string subject)
        {
            if (_connectedDocList.Count()>=1)
            {
                for(int i =0; i< _connectedDocList.Count(); i++)
                {
                    if (GetText(_driver, _connectedDocSubjectList().ElementAt(i)).Equals(subject))
                    {
                        return GetText(_driver, _connectedDocList.ElementAt(i));
                    }
                }
            }

            return "No Connected Doc Found in List!!!";
        }

        public string readRefNoFromListForAnyDoc()
        {
            if (_connectedDocList.Count() >= 1)
            {
                return GetText(_driver, _connectedDocList.ElementAt(0));
            }
            return "No Connected Doc Found in List!!!";
        }

        public string SelectConnectedDocWithRefNoToSave(string subject)
        {
            if (subject.Equals("Any Doc"))
            {
                SearchConnectedDocForAnyDoc();
                Thread.Sleep(3000);
                int searchResults2 = _connectedDocSearchedReferenceNo().Count;
                if (searchResults2 >= 1)
                {
                    Click(_driver, _connectedDocSearchedCheckBoxes().ElementAt(0));
                    Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                    return readRefNoFromListForAnyDoc();
                }
                Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                return "No Data Found for Connected Doc !!!";
            }
            else
            {
                SearchConnectedDoc(subject);
            }
            Thread.Sleep(3000);
            int searchResults = _connectedDocSearchedReferenceNo().Count;
            if (searchResults >= 1)
            {
                Click(_driver, _connectedDocSearchedCheckBoxes().ElementAt(0));
                Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                return readRefNoFromList(subject);
            }
            Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
            return "No Data Found for Connected Doc !!!";
        }

        public int SelectConnectedDoc(string subject,bool statusSave= true)
        {
            if(subject.Equals("Any Doc"))
            {
                SearchConnectedDocForAnyDoc();
                Thread.Sleep(3000);
                int searchResults2 = _connectedDocSearchedReferenceNo().Count;
                if (searchResults2 >= 1)
                {
                    Click(_driver, _connectedDocSearchedCheckBoxes().ElementAt(0));
                    Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                    return searchResults2;
                }
                Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                return searchResults2;
            }
            SearchConnectedDoc(subject);
            int searchResults = _connectedDocSearchedSubjects().Count;
            //SearchConnectedDocWithRefrenceNo(refno);
            //int searchResults = _connectedDocSearchedReferenceNo().Count;
            if (searchResults >= 1) {
                Click(_driver, _connectedDocSearchedCheckBoxes().ElementAt(0));
                if (statusSave == true)
                { 
                    Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                    return searchResults;
                }
                else if(statusSave == false)
                {
                    Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                    return searchResults;
                }
            }
            Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
            return searchResults;
        }

        public bool CheckVisibiltyOnConnectedPerson(string buttonName, bool value)
        {
            Click(_driver, _connectedPersonTab);
            if (buttonName.Equals("Add"))
            {
                return ElementIsDisplayed(_driver, _addNewBtnPersonTab) == value;
            }
            else if (buttonName.Equals("Delete"))
            {
                return ElementIsDisplayed(_driver, _connectedPersonDeleteBtn) == value;
            }
            else if (buttonName.Equals("Edit"))
            {
                return ElementIsDisplayed(_driver, _editBtnPersonTab) == value;
            }
            return false;
        }

        public bool CheckVisibiltyOnConnectedDoc(string buttonName, bool value)
        {
            Click(_driver, _connectedDocTab);
            if (buttonName.Equals("Add")) {
                return ElementIsDisplayed(_driver, _addNewBtn) == value;
            }
            else if (buttonName.Equals("Delete"))
            {
                return ElementIsDisplayed(_driver, _connectedDocDeleteBtn) == value;
            }
            return false;
        }

        public void ClickExportedTabBtn()
        {
            Click(_driver, _outgoingIncomingDateTab);
            Thread.Sleep(1000);
            Click(_driver, _connectedTabDoc);
        }

        public bool CheckVisibiltyOfTab(string tab, bool value)
        {
            if (tab.Equals("Connected Document"))
            {
                bool chk = ElementIsDisplayed(_driver, _connectedDocTab) == value;
                return chk;
            }
            if(tab.Equals("Connected Persons"))
            {
                return ElementIsDisplayed(_driver, _connectedPersonTab) == value;
            }
            
            return false;
        }

        public void ClickOnReply()
        {
            Click(_driver, _replyBtn);
            Thread.Sleep(5000);
        }

        public void ClickOnForward()
        {
            Click(_driver, _forwardBtn);
            Thread.Sleep(5000);
        }

        public void clickOnYesbtn()
        {
            Thread.Sleep(2000);
            Click(_driver, _yesBtn);
        }

        public void clickOnCancelbtn()
        {
            Thread.Sleep(2000);
            Click(_driver, _connectedPersonCancelBtn.ElementAt(_connectedPersonSaveBtn.Count - 1));
        }

        public bool DeleteMail()
        {
            try
            {
                WaitTillProcessing();
                Click(_driver, _deleteMailBtn);
                Thread.Sleep(1000);
                Click(_driver, _yesBtn);
                Console.WriteLine("Mail Deleted!!!");
                return true;
            }
            catch
            {
                Console.WriteLine("Some Error in Deleting Mail!!!");
                return false;
            }
        }

        public void DeleteDraft()
        {
            SaveDraft();
            WaitTillProcessing();
            Click(_driver, _deleteDraftBtn);
            Click(_driver, _yesBtn);
        }

        public void ClickOnArchive(string comnt, string attachmentFile="", string dept="")
        {
            if (dept.Equals("my"))
            {
                Click(_driver, _inboxArchiveBtn);
                WaitTillProcessing();
            }
            else if (dept.Equals("dept"))
            {
                Click(_driver, _inboxDeptArchiveBtn);
                WaitTillProcessing();
            }
            else if(dept.Equals("deptOutgoing"))
            {
                Click(_driver, _inboxDeptOutgoingArchiveBtn);

                WaitTillProcessing();
            }
            else if (dept.Equals("deptCommDept"))
            {
                Click(_driver, _commDeptExportArchiveBtn);
                WaitTillProcessing();
            }
            if (!comnt.Equals(""))
            {
                SendKeys(_driver, _inboxArchiveComment, comnt);
            }
            if (!attachmentFile.Equals(""))
            {
                for (int i = 0; i < 1; i++)
                {
                    Click(_driver, _archiveAttacheBtn);
                    Thread.Sleep(1600);
                    AutoItX3 autoIt = new AutoItX3();
                    autoIt.WinActivate("Open");
                    readFromConfig = new ReadFromConfig();
                    var filePath = readFromConfig.GetValue("AttachementFolder") + attachmentFile;
                    autoIt.Send(filePath);
                    autoIt.Send("{ENTER}");

                    WaitForUploading();
                }
                Thread.Sleep(1000);
                if (dept.Equals("deptCommDept"))
                {
                    Click(_driver, _okArchiveBtn);
                    return;
                }
            }
            ClickOkBtn();
        }

        public void SaveDraft()
        {
            Click(_driver, _saveDraftBtn);
        }

        public void DeleteDocumetFromTheList(IWebDriver driver,string subject)
        {
            Click(_driver, _connectedDocTab);
            for (int index = 0; index <= _connectedDocSubjectList().Count(); index++)
            {
                if (ValidateConnectedDocumentList(subject))
                {
                    Click(driver, _connectedDocSubjectListCheckBox.ElementAt(index));
                    WaitTillProcessing();
                    Click(driver, _connectedDocDeleteBtn);
                    WaitTillProcessing();
                    Click(driver,_yesBtn);
                    ChkIfPopupThenOK();
                    return;
                }
            }
        }

        public void ChkIfPopupThenOK()
        {
            _ifOkBtn();
        }

        public void createFolder(String name)
        {
            RightClick(_driver, _inboxBtn);
            Click(_driver, _createFolder);
            Thread.Sleep(3000);
            SendKeys(_driver, _folderName, name);
            Thread.Sleep(1000);
            Click(_driver, _okBtn());
        }

        public void EditPersonFromTheList(IWebDriver driver, string name , string personName = "", string email = "", string mbl = "", string idNum = "", string idIssue = "", string issueDate = "", string idType = "", string saveStatus = "True")
        {
            for (int index = 0; index <= _connectedPersonNameList().Count(); index++)
            {
                if (ValidateConnectedPersonList(name))
                {
                    Click(driver, _connectedPersonListCheckBox.ElementAt(index));
                    WaitTillProcessing();
                    Click(driver, _editBtnPersonTab);
                    WaitTillProcessing();
                    if (!personName.Equals(""))
                    {
                        Thread.Sleep(1000);
                        SendKeys(driver, _personTabName, personName);
                    }
                    if (!email.Equals(""))
                    {
                        Thread.Sleep(1000);
                        SendKeys(driver, _personTabEmail, email);
                    }
                    if (!mbl.Equals(""))
                    {
                        Thread.Sleep(1000);
                        SendKeys(driver, _personTabMobile, mbl);
                    }
                    if (!idNum.Equals(""))
                    {
                        Thread.Sleep(1000);
                        SendKeys(driver, _personTabIdNumber, idNum);
                    }
                    if (!idIssue.Equals(""))
                    {
                        Thread.Sleep(1000);
                        SendKeys(driver, _personTabIdIssuer, idIssue);
                    }
                    if (!issueDate.Equals(""))
                    {
                        SendKeys(driver, _personTabIssueDate, new DateTimeHelper().GetDate(issueDate));
                        var result = _daysOnCal();
                        Click(driver, _daysOnCal().ElementAt(new DateTimeHelper().GetDay(issueDate) - 1));
                    }
                    if (!idType.Equals(""))
                    {
                        Thread.Sleep(1000);
                        DropdownSelectByText(driver, _personTabIdType(driver), idType);
                    }
                    if (saveStatus.Equals("True"))
                    {
                        Click(_driver, _connectedPersonSaveBtn.ElementAt(_connectedPersonSaveBtn.Count - 1));
                        Thread.Sleep(1000);
                    }
                    if (saveStatus.Equals("False"))
                    {
                        Click(_driver, _connectedPersonCancelBtn.ElementAt(_connectedPersonSaveBtn.Count - 1));
                        Thread.Sleep(1000);
                    }
                    Thread.Sleep(5000);
                    return;
                }
            }
        }
        public void DeletePersonFromTheList(IWebDriver driver, string name)
        {
            for (int index = 0; index <= _connectedPersonNameList().Count(); index++)
            {
                if (ValidateConnectedPersonList(name))
                {
                    Click(driver, _connectedPersonListCheckBox.ElementAt(index));
                    WaitTillProcessing();
                    Click(driver, _connectedPersonDeleteBtn);
                    WaitTillProcessing();
                    Click(driver, _yesBtn);
                    WaitTillProcessing();
                    return;
                }
            }
        }
        
        public bool ValidateConnectedPersonList(string name)
        {
            var names = _connectedPersonNameList();
            foreach (IWebElement listName in names)
            {
                if (GetText(_driver, listName).Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateConnectedDocumentList(string subject)
        {
            var subjects = _connectedDocSubjectList();
            foreach (IWebElement listSubject in subjects) {
                if (GetText(_driver, listSubject).Equals(subject)) {
                             return true;
                }
            }
            return false;
        }
        
        public void clickOnConnectedDocumentList(IWebDriver driver, string subject)
        {
            for (int index = 0; index < _connectedDocSubjectList().Count(); index++)
            {
                if (GetText(driver, _connectedDocSubjectList().ElementAt(index)).Equals(subject))
                {
                    Click(driver, _connectedDocSubjectList().ElementAt(index));
                    Thread.Sleep(5000);
                    return;
                }
            }
        }

        public void connectedDocListPopupsTab(IWebDriver driver, string tabName)
        {
            IWebElement element = null;
            switch (tabName)
            {
                case "Attributes":
                    element = _connectedTabAttribute;
                    break;
                case "Document Flow":
                    element = _connectedTabDocFlow;
                    break;
                case "Actions":
                    element = _connectedTabAction;
                    break;
                case "Connected Documents":
                    element = _connectedTabConnentedDocument;
                    break;
                case "Document":
                    element = _connectedTabDoc;
                    break;
            }
            driver.SwitchTo().Frame("iDocView");
            Click(driver, element);
            driver.SwitchTo().DefaultContent();
            //IAlert alert = driver.SwitchTo().Alert();
        }

        public void connectedDocListPopupTabTo(IWebDriver driver,string toData)
        {
            driver.SwitchTo().Frame("iDocView");
            foreach (IWebElement to in _connectedTabTo){
                if (GetText(driver, to).Contains(toData))
                {
                    Click(_driver, to);
                    Thread.Sleep(3000);
                    Click(driver, _connectedTabToCloseBtn);
                }
            }
            driver.SwitchTo().DefaultContent();
        }

        public void connectedDocListPopupTabFrom(IWebDriver driver, string toData)
        {
            driver.SwitchTo().Frame("iDocView");
            if (GetText(driver, _connectedTabFrom).Contains(toData))
            {
                Click(_driver, _connectedTabFrom);
                Thread.Sleep(3000);
                ClickOkBtn();
            }
            driver.SwitchTo().DefaultContent();
        }

        public void CloseConnectedTabPopup(IWebDriver driver)
        {
            driver.SwitchTo().Frame("iDocView");
            Click(driver, _connectedTabPopupCancelBtn);
            driver.SwitchTo().DefaultContent();
        }

        public int FindError(IWebDriver driver, string errorMessage = "", string field = "")
        {
            if (errorMessage.Equals("") || field.Equals(""))
            {
                if (_errorMessage.Count > 0)
                    return 1;
                else return 0;
            }
            string id = "";

            switch (field)
            {
                case "Name":
                    id = "Name";
                    break;
                case "Email":
                    id = "Email_Persion";
                    break;
                case "Mobile":
                    id = "Mobile_Persion";
                    break;
                case "IDNumber":
                    id = "IdNumber";
                    break;
                case "ID":
                    id = "IdType";
                    break;
            }
            foreach (IWebElement i in _errorMessage)
            {

                if (GetText(driver, i).Equals(errorMessage))
                {
                    IWebElement parent = i.FindElement(By.XPath("../.."));
                    try
                    {
                        IWebElement child = parent.FindElement(By.XPath(".//*[@id='" + id + "']"));
                        Console.WriteLine("\n Error message is :" + errorMessage + " in Field :" + field + "\n\n");
                        return 1;
                    }
                    catch { }

                }
            }
            return 2;
        }

    }
}
