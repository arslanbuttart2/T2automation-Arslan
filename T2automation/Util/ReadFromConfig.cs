using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace T2automation.Util
{
    class ReadFromConfig
    {

        public ReadFromConfig() {

        }

        public string GetBaseUrl(string url) {
            return ConfigurationSettings.AppSettings[url].ToString();
        }

        public string GetBrowserType()
        {
            return ConfigurationSettings.AppSettings["BrowserType"].ToString();
        }

        public string GetUserName(string username) {
            return ConfigurationSettings.AppSettings[username].ToString();
        }

        public string GetPassword(string password)
        {
            return ConfigurationSettings.AppSettings[password].ToString();
        }

        public string GetDeptName(string dept) {
            return ConfigurationSettings.AppSettings[dept].ToString();
        }

        public string GetValue(string key) {
            return ConfigurationSettings.AppSettings[key].ToString();
        }
    }
}
