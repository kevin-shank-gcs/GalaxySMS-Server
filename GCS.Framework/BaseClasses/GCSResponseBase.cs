using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GCS.Framework.BaseClasses
{
	[DataContract]
	public class GCSResponseBase : GCSEntityBase
	{
		// Summary:
		//     Default constructor for the GCSServiceResponseBase class
		public GCSResponseBase():base()
		{
		}

		// Summary:
		//     The actual .NET error message returned from the last service operation
		[DataMember]
		public string ErrorMessage { get; set; }
		//
		// Summary:
		//     The full .ToString() of the .NET error message
		[DataMember]
		public string ErrorMessageExtended { get; set; }
		//
		// Summary:
		//     Get/Set the Friendly Error Message to show to the user
		[DataMember]
		public string FriendlyErrorMessage { get; set; }
		//
		// Summary:
		//     Get/Set the Status of the last operation
		[DataMember]
		public GCSSuccessFailureStatus SuccessOrFailureStatus { get; set; }

		[DataMember]
		public Exception Exception { get; set; }
	}
}
