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
	public partial class PersonLastUsage : DbObjectBase, ITableEntityBase
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
        public partial class PersonLastUsage
        {
        	public PersonLastUsage() : base()
        	{
        		Initialize();
        	}
        
        	public PersonLastUsage(PersonLastUsage e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonLastUsage e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonUid = e.PersonUid;
        		this.LastAccessPortalActivityEventUid = e.LastAccessPortalActivityEventUid;
        		this.LastAccessGrantedAccessPortalActivityEventUid = e.LastAccessGrantedAccessPortalActivityEventUid;
        		
        	}
        
        	public PersonLastUsage Clone(PersonLastUsage e)
        	{
        		return new PersonLastUsage(e);
        	}
        
        	public bool Equals(PersonLastUsage other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonLastUsage other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonUid != this.PersonUid )
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
    
    	
    	private System.Guid _personUid;
    
    	[DataMember]
    	public System.Guid PersonUid
    	{ 
    		get { return _personUid; }
    		set
    		{
    			if (_personUid != value )
    			{
    				_personUid = value;
    				OnPropertyChanged(() => PersonUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _lastAccessPortalActivityEventUid;
    
    	[DataMember]
    	public Nullable<System.Guid> LastAccessPortalActivityEventUid
    	{ 
    		get { return _lastAccessPortalActivityEventUid; }
    		set
    		{
    			if (_lastAccessPortalActivityEventUid != value )
    			{
    				_lastAccessPortalActivityEventUid = value;
    				OnPropertyChanged(() => LastAccessPortalActivityEventUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _lastAccessGrantedAccessPortalActivityEventUid;
    
    	[DataMember]
    	public Nullable<System.Guid> LastAccessGrantedAccessPortalActivityEventUid
    	{ 
    		get { return _lastAccessGrantedAccessPortalActivityEventUid; }
    		set
    		{
    			if (_lastAccessGrantedAccessPortalActivityEventUid != value )
    			{
    				_lastAccessGrantedAccessPortalActivityEventUid = value;
    				OnPropertyChanged(() => LastAccessGrantedAccessPortalActivityEventUid);
    			}
    		}
    	}
    
    	
    	private Person _person;
    
    	[DataMember]
    	public virtual Person Person
    	{ 
    		get { return _person; }
    		set
    		{
    			if (_person != value )
    			{
    				_person = value;
    				OnPropertyChanged(() => Person);
    			}
    		}
    	}
    }
    
}
