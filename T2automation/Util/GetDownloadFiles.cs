using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2automation.Util
{
    class GetDownloadFiles
    {

        TextFileManager fileManager;
        ReadFromConfig readFromConfig;
        string Path = @"E:\T2automation-Arslan\T2automation\Downloads";


        public bool ValidateFilesNos(int fileNos) {
            string[] filePaths = Directory.GetFiles(@"E:\T2automation-Arslan\T2automation\Downloads");
            return filePaths.Count() == fileNos;
        }

        public bool ValidateFiles(string name)
        {
            string[] filePaths = Directory.GetFiles(@"E:\T2automation-Arslan\T2automation\Downloads");
            if (filePaths.Count() >= 1)
            {
                string nameNew = "";
                string[] nameOfFile = name.Split(',');
                Console.WriteLine("Type: " + nameOfFile[0]);
                Console.WriteLine("Subject: " + nameOfFile[1]);
                Console.WriteLine("File name: " + nameOfFile[2]);

                fileManager = new TextFileManager();

                string refno = fileManager.readFromFileForCD(nameOfFile[1], nameOfFile[0]);
                refno = fileManager.refnoPure(refno);
                //full name of file
                nameNew = nameOfFile[2] + refno + ".pdf";
                //just extension!!!
                //nameNew = ".pdf";
                return CheckFileDownloaded(nameNew);
            }
            return false;
        }
        private static bool CheckFileDownloaded(string filename)
        {
            bool exist = false;
            //string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(@"E:\T2automation-Arslan\T2automation\Downloads");
            
            for(int i= 0; i< filePaths.Count();i++)
            {
                Console.WriteLine(filePaths[i]);
            }
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    //FileInfo thisFile = new FileInfo(p);
                    ////Check the file that are downloaded in the last 3 minutes
                    //if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    //thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    //thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    //thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    //    exist = true;
                    //File.Delete(p);
                    exist = true;
                    break;
                }
            }
            return exist;
        }

    }
}
