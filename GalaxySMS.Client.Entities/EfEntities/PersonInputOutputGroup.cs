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
    /// <summary>   A person input output group. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class PersonInputOutputGroup : DbObjectBase, ITableEntityBase
    {
    
        /// <summary>   The person input output group UID. </summary>
    	private System.Guid _personInputOutputGroupUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person input output group UID. </summary>
        ///
        /// <value> The person input output group UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid PersonInputOutputGroupUid
    	{ 
    		get { return _personInputOutputGroupUid; }
    		set
    		{
    			if (_personInputOutputGroupUid != value )
    			{
    				_personInputOutputGroupUid = value;
    				OnPropertyChanged(() => PersonInputOutputGroupUid);
    			}
    		}
    	}
    	
        /// <summary>   The person cluster permission UID. </summary>
    	private System.Guid _personClusterPermissionUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person cluster permission UID. </summary>
        ///
        /// <value> The person cluster permission UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid PersonClusterPermissionUid
    	{ 
    		get { return _personClusterPermissionUid; }
    		set
    		{
    			if (_personClusterPermissionUid != value )
    			{
    				_personClusterPermissionUid = value;
    				OnPropertyChanged(() => PersonClusterPermissionUid);
    			}
    		}
    	}
    	
        /// <summary>   The input output group UID. </summary>
    	private System.Guid _inputOutputGroupUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group UID. </summary>
        ///
        /// <value> The input output group UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid InputOutputGroupUid
    	{ 
    		get { return _inputOutputGroupUid; }
    		set
    		{
    			if (_inputOutputGroupUid != value )
    			{
    				_inputOutputGroupUid = value;
    				OnPropertyChanged(() => InputOutputGroupUid, true, true);
    			}
    		}
    	}
    	
        /// <summary>   The order number. </summary>
    	private short _orderNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the order number. </summary>
        ///
        /// <value> The order number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short OrderNumber
    	{ 
    		get { return _orderNumber; }
    		set
    		{
    			if (_orderNumber != value )
    			{
    				_orderNumber = value;
    				OnPropertyChanged(() => OrderNumber);
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


        //   /// <summary>   Group the input output belongs to. </summary>
        //private InputOutputGroup _inputOutputGroup;

        //   ////////////////////////////////////////////////////////////////////////////////////////////////////
        //   /// <summary>   Gets or sets the group the input output belongs to. </summary>
        //   ///
        //   /// <value> The input output group. </value>
        //   ////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public virtual InputOutputGroup InputOutputGroup
        //{ 
        //	get { return _inputOutputGroup; }
        //	set
        //	{
        //		if (_inputOutputGroup != value )
        //		{
        //			_inputOutputGroup = value;
        //			OnPropertyChanged(() => InputOutputGroup);
        //		}
        //	}
        //}
    }
    
}
