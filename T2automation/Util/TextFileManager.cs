using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2automation.Util
{
    class TextFileManager
    {
        string path = getDirectory()+"/"+"data.txt";

        public static string getDirectory()
        {
            Directory.SetCurrentDirectory(@"E:\T2automation-Arslan");
            return Directory.GetCurrentDirectory();
        }

        public void creatTxtFile(bool flag = true)
        {
            var obj = File.CreateText(path);
            obj.Close();
            if (flag)
            {
                //First add headers
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine("TYPE" + "," + "SUBJECT" + "," + "REFERENCE NUMBER");
                writer.Close();
            }
            Console.WriteLine("File Created!!!");
        }

       public string readFromFile(string subject)
        {
            if (!File.Exists(path))
            {
                creatTxtFile();
            }

            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string data = reader.ReadToEnd();
                string[] lines = data.Split('\n');
                string[] strArray;
                for (int i = 0; i < lines.Count(); i++)
                {
                    strArray = lines[i].Split(',');
                    if (subject.Equals(strArray[1]))
                    {
                        reader.Close();
                        return strArray[2];
                    }
                }
                reader.Close();
                return "No Data Found!!!";
            }
            return null;
        }

        public bool writeToFile(string type, string subject, string refno)
        {
            string dataOfFile;
            bool flag = true;
            if (!File.Exists(path))
            {
                creatTxtFile();
            }
            if(File.Exists(path))
            {
                StreamReader reader = new StreamReader(path,true);
                dataOfFile = reader.ReadToEnd();
                string[] lines = dataOfFile.Split('\n');
                string[] strArray;
                for (int i = 0; i < lines.Count(); i++)
                {
                    strArray = lines[i].Split(',');
                    if (type.Equals(strArray[0]) && subject.Equals(strArray[1]))
                    {
                        reader.Close();
                        strArray[2] = refno;
                        string temp = strArray[0] +","+ strArray[1] +","+ strArray[2];
                        lines[i] = temp;
                        updateData(lines);
                        flag = false;
                        break;
                    }
                }
                reader.Close();
                if (flag)
                {
                    StreamWriter writer = new StreamWriter(path, true);
                    writer.WriteLine(type + "," + subject + "," + refno);
                    writer.Close();
                    return true;
                }
                return true;
            }
            return false;
        }

        public void updateData(string[] updatedLines)
        {
            File.Delete(path);
            creatTxtFile(false);
            StreamWriter writer = new StreamWriter(path, true);
            for (int i= 0; i< updatedLines.Count(); i++)
            {
                string s = updatedLines[i];
                if (!(updatedLines[i].Equals("\r") || updatedLines[i].Equals("\n") || updatedLines[i].Equals("")))
                {
                    writer.WriteLine(updatedLines[i]);
                }
            }
            writer.WriteLine();
            writer.Close();

        }





    }
}
