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
	public partial class MercScpGroup : DbObjectBase, IHasEntityMappingList, ITableEntityBase
    {
    	private System.Guid _mercScpGroupUid;
    
    	[DataMember]
    	public System.Guid MercScpGroupUid
    	{ 
    		get { return _mercScpGroupUid; }
    		set
    		{
    			if (_mercScpGroupUid != value )
    			{
    				_mercScpGroupUid = value;
    				OnPropertyChanged(() => MercScpGroupUid);
    			}
    		}
    	}
    	
    	private System.Guid _entityId;
    
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
    	
    	private string _name;
    
    	[DataMember]
    	public string Name
    	{ 
    		get { return _name; }
    		set
    		{
    			if (_name != value )
    			{
    				_name = value;
    				OnPropertyChanged(() => Name);
    			}
    		}
    	}

        private string _description;

        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        private bool _isActive;

        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged(() => IsActive);
                }
            }
        }


        private int _numberOfTransactions;
    
    	[DataMember]
    	public int NumberOfTransactions
    	{ 
    		get { return _numberOfTransactions; }
    		set
    		{
    			if (_numberOfTransactions != value )
    			{
    				_numberOfTransactions = value;
    				OnPropertyChanged(() => NumberOfTransactions);
    			}
    		}
    	}
    	
    	private short _numberOfOperatingModes;
    
    	[DataMember]
    	public short NumberOfOperatingModes
    	{ 
    		get { return _numberOfOperatingModes; }
    		set
    		{
    			if (_numberOfOperatingModes != value )
    			{
    				_numberOfOperatingModes = value;
    				OnPropertyChanged(() => NumberOfOperatingModes);
    			}
    		}
    	}
    	
    	private short _operatingModeType;
    
    	[DataMember]
    	public short OperatingModeType
    	{ 
    		get { return _operatingModeType; }
    		set
    		{
    			if (_operatingModeType != value )
    			{
    				_operatingModeType = value;
    				OnPropertyChanged(() => OperatingModeType);
    			}
    		}
    	}
    	
    	private bool _allowConnection;
    
    	[DataMember]
    	public bool AllowConnection
    	{ 
    		get { return _allowConnection; }
    		set
    		{
    			if (_allowConnection != value )
    			{
    				_allowConnection = value;
    				OnPropertyChanged(() => AllowConnection);
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
    	
    	private System.DateTimeOffset _insertDate;
    
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
    	
    	private Nullable<System.DateTimeOffset> _updateDate;
    
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
    
    	
    	//private gcsEntity _gcsEntity;
    
    	//[DataMember]
    	//public virtual gcsEntity gcsEntity
    	//{ 
    	//	get { return _gcsEntity; }
    	//	set
    	//	{
    	//		if (_gcsEntity != value )
    	//		{
    	//			_gcsEntity = value;
    	//			OnPropertyChanged(() => gcsEntity);
    	//		}
    	//	}
    	//}
    	
    	//private ICollection<MercScp> _mercScps;
    
    	//[DataMember]
    	//public virtual ICollection<MercScp> MercScps
    	//{ 
    	//	get { return _mercScps; }
    	//	set
    	//	{
    	//		if (_mercScps != value )
    	//		{
    	//			_mercScps = value;
    	//			OnPropertyChanged(() => MercScps);
    	//		}
    	//	}
    	//}
    	
    	//private Site _site;
    
    	//[DataMember]
    	//public virtual Site Site
    	//{ 
    	//	get { return _site; }
    	//	set
    	//	{
    	//		if (_site != value )
    	//		{
    	//			_site = value;
    	//			OnPropertyChanged(() => Site);
    	//		}
    	//	}
    	//}


        /// <summary>   List of identifiers for the entities. </summary>
        private ICollection<Guid> _entityIds;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the entities. </summary>
        ///
        /// <value> A list of identifiers of the entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ICollection<Guid> EntityIds
        {
            get { return _entityIds; }
            set
            {
                if (_entityIds != value)
                {
                    _entityIds = value;
                    OnPropertyChanged(() => EntityIds);
                }
            }
        }


        /// <summary>   List of identifiers for the roles that can access this cluster. </summary>
        private ICollection<Guid> _roleIds;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the roles that have access to this item. </summary>
        ///
        /// <value> A list of identifiers of the roles. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ICollection<Guid> RoleIds
        {
            get { return _roleIds; }
            set
            {
                if (_roleIds != value)
                {
                    _roleIds = value;
                    OnPropertyChanged(() => RoleIds);
                }
            }
        }

        /// <summary>   The mapped entities permission levels. </summary>
        private ICollection<EntityIdEntityMapPermissionLevel> _MappedEntitiesPermissionLevels;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the mapped entities permission levels. </summary>
        ///
        /// <value> The mapped entities permission levels. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels
        {
            get { return _MappedEntitiesPermissionLevels; }
            set
            {
                if (_MappedEntitiesPermissionLevels != value)
                {
                    _MappedEntitiesPermissionLevels = value;
                    OnPropertyChanged(() => MappedEntitiesPermissionLevels);
                }
            }
        }

    }

}
