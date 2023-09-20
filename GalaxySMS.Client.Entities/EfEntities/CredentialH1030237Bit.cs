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
	
	[DataContract]
	public partial class CredentialH1030237Bit : DbObjectBase, ITableEntityBase
	{
		
		private System.Guid _credentialUid;
	
		[DataMember]
		public System.Guid CredentialUid
		{ 
			get { return _credentialUid; }
			set
			{
				if (_credentialUid != value )
				{
					_credentialUid = value;
					OnPropertyChanged(() => CredentialUid);
				}
			}
		}
		
		private long _iDCode;
	
		[DataMember]
		public long IdCode
		{ 
			get { return _iDCode; }
			set
			{
				if (_iDCode != value )
				{
					_iDCode = value;
					OnPropertyChanged(() => IdCode);
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
	
		
		private Credential _credential;
	
		[DataMember]
		public virtual Credential Credential
		{ 
			get { return _credential; }
			set
			{
				if (_credential != value )
				{
					_credential = value;
					OnPropertyChanged(() => Credential);
				}
			}
		}
	}
	
}
