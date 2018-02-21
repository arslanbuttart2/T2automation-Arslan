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
using System.Data;

namespace T2automation.Util
{
    class ExcelDataManager
    {
        
        private static string path = @"E:\T2automation-Arslan\ExcelSheetForRefNo\TestData.xlsx";
        private Excel.Application xlApp = new Application();
        private Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;
        private Excel.Range xlRange;
        private object misValue = System.Reflection.Missing.Value;
        //del the following soon
        static System.Globalization.CultureInfo oldCI;

        //connection for Excel
        static OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + path + "; Extended Properties = 'Excel 12.0;ReadOnly=false';");
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter("select * from [sheet1$]", selectConnection: con);
        
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
            xlWorkBook.Close(true, path, null);
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
            string[] filePaths = Directory.GetFiles(@"E:\T2automation-Arslan\ExcelSheetForRefNo");
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
                return "";
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

        private string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = path;

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        public bool writeToExcel(string subject, string refno)
        {

            DataSet ds = new DataSet();

            string connectionString = GetConnectionString();

            using (OleDbConnection conn1 = new OleDbConnection(connectionString))
            {
                conn1.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn1;

                // Get all Sheets in Excel File
                System.Data.DataTable dtSheet = conn1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                // Loop through all Sheets to get data
                foreach (DataRow dr in dtSheet.Rows)
                {
                    string sheetName = dr["sheet1"].ToString();

                    if (!sheetName.EndsWith("$"))
                        continue;

                    // Get all rows from the Sheet
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.TableName = sheetName;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    ds.Tables.Add(dt);
                }

                cmd = null;
                conn1.Close();
            }
            
            return true;





            /*
             * new
            conn.Open();
            //OleDbDataAdapter da = new OleDbDataAdapter("select subject from [sheet1$] where subject = "+subject+"", selectConnection: conn);
            OleDbCommand comd = new OleDbCommand();
            comd.Connection = conn;
            comd.CommandText = "select * from [sheet1$]";
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.TableName = "sheet1";
            OleDbDataAdapter da = new OleDbDataAdapter(comd);
            da.Fill(dt);


            */

            /*
             da.Fill(data);
             string subfromfile = data.ToString();
             if (subfromfile.Equals(subject))
             {
                 //da;
             }
            using (OleDbCommand comm = new OleDbCommand())
            {
                comm.CommandText = "select subject from[sheet1$] where subject = "+subject;
                comm.Connection = conn;
               
                    da.SelectCommand = comm;
                 
            }*/

            return false;
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

