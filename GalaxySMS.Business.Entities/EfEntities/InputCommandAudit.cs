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
    public partial class InputCommandAudit : EntityBase, IIdentifiableEntity, IEquatable<InputCommandAudit>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class InputCommandAudit
        {
        	public InputCommandAudit()
        	{
        		Initialize();
        	}
        
        	public InputCommandAudit(InputCommandAudit e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(InputCommandAudit e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.InputCommandAuditUid = e.InputCommandAuditUid;
        		this.UserId = e.UserId;
        		this.InputCommandUid = e.InputCommandUid;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public bool IsAnythingDirty
        	{
        		get
        		{
        			//foreach( var o in InterfaceBoardSections)
        			//{
        			//	if (o.IsAnythingDirty == true)
        			//		return true;
        			//}
        			return IsDirty;                
        		}
        	}
        
        	public InputCommandAudit Clone(InputCommandAudit e)
        	{
        		return new InputCommandAudit(e);
        	}
        
        	public bool Equals(InputCommandAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputCommandAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputCommandAuditUid != this.InputCommandAuditUid )
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
    	public System.Guid InputCommandAuditUid { get; set; }
    	public System.Guid UserId { get; set; }
    	public System.Guid InputCommandUid { get; set; }
    	public System.Guid InputDeviceUid { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public gcsUser gcsUser { get; set; }
    	public InputCommand InputCommand { get; set; }
    	public InputDevice InputDevice { get; set; }
    
    }
}
