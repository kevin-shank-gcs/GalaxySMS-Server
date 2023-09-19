////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\GalaxyCpuCommandAction.cs
//
// summary:	Implements the galaxy CPU command action class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command action. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]

    public class GalaxyCpuCommandBase : ObjectBase
    {

        /// <summary>   The cluster UID. </summary>
        private Guid _ClusterUid;
        /// <summary>   The galaxy panel UID. </summary>
        private Guid _GalaxyPanelUid;
        /// <summary>   The CPU UID. </summary>
        private Guid _CpuUid;
        /// <summary>   The cluster uids. </summary>
        private List<Guid> _ClusterUids;
        /// <summary>   The galaxy panel uids. </summary>
        private List<Guid> _GalaxyPanelUids;
        /// <summary>   The CPU uids. </summary>
        private List<Guid> _CpuUids;
        /// <summary>   The cluster addresses. </summary>
        private List<ClusterAddress> _clusterAddresses;
        /// <summary>   The CPU addresses. </summary>
        private List<CpuHardwareAddress> _CpuAddresses;

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
        /// <summary>   Initializes this GalaxyCpuCommandAction. </summary>
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

        [DataMember]
        public Guid ClusterUid
        {
            get { return _ClusterUid; }
            set
            {
                if (_ClusterUid != value)
                {
                    _ClusterUid = value;
                    OnPropertyChanged(() => ClusterUid, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel UID. </summary>
        ///
        /// <value> The galaxy panel UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid GalaxyPanelUid
        {
            get { return _GalaxyPanelUid; }
            set
            {
                if (_GalaxyPanelUid != value)
                {
                    _GalaxyPanelUid = value;
                    OnPropertyChanged(() => GalaxyPanelUid, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU UID. </summary>
        ///
        /// <value> The CPU UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid CpuUid
        {
            get { return _CpuUid; }
            set
            {
                if (_CpuUid != value)
                {
                    _CpuUid = value;
                    OnPropertyChanged(() => CpuUid, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster uids. </summary>
        ///
        /// <value> The cluster uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public List<Guid> ClusterUids
        {
            get { return _ClusterUids; }
            set
            {
                if (_ClusterUids != value)
                {
                    _ClusterUids = value;
                    OnPropertyChanged(() => ClusterUids, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel uids. </summary>
        ///
        /// <value> The galaxy panel uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public List<Guid> GalaxyPanelUids
        {
            get { return _GalaxyPanelUids; }
            set
            {
                if (_GalaxyPanelUids != value)
                {
                    _GalaxyPanelUids = value;
                    OnPropertyChanged(() => GalaxyPanelUids, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU uids. </summary>
        ///
        /// <value> The CPU uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public List<Guid> CpuUids
        {
            get { return _CpuUids; }
            set
            {
                if (_CpuUids != value)
                {
                    _CpuUids = value;
                    OnPropertyChanged(() => CpuUids, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster addresses. </summary>
        ///
        /// <value> The cluster addresses. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public List<ClusterAddress> ClusterAddresses
        {
            get { return _clusterAddresses; }
            set
            {
                if (_clusterAddresses != value)
                {
                    _clusterAddresses = value;
                    OnPropertyChanged(() => ClusterAddresses, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU addresses. </summary>
        ///
        /// <value> The CPU addresses. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public List<CpuHardwareAddress> CpuAddresses
        {
            get { return _CpuAddresses; }
            set
            {
                if (_CpuAddresses != value)
                {
                    _CpuAddresses = value;
                    OnPropertyChanged(() => CpuAddresses, true);
                }
            }
        }

        private Guid _commandUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command UID. </summary>
        ///
        /// <value> The command UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CommandUid
        {
            get { return _commandUid; }
            set
            {
                if (_commandUid != value)
                {
                    _commandUid = value;
                    OnPropertyChanged(() => CommandUid, true);
                }
            }
        }

    }
}
