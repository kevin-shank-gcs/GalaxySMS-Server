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
    public partial class AccessPortalType : EntityBase, IIdentifiableEntity, IEquatable<AccessPortalType>, ITableEntityBase, IHasBinaryResource
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class AccessPortalType
        {
        	public AccessPortalType()
        	{
        		Initialize();
        	}
        
        	public AccessPortalType(AccessPortalType e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(AccessPortalType e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.AccessPortalTypeUid = e.AccessPortalTypeUid;
        		this.CredentialReaderTypeUid = e.CredentialReaderTypeUid;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.AccessPortalTypeDescription = e.AccessPortalTypeDescription;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public AccessPortalType Clone(AccessPortalType e)
        	{
        		return new AccessPortalType(e);
        	}
        
        	public bool Equals(AccessPortalType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalTypeUid != this.AccessPortalTypeUid )
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
    	public System.Guid AccessPortalTypeUid { get; set; }
    	public System.Guid CredentialReaderTypeUid { get; set; }
    	public Nullable<System.Guid> BinaryResourceUid { get; set; }
    	public string AccessPortalTypeDescription { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }

        public string Name { get { return AccessPortalTypeDescription; } set { AccessPortalTypeDescription = value; } }
        public gcsBinaryResource gcsBinaryResource { get; set; }
    
    }
}
