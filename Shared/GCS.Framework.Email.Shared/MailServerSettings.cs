using System;
using System.Collections.Generic;
using System.Text;

namespace GCS.Framework.Email
{
    public class MailServerSettings
    {
        public string Host { get; set; }
        public int HostPort { get; set; }
        public bool UseSSL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
