    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class gcsUserSession
        {
        	public gcsUserSession()
        	{
        		Initialize();
        	}
        
        	public gcsUserSession(gcsUserSession e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsUserSession e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.gcsUserSessionUid = e.gcsUserSessionUid;
        		this.ApplicationId = e.ApplicationId;
        		this.UserId = e.UserId;
        		this.UserName = e.UserName;
        		this.ApplicationName = e.ApplicationName;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public gcsUserSession Clone(gcsUserSession e)
        	{
        		return new gcsUserSession(e);
        	}
        
        	public bool Equals(gcsUserSession other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsUserSession other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.gcsUserSessionUid != this.gcsUserSessionUid )
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
