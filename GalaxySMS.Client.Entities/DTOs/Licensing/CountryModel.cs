using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Licensing.Entities
{
    public class CountryModel
    {
        public Guid Id { get; set; }
        public string CountryIso { get; set; }
        public string CountryName { get; set; }
        public string Iso3 { get; set; }
        public byte[] FlagImage { get; set; }

        public IEnumerable<StateModel> States {get;set;}
    }
}
