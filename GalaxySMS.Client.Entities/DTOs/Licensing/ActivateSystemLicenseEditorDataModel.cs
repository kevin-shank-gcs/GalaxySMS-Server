using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Licensing.Entities
{
    public class ActivateSystemLicenseEditorDataModel
    {
        public IEnumerable<CountryModel> Countries { get; set; }
        public IEnumerable<FacilityTypeModel> FacilityTypes { get; set; }
        public ActivateSystemLicenseModel CurrentSystemLicenseData { get; set; }
    }
}
