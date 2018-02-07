using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace T2automation.Util
{
    class ExcelDataManager
    {
        string path = @"E:\T2automation-Arslan\TestCaseResults";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public void createNewFile()
        {
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[1];
        }

        public string readDataFromExcel(string subject)
        {
            if (excel.FindFile())
            {

            }
            else
            {
                createNewFile();
                return "New file generated!";
            }

            return null;
        }
    }
}
