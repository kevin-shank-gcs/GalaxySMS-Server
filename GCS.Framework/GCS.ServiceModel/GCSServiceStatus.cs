using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.ServiceModel
{
	// Summary:
	//     Enumeration for what happened when calling a Service
	public enum GCSServiceStatus
	{
		// Summary:
		//     Default value for Service Status
		Unknown = 0,
		//
		// Summary:
		//     Service Succeeded
		Success = 1,
		//
		// Summary:
		//     An exception occurred calling the service
		Exception = 2,
		//
		// Summary:
		//     No records were returned or affected by the last call
		NoRecords = 3,
		//
		// Summary:
		//     No more pages were found
		NoMorePages = 4,
		//
		// Summary:
		//     The primary key you were searching for was not found
		PrimaryKeyNotFound = 5,
		//
		// Summary:
		//     A business rule validation failed
		ValidationFailed = 6,
		//
		// Summary:
		//     The user is not authenticated
		NotAuthenticated = 7,
	}
}
