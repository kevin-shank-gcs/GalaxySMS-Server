using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Notification
{
    public class Email
    {
        public class EmailParameters
        {
            public EmailParameters()
            {
                EnableSsl = true;
                PortNumber = 587;
                IsBodyHtml = true;
                Attachments = new List<string>();
            }

            /// <summary>
            /// Get/Set SmtpAddress
            /// </summary>
            public string SmtpAddress { get; set; }

            public int PortNumber { get; set; }
            /// <summary>
            /// Get/Set EmailFrom
            /// </summary>
            public string EmailFrom { get; set; }

            /// <summary>
            /// Get/Set Password
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Get/Set EmailTo
            /// </summary>
            public string EmailTo { get; set; }

            /// <summary>
            /// Get/Set Subject
            /// </summary>
            public string Subject { get; set; }

            /// <summary>
            /// Get/Set Body
            /// </summary>
            public string Body { get; set; }

            /// <summary>
            /// Get/Set EnableSsl
            /// </summary>
            public bool EnableSsl { get; set; }

            /// <summary>
            /// Get/Set IsBodyHtml
            /// </summary>
            public bool IsBodyHtml { get; set; }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the attachments. </summary>
            ///
            /// <value> The attachments. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public ICollection<string> Attachments { get; set; }

        }

        public static async Task SendAsync(EmailParameters parameters)
        {

            using (MailMessage mail = new MailMessage())
            {
                if( !string.IsNullOrWhiteSpace(parameters.EmailFrom))
                    mail.From = new MailAddress(parameters.EmailFrom);
                mail.To.Add(parameters.EmailTo);
                mail.Subject = parameters.Subject;
                mail.Body = parameters.Body;
                mail.IsBodyHtml = parameters.IsBodyHtml;
                // Can set to false, if you are sending pure text.

                foreach (var attachemnt in parameters.Attachments)
                {
                    mail.Attachments.Add(new Attachment(attachemnt));
                }

                using (SmtpClient smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
