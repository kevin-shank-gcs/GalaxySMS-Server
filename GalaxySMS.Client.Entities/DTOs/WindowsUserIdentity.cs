////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\WindowsUserIdentity.cs
//
// summary:	Implements the windows user identity class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The windows user identity. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class WindowsUserIdentity : DtoObjectBase
    {

        /// <summary>   The name. </summary>
        private string _name;
        /// <summary>   Type of the authentication. </summary>
        private string _authenticationType;
        /// <summary>   True if this WindowsUserIdentity is authenticated. </summary>
        private bool _isAuthenticated;
        /// <summary>   Name of the domain. </summary>
        private string _domainName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public WindowsUserIdentity()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            if (current != null)
            {
                Name = current.Name;
                AuthenticationType = current.AuthenticationType;
                IsAuthenticated = current.IsAuthenticated;
                try
                {
                    //MessageBox.Show("About to call  DomainName = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().Name");
                    DomainName = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().Name;
                    //MessageBox.Show($"Domain.GetCurrentDomain().Name = {DomainName}");
                }
                catch (ActiveDirectoryObjectNotFoundException e)
                {
                    DomainName = string.Empty;
                    //DomainName = "GALAXYSYS";
                }
                catch (ActiveDirectoryOperationException e)
                {
                    DomainName = string.Empty;
                    //DomainName = "GALAXYSYS";
                }
                catch (Exception ex)
                {
                    DomainName = string.Empty;
                    //MessageBox.Show(ex.ToString());
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Name
        {
            get { return _name; }
            internal set { _name = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the authentication. </summary>
        ///
        /// <value> The type of the authentication. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string AuthenticationType
        {
            get { return _authenticationType; }
            internal set { _authenticationType = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this WindowsUserIdentity is authenticated.
        /// </summary>
        ///
        /// <value> True if this WindowsUserIdentity is authenticated, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            internal set { _isAuthenticated = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the domain. </summary>
        ///
        /// <value> The name of the domain. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string DomainName
        {
            get { return _domainName; }
            internal set { _domainName = value; }
        }

    }
}
