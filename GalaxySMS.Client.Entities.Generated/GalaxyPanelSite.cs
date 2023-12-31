//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    
	[DataContract]
	public partial class GalaxyPanelSite : DbObjectBase, ITableEntityBase
    {
    
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class GalaxyPanelSite
        {
        	public GalaxyPanelSite() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyPanelSite(GalaxyPanelSite e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyPanelSite e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyPanelSiteUid = e.GalaxyPanelSiteUid;
        		this.GalaxyPanelUid = e.GalaxyPanelUid;
        		this.SiteUid = e.SiteUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyPanelSite Clone(GalaxyPanelSite e)
        	{
        		return new GalaxyPanelSite(e);
        	}
        
        	public bool Equals(GalaxyPanelSite other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyPanelSite other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyPanelSiteUid != this.GalaxyPanelSiteUid )
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
    
    	
    	private System.Guid _galaxyPanelSiteUid;
    
    	[DataMember]
    	public System.Guid GalaxyPanelSiteUid
    	{ 
    		get { return _galaxyPanelSiteUid; }
    		set
    		{
    			if (_galaxyPanelSiteUid != value )
    			{
    				_galaxyPanelSiteUid = value;
    				OnPropertyChanged(() => GalaxyPanelSiteUid);
    			}
    		}
    	}
    	
    	private System.Guid _galaxyPanelUid;
    
    	[DataMember]
    	public System.Guid GalaxyPanelUid
    	{ 
    		get { return _galaxyPanelUid; }
    		set
    		{
    			if (_galaxyPanelUid != value )
    			{
    				_galaxyPanelUid = value;
    				OnPropertyChanged(() => GalaxyPanelUid);
    			}
    		}
    	}
    	
    	private System.Guid _siteUid;
    
    	[DataMember]
    	public System.Guid SiteUid
    	{ 
    		get { return _siteUid; }
    		set
    		{
    			if (_siteUid != value )
    			{
    				_siteUid = value;
    				OnPropertyChanged(() => SiteUid);
    			}
    		}
    	}
    	
    	private string _insertName;
    
    	[DataMember]
    	public string InsertName
    	{ 
    		get { return _insertName; }
    		set
    		{
    			if (_insertName != value )
    			{
    				_insertName = value;
    				OnPropertyChanged(() => InsertName);
    			}
    		}
    	}
    	
    	private System.DateTime _insertDate;
    
    	[DataMember]
    	public System.DateTime InsertDate
    	{ 
    		get { return _insertDate; }
    		set
    		{
    			if (_insertDate != value )
    			{
    				_insertDate = value;
    				OnPropertyChanged(() => InsertDate);
    			}
    		}
    	}
    	
    	private string _updateName;
    
    	[DataMember]
    	public string UpdateName
    	{ 
    		get { return _updateName; }
    		set
    		{
    			if (_updateName != value )
    			{
    				_updateName = value;
    				OnPropertyChanged(() => UpdateName);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTime> _updateDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> UpdateDate
    	{ 
    		get { return _updateDate; }
    		set
    		{
    			if (_updateDate != value )
    			{
    				_updateDate = value;
    				OnPropertyChanged(() => UpdateDate);
    			}
    		}
    	}
    	
    	private Nullable<short> _concurrencyValue;
    
    	[DataMember]
    	public Nullable<short> ConcurrencyValue
    	{ 
    		get { return _concurrencyValue; }
    		set
    		{
    			if (_concurrencyValue != value )
    			{
    				_concurrencyValue = value;
    				OnPropertyChanged(() => ConcurrencyValue);
    			}
    		}
    	}
    
    	
    	private GalaxyPanel _galaxyPanel;
    
    	[DataMember]
    	public virtual GalaxyPanel GalaxyPanel
    	{ 
    		get { return _galaxyPanel; }
    		set
    		{
    			if (_galaxyPanel != value )
    			{
    				_galaxyPanel = value;
    				OnPropertyChanged(() => GalaxyPanel);
    			}
    		}
    	}
    	
    	private Site _site;
    
    	[DataMember]
    	public virtual Site Site
    	{ 
    		get { return _site; }
    		set
    		{
    			if (_site != value )
    			{
    				_site = value;
    				OnPropertyChanged(() => Site);
    			}
    		}
    	}
    }
    
}
