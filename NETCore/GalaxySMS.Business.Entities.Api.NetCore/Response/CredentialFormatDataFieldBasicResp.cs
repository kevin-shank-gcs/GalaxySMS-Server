using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class CredentialFormatDataFieldBasicResp
    {
//        public System.Guid CredentialFormatDataFieldUid { get; set; }

//        public System.Guid CredentialFormatUid { get; set; }

        public string FieldName { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }

//        public short StartsAt { get; set; }

//        public short BitLength { get; set; }
        public ulong MinimumValue { get; set; }
        public ulong MaximumValue { get; set; }
        public short FieldNumber { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsVisible { get; set; }
        public ulong DefaultValue { get; set; }
    }
}
