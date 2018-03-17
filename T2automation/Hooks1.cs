using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using T2automation.Init;
using T2automation.Pages.Comm;
using T2automation.Util;
using TechTalk.SpecFlow;

namespace T2automation
{
    [Binding]
    public sealed class Hooks1
    {
        [BeforeScenario]
        public static void SignOut()
        {
            ReadFromConfig readFromConfig = new ReadFromConfig();
            Directory.SetCurrentDirectory(readFromConfig.GetValue("DefaultDir"));
            string path = Directory.GetCurrentDirectory();
            DriverFactory driverFactory = new DriverFactory("BaseUrl");
            IWebDriver driver = driverFactory.GetDriver();
            //driver.Navigate().GoToUrl("http://qa.ole5.sa");
            driver.Navigate().GoToUrl("http://qa-stg.ole5.sa");
            Array.ForEach(Directory.GetFiles(path+"\\T2automation\\Downloads"), File.Delete);
            //string path1 = @"";
            //File.Delete(path1);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            DriverFactory driverFactory = new DriverFactory("BaseUrl");
            driverFactory.DisposeDriver();
        }
    }
}
