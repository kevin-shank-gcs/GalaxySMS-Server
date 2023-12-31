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
	using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class Address : DbObjectBase
    {

        /*	// Move to partial class
        using System;
        using System.Collections.Generic;
        using System.Runtime.Serialization;
        using GCS.Core.Common.Core;
        using FluentValidation;
        using System.Collections.ObjectModel;
        using GCS.Core.Common.Extensions;

        namespace GalaxySMS.Client.Entities
        {
            public partial class Address
            {
                public Address()
                {
                    Initialize();
                }

                public Address(Address e)
                {
                    Initialize(e);
                }

                public void Initialize()
                {
                    StateProvince = new StateProvince();
                }

                public void Initialize(Address e)
                {
                    Initialize();
                    if( e == null )
                        return;
                    this.AddressUid = e.AddressUid;
                    this.StreetAddress = e.StreetAddress;
                    this.PostalCode = e.PostalCode;
                    this.City = e.City;
                    this.StateProvinceUid = e.StateProvinceUid;
                    this.Longitude = e.Longitude;
                    this.Latitude = e.Latitude;
                    this.InsertName = e.InsertName;
                    this.InsertDate = e.InsertDate;
                    this.UpdateName = e.UpdateName;
                    this.UpdateDate = e.UpdateDate;
                    this.ConcurrencyValue = e.ConcurrencyValue;
                    this.StateProvince = e.StateProvince;
                }

                public Address Clone(Address e)
                {
                    return new Address(e);
                }

                public bool Equals(Address other)
                {
                    return base.Equals(other);
                }

                public bool IsPrimaryKeyEqual(Address other)
                {
                    if( other == null ) 
                        return false;

                    if(other.AddressUid != this.AddressUid )
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


        /// <summary>   The address UID. </summary>
        private System.Guid _addressUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the address UID. </summary>
        ///
        /// <value> The address UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid AddressUid
    	{ 
    		get { return _addressUid; }
    		set
    		{
    			if (_addressUid != value )
    			{
    				_addressUid = value;
    				OnPropertyChanged(() => AddressUid);
    			}
    		}
    	}
    	
        /// <summary>   The street address. </summary>
    	private string _streetAddress;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the street address. </summary>
        ///
        /// <value> The street address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string StreetAddress
    	{ 
    		get { return _streetAddress; }
    		set
    		{
    			if (_streetAddress != value )
    			{
    				_streetAddress = value;
    				OnPropertyChanged(() => StreetAddress);
    			}
    		}
    	}
    	
        /// <summary>   The postal code. </summary>
    	private string _postalCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the postal code. </summary>
        ///
        /// <value> The postal code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string PostalCode
    	{ 
    		get { return _postalCode; }
    		set
    		{
    			if (_postalCode != value )
    			{
    				_postalCode = value;
    				OnPropertyChanged(() => PostalCode);
    			}
    		}
    	}
    	
        /// <summary>   The city. </summary>
    	private string _city;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the city. </summary>
        ///
        /// <value> The city. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string City
    	{ 
    		get { return _city; }
    		set
    		{
    			if (_city != value )
    			{
    				_city = value;
    				OnPropertyChanged(() => City);
    			}
    		}
    	}
    	
        /// <summary>   The state province UID. </summary>
    	private System.Guid _stateProvinceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state province UID. </summary>
        ///
        /// <value> The state province UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid StateProvinceUid
    	{ 
    		get { return _stateProvinceUid; }
    		set
    		{
    			if (_stateProvinceUid != value )
    			{
    				_stateProvinceUid = value;
    				OnPropertyChanged(() => StateProvinceUid);
    			}
    		}
    	}
    	
        /// <summary>   The longitude. </summary>
    	private Nullable<double> _longitude;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the longitude. </summary>
        ///
        /// <value> The longitude. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<double> Longitude
    	{ 
    		get { return _longitude; }
    		set
    		{
    			if (_longitude != value )
    			{
    				_longitude = value;
    				OnPropertyChanged(() => Longitude);
    			}
    		}
    	}
    	
        /// <summary>   The latitude. </summary>
    	private Nullable<double> _latitude;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the latitude. </summary>
        ///
        /// <value> The latitude. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<double> Latitude
    	{ 
    		get { return _latitude; }
    		set
    		{
    			if (_latitude != value )
    			{
    				_latitude = value;
    				OnPropertyChanged(() => Latitude);
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

        /// <summary>   The state province. </summary>
        private StateProvince _stateProvince;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state province. </summary>
        ///
        /// <value> The state province. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual StateProvince StateProvince
    	{ 
    		get { return _stateProvince; }
    		set
    		{
    			if (_stateProvince != value )
    			{
    				_stateProvince = value;
    				OnPropertyChanged(() => StateProvince);
    			}
    		}
    	}
    }
    
}
