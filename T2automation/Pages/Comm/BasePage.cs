using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace T2automation.Pages.Comm
{
    class BasePage
    {
        public static TimeSpan WAIT_FOR_SECONDS = TimeSpan.FromSeconds(45);

        public static bool ElementIsDisplayed(IWebDriver driver, IWebElement element) {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_FOR_SECONDS);
            try
            {
                return element.Displayed;
            }
            catch (Exception) {
                return false;
            }
        }

        public void WaitForElement(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_FOR_SECONDS);
            wait.Until(drv => ElementIsDisplayed(driver, element));
        }

        public bool Click(IWebDriver driver, IWebElement element) {
            try
            {
                WaitForElement(driver, element);
                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                element.Click();
                return true;
            }
            catch (Exception) {
                try
                {
                    Thread.Sleep(3000);
                    element.Click();
                    return true;
                }
                catch (Exception) {
                    try
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", element);
                        element.Click();
                        return true;
                    }
                    catch (Exception)
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                        return false;
                    }
                }
            }
        }

        public void Submit(IWebDriver driver, IWebElement element)
        {
            WaitForElement(driver, element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Submit();
        }

        public void SendKeys(IWebDriver driver, IWebElement element, string value)
        {
            WaitForElement(driver, element);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Clear();
            element.SendKeys(value);
            //element.SendKeys(Keys.Tab);
        }

        public string GetText(IWebDriver driver, IWebElement element) {
            WaitForElement(driver, element);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element.Text;

        }

        public bool IsSelected(IWebDriver driver, IWebElement element)
        {
            WaitForElement(driver, element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            var results = ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked;", element);
            return element.Selected;
        }

        public string GetAttribute(IWebDriver driver, IWebElement element, string attribute)
        {
            WaitForElement(driver, element);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element.GetAttribute(attribute);
        }

        public bool IsAt(IWebDriver driver, string title)
        {
            return driver.Title.Equals(title);
        }

        public void CheckLogin(IWebDriver driver) {
            if (!(IsAt(driver, "Login") || IsAt(driver, "تسجيل الدخول")))
            {
                new Header(driver).Signout(driver);
                Thread.Sleep(2000);
            }
        }

        public void DropdownSelectByText(IWebDriver driver, SelectElement select, String text)
        {
            try
            {
                select.SelectByText(text);
            }
            catch (Exception) {
                Console.WriteLine("Unexpected issue in dropdown select");
            }
        }

        public Dictionary<string, string> testingDic;
    }
}
