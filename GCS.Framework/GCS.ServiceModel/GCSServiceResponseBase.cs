using System;
using System.Runtime.Serialization;

namespace GCS.ServiceModel
{

		 [DataContract]
		 public class GCSServiceResponseBase
		 {
			 // Summary:
			 //     Default constructor for the GCSServiceResponseBase class
             public GCSServiceResponseBase() { }

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
			 //     The number of rows affected by the last service operation
			 [DataMember]
			 public long RowsAffected { get; set; }
			 //
			 // Summary:
			 //     Get/Set the Status of the last operation
			 [DataMember]
			 public GCSServiceStatus Status { get; set; }
			 //
			 // Summary:
			 //     The number of pages for this record set
			 [DataMember]
			 public int TotalPages { get; set; }
		 }
}
