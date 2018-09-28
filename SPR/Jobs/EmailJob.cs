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

            List<Email> EmailsList = new List<Email>();

            Email a1 = new Email("xamorach@gmail.com", "This is the last server usage report", "Test Mail Chart", "Javier", "Mora", "Chacón,", "486", "1024", "512", "89");
            Email a2 = new Email("javier.mora@dxcfds.com", "This is the last server usage report", "Test Mail Chart", "Jhon", "Doe", "Wayne", "486", "1024", "512", "89");
            Email a3 = new Email("azumimi@gmail.com", "Miriam", "This is the last server usage report", "Test Mail Chart", "Constanti", "Labella", "486", "1024", "512", "89");
            Email a4 = new Email("cchaconcubero@gmail.com", "This is the last server usage report", "Test Mail Chart", "Carmen", "Chacón", "Cubero", "486", "1024", "512", "89");
            Email a5 = new Email("purificacionchacon47@gmail.com", "This is the last server usage report", "Test Mail Chart", "Purificación", "Chacón", "Cubero", "486", "1024", "512", "89");

            EmailsList.Add(a1);
            EmailsList.Add(a2);
            //EmailsList.Add(a3);
            //EmailsList.Add(a4);
            //EmailsList.Add(a5);

            ChartsForm c = new ChartsForm();
            c.createMockChart();  //Creates the chart, for the moment is a mock

            EmailsList.ForEach(d =>
            {
                SendEmail(d);
                SaveDataTest(d);
            });
        }

        private void SendEmail(Email d)
        {
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
                SmtpClient.Credentials = new System.Net.NetworkCredential("xamorach@gmail.com", "changeForRealPass");
                SmtpClient.EnableSsl = true;

                SmtpClient.Send(mail);
                Console.WriteLine(FileController.writeDataIntoALog("MAIL SENT TO " + d.EmailAddress, FileController.fileStr));
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(e.Message);
                sb.Append(e.StackTrace);
                FileController.writeDataIntoALog(sb.ToString(), FileController.fileStr);
                Console.WriteLine(e.Message);
            }
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

                //entity.Emails.Add(e);
                //foreach (var item in entity.GetValidationErrors())
                //{
                //    Console.WriteLine(FileController.writeDataIntoALog(item.ValidationErrors.ToString(), FileController.fileStr));
                //    Console.WriteLine(FileController.writeDataIntoALog(item.ValidationErrors., FileController.fileStr));
                //    Console.WriteLine(FileController.writeDataIntoALog(item.ValidationErrors.ToString(), FileController.fileStr));
                //}
                //entity.SaveChanges();

                //Inner Exception 1:
                //UpdateException: Se produjo un error mientras se actualizaban las entradas.
                //Vea la excepción interna para obtener detalles.

                //Inner Exception 2:
                //SqlException: The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Emails_Receivers".
                //The conflict occurred in database "BS_SRVReportings_DB", table "dbo.Receivers", column 'Receiver_ID'.
                //The statement has been terminated.

            }

        }
    }
}
