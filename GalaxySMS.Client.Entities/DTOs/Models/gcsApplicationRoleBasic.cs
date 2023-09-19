using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
	public partial class gcsApplicationRoleBasic
    {
    
        /// <summary>   Identifier for the role. </summary>
    	private System.Guid _roleId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the role. </summary>
        ///
        /// <value> The identifier of the role. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid RoleId
    	{ 
    		get { return _roleId; }
    		set
    		{
    			if (_roleId != value )
    			{
    				_roleId = value;
    				////OnPropertyChanged(() => RoleId);
    			}
    		}
    	}
    	
     //   /// <summary>   Identifier for the application. </summary>
    	//private System.Guid _applicationId;

     //   ////////////////////////////////////////////////////////////////////////////////////////////////////
     //   /// <summary>   Gets or sets the identifier of the application. </summary>
     //   ///
     //   /// <value> The identifier of the application. </value>
     //   ////////////////////////////////////////////////////////////////////////////////////////////////////

    	//[DataMember]
    	//public System.Guid ApplicationId
    	//{ 
    	//	get { return _applicationId; }
    	//	set
    	//	{
    	//		if (_applicationId != value )
    	//		{
    	//			_applicationId = value;
    	//			//OnPropertyChanged(() => ApplicationId);
    	//		}
    	//	}
    	//}
    	
        /// <summary>   Name of the role. </summary>
    	private string _roleName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the role. </summary>
        ///
        /// <value> The name of the role. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string RoleName
    	{ 
    		get { return _roleName; }
    		set
    		{
    			if (_roleName != value )
    			{
    				_roleName = value;
    				//OnPropertyChanged(() => RoleName);
    			}
    		}
    	}
    	
        /// <summary>   Information describing the role. </summary>
    	private string _roleDescription;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the role. </summary>
        ///
        /// <value> Information describing the role. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string RoleDescription
    	{ 
    		get { return _roleDescription; }
    		set
    		{
    			if (_roleDescription != value )
    			{
    				_roleDescription = value;
    				//OnPropertyChanged(() => RoleDescription);
    			}
    		}
    	}
    	
        /// <summary>   True if this gcsRole is active. </summary>
    	private bool _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsRole is active. </summary>
        ///
        /// <value> True if this gcsRole is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool IsActive
    	{ 
    		get { return _isActive; }
    		set
    		{
    			if (_isActive != value )
    			{
    				_isActive = value;
    				//OnPropertyChanged(() => IsActive);
    			}
    		}
    	}
    	
        /// <summary>   True if this gcsRole is template role. </summary>
    	private bool _isDefault;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsRole is template role. </summary>
        ///
        /// <value> True if this gcsRole is template role, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool IsDefault
        { 
    		get { return _isDefault; }
    		set
    		{
    			if (_isDefault != value )
    			{
    				_isDefault = value;
    				//OnPropertyChanged(() => IsTemplateRole);
    			}
    		}
    	}
     	
        /// <summary>   True if this gcsRole is administrator role. </summary>
        private bool _isAdministratorRole;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this gcsRole is administrator role.
        /// </summary>
        ///
        /// <value> True if this gcsRole is administrator role, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsAdministratorRole
        { 
            get { return _isAdministratorRole; }
            set
            {
                if (_isAdministratorRole != value )
                {
                    _isAdministratorRole = value;
                    //OnPropertyChanged(() => IsAdministratorRole);
                }
            }
        }
    }
    
}
