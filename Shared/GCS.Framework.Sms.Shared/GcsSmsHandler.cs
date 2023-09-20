using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace GCS.Framework.Sms
{
    public class GcsSmsHandler : IGcsSmsHandler
    {
        private readonly string _accountSid;
        private readonly string _authToken;

        public GcsSmsHandler(string accountSid, string authToken)
        {
            _accountSid = accountSid;
            _authToken = authToken;
        }

        public async Task<string> SendMessage(string toPhoneNumber, string fromPhoneNumber, string message)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var to = new PhoneNumber(toPhoneNumber);
            var from = new PhoneNumber(fromPhoneNumber);

            var msg = await MessageResource.CreateAsync(to: to, from: from, body: message);
            return msg.Sid;
        }
    }
}
