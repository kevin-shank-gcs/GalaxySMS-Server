using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.BaseClasses
{
	[DataContract]
	public class GCSEntityBase : INotifyPropertyChanged, IExtensibleDataObject
	{
		#region Private Variables
		private string _ClassName = string.Empty;
		private string _DefaultLanguage = "en-US";
		private string _InsertName = string.Empty;
		private DateTimeOffset _InsertDate = DateTimeOffset.Now;
		private string _UpdateName = string.Empty;
		private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
		private short _ConcurrencyValue = 0;
		ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }
		#endregion

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Default constructor. </summary>
		///
		/// <remarks>	Kevin, 10/11/2013. </remarks>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public GCSEntityBase()
		{ }

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Copy constructor. </summary>
		///
		/// <remarks>	Kevin, 10/11/2013. </remarks>
		///
		/// <param name="o">	The GCSEntityBase to process. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public GCSEntityBase(GCSEntityBase o)
		{
			ClassName = o.ClassName;
			DefaultLanguage = o.DefaultLanguage;
			InsertName = o.InsertName;
			InsertDate = o.InsertDate;
			UpdateName = o.UpdateName;
			UpdateDate = o.UpdateDate;
			ConcurrencyValue = o.ConcurrencyValue;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Returns a string that represents the current object. </summary>
		///
		/// <remarks>	Kevin, 10/11/2013. </remarks>
		///
		/// <returns>	A string that represents the current object. </returns>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public override string ToString()
		{
			return ClassName;
		}
		
		#region INotifyPropertyChanged Members

		 public event PropertyChangedEventHandler PropertyChanged;
		 #endregion

		 ////////////////////////////////////////////////////////////////////////////////////////////////////
		 /// <summary>	Raises the property changed event. </summary>
		 ///
		 /// <remarks>	Kevin, 10/11/2013. </remarks>
		 ///
		 /// <param name="propertyName">	Name of the property. </param>
		 ////////////////////////////////////////////////////////////////////////////////////////////////////

		 protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

		 ////////////////////////////////////////////////////////////////////////////////////////////////////
		 /// <summary>	Query if 'originalValue' has value changed. </summary>
		 ///
		 /// <remarks>	Kevin, 10/11/2013. </remarks>
		 ///
		 /// <param name="originalValue">	The original value. </param>
		 /// <param name="newValue">			The new value. </param>
		 ///
		 /// <returns>	true if value changed, false if not. </returns>
		 ////////////////////////////////////////////////////////////////////////////////////////////////////

		 public bool HasValueChanged(object originalValue, object newValue)
		 {
			 if (originalValue != newValue)
				 return true;
			 return false;
		 }

		 ////////////////////////////////////////////////////////////////////////////////////////////////////
		 /// <summary>	Query if 'originalValue' has value changed. </summary>
		 ///
		 /// <remarks>	Kevin, 10/11/2013. </remarks>
		 ///
		 /// <param name="originalValue">	The original value. </param>
		 /// <param name="newValue">			The new value. </param>
		 /// <param name="propertyName"> 	Name of the property. </param>
		 ///
		 /// <returns>	true if value changed, false if not. </returns>
		 ////////////////////////////////////////////////////////////////////////////////////////////////////

		 public bool HasValueChanged(object originalValue, object newValue, string propertyName)
		 {
			 if (originalValue != newValue)
				 return true;
			 return false;
		 }
		#region Public properties

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Gets or sets the name of the class. </summary>
		///
		/// <value>	The name of the class. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		 [DataMember]
		 public string ClassName
		 {
			 get { return _ClassName; }
			 set
			 {
				 if (HasValueChanged(_ClassName, value, "ClassName"))
				 {
					 _ClassName = value;
					 RaisePropertyChanged("ClassName");
				 }
			 }
		 }

		 ////////////////////////////////////////////////////////////////////////////////////////////////////
		 /// <summary>	Gets or sets the default language. </summary>
		 ///
		 /// <value>	The default language. </value>
		 ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string DefaultLanguage
		 {
			 get { return _DefaultLanguage; }
			 set
			 {
				 if (HasValueChanged(_DefaultLanguage, value, "DefaultLanguage"))
				 {
					 _DefaultLanguage = value;
					 RaisePropertyChanged("DefaultLanguage");
				 }
			 }
		 }

		/// <summary>
		 /// Get/Set the Insert Name value
		 /// </summary>
		 [DataMember]
		 public string InsertName
		 {
			 get { return _InsertName; }
			 set
			 {
				 if (HasValueChanged(_InsertName, value, "InsertName"))
				 {
					 _InsertName = value;
					 RaisePropertyChanged("InsertName");
				 }
			 }
		 }

		 /// <summary>
		 /// Get/Set the Insert Date value
		 /// </summary>
		 [DataMember]
		 public DateTimeOffset InsertDate
		 {
			 get { return _InsertDate; }
			 set
			 {
				 if (HasValueChanged(_InsertDate, value, "InsertDate"))
				 {
					 _InsertDate = value;
					 RaisePropertyChanged("InsertDate");
				 }
			 }
		 }

		 /// <summary>
		 /// Get/Set the Update Name value
		 /// </summary>
		 [DataMember]
		 public string UpdateName
		 {
			 get { return _UpdateName; }
			 set
			 {
				 if (HasValueChanged(_UpdateName, value, "UpdateName"))
				 {
					 _UpdateName = value;
					 RaisePropertyChanged("UpdateName");
				 }
			 }
		 }

		 /// <summary>
		 /// Get/Set the Update Date value
		 /// </summary>
		 [DataMember]
		 public DateTimeOffset UpdateDate
		 {
			 get { return _UpdateDate; }
			 set
			 {
				 if (HasValueChanged(_UpdateDate, value, "UpdateDate"))
				 {
					 _UpdateDate = value;
					 RaisePropertyChanged("UpdateDate");
				 }
			 }
		 }

		 /// <summary>
		 /// Get/Set the Concurrency Value value
		 /// </summary>
		 [DataMember]
		 public short ConcurrencyValue
		 {
			 get { return _ConcurrencyValue; }
			 set
			 {
				 if (HasValueChanged(_ConcurrencyValue, value, "ConcurrencyValue"))
				 {
					 _ConcurrencyValue = value;
					 RaisePropertyChanged("ConcurrencyValue");
				 }
			 }
		 }

		#endregion
	}
}
