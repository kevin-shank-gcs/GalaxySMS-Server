using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class DecodeCredentialNumberParameters : EntityBase
    {
        public short BitCount { get; set; }
        public string CredentialNumber { get; set; }
    }


}
