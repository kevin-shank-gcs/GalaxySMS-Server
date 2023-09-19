using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
	public partial class gcsApplicationBasic// : DbObjectBase
    {
        
    	
        /// <summary>   Identifier for the application. </summary>
    	private System.Guid _applicationId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the application. </summary>
        ///
        /// <value> The identifier of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid ApplicationId
    	{ 
    		get { return _applicationId; }
    		set
    		{
    			if (_applicationId != value )
    			{
    				_applicationId = value;
    				//OnPropertyChanged(() => ApplicationId);
    			}
    		}
    	}
    	
     //   /// <summary>   Identifier for the language. </summary>
    	//private Nullable<System.Guid> _languageId;

     //   ////////////////////////////////////////////////////////////////////////////////////////////////////
     //   /// <summary>   Gets or sets the identifier of the language. </summary>
     //   ///
     //   /// <value> The identifier of the language. </value>
     //   ////////////////////////////////////////////////////////////////////////////////////////////////////

    	//[DataMember]
    	//public Nullable<System.Guid> LanguageId
    	//{ 
    	//	get { return _languageId; }
    	//	set
    	//	{
    	//		if (_languageId != value )
    	//		{
    	//			_languageId = value;
    	//			//OnPropertyChanged(() => LanguageId);
    	//		}
    	//	}
    	//}
    	
     //   /// <summary>   Identifier for the system role. </summary>
    	//private Nullable<System.Guid> _systemRoleId;

     //   ////////////////////////////////////////////////////////////////////////////////////////////////////
     //   /// <summary>   Gets or sets the identifier of the system role. </summary>
     //   ///
     //   /// <value> The identifier of the system role. </value>
     //   ////////////////////////////////////////////////////////////////////////////////////////////////////

    	//[DataMember]
    	//public Nullable<System.Guid> SystemRoleId
    	//{ 
    	//	get { return _systemRoleId; }
    	//	set
    	//	{
    	//		if (_systemRoleId != value )
    	//		{
    	//			_systemRoleId = value;
    	//			//OnPropertyChanged(() => SystemRoleId);
    	//		}
    	//	}
    	//}
    	
        /// <summary>   Name of the application. </summary>
    	private string _applicationName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the application. </summary>
        ///
        /// <value> The name of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string ApplicationName
    	{ 
    		get { return _applicationName; }
    		set
    		{
    			if (_applicationName != value )
    			{
    				_applicationName = value;
    				//OnPropertyChanged(() => ApplicationName);
    			}
    		}
    	}
    	
        /// <summary>   Information describing the application. </summary>
    	private string _applicationDescription;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the application. </summary>
        ///
        /// <value> Information describing the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string ApplicationDescription
    	{ 
    		get { return _applicationDescription; }
    		set
    		{
    			if (_applicationDescription != value )
    			{
    				_applicationDescription = value;
    				//OnPropertyChanged(() => ApplicationDescription);
    			}
    		}
    	}
    	
 	
    	private ICollection<gcsApplicationRoleBasic> _roles;


    	[DataMember]
    	public virtual ICollection<gcsApplicationRoleBasic> Roles
    	{ 
    		get { return _roles; }
    		set
    		{
    			if (_roles != value )
    			{
    				_roles = value;
    				//OnPropertyChanged(() => gcsPermissionCategories);
    			}
    		}
    	}
    }
    
}
