using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2automation.Pages.Comm;

namespace T2automation.Pages.Comm
{
    class HomePage : LeftMenu
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver): base(driver) {
            _driver = driver;
        }
    }
}
