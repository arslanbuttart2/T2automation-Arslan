using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Pages.Comm;

namespace T2automation.Pages.MyMessages
{
    class OutboxPage : LeftMenu
    {
        private readonly IWebDriver _driver;

        private IWebElement _mailLoading(IWebDriver driver)
        {
            return driver.FindElement(By.Id("container_processing"));
        }

        private IWebElement _processing(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("dataTables_processing"));
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']//a/i[@class='fa fa-search']")]
        private IWebElement _outboxSearchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtSubject']")]
        private IWebElement _outboxSearchField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/*//a/i[@class='fa fa-eraser']")]
        private IWebElement _outboxPageEraseButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-parent']/*//a/label/i[@class='fa fa-undo']")]
        private IWebElement _btnRollback;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtRefernceNumber']")]
        private IWebElement _outboxRefNoSearchField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td/label")]
        private IList<IWebElement> _checkboxList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[3]")]
        private IList<IWebElement> _subjectList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[4]")]
        private IList<IWebElement> _referenceNoList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[5]")]
        private IList<IWebElement> _sendDateList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/div[1]/div[2]/ul")]
        private IWebElement _mailTo;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/*//div[2]/ul/li[@class='normal-text']")]
        private IWebElement _subject;
        //*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[2]/div[2]/label
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[14]/div[2]/div[2]/label")]
        private IWebElement _referenceNo;

        [FindsBy(How = How.XPath, Using = ".//*[@id='contentBody']/div/div[@class = 'contentBodyHtml']")]
        private IWebElement _contentBody;

        [FindsBy(How = How.Id, Using = "txtPass")]
        private IWebElement _encryptedPassword;

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        private IWebElement _encryptedPasswordOkBtn;

        [FindsBy(How = How.Id, Using = "tabAttache")]
        private IWebElement _attachmentTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='files-parent']/div/div[2]")]
        private IList<IWebElement> _attachments;

        public string EncryptedPassword
        {
            set
            {
                SendKeys(_driver, _encryptedPassword, value);
            }
        }

        private IWebElement _UpperHeadMenuTabBtns(IWebDriver driver, string btnTxt)
        {
            return driver.FindElement(By.XPath(".//*[@id='head-menu']/*/a/label[text()='" + btnTxt + "']"));
        }

        public string title = "Outbox - Ole5.1";

        public OutboxPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        
        public void firstSearchFolderWithRefNo(string refno)
        {
            Click(_driver, _outboxPageEraseButton);
            WaitTillProcessing();
            SendKeys(_driver, _outboxRefNoSearchField, refno);
            Click(_driver, _outboxSearchButton);
            WaitTillProcessing();
        }

        public void firstSearchOutbox(string subject)
        {
            Click(_driver, _outboxPageEraseButton);
            WaitTillProcessing();
            SendKeys(_driver, _outboxSearchField, subject);
            Click(_driver, _outboxSearchButton);
            WaitTillProcessing();
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
            catch (Exception)
            {
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
        
        public bool OpenMailSpecialForTxtFile(IWebDriver driver, string strData, string encryptPass = "", bool withSubject = true)
        {
            Thread.Sleep(2000);
            //firstSearchOutbox(strData);

            Click(_driver, _outboxPageEraseButton);
            WaitTillMailsGetLoad();
           
            int searchResult = _subjectList.Count();

            if (searchResult >= 1 && withSubject == true)
            {
                Thread.Sleep(2000);
                Click(driver, _subjectList.ElementAt(0));
                return true;
            }
            else if (searchResult >= 1 && withSubject == false)
            {
                Thread.Sleep(2000);
                Click(driver, _referenceNoList.ElementAt(0));
                return true;
            }
            Console.WriteLine("No such mail found!!!");
            return false;
        }

        public bool OpenMailSpecial(IWebDriver driver, string strData, string encryptPass = "", bool withSubject = true)
        {
            if (withSubject == false)
            {
                firstSearchFolderWithRefNo(strData);
                WaitTillMailsGetLoad();
            }
            else if (withSubject == true)
            {
                firstSearchOutbox(strData);
                WaitTillMailsGetLoad();
            }

            int searchResult = _subjectList.Count();

            if (searchResult >= 1 && withSubject == true)
            {
                Thread.Sleep(2000);
                Click(driver, _subjectList.ElementAt(0));
                return true;
            }
            else if (searchResult >= 1 && withSubject == false)
            {
                Thread.Sleep(2000);
                Click(driver, _referenceNoList.ElementAt(0));
                return true;
            }
            Console.WriteLine("No such mail found!!!");
            return false;
        }

        public bool userClickRollbackBtn(IWebDriver driver)
        {
            try
            {
                Click(driver, _btnRollback);
                Console.WriteLine("Rollback is Clicked!!!");
                return true;
            }
            catch
            {
                Console.WriteLine("Unable to Click!!!");
                return false;
            }
        }

        public bool userClickUpperTabBtn(IWebDriver driver,string btnName)
        {
            try
            {
                Click(driver, _UpperHeadMenuTabBtns(driver, btnName));
                Console.WriteLine("Upper Button tab Clicked!!!");
                return true;
            }
            catch
            {
                Console.WriteLine("Upper Button tab is not Clicked!!!");
                return false;
            }
        }

        public bool OpenMail(IWebDriver driver, string subject, string encryptPass = "")
        {
            Thread.Sleep(3000);
            foreach (IWebElement elem in _subjectList)
            {
                if (GetText(driver, elem).Equals(subject))
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
            return false;
        }
        
        public string readRefNoFromMail(IWebDriver driver,string subject)
        {
            WaitForElement(driver, _referenceNo);
            if(GetText(driver, _subject).Equals(subject))
            {
                return GetText(driver, _referenceNo);
            }
            else
            {
                return "Subjects not matched in mail!!!";
            }
        }

        public bool ValidateTo(IWebDriver driver, string to)
        {
            return GetText(driver, _mailTo).Contains(to);
        }

        public bool ValidateSubject(IWebDriver driver, string subject)
        {
            return GetText(driver, _subject).Equals(subject);
        }
        
        public bool ValidateContentBody(IWebDriver driver, string contentBody)
        {
            return GetText(driver, _contentBody).Equals(contentBody);
        }

        public bool ValidateAttachments(IWebDriver driver, int attachmentNo, string attachment)
        {
            Click(driver, _attachmentTab);
            if (_attachments.Count == attachmentNo)
            {
                for (int index = 0; index < attachmentNo; index++)
                {
                   if (!attachment.Contains(GetAttribute(driver, _attachments.ElementAt(index), "title")))
                   {
                        return false;
                   }
                }
                return true;
            }
            return false;
        }

        public bool ValidateMail(IWebDriver driver, string to, string subject, string body, int attachmentNo = 1, string attachment = null)
        {
            if (OpenMailSpecial(driver, subject))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject) && ValidateContentBody(driver, body) && ValidateAttachments(driver, attachmentNo, attachment));
            }
            return false;
        }

        public bool ValidateMail(IWebDriver driver, string to, string subject, string body, string listSubject, string encryptPass)
        {
            if (OpenMailSpecial(driver, listSubject, encryptPass))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject) && ValidateContentBody(driver, body));
            }
            return false;
        }

    }
}

