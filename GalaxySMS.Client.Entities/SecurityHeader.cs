////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	SecurityHeader.cs
//
// summary:	Implements the security header class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A security header. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SecurityHeader : ObjectBase
    {
        /// <summary>   Unique identifier for the galaxy user session. </summary>
        Guid _galaxyUserSessionGuid;
        /// <summary>   The current windows user name. </summary>
        private string _currentWindowsUserName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the galaxy user session. </summary>
        ///
        /// <value> Unique identifier of the galaxy user session. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid GalaxyUserSessionGuid
        {
            get { return _galaxyUserSessionGuid; }
            set
            {
                if (_galaxyUserSessionGuid != value)
                {
                    _galaxyUserSessionGuid = value;
                    OnPropertyChanged(() => GalaxyUserSessionGuid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current windows user name. </summary>
        ///
        /// <value> The name of the current windows user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CurrentWindowsUserName
        {
            get { return _currentWindowsUserName; }
            set
            {
                if (_currentWindowsUserName != value)
                {
                    _currentWindowsUserName = value;
                    OnPropertyChanged(() => CurrentWindowsUserName);
                }
            }
        }

    }

}
