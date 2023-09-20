using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Geography.DataClasses
{
    public class LookupPostalCodeParameters
    {
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string UserName { get; set; }
    }
}
