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
	public partial class GalaxyFlashImage : DbObjectBase, ITableEntityBase
    {
    	
    	private System.Guid _galaxyFlashImageUid;
    
    	[DataMember]
    	public System.Guid GalaxyFlashImageUid
    	{ 
    		get { return _galaxyFlashImageUid; }
    		set
    		{
    			if (_galaxyFlashImageUid != value )
    			{
    				_galaxyFlashImageUid = value;
    				OnPropertyChanged(() => GalaxyFlashImageUid);
    			}
    		}
    	}
    	
    	private System.Guid _galaxyCpuModelUid;
    
    	[DataMember]
    	public System.Guid GalaxyCpuModelUid
    	{ 
    		get { return _galaxyCpuModelUid; }
    		set
    		{
    			if (_galaxyCpuModelUid != value )
    			{
    				_galaxyCpuModelUid = value;
    				OnPropertyChanged(() => GalaxyCpuModelUid);
    			}
    		}
    	}
    	
    	private string _package;
    
    	[DataMember]
    	public string Package
    	{ 
    		get { return _package; }
    		set
    		{
    			if (_package != value )
    			{
    				_package = value;
    				OnPropertyChanged(() => Package);
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
    			if (_description != value )
    			{
    				_description = value;
    				OnPropertyChanged(() => Description);
    			}
    		}
    	}
    	
    	private string _importedFilename;
    
    	[DataMember]
    	public string ImportedFilename
    	{ 
    		get { return _importedFilename; }
    		set
    		{
    			if (_importedFilename != value )
    			{
    				_importedFilename = value;
    				OnPropertyChanged(() => ImportedFilename);
    			}
    		}
    	}
    	
    	private System.DateTimeOffset _fileDateTime;
    
    	[DataMember]
    	public System.DateTimeOffset FileDateTime
    	{ 
    		get { return _fileDateTime; }
    		set
    		{
    			if (_fileDateTime != value )
    			{
    				_fileDateTime = value;
    				OnPropertyChanged(() => FileDateTime);
    			}
    		}
    	}
    	
    	private string _checksum;
    
    	[DataMember]
    	public string Checksum
    	{ 
    		get { return _checksum; }
    		set
    		{
    			if (_checksum != value )
    			{
    				_checksum = value;
    				OnPropertyChanged(() => Checksum);
    			}
    		}
    	}
    	
    	private string _version;
    
    	[DataMember]
    	public string Version
    	{ 
    		get { return _version; }
    		set
    		{
    			if (_version != value )
    			{
    				_version = value;
    				OnPropertyChanged(() => Version);
    			}
    		}
    	}
    	
    	private string _dataFormat;
    
    	[DataMember]
    	public string DataFormat
    	{ 
    		get { return _dataFormat; }
    		set
    		{
    			if (_dataFormat != value )
    			{
    				_dataFormat = value;
    				OnPropertyChanged(() => DataFormat);
    			}
    		}
    	}
    	
    	private byte[] _data;
    
    	[DataMember]
    	public byte[] Data
    	{ 
    		get { return _data; }
    		set
    		{
    			if (_data != value )
    			{
    				_data = value;
    				OnPropertyChanged(() => Data);
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
    
    	
    	private GalaxyCpuModel _galaxyCpuModel;
    
    	[DataMember]
    	public virtual GalaxyCpuModel GalaxyCpuModel
    	{ 
    		get { return _galaxyCpuModel; }
    		set
    		{
    			if (_galaxyCpuModel != value )
    			{
    				_galaxyCpuModel = value;
    				OnPropertyChanged(() => GalaxyCpuModel);
    			}
    		}
    	}
    }
    
}
