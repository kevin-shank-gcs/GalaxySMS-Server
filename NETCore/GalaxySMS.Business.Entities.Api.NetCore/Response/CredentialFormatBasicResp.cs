using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class CredentialFormatBasicResp
    {
        public System.Guid CredentialFormatUid { get; set; }

        public string Display { get; set; }
        public string Description { get; set; }
        public CredentialFormatCodes CredentialFormatCode { get; set; }

        public string CredentialFormatCodeKey { get => CredentialFormatCode.ToString(); }
        public bool UseCardNumber { get; set; }
        public short BitLength { get; set; }

//        public bool IsEnabled { get; set; }
//        public bool BiometricEnrollmentSupported { get; set; }
//        public short BiometricIdField { get; set; }
//        public bool BatchLoadSupported { get; set; }
//        public short BatchLoadIncrementField { get; set; }
//        public bool IsAllowed { get; set; }
//        public Guid EntityId { get; set; }

        public ICollection<CredentialFormatDataFieldBasicResp> CredentialFormatDataFields { get; set; }

//        public ICollection<CredentialFormatParityBasic> CredentialFormatParities { get; set; }
    }
}
