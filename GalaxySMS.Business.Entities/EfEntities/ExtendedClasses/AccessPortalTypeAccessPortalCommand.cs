    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class AccessPortalTypeAccessPortalCommand
        {
        	public AccessPortalTypeAccessPortalCommand()
        	{
        		Initialize();
        	}
        
        	public AccessPortalTypeAccessPortalCommand(AccessPortalTypeAccessPortalCommand e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(AccessPortalTypeAccessPortalCommand e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.AccessPortalTypeAccessPortalCommandUid = e.AccessPortalTypeAccessPortalCommandUid;
        		this.AccessPortalCommandUid = e.AccessPortalCommandUid;
        		this.AccessPortalTypeUid = e.AccessPortalTypeUid;
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
        
        	public AccessPortalTypeAccessPortalCommand Clone(AccessPortalTypeAccessPortalCommand e)
        	{
        		return new AccessPortalTypeAccessPortalCommand(e);
        	}
        
        	public bool Equals(AccessPortalTypeAccessPortalCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalTypeAccessPortalCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalTypeAccessPortalCommandUid != this.AccessPortalTypeAccessPortalCommandUid )
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
