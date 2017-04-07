using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class Mailer
    {
        /// <summary>
        /// Send Mails To Users
        /// </summary>
        /// <param name="model">Object Of Type DTO.IGUNHS.COM.MailerModel</param>
        /// <returns>Boolean Type</returns>
        private Boolean SendMail(DTO.LABURNUM.COM.MailerModel model)
        {
            MailMessage mail = new MailMessage();
            try
            {
                string[] Multi = model.ToEmails.Split(',');
                foreach (string Multiemailid in Multi)
                {
                    mail.To.Add(new MailAddress(Multiemailid));
                }
                mail.From = new MailAddress(model.From);
                // Add a carbon copy recipient.
                if (model.CCMail != "" && model.CCMail != null)
                {
                    MailAddress copy = new MailAddress(model.CCMail);
                    mail.CC.Add(copy);
                }
                mail.Subject = model.Subject;
                if (model.Attachment != null)
                {
                    mail.Attachments.Add(new Attachment(""));
                }
                mail.Body = model.Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = API.LABURNUM.COM.Component.Constants.SMTP.SMTPHOST;
                smtp.Port = API.LABURNUM.COM.Component.Constants.SMTP.SMTPPORT;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                (API.LABURNUM.COM.Component.Constants.SMTP.SMTPEMAIL, API.LABURNUM.COM.Component.Constants.SMTP.SMTPPASSWORD);
                smtp.EnableSsl = false;
                smtp.Send(mail);
                mail.Attachments.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                mail.Attachments.Dispose();
                return false;
            }
        }

        public Boolean MailSend(string mailTo, string mailCC, string mailBody, string mailFrom, string mailSubject)
        {
            DTO.LABURNUM.COM.MailerModel model = new DTO.LABURNUM.COM.MailerModel()
            {
                ToEmails = mailTo,
                Body = mailBody,
                CCMail = mailCC,
                From = mailFrom,
                Subject = mailSubject
            };
            return SendMail(model);
        }
    }
}