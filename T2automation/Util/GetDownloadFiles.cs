﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2automation.Util
{
    class GetDownloadFiles
    {
        public bool ValidateFilesNos(int fileNos) {
            string[] filePaths = Directory.GetFiles(@"E:\T2automation-Arslan\T2automation\Downloads");
            return filePaths.Count() == fileNos;
        }

    }
}
