using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2automation.Util;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using System.IO;

namespace T2automation.Init
{
    class DriverFactory
    {
        protected static IWebDriver driver;
        ReadFromConfig readFromConfig = new ReadFromConfig();

        public DriverFactory(String url)
        {
            IntializeDriver(url);
        }

        public void IntializeDriver(String url)
        {
            if (driver == null)
            {
                SetupWebdriver(url);
            }
        }

        private void SetupWebdriver(String url)
        {
            String browserType = readFromConfig.GetBrowserType();
            String _url = readFromConfig.GetBaseUrl(url);

            if (browserType.Equals("firefox") || browserType.Equals("ff"))
            {
                driver = new FirefoxDriver();
            }

            else if (browserType.Equals("chrome") || browserType.Equals("ch"))
            {
                Directory.SetCurrentDirectory(@"E:\T2automation-Arslan");
                string path = Directory.GetCurrentDirectory();
                Array.ForEach(Directory.GetFiles(path+"\\T2automation\\Downloads"), File.Delete);
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", path+"\\T2automation\\Downloads");
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                driver = new ChromeDriver(chromeOptions);
            }

            else if (browserType.Equals("Internet Explorer") || browserType.Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }

            else if (browserType.Equals("Edge") || browserType.Equals("ed"))
            {
                driver = new EdgeDriver();
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_url);
        }

        public IWebDriver GetDriver() {
            return driver;
        }

        public void DisposeDriver() {
            driver.Dispose();
            driver = null;
        }
    }
}
