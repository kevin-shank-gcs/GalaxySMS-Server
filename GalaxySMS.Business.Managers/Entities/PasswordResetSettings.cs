using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Managers
{
    public class PasswordResetSettings
    {
        public int TokenLifespan { get; set; }
        public string TokenEmailSubject { get; set; }
        public string TokenEmailTemplate { get; set; }
        public string TokenSmsTemplate { get; set; }

    }
}
