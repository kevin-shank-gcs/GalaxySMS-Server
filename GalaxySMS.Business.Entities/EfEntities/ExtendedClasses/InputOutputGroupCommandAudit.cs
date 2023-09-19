    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class InputOutputGroupCommandAudit
        {
        	public InputOutputGroupCommandAudit()
        	{
        		Initialize();
        	}
        
        	public InputOutputGroupCommandAudit(InputOutputGroupCommandAudit e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(InputOutputGroupCommandAudit e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.InputOutputGroupCommandAuditUid = e.InputOutputGroupCommandAuditUid;
        		this.UserId = e.UserId;
        		this.InputOutputGroupCommandUid = e.InputOutputGroupCommandUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
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
        
        	public InputOutputGroupCommandAudit Clone(InputOutputGroupCommandAudit e)
        	{
        		return new InputOutputGroupCommandAudit(e);
        	}
        
        	public bool Equals(InputOutputGroupCommandAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputOutputGroupCommandAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputOutputGroupCommandAuditUid != this.InputOutputGroupCommandAuditUid )
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
