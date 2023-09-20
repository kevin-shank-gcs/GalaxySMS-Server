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
    public partial class AssaAccessPoint : EntityBase, IIdentifiableEntity, IEquatable<AssaAccessPoint>
    {
        /*	// Move to partial class
        using System;
        using System.Collections.Generic;
        using GCS.Core.Common.Contracts;
        using GCS.Core.Common.Core;
        using GCS.Core.Common.Extensions;

        namespace GalaxySMS.Business.Entities
        {
            public partial class AssaAccessPoint
            {
                public AssaAccessPoint()
                {
                    Initialize();
                }

                public AssaAccessPoint(AssaAccessPoint e)
                {
                    Initialize(e);
                }

                public void Initialize()
                {
                }

                public void Initialize(AssaAccessPoint e)
                {
                    Initialize();
                    if( e == null )
                        return;
                    this.AssaAccessPointUid = e.AssaAccessPointUid;
                    this.AssaDsrUid = e.AssaDsrUid;
                    this.AssaAccessPointTypeUid = e.AssaAccessPointTypeUid;
                    this.SerialNumber = e.SerialNumber;
                    this.AccessPointName = e.AccessPointName;
                    this.FirmwareVersion = e.FirmwareVersion;
                    this.AccessPointTypeDescription = e.AccessPointTypeDescription;
                    this.InsertName = e.InsertName;
                    this.InsertDate = e.InsertDate;
                    this.UpdateName = e.UpdateName;
                    this.UpdateDate = e.UpdateDate;
                    this.ConcurrencyValue = e.ConcurrencyValue;

                }

                public AssaAccessPoint Clone(AssaAccessPoint e)
                {
                    return new AssaAccessPoint(e);
                }

                public bool Equals(AssaAccessPoint other)
                {
                    return base.Equals(other);
                }

                public bool IsPrimaryKeyEqual(AssaAccessPoint other)
                {
                    if( other == null ) 
                        return false;

                    if(other.AssaAccessPointUid != this.AssaAccessPointUid )
                        return false;
                    return true;
                }

                public override int GetHashCode()
                {
                    return base.GetHashCode();
                }

                public override string ToString()
                {
                    return base.ToString();
                }
            }
        }
        */
        public System.Guid AssaAccessPointUid { get; set; }
    	public System.Guid AssaDsrUid { get; set; }
    	public System.Guid AssaAccessPointTypeUid { get; set; }
    	public string SerialNumber { get; set; }
    	public string AccessPointName { get; set; }
    	public string FirmwareVersion { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
        public System.Guid SiteUid { get; set; }
        public string AssaUniqueId { get; set; }
        public string AccessPointTypeDescription { get; set; }
        public AssaAbloyDsr.AccessPoint AccessPoint { get; set; }
        //   public AssaAccessPointType AssaAccessPointType { get; set; }
        //public AssaDsr AssaDsr { get; set; }

    }
}
