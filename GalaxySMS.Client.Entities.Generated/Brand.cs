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
	public partial class Brand : DbObjectBase, ITableEntityBase
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
        public partial class Brand
        {
        	public Brand() : base()
        	{
        		Initialize();
        	}
        
        	public Brand(Brand e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(Brand e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.BrandUid = e.BrandUid;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.BrandName = e.BrandName;
        		this.CompanyName = e.CompanyName;
        		this.Category = e.Category;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public Brand Clone(Brand e)
        	{
        		return new Brand(e);
        	}
        
        	public bool Equals(Brand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(Brand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.BrandUid != this.BrandUid )
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
    
    	
    	private System.Guid _brandUid;
    
    	[DataMember]
    	public System.Guid BrandUid
    	{ 
    		get { return _brandUid; }
    		set
    		{
    			if (_brandUid != value )
    			{
    				_brandUid = value;
    				OnPropertyChanged(() => BrandUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _binaryResourceUid;
    
    	[DataMember]
    	public Nullable<System.Guid> BinaryResourceUid
    	{ 
    		get { return _binaryResourceUid; }
    		set
    		{
    			if (_binaryResourceUid != value )
    			{
    				_binaryResourceUid = value;
    				OnPropertyChanged(() => BinaryResourceUid);
    			}
    		}
    	}
    	
    	private string _brandName;
    
    	[DataMember]
    	public string BrandName
    	{ 
    		get { return _brandName; }
    		set
    		{
    			if (_brandName != value )
    			{
    				_brandName = value;
    				OnPropertyChanged(() => BrandName);
    			}
    		}
    	}
    	
    	private string _companyName;
    
    	[DataMember]
    	public string CompanyName
    	{ 
    		get { return _companyName; }
    		set
    		{
    			if (_companyName != value )
    			{
    				_companyName = value;
    				OnPropertyChanged(() => CompanyName);
    			}
    		}
    	}
    	
    	private string _category;
    
    	[DataMember]
    	public string Category
    	{ 
    		get { return _category; }
    		set
    		{
    			if (_category != value )
    			{
    				_category = value;
    				OnPropertyChanged(() => Category);
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
    
    	
    	private gcsBinaryResource _gcsBinaryResource;
    
    	[DataMember]
    	public virtual gcsBinaryResource gcsBinaryResource
    	{ 
    		get { return _gcsBinaryResource; }
    		set
    		{
    			if (_gcsBinaryResource != value )
    			{
    				_gcsBinaryResource = value;
    				OnPropertyChanged(() => gcsBinaryResource);
    			}
    		}
    	}
    }
    
}
