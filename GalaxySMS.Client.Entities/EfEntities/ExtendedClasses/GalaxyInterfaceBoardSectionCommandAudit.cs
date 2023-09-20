    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class GalaxyInterfaceBoardSectionCommandAudit
        {
        	public GalaxyInterfaceBoardSectionCommandAudit() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyInterfaceBoardSectionCommandAudit(GalaxyInterfaceBoardSectionCommandAudit e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyInterfaceBoardSectionCommandAudit e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyInterfaceBoardSectionCommandAuditUid = e.GalaxyInterfaceBoardSectionCommandAuditUid;
        		this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
        		this.UserId = e.UserId;
        		this.GalaxyInterfaceBoardSectionCommandUid = e.GalaxyInterfaceBoardSectionCommandUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyInterfaceBoardSectionCommandAudit Clone(GalaxyInterfaceBoardSectionCommandAudit e)
        	{
        		return new GalaxyInterfaceBoardSectionCommandAudit(e);
        	}
        
        	public bool Equals(GalaxyInterfaceBoardSectionCommandAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSectionCommandAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyInterfaceBoardSectionCommandAuditUid != this.GalaxyInterfaceBoardSectionCommandAuditUid )
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
