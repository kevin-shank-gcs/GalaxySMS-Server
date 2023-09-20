using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Sms
{
    public interface IGcsSmsHandler
    {
        Task<string> SendMessage( string toPhoneNumber, string fromPhoneNumber, string message);
    }
}
