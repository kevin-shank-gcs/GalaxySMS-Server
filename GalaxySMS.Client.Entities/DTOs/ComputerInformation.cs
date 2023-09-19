////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\ComputerInformation.cs
//
// summary:	Implements the computer information class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the computer. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ComputerInformation : DtoObjectBase
    {
        /// <summary>   Name of the machine. </summary>
        private string _machineName = string.Empty;
        /// <summary>   Name of the domain. </summary>
        private string _domainName = string.Empty;
        /// <summary>   The IP addresses. </summary>
        private List<string> _ipAddresses = new List<string>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ComputerInformation()
        {
            IPAddresses = new List<string>();
            MachineName = GCS.Framework.Utilities.SystemUtilities.MyMachineName();
            System.Net.IPAddress[] addresses = GCS.Framework.Utilities.SystemUtilities.MyIPAddresses();
            foreach (System.Net.IPAddress address in addresses)
                IPAddresses.Add(address.ToString());
            try
            {
                DomainName = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().Name;
            }
            catch (ActiveDirectoryObjectNotFoundException ex)
            {

                DomainName = string.Empty;
                //DomainName = "GALAXYSYS";
            }
            catch
            {
                DomainName = string.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the machine. </summary>
        ///
        /// <value> The name of the machine. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
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
            set { _domainName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the IP addresses. </summary>
        ///
        /// <value> The IP addresses. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public List<string> IPAddresses
        {
            get { return _ipAddresses; }
            internal set { _ipAddresses = value; }
        }
    }
}
