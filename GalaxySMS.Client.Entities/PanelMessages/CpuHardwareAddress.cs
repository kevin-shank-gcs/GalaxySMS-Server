////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\CpuHardwareAddress.cs
//
// summary:	Implements the CPU hardware address class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A CPU hardware address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class CpuHardwareAddress : ClusterAddress
    {
        /// <summary>   The panel number. </summary>
	    private Int32 _panelNumber;
        /// <summary>   Identifier for the CPU. </summary>
	    private Int32 _cpuId;
        /// <summary>   The CPU model. </summary>
	    private CpuModel _cpuModel;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent CPU numbers. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum CpuNumber { None = 0, One = 1, Two = 2, Both = 3 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent system panel address. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum SystemPanelAddress { None = 0, AllPanels = 255 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuHardwareAddress()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The CpuHardwareAddress to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuHardwareAddress(CpuHardwareAddress o) : base(o)
        {
            if (o != null)
            {
                PanelNumber = o.PanelNumber;
                CpuId = o.CpuId;
                CpuModel = o.CpuModel;
                CpuUid = o.CpuUid;
                PanelUid = o.PanelUid;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="clusterNumber">    The cluster number. </param>
        /// <param name="panelId">          Identifier for the panel. </param>
        /// <param name="cpuId">            The identifier of the CPU. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuHardwareAddress(Int32 clusterNumber, Int32 panelId, Int32 cpuId) : base(clusterNumber)
        {
            ClusterNumber = clusterNumber;
            PanelNumber = panelId;
            CpuId = cpuId;
        }

        //		[DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public new String UniqueId { get { return string.Format("{0}:{1:D3}:{2:D3}:{3:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel number. </summary>
        ///
        /// <value> The panel number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 PanelNumber
        {
            get { return _panelNumber; }
            set
            {
                if (_panelNumber != value)
                {
                    _panelNumber = value;
                    OnPropertyChanged(() => PanelNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the CPU. </summary>
        ///
        /// <value> The identifier of the CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 CpuId
        {
            get { return _cpuId; }
            set
            {
                if (_cpuId != value)
                {
                    _cpuId = value;
                    OnPropertyChanged(() => CpuId);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU model. </summary>
        ///
        /// <value> The CPU model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public CpuModel CpuModel
        {
            get { return _cpuModel; }
            set
            {
                if (_cpuModel != value)
                {
                    _cpuModel = value;
                    OnPropertyChanged(() => CpuModel);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU UID. </summary>
        ///
        /// <value> The CPU UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CpuUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel UID. </summary>
        ///
        /// <value> The panel UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid PanelUid { get; set; }


        public CpuHardwareAddress CpuAddress { get { return this; } set { } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return UniqueId;
        }
    }
}
