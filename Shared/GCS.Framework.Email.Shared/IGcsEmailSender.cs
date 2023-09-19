using System.Collections.Generic;
using System.Threading.Tasks;
using MimeKit;

namespace GCS.Framework.Email
{
    public interface IGcsEmailSender
    {
        Task SendEmailAsync(string toEmail, string fromEmail, string subject, string htmlMessage, IEnumerable<MimePart> attachments );     
        Task SendEmailAsync(string toEmail, string fromEmail, string subject, string htmlMessage);
    }
}
