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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person list property item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class PersonListPropertyItem : DbObjectBase, ITableEntityBase
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
        public partial class PersonListPropertyItem
        {
        	public PersonListPropertyItem() : base()
        	{
        		Initialize();
        	}
        
        	public PersonListPropertyItem(PersonListPropertyItem e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonListPropertyItem e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonListPropertyItemUid = e.PersonListPropertyItemUid;
        		this.PersonUid = e.PersonUid;
        		this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
        		this.UserDefinedListPropertyItemUid = e.UserDefinedListPropertyItemUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public PersonListPropertyItem Clone(PersonListPropertyItem e)
        	{
        		return new PersonListPropertyItem(e);
        	}
        
        	public bool Equals(PersonListPropertyItem other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonListPropertyItem other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonListPropertyItemUid != this.PersonListPropertyItemUid )
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
    
    	
        /// <summary>   The person list property item UID. </summary>
    	private System.Guid _personListPropertyItemUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person list property item UID. </summary>
        ///
        /// <value> The person list property item UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid PersonListPropertyItemUid
    	{ 
    		get { return _personListPropertyItemUid; }
    		set
    		{
    			if (_personListPropertyItemUid != value )
    			{
    				_personListPropertyItemUid = value;
    				OnPropertyChanged(() => PersonListPropertyItemUid);
    			}
    		}
    	}
    	
        /// <summary>   The person UID. </summary>
    	private System.Guid _personUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person UID. </summary>
        ///
        /// <value> The person UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    	
        /// <summary>   The user defined property UID. </summary>
    	private System.Guid _userDefinedPropertyUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user defined property UID. </summary>
        ///
        /// <value> The user defined property UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid UserDefinedPropertyUid
    	{ 
    		get { return _userDefinedPropertyUid; }
    		set
    		{
    			if (_userDefinedPropertyUid != value )
    			{
    				_userDefinedPropertyUid = value;
    				OnPropertyChanged(() => UserDefinedPropertyUid);
    			}
    		}
    	}
    	
        /// <summary>   The user defined list property item UID. </summary>
    	private System.Guid _userDefinedListPropertyItemUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user defined list property item UID. </summary>
        ///
        /// <value> The user defined list property item UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid UserDefinedListPropertyItemUid
    	{ 
    		get { return _userDefinedListPropertyItemUid; }
    		set
    		{
    			if (_userDefinedListPropertyItemUid != value )
    			{
    				_userDefinedListPropertyItemUid = value;
    				OnPropertyChanged(() => UserDefinedListPropertyItemUid);
    			}
    		}
    	}
    	
        /// <summary>   Name of the insert. </summary>
    	private string _insertName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the insert. </summary>
        ///
        /// <value> The name of the insert. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    	
        /// <summary>   The insert date. </summary>
    	private System.DateTimeOffset _insertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.DateTimeOffset InsertDate
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
    	
        /// <summary>   Name of the update. </summary>
    	private string _updateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the update. </summary>
        ///
        /// <value> The name of the update. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    	
        /// <summary>   The update. </summary>
    	private Nullable<System.DateTimeOffset> _updateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.DateTimeOffset> UpdateDate
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
    	
        /// <summary>   The concurrency value. </summary>
    	private Nullable<short> _concurrencyValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency value. </summary>
        ///
        /// <value> The concurrency value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    
    	
        /// <summary>   The user defined property. </summary>
    	private UserDefinedProperty _userDefinedProperty;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user defined property. </summary>
        ///
        /// <value> The user defined property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual UserDefinedProperty UserDefinedProperty
    	{ 
    		get { return _userDefinedProperty; }
    		set
    		{
    			if (_userDefinedProperty != value )
    			{
    				_userDefinedProperty = value;
    				OnPropertyChanged(() => UserDefinedProperty);
    			}
    		}
    	}
    }
    
}
