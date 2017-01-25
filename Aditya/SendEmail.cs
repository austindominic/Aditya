using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Aditya
{
    public class SendEmail
    {
        public static bool sendMailInd(string fromName, MailDetail mailDetails, bool isHtml)
        {
            try
            {
                const string fromEmailID = "holyalexander1008@gmail.com";
                MailMessage myMessage = new MailMessage();
                myMessage.IsBodyHtml = isHtml;
                myMessage.Subject = mailDetails.Subject;
                myMessage.Body = mailDetails.Body;
                myMessage.From = new MailAddress(fromEmailID, fromName);

                SmtpClient mySmtpClient = new SmtpClient()
                {
                    Host = ConfigurationManager.AppSettings["smtpServer"],
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]),
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"])
                };

                if (mailDetails.To.MailID != null) { myMessage.To.Add(new MailAddress(mailDetails.To.MailID, mailDetails.To.Name)); }
                if (mailDetails.Cc.MailID != null) { myMessage.CC.Add(new MailAddress(mailDetails.Cc.MailID, mailDetails.Cc.Name)); }
                if (mailDetails.Bcc.MailID != null) { myMessage.Bcc.Add(new MailAddress(mailDetails.Bcc.MailID, mailDetails.Bcc.Name)); }
                if (mailDetails.Attachments.Count > 0)
                {
                    foreach (var attachment in mailDetails.Attachments)
                    {
                        myMessage.Attachments.Add(attachment);
                    }
                }

                mySmtpClient.Send(myMessage);
            }
            catch (Exception ex)
            {
                string Msg = ex.Message.ToString();
            }

            return false;
        }

        public class MailDetail
        {
            public MailDetail()
            {
                To = new MailPersonDetails();
                Cc = new MailPersonDetails();
                Bcc = new MailPersonDetails();
                Attachments = new List<Attachment>();
            }

            public string Subject { get; set; }
            public string Body { get; set; }
            public MailPersonDetails To { get; set; }
            public MailPersonDetails Cc { get; set; }
            public MailPersonDetails Bcc { get; set; }
            public List<Attachment> Attachments { get; set; }
        }

        public class MailPersonDetails
        {
            public string MailID { get; set; }
            public string Name { get; set; }
        }
    }
}