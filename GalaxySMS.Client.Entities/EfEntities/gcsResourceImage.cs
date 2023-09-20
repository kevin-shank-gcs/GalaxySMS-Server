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
    /// <summary>   The gcs resource image. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class gcsResourceImage : DbObjectBase
    {
        /// <summary>   Identifier for the resource image. </summary>
    	private System.Guid _resourceImageId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the resource image. </summary>
        ///
        /// <value> The identifier of the resource image. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid ResourceImageId
    	{ 
    		get { return _resourceImageId; }
    		set
    		{
    			if (_resourceImageId != value )
    			{
    				_resourceImageId = value;
    				OnPropertyChanged(() => ResourceImageId);
    			}
    		}
    	}
        
        /// <summary>   Name of the resource. </summary>
    	private string _resourceName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the resource. </summary>
        ///
        /// <value> The name of the resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string ResourceName
    	{ 
    		get { return _resourceName; }
    		set
    		{
    			if (_resourceName != value )
    			{
    				_resourceName = value;
    				OnPropertyChanged(() => ResourceName);
    			}
    		}
    	}
        
        /// <summary>   The resource number. </summary>
    	private Nullable<int> _resourceNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the resource number. </summary>
        ///
        /// <value> The resource number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<int> ResourceNumber
    	{ 
    		get { return _resourceNumber; }
    		set
    		{
    			if (_resourceNumber != value )
    			{
    				_resourceNumber = value;
    				OnPropertyChanged(() => ResourceNumber);
    			}
    		}
    	}
        
        /// <summary>   Name of the resource class. </summary>
    	private string _resourceClassName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the resource class. </summary>
        ///
        /// <value> The name of the resource class. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string ResourceClassName
    	{ 
    		get { return _resourceClassName; }
    		set
    		{
    			if (_resourceClassName != value )
    			{
    				_resourceClassName = value;
    				OnPropertyChanged(() => ResourceClassName);
    			}
    		}
    	}
        
        /// <summary>   Identifier for the image type. </summary>
    	private Nullable<System.Guid> _imageTypeId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the image type. </summary>
        ///
        /// <value> The identifier of the image type. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> ImageTypeId
    	{ 
    		get { return _imageTypeId; }
    		set
    		{
    			if (_imageTypeId != value )
    			{
    				_imageTypeId = value;
    				OnPropertyChanged(() => ImageTypeId);
    			}
    		}
    	}
        
        /// <summary>   Information describing the image. </summary>
    	private byte[] _imageData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the image. </summary>
        ///
        /// <value> Information describing the image. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public byte[] ImageData
    	{ 
    		get { return _imageData; }
    		set
    		{
    			if (_imageData != value )
    			{
    				_imageData = value;
    				OnPropertyChanged(() => ImageData);
    			}
    		}
    	}
        
        /// <summary>   URI of the image. </summary>
    	private string _imageUri;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URI of the image. </summary>
        ///
        /// <value> The image URI. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string ImageUri
    	{ 
    		get { return _imageUri; }
    		set
    		{
    			if (_imageUri != value )
    			{
    				_imageUri = value;
    				OnPropertyChanged(() => ImageUri);
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
    }
    
}
