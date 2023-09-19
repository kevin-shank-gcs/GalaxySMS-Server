using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
	public class DecodeCredentialNumberParametersReq//: EntityBase
    {
        public short BitCount { get; set; }

        public string CredentialNumber { get; set; }
    }
}
