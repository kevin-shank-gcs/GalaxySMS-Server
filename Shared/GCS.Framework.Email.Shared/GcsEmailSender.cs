using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using GCS.Core.Common.Logger;

namespace GCS.Framework.Email
{
    public class GcsEmailSender : IGcsEmailSender
    {
        // Our private configuration variables

        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        // Get our parameterized configuration

        public GcsEmailSender(string host, int port, bool enableSSL, string userName, string password)
        {

            this.host = host;

            this.port = port;

            this.enableSSL = enableSSL;

            this.userName = userName;

            this.password = password;

        }


        // Use our configuration to send the email by using SmtpClient

        public async Task SendEmailAsync(string toEmail, string fromEmail, string subject, string htmlMessage)
        {
            await SendEmailAsync(toEmail, fromEmail, subject, htmlMessage, new List<MimePart>());
        }

        public async Task SendEmailAsync(string toEmail, string fromEmail, string subject, string htmlMessage, IEnumerable<MimePart> attachments)
        {
            try
            {
                if( string.IsNullOrEmpty(toEmail))
                    toEmail = "kshank@galaxysys.com";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromEmail, fromEmail));
                message.To.Add(new MailboxAddress(toEmail, toEmail));
                message.Subject = subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = htmlMessage;
                foreach (var attachment in attachments)
                    builder.Attachments.Add(attachment);

                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(host, port, MailKit.Security.SecureSocketOptions.Auto);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(userName, password);

                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
