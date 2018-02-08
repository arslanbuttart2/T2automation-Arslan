using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace T2automation.Util
{
    class ExcelDataManager
    {
        string path = @"E:\T2automation-Arslan\TestCaseResults";
        Excel.Application xlApp = new  Microsoft.Office.Interop.Excel.Application();
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        public bool checkExcelIsOnPC()
        {
            if(xlApp == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return false;
            }
            return true;
        }

        public void createNewFile()
        {
            if (checkExcelIsOnPC())
            {
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1,1] = "Subjects";
                xlWorkSheet.Cells[1, 2] = "Refrence Num";
            }
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
