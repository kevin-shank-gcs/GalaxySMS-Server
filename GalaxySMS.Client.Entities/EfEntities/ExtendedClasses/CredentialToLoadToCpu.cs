    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class CredentialToLoadToCpu
        {
        	public CredentialToLoadToCpu() : base()
        	{
        		Initialize();
        	}
        
        	public CredentialToLoadToCpu(CredentialToLoadToCpu e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(CredentialToLoadToCpu e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.CredentialToLoadToCpuUid = e.CredentialToLoadToCpuUid;
        		this.CpuUid = e.CpuUid;
        		this.CredentialUid = e.CredentialUid;
        		this.LastCredentialChangeDate = e.LastCredentialChangeDate;
        		this.LastPersonalAccessGroupChangeDate = e.LastPersonalAccessGroupChangeDate;
        		this.LastCredentialLoadedDate = e.LastCredentialLoadedDate;
        		this.LastPersonalAccessGroupLoadedDate = e.LastPersonalAccessGroupLoadedDate;
        		this.LastForceLoadDate = e.LastForceLoadDate;
        	}
        
        	public CredentialToLoadToCpu Clone(CredentialToLoadToCpu e)
        	{
        		return new CredentialToLoadToCpu(e);
        	}
        
        	public bool Equals(CredentialToLoadToCpu other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(CredentialToLoadToCpu other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CredentialToLoadToCpuUid != this.CredentialToLoadToCpuUid )
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
