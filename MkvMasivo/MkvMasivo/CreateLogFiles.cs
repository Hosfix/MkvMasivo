using System;
using System.IO;

namespace MkvMasivo
{
    class CreateLogFiles
    {
        private string LogFormat { get; set; }
        private string ErrorTime { get; set; }

        public CreateLogFiles()
        {
            LogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            ErrorTime = sYear + sMonth + sDay;
        }

        public void ErrorLog(string sPathName, string sErrMsg)
        {
            var logFile = sPathName + ErrorTime;

            Directory.CreateDirectory(sPathName);

            if (!File.Exists(logFile))
            {
                FileStream f = File.Create(logFile);
                f.Close();
            }

            StreamWriter sw = new StreamWriter(logFile, true);
            sw.WriteLine(LogFormat + sErrMsg);
            sw.Flush();
            sw.Close();
        }
    }
}
