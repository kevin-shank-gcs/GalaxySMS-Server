using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class TwoFactorAuthParameters
    {
        public int TwoFactorTokenLifespan { get; set; }
        public string TwoFactorAuthTokenEmailSubject { get; set; }
        public string TwoFactorAuthTokenEmailTemplate { get; set; }
        public string TwoFactorAuthTokenSmsTemplate { get; set; }

    }
}
