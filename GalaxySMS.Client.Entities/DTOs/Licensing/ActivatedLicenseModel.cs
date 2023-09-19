using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Licensing.Entities
{
    public class ActivatedLicenseModel
    {
        public string SupportingOrganizationName { get; set; }

        public string LicenseContent { get; set; }
        public string RegistrationCode { get; set; }


        public string PublicKey { get; set; }

    }
}
