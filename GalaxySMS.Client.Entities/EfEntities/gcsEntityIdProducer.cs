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
	using GCS.Core.Common.Contracts;	
    using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs entity identifier producer. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class gcsEntityIdProducer : DbObjectBase, ITableEntityBase
    {
        /// <summary>   Identifier for the entity. </summary>
    	private System.Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid EntityId
    	{ 
    		get { return _entityId; }
    		set
    		{
    			if (_entityId != value )
    			{
    				_entityId = value;
    				OnPropertyChanged(() => EntityId);
    			}
    		}
    	}
    	
        /// <summary>   _URL of the document. </summary>
    	private string _url;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URL of the document. </summary>
        ///
        /// <value> The URL. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Url
    	{ 
    		get { return _url; }
    		set
    		{
    			if (_url != value )
    			{
    				_url = value;
    				OnPropertyChanged(() => Url);
    			}
    		}
    	}
    	
        /// <summary>   URL of the development. </summary>
    	private string _devUrl;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URL of the development. </summary>
        ///
        /// <value> The development URL. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string DevUrl
    	{ 
    		get { return _devUrl; }
    		set
    		{
    			if (_devUrl != value )
    			{
    				_devUrl = value;
    				OnPropertyChanged(() => DevUrl);
    			}
    		}
    	}
    	
        /// <summary>   URL of the web client. </summary>
    	private string _webClientUrl;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URL of the web client. </summary>
        ///
        /// <value> The web client URL. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string WebClientUrl
    	{ 
    		get { return _webClientUrl; }
    		set
    		{
    			if (_webClientUrl != value )
    			{
    				_webClientUrl = value;
    				OnPropertyChanged(() => WebClientUrl);
    			}
    		}
    	}


        private string _signalRUrl;

        [DataMember]
        public string SignalRUrl
        {
            get { return _signalRUrl; }
            set
            {
                if (_signalRUrl != value)
                {
                    _signalRUrl = value;
                    OnPropertyChanged(() => SignalRUrl);
                }
            }
        }

        /// <summary>   Identifier for the subscription. </summary>
        private int _subscriptionId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the subscription. </summary>
        ///
        /// <value> The identifier of the subscription. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int SubscriptionId
    	{ 
    		get { return _subscriptionId; }
    		set
    		{
    			if (_subscriptionId != value )
    			{
    				_subscriptionId = value;
    				OnPropertyChanged(() => SubscriptionId);
    			}
    		}
    	}
    	
        /// <summary>   Name of the identifier producer user. </summary>
    	private string _idProducerUserName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the identifier producer user. </summary>
        ///
        /// <value> The name of the identifier producer user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string idProducerUserName
    	{ 
    		get { return _idProducerUserName; }
    		set
    		{
    			if (_idProducerUserName != value )
    			{
    				_idProducerUserName = value;
    				OnPropertyChanged(() => idProducerUserName);
    			}
    		}
    	}
    	
        /// <summary>   The identifier producer password. </summary>
    	private string _idProducerPassword;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier producer password. </summary>
        ///
        /// <value> The identifier producer password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string idProducerPassword
    	{ 
    		get { return _idProducerPassword; }
    		set
    		{
    			if (_idProducerPassword != value )
    			{
    				_idProducerPassword = value;
    				OnPropertyChanged(() => idProducerPassword);
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
