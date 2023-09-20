﻿
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IGalaxyCpuCommandBase
    {
        void Init();

        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>

        Guid ClusterUid { get; set; }

        /// <summary>   Gets or sets the galaxy panel UID. </summary>
        ///
        /// <value> The galaxy panel UID. </value>

        Guid GalaxyPanelUid { get; set; }

        /// <summary>   Gets or sets the CPU UID. </summary>
        ///
        /// <value> The CPU UID. </value>

        Guid CpuUid { get; set; }

        /// <summary>   Gets or sets the cluster uids. </summary>
        ///
        /// <value> The cluster uids. </value>

        List<Guid> ClusterUids { get; set; }

        /// <summary>   Gets or sets the galaxy panel uids. </summary>
        ///
        /// <value> The galaxy panel uids. </value>

        List<Guid> GalaxyPanelUids { get; set; }

        /// <summary>   Gets or sets the CPU uids. </summary>
        ///
        /// <value> The CPU uids. </value>

        List<Guid> CpuUids { get; set; }

        /// <summary>   Gets or sets the cluster addresses. </summary>
        ///
        /// <value> The cluster addresses. </value>

        List<ClusterAddress> ClusterAddresses { get; set; }

        /// <summary>   Gets or sets the CPU addresses. </summary>
        ///
        /// <value> The CPU addresses. </value>

        List<CpuHardwareAddress> CpuAddresses { get; set; }

        /// <summary>   Gets or sets the command UID. </summary>
        ///
        /// <value> The command UID. </value>

        Guid CommandUid { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command base. </summary>
    ///
    /// <remarks>   Kevin, 1/21/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif

    public partial class GalaxyCpuCommandBase //: ObjectBase
        : IGalaxyCpuCommandBase
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuCommandBase()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ///
        /// <param name="o">    The GalaxyCpuCommandAction to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuCommandBase(GalaxyCpuCommandBase o)
        {
            Init();

            if (o == null)
                return;

            this.ClusterUid = o.ClusterUid;
            this.GalaxyPanelUid = o.GalaxyPanelUid;
            this.CpuUid = o.CpuUid;
            this.CommandUid = o.CommandUid;

            if (o.ClusterUids != null)
                this.ClusterUids = o.ClusterUids.ToList();
            if (o.GalaxyPanelUids != null)
                this.GalaxyPanelUids = o.GalaxyPanelUids.ToList();
            if (o.CpuUids != null)
                this.CpuUids = o.CpuUids.ToList();
            if (o.ClusterAddresses != null)
                this.ClusterAddresses = o.ClusterAddresses.ToList();
            if (o.CpuAddresses != null)
                this.CpuAddresses = o.CpuAddresses.ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this GalaxyCpuCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            ClusterUids = new List<Guid>();
            GalaxyPanelUids = new List<Guid>();
            CpuUids = new List<Guid>();
            ClusterAddresses = new List<ClusterAddress>();
            CpuAddresses = new List<CpuHardwareAddress>();
            this.ClusterUid = Guid.Empty;
            this.GalaxyPanelUid = Guid.Empty;
            this.CpuUid = Guid.Empty;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel UID. </summary>
        ///
        /// <value> The galaxy panel UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU UID. </summary>
        ///
        /// <value> The CPU UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster uids. </summary>
        ///
        /// <value> The cluster uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> ClusterUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel uids. </summary>
        ///
        /// <value> The galaxy panel uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> GalaxyPanelUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU uids. </summary>
        ///
        /// <value> The CPU uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> CpuUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster addresses. </summary>
        ///
        /// <value> The cluster addresses. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public List<ClusterAddress> ClusterAddresses { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU addresses. </summary>
        ///
        /// <value> The CPU addresses. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public List<CpuHardwareAddress> CpuAddresses { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command UID. </summary>
        ///
        /// <value> The command UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CommandUid { get; set; }
    }
}