using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class MailerModel
    {
        public string ToEmails { get; set; }
        public string Subject { get; set; }
        public string Attachment { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Contact { get; set; }
        public string CCMail { get; set; }
    }
}
