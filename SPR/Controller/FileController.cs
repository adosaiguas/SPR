using SPR.Model;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Reads the list of emails from the emailsFile
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadEmailList()
        {
           List<string> emailList = new List<string>();
           string[] textLines = File.ReadAllLines(@"c:\\testEmailsFile.csv");  //TODO: Change for real file with real emails

           foreach (var item in textLines)
           {
               if (IsValidEmail(item))
               {
                   emailList.Add(item);
               }
               else 
               {
                    Console.WriteLine(writeDataIntoALog("The email " + item.ToString() + " is no  a valid email." +
                        "Please check the email located in the emails file", fileStr));
               }
           }
           return emailList;
        }


        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
