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
    /// <summary>   A user defined list property item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class UserDefinedListPropertyItem : DbObjectBase, ITableEntityBase
    {
    
    	
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
    	
        /// <summary>   The display. </summary>
    	private string _display;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display. </summary>
        ///
        /// <value> The display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Display
    	{ 
    		get { return _display; }
    		set
    		{
    			if (_display != value )
    			{
    				_display = value;
    				OnPropertyChanged(() => Display);
    			}
    		}
    	}
    	
        /// <summary>   The display resource key. </summary>
    	private Nullable<System.Guid> _displayResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display resource key. </summary>
        ///
        /// <value> The display resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> DisplayResourceKey
    	{ 
    		get { return _displayResourceKey; }
    		set
    		{
    			if (_displayResourceKey != value )
    			{
    				_displayResourceKey = value;
    				OnPropertyChanged(() => DisplayResourceKey);
    			}
    		}
    	}
    	
        /// <summary>   The description. </summary>
    	private string _description;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Description
    	{ 
    		get { return _description; }
    		set
    		{
    			if (_description != value )
    			{
    				_description = value;
    				OnPropertyChanged(() => Description);
    			}
    		}
    	}
    	
        /// <summary>   The description resource key. </summary>
    	private Nullable<System.Guid> _descriptionResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description resource key. </summary>
        ///
        /// <value> The description resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> DescriptionResourceKey
    	{ 
    		get { return _descriptionResourceKey; }
    		set
    		{
    			if (_descriptionResourceKey != value )
    			{
    				_descriptionResourceKey = value;
    				OnPropertyChanged(() => DescriptionResourceKey);
    			}
    		}
    	}
    	
        /// <summary>   The item value. </summary>
    	private string _itemValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the item value. </summary>
        ///
        /// <value> The item value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string ItemValue
    	{ 
    		get { return _itemValue; }
    		set
    		{
    			if (_itemValue != value )
    			{
    				_itemValue = value;
    				OnPropertyChanged(() => ItemValue);
    			}
    		}
    	}
    	
        /// <summary>   The display order. </summary>
    	private Nullable<short> _displayOrder;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display order. </summary>
        ///
        /// <value> The display order. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<short> DisplayOrder
    	{ 
    		get { return _displayOrder; }
    		set
    		{
    			if (_displayOrder != value )
    			{
    				_displayOrder = value;
    				OnPropertyChanged(() => DisplayOrder);
    			}
    		}
    	}
    	
        /// <summary>   The item image. </summary>
    	private byte[] _itemImage;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the item image. </summary>
        ///
        /// <value> The item image. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public byte[] ItemImage
    	{ 
    		get { return _itemImage; }
    		set
    		{
    			if (_itemImage != value )
    			{
    				_itemImage = value;
    				OnPropertyChanged(() => ItemImage);
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
