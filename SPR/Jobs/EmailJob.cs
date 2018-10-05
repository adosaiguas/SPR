using Microsoft.Exchange.WebServices.Data;
using Quartz;
using SPR.BD;
using SPR.Controller;
using SPR.Forms;
using SPR.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;


namespace SPR.Jobs
{
    public class EmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {

            #region Console initial message 
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(FileController.writeDataIntoALog("SENDING MAILS...", FileController.fileStr));
            Console.ResetColor();
            #endregion 

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

        #region Send emails using the Outlook client.
        //private bool SendEmailUsingOutlook(Email email)
        //{
        //    try
        //    {
        //        Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
        //        Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
        //        mailItem.Subject = "This is the subject II";
        //        mailItem.To = "javier.mora@dxcfds.com";
        //        mailItem.Body = "This is the message. II";
        //        string sDisplayName = "MyAttachment";
        //        int iPosition = (int)mailItem.Body.Length + 1;
        //        int iAttachType = (int)Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue;
        //        mailItem.Attachments.Add($"C:\\Users\\Javi\\source\\repos\\SPR\\SPR\\bin\\Debug\\charts\\mockChart.jpg", iAttachType, iPosition, sDisplayName);
        //        mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
        //        mailItem.Display(false);
        //        mailItem.Send();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(ex.Message);
        //        sb.Append(ex.StackTrace);
        //        FileController.writeDataIntoALog(sb.ToString(), FileController.fileStr);
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }

        //}
        #endregion

        #region Send email using an Exchange server
        //private bool sendemailExchange(Email e)
        //{
        //    try
        //    {
        //        var ev = ExchangeVersion.Exchange2007_SP1;
        //        var es = new ExchangeService(ev);
        //        es.Credentials = new NetworkCredential("esfds\\59001624", "excelsior82!");
        //        es.Url = new Uri($"https://itrmt-pexc01.esfds.net:444/ews/services.wsdl");

        //        EmailMessage message = new EmailMessage(es);
        //        message.Subject = "test subject using Exchange";
        //        message.Body = "test body using Exchange";
        //        message.ToRecipients.Add(e.EmailAddress.Trim());
        //        message.Send();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(ex.Message);
        //        sb.Append(ex.StackTrace);
        //        FileController.writeDataIntoALog(sb.ToString(), FileController.fileStr);
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //}
        #endregion

        #region Send email using a simple SMPT .net client
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

                mail.Attachments.Add(new System.Net.Mail.Attachment("charts\\mockChart.jpg"));

                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Port = 587;

               //SmtpClient.Credentials = new NetworkCredential("anEmail@fake.es", "aFakePassword");
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
        #endregion


        //TODO: Set into another job
        private List<Object> GetServerPerformance()
        {
            //TODO: Get server performance values

            return null;
        }


        private void SaveDataTest(Email e)
        {
            using (var ctxt = new BD_SPR_BSEntities())
            {
                ctxt.insertEmail(e.surname1, e.Name, e.EmailAddress, e.Subject, e.Body, e.CPU, e.RAM, e.IO_Disk, e.IIS_Sessions);
            }

        }
    }
}
