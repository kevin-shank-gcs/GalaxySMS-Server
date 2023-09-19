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
	public partial class gcsReferenceTable : DbObjectBase, ITableEntityBase
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
        public partial class gcsReferenceTable
        {
        	public gcsReferenceTable() : base()
        	{
        		Initialize();
        	}
        
        	public gcsReferenceTable(gcsReferenceTable e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(gcsReferenceTable e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.ReferenceTableId = e.ReferenceTableId;
        		this.ApplicationId = e.ApplicationId;
        		this.LanguageId = e.LanguageId;
        		this.TableName = e.TableName;
        		this.TableDisplayName = e.TableDisplayName;
        		this.TableDisplayNameResourceKey = e.TableDisplayNameResourceKey;
        		this.PrimaryKeyColumnName = e.PrimaryKeyColumnName;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public gcsReferenceTable Clone(gcsReferenceTable e)
        	{
        		return new gcsReferenceTable(e);
        	}
        
        	public bool Equals(gcsReferenceTable other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsReferenceTable other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.ReferenceTableId != this.ReferenceTableId )
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
    
    	
    	private System.Guid _referenceTableId;
    
    	[DataMember]
    	public System.Guid ReferenceTableId
    	{ 
    		get { return _referenceTableId; }
    		set
    		{
    			if (_referenceTableId != value )
    			{
    				_referenceTableId = value;
    				OnPropertyChanged(() => ReferenceTableId);
    			}
    		}
    	}
    	
    	private System.Guid _applicationId;
    
    	[DataMember]
    	public System.Guid ApplicationId
    	{ 
    		get { return _applicationId; }
    		set
    		{
    			if (_applicationId != value )
    			{
    				_applicationId = value;
    				OnPropertyChanged(() => ApplicationId);
    			}
    		}
    	}
    	
    	private System.Guid _languageId;
    
    	[DataMember]
    	public System.Guid LanguageId
    	{ 
    		get { return _languageId; }
    		set
    		{
    			if (_languageId != value )
    			{
    				_languageId = value;
    				OnPropertyChanged(() => LanguageId);
    			}
    		}
    	}
    	
    	private string _tableName;
    
    	[DataMember]
    	public string TableName
    	{ 
    		get { return _tableName; }
    		set
    		{
    			if (_tableName != value )
    			{
    				_tableName = value;
    				OnPropertyChanged(() => TableName);
    			}
    		}
    	}
    	
    	private string _tableDisplayName;
    
    	[DataMember]
    	public string TableDisplayName
    	{ 
    		get { return _tableDisplayName; }
    		set
    		{
    			if (_tableDisplayName != value )
    			{
    				_tableDisplayName = value;
    				OnPropertyChanged(() => TableDisplayName);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _tableDisplayNameResourceKey;
    
    	[DataMember]
    	public Nullable<System.Guid> TableDisplayNameResourceKey
    	{ 
    		get { return _tableDisplayNameResourceKey; }
    		set
    		{
    			if (_tableDisplayNameResourceKey != value )
    			{
    				_tableDisplayNameResourceKey = value;
    				OnPropertyChanged(() => TableDisplayNameResourceKey);
    			}
    		}
    	}
    	
    	private string _primaryKeyColumnName;
    
    	[DataMember]
    	public string PrimaryKeyColumnName
    	{ 
    		get { return _primaryKeyColumnName; }
    		set
    		{
    			if (_primaryKeyColumnName != value )
    			{
    				_primaryKeyColumnName = value;
    				OnPropertyChanged(() => PrimaryKeyColumnName);
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
    			if (_isActive != value )
    			{
    				_isActive = value;
    				OnPropertyChanged(() => IsActive);
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
    	
    	private Nullable<System.DateTime> _insertDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> InsertDate
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
    }
    
}
