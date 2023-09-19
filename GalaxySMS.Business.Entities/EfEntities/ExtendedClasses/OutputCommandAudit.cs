    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class OutputCommandAudit
        {
        	public OutputCommandAudit()
        	{
        		Initialize();
        	}
        
        	public OutputCommandAudit(OutputCommandAudit e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(OutputCommandAudit e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.OutputCommandAuditUid = e.OutputCommandAuditUid;
        		this.UserId = e.UserId;
        		this.OutputCommandUid = e.OutputCommandUid;
        		this.OutputDeviceUid = e.OutputDeviceUid;
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
        
        	public OutputCommandAudit Clone(OutputCommandAudit e)
        	{
        		return new OutputCommandAudit(e);
        	}
        
        	public bool Equals(OutputCommandAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(OutputCommandAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.OutputCommandAuditUid != this.OutputCommandAuditUid )
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
