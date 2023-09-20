using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{    
    public partial class CountryBasicResp
    {
        public System.Guid CountryUid { get; set; }
        public string CountryIso { get; set; }
        public string CountryName { get; set; }
        public string LongCountryName { get; set; }
        public string Iso3 { get; set; }

//        public string NumberCode { get; set; }
//        public bool UnitedNationsMemberState { get; set; }
//        public string CallingCode { get; set; }
//        public string CCTLD { get; set; }
        public byte[] FlagImage { get; set; }
        public ICollection<StateProvinceBasicResp> StateProvinces { get; set; }

    }
}
