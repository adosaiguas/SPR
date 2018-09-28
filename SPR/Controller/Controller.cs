using System;
using System.IO;
using System.Text;

namespace SPR.Controller
{
    class FileController
    {
        public static string fileStr = $"log\\log { DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") }.txt";

        /// <summary>
        ///  Creates a log file to record the user actions and events
        /// </summary>
        /// <returns>fileStr</returns>
        public static void createLogFile()
        {
            Directory.CreateDirectory("log");
            File.Create(fileStr).Close();
        }

        public static string writeDataIntoALog(string str, string fileStr)
        {
            FileStream fos = null;
            StreamWriter writer = null;

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"[{DateTime.Now.ToLongTimeString()}] --> ");
                sb.Append(str);

                using (fos = new FileStream(fileStr, FileMode.Append, FileAccess.Write))
                {
                    writer = new StreamWriter(fos);
                    writer.WriteLine(sb.ToString());
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot open or create the log file.");
                Console.WriteLine(ex.Message);
                return ex.Message;

            }
            finally
            {
                fos.Dispose();
            }
            return str;
        }

    }
}
