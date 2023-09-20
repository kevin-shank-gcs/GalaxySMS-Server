using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Licensing.Entities
{
    public class StateModel
    {
        public Guid Id { get; set; }

        public string StateName { get; set; }

        public string StateProvinceCode { get; set; }

        public IEnumerable<CityModel> Cities { get; set; }

    }
}
