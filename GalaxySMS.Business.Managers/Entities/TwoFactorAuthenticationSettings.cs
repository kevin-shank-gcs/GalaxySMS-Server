using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Managers
{
    public class TwoFactorAuthenticationSettings
    {
        public int TokenLifespan { get; set; }
        public string AuthTokenEmailSubject { get; set; }
        public string AuthTokenEmailTemplate { get; set; }
        public string AuthTokenSmsTemplate { get; set; }

    }
}
