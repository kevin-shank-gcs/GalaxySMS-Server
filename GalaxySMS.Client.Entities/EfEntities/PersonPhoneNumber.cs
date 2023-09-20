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
	/// <summary>   A person phone number. </summary>
	///
	/// <remarks>   Kevin, 12/26/2018. </remarks>
	////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class PersonPhoneNumber : DbObjectBase, ITableEntityBase
	{    	
		/// <summary>   The person phone number UID. </summary>
		private System.Guid _personPhoneNumberUid;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the person phone number UID. </summary>
		///
		/// <value> The person phone number UID. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public System.Guid PersonPhoneNumberUid
		{ 
			get { return _personPhoneNumberUid; }
			set
			{
				if (_personPhoneNumberUid != value )
				{
					_personPhoneNumberUid = value;
					OnPropertyChanged(() => PersonPhoneNumberUid);
				}
			}
		}
		
		/// <summary>   The person UID. </summary>
		private System.Guid _personUid;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the person UID. </summary>
		///
		/// <value> The person UID. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public System.Guid PersonUid
		{ 
			get { return _personUid; }
			set
			{
				if (_personUid != value )
				{
					_personUid = value;
					OnPropertyChanged(() => PersonUid);
				}
			}
		}
		
		/// <summary>   The cell carrier UID. </summary>
		private Nullable<System.Guid> _cellCarrierUid;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the cell carrier UID. </summary>
		///
		/// <value> The cell carrier UID. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Nullable<System.Guid> CellCarrierUid
		{ 
			get { return _cellCarrierUid; }
			set
			{
				if (_cellCarrierUid != value )
				{
					_cellCarrierUid = value;
					OnPropertyChanged(() => CellCarrierUid);
				}
			}
		}
		
		/// <summary>   The label. </summary>
		private string _label;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the label. </summary>
		///
		/// <value> The label. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string Label
		{ 
			get { return _label; }
			set
			{
				if (_label != value )
				{
					_label = value;
					OnPropertyChanged(() => Label);
				}
			}
		}
		
		/// <summary>   The phone number. </summary>
		private string _phoneNumber;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the phone number. </summary>
		///
		/// <value> The phone number. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string PhoneNumber
		{ 
			get { return _phoneNumber; }
			set
			{
				if (_phoneNumber != value )
				{
					_phoneNumber = value;
					OnPropertyChanged(() => PhoneNumber);
				}
			}
		}


		private bool _smsPermitted;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets a value indicating whether the SMS permitted. </summary>
		///
		/// <value> True if SMS permitted, false if not. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////
		[DataMember]

		public bool SmsPermitted
		{
			get { return _smsPermitted; }
			set
			{
				if (_smsPermitted != value)
				{
					_smsPermitted = value;
					OnPropertyChanged(() => SmsPermitted);
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
	
		
	 //   /// <summary>   The person. </summary>
		//private Person _person;

	 //   ////////////////////////////////////////////////////////////////////////////////////////////////////
	 //   /// <summary>   Gets or sets the person. </summary>
	 //   ///
	 //   /// <value> The person. </value>
	 //   ////////////////////////////////////////////////////////////////////////////////////////////////////

		//[DataMember]
		//public virtual Person Person
		//{ 
		//	get { return _person; }
		//	set
		//	{
		//		if (_person != value )
		//		{
		//			_person = value;
		//			OnPropertyChanged(() => Person);
		//		}
		//	}
		//}
	}
	
}
