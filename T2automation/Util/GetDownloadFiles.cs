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

        private TextFileManager fileManager;
        private static ReadFromConfig readFromConfig;
        

        public bool ValidateFilesNos(int fileNos)
        {
            readFromConfig = new ReadFromConfig();
            string[] filePaths = Directory.GetFiles(readFromConfig.GetValue("DefaultDownload"));
            return filePaths.Count() == fileNos;
        }

        public bool ValidateFiles(string name)
        {
            readFromConfig = new ReadFromConfig();
            string[] filePaths = Directory.GetFiles(readFromConfig.GetValue("DefaultDownload"));
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

            readFromConfig = new ReadFromConfig();
            bool exist = false;
            string[] filePaths = Directory.GetFiles(readFromConfig.GetValue("DefaultDownload"));
            
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
