using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Aditya
{
    public class Communication
    {
        public static bool ConfirmationMail(string userName, string userEmail)
        {
            string backImageUrl = "http://holyalexander.com/wp-content/uploads/2016/08/pic-4.jpg";

            string body = string.Empty;
            //using streamreader for reading my htmltemplate

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplates/ConfirmEmailID.html")))

            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{backImageUrl}", backImageUrl); //replacing the required things

            body = body.Replace("{userNameUpdate}", userName);

            body = body.Replace("{confirmURL}", "http://104.196.141.47/Login/Login?EmailId=" + userEmail);

            if (SendEmail.sendMailInd("Registered to " + Constants.AppName, new SendEmail.MailDetail { To = new SendEmail.MailPersonDetails { Name = userName, MailID = userEmail }, Body = body.ToString(), Subject = "Welcome to " + Constants.AppName }, true))
            {
                return true;
            }

            return true;
        }
    }
}