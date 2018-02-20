using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace T2automation.Util
{
    class ExcelDataManager
    {
        private static string path = @"D:\T2automation-Arslan\ExcelSheetForRefNo\TestData.xls";
        private string halfpath = @"D:\T2automation-Arslan\ExcelSheetForRefNo";
        private Excel.Application xlApp = new Application();
        private Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;
        private Excel.Range xlRange;
        private object misValue = System.Reflection.Missing.Value;
        //del the following soon
        static System.Globalization.CultureInfo oldCI;

        //connection for Excel
        static OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + path + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;ReadOnly=false';");
        OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [sheet1$]", selectConnection: conn);
        


        public bool checkXlIsOnPC()
        {
            if (xlApp == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return false;
            }
            return true;
        }

        public void CreateNewXlFile()
        {
            if (checkXlIsOnPC())
            {
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Subjects";
                xlWorkSheet.Cells[1, 2] = "Reference Number";
                xlSaveAs(path);
            }
        }

        public void CloseXlApp()
        {
            xlWorkBook.Close(true, halfpath, null);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            GC.Collect();
        }

        public bool xlSaveAs(string _path)
        {
            try
            {
                //xlWorkBook.SaveAs(Filename, FileFormat, Password, WriteResPassword, ReadOnlyRecommended, CreateBackup, AccessMode, ConflictResolution, AddToMru, TextCodepage, TextVisualLayout,Local);
                xlWorkBook.SaveAs(_path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, false, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                //xlWorkBook.Save();
                return true;
            }
            catch
            {
                Console.WriteLine("Error in saving file!!");
                return false;
            }
        }
        
        private bool ifFileExist()
        {
            string[] filePaths = Directory.GetFiles(@"D:\T2automation-Arslan\ExcelSheetForRefNo");
            if (filePaths.Count() >= 1)
            {
                return true;
            }
            return false;
        }
        
        public string readDataFromExcel(string subject)
        {
            
            if(!ifFileExist())
            {
                CreateNewXlFile();
                Console.WriteLine("File Just created! No such data found!");
                return "What are you looking for?? huh!";
            }

            if (ifFileExist())
            {
                string str;
                string chkString;
                int rCnt;
                int cCnt;
                int rw = 0;
                int cl = 0;

                oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                xlWorkBook = xlApp.Workbooks.Open(path, 0, false, 1, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, Microsoft.Office.Interop.Excel.XlCorruptLoad.xlExtractData);

                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

                xlApp = new Excel.Application();
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlRange = xlWorkSheet.UsedRange;
                rw = xlRange.Rows.Count;
                cl = xlRange.Columns.Count;

                for (rCnt = 1; rCnt <= rw; rCnt++)
                {
                    for (cCnt = 1; cCnt <= cl; cCnt++)
                    {
                        chkString = (string)(xlRange.Cells[rCnt, 1] as Excel.Range).Value2;
                        if (chkString.Equals(subject))
                        {
                            str = (string)(xlRange.Cells[rCnt, 2] as Excel.Range).Value2;
                            Console.WriteLine(str);
                            CloseXlApp();
                            return str;
                        }
                    }
                }
                CloseXlApp();
                Console.WriteLine("No data found with subject: '" + subject + "' ");
                return "No data found!!";
            }

            return null;
        }

        public bool writeDataToExcel(string subject, string refno)
        {
            
            if (!ifFileExist())
            {
                CreateNewXlFile();
            }

            if (ifFileExist())
            {
                string chkString;
                int rCnt;
                int cCnt;
                int rw = 0;
                int cl = 0;

                xlApp = new Excel.Application();

                oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                xlWorkBook = xlApp.Workbooks.Open(path, 0, false, 1, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, Microsoft.Office.Interop.Excel.XlCorruptLoad.xlExtractData);

                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlRange = xlWorkSheet.UsedRange;
                rw = xlRange.Rows.Count;
                cl = xlRange.Columns.Count;

                for (rCnt = 1; rCnt <= rw; rCnt++)
                {
                    for (cCnt = 1; cCnt < cl; cCnt++)
                    {
                        chkString = (string)(xlRange.Cells[rCnt, 1] as Excel.Range).Value2;
                        if (chkString.Equals(subject))
                        {
                            xlWorkSheet.Cells[rCnt, 2] = string.Empty;
                            xlWorkSheet.Cells[rCnt, 2] = refno;
                            Console.WriteLine("Reference number of subject: '" + subject + "' updated to : "+refno);
                            CloseXlApp();
                            return true;
                        }
                    }
                }
                Console.WriteLine("No data found with subject: '" + subject + "' ");
                Console.WriteLine("Adding new subject: '" + subject + "' in excel with reference number: '" + refno + "' ");

                rw++;

                xlWorkSheet.Cells[rw, 1] = subject;
                xlWorkSheet.Cells[rw, 2] = refno;
                CloseXlApp();
                return true;
            }

            return false;
        }

        ///End
    }

}

