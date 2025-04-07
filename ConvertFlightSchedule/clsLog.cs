using System;
using System.IO;
namespace ConvertFlightSchedule
{
    public class clsLog
    {
        public clsLog(string logMessage)
        {
            LogWrite(logMessage);
        }
        public void LogWrite(string logMessage)
        {

            //string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments); //System.IO.Directory.GetCurrentDirectory();
            string currentPath = System.IO.Directory.GetCurrentDirectory();
            if (!Directory.Exists(currentPath + @"\Log"))
            {
                Directory.CreateDirectory(currentPath + @"\Log");
            }
            try
            {
                using (StreamWriter w = File.AppendText(currentPath + @"\Log\" + DateTime.Now.ToString("yyyy-MM-dd") + "-log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\n-Log Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
