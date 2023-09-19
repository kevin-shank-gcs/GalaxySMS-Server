//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Business.Entities
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
    using GCS.Core.Common.Core;
    public partial class gcsSystem : EntityBase, IIdentifiableEntity, IEquatable<gcsSystem>
    {
        public System.Guid SystemId { get; set; }
        public string License { get; set; }
        public string PublicKey { get; set; }
        public string InsertName { get; set; }
        public System.DateTimeOffset InsertDate { get; set; }
        public string UpdateName { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<short> ConcurrencyValue { get; set; }
        public string SystemName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string SupportCompany { get; set; }
        public string SupportContact { get; set; }
        public string SupportPhone { get; set; }
        public string SupportEmail { get; set; }
        public string SupportUrl { get; set; }
        public byte[] SupportImage { get; set; }
        public byte[] SystemImage { get; set; }
        public License TheLicense { get; set; }

        public Version SystemVersion { get; set; }
    }
}
