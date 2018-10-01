using Quartz;
using SPR.BD;
using SPR.Controller;
using SPR.Forms;
using SPR.Model;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;


namespace SPR.Jobs
{
    public class EmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            FileController.createLogFile();

            #region Test  
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(FileController.writeDataIntoALog("SERVICE HAS BEEN LAUNCHED", FileController.fileStr));
            Console.WriteLine(FileController.writeDataIntoALog("SENDING MAILS...", FileController.fileStr));
            Console.ResetColor();
            #endregion end Test   

            IList<string> addressList = FileController.ReadEmailList();

            ChartsForm c = new ChartsForm();
            c.createMockChart();  //Creates the chart, for the moment is a mock

            for (int i = 0; i < addressList.Count; i++)
            {
                Email email = new Email(addressList[i], "This is the last server usage report", "Test Mail Chart", "John", "Doe", "Chacón,", "486", "1024", "512", "89");

                if (SendEmail(email)) //Email sent correctly
                {
                    SaveDataTest(email);
                }
            }
        }

        private bool SendEmail(Email d)
        {
            bool resul = false;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(d.EmailAddress);
                mail.To.Add(d.EmailAddress);
                mail.Subject = d.Subject;
                LinkedResource linkedImg = new LinkedResource(@"charts\\mockChart.jpg");
                linkedImg.ContentId = "mockChart";
                linkedImg.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    "Dear Mr/Ms " + d.Name + " " + d.surname1 +
                    "</br></br>" + d.Body + "\n <img src=charts\\mockChart.jpg>",
                    null, "text/html");

                htmlView.LinkedResources.Add(linkedImg);
                mail.AlternateViews.Add(htmlView);

                mail.Attachments.Add(new Attachment("charts\\mockChart.jpg"));

                SmtpClient.Port = 587;
                SmtpClient.Credentials = new System.Net.NetworkCredential("xamorach@gmail.com", "Mesopotamia82!");
                SmtpClient.EnableSsl = true;

                SmtpClient.Send(mail);
                resul = true;
                Console.WriteLine(FileController.writeDataIntoALog("MAIL SENT TO " + d.EmailAddress, FileController.fileStr));
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(e.Message);
                sb.Append(e.StackTrace);
                FileController.writeDataIntoALog(sb.ToString(), FileController.fileStr);
                Console.WriteLine(e.Message);
                resul = false;
            }

            return resul;
        }

        private List<Object> GetServerPerformance()
        {
            //TODO: Get server performance values

            return null;
        }

        //Test method
        private void SaveDataTest(Email e)
        {
            using (var ctxt = new BS_SPR_DB_Entities())
            {
                ctxt.insertEmail(e.surname1, e.Name, e.EmailAddress, e.Subject, e.Body, e.CPU, e.RAM, e.IO_Disk, e.IIS_Sessions);
            }

        }
    }
}
