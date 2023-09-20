////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyCpuDatabaseInformation.cs
//
// summary:	Implements the galaxy CPU database information class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about a Galaxy CPU. </summary>
    ///
    /// <remarks>   Kevin, 9/4/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyCpuDatabaseInformation
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuDatabaseInformation()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyCpuDatabaseInformation to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuDatabaseInformation(GalaxyCpuDatabaseInformation e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyCpuDatabaseInformation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            AlertEventAcknowledgeData = new List<GalaxyPanel_GetAlertEventAcknowledgeData>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyCpuDatabaseInformation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyCpuDatabaseInformation to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(GalaxyCpuDatabaseInformation e)
        {
            Initialize();
            if (e == null)
                return;
            ClusterUid = e.ClusterUid;
            GalaxyPanelUid = e.GalaxyPanelUid;
            CpuUid = e.CpuUid;
            ClusterGroupId = e.ClusterGroupId;
            ClusterNumber = e.ClusterNumber;
            PanelNumber = e.PanelNumber;
            CpuNumber = e.CpuNumber;
            SerialNumber = e.SerialNumber;
            IpAddress = e.IpAddress;
            DefaultEventLoggingOn = e.DefaultEventLoggingOn;
            PreventDataLoading = e.PreventDataLoading;
            PreventFlashLoading = e.PreventFlashLoading;
            LastLogIndex = e.LastLogIndex;
            ClusterName = e.ClusterName;
            PanelName = e.PanelName;
            ClusterTypeCode = e.ClusterTypeCode;
            ClusterTypeIsActive = e.ClusterTypeIsActive;
            CredentialDataLength = e.CredentialDataLength;
            PanelLocation = e.PanelLocation;
            PanelModelTypeCode = e.PanelModelTypeCode;
            PanelModelIsActive = e.PanelModelIsActive;
            CpuIsActive = e.CpuIsActive;
            EntityId = e.EntityId;
            EntityName = e.EntityName;
            EntityType = e.EntityType;
            SiteUid = e.SiteUid;
            SiteName = e.SiteName;
            this.IsConnected = e.IsConnected;
            this.TimeZoneId = e.TimeZoneId;
            if( e.AlertEventAcknowledgeData != null)
                this.AlertEventAcknowledgeData = e.AlertEventAcknowledgeData.ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this GalaxyCpuDatabaseInformation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyCpuDatabaseInformation to process. </param>
        ///
        /// <returns>   A copy of this GalaxyCpuDatabaseInformation. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuDatabaseInformation Clone(GalaxyCpuDatabaseInformation e)
        {
            return new GalaxyCpuDatabaseInformation(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this GalaxyCpuDatabaseInformation is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(GalaxyCpuDatabaseInformation other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(GalaxyCpuDatabaseInformation other)
        {
            if (other == null)
                return false;

            if (other.CpuUid != this.CpuUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
