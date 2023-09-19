////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyInterfaceBoardSection.cs
//
// summary:	Implements the galaxy interface board section class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Constants;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy interface board section. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyInterfaceBoardSection
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSection()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInterfaceBoardSection to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSection(GalaxyInterfaceBoardSection e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyInterfaceBoardSection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.GalaxyHardwareModules = new ObservableCollection<GalaxyHardwareModule>();// HashSet<GalaxyHardwareModule>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyInterfaceBoardSection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInterfaceBoardSection to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(GalaxyInterfaceBoardSection e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.SectionNumber = e.SectionNumber;
            this.IsSectionActive = e.IsSectionActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyHardwareModules = e.GalaxyHardwareModules.ToObservableCollection();

            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ModeCode = e.ModeCode;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this GalaxyInterfaceBoardSection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInterfaceBoardSection to process. </param>
        ///
        /// <returns>   A copy of this GalaxyInterfaceBoardSection. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSection Clone(GalaxyInterfaceBoardSection e)
        {
            return new GalaxyInterfaceBoardSection(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this GalaxyInterfaceBoardSection is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(GalaxyInterfaceBoardSection other)
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

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSection other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardSectionUid != this.GalaxyInterfaceBoardSectionUid)
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the modules. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="mode"> The mode. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CreateModules(InterfaceBoardSectionMode mode)
        {
            if (this.InterfaceBoardSectionModeUid != mode.InterfaceBoardSectionModeUid)
            {
                this.InterfaceBoardSectionModeUid = mode.InterfaceBoardSectionModeUid;
            }

            if (this.GalaxyHardwareModules == null)
                this.GalaxyHardwareModules = new ObservableCollection<GalaxyHardwareModule>();

            if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused)
            {
                GalaxyHardwareModules.Clear();
            }
            else if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule)
            {   // Create a single module to represent for the remote readers
                foreach (var o in this.GalaxyHardwareModules.ToList())
                {
                    if (o.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RemoteDoorModule)
                    {
                        this.GalaxyHardwareModules.Remove(o);
                    }
                }

                var m = this.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RemoteDoorModule && o.ModuleNumber == 1);
                if (m == null)
                {
                    m = new GalaxyHardwareModule()
                    {
                        GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RemoteDoorModule,
                        ModuleNumber = 1
                    };

                    // Create nodes for each possible remote door
                    for (var x = GalaxySMS.Common.Constants.GalaxyRemoteDoorModuleLimits.LowestDefinableDoorNumber; x <= GalaxySMS.Common.Constants.GalaxyRemoteDoorModuleLimits.HighestDefinableDoorNumber; x++)
                    {
                        m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = true });
                    }
                    this.GalaxyHardwareModules.Add(m);
                }
            }
            else if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule)
            {   // Create a single module for the remote inputs
                foreach (var o in this.GalaxyHardwareModules.ToList())
                {
                    if (o.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16)
                    {
                        this.GalaxyHardwareModules.Remove(o);
                    }
                }

                for (short moduleNumber = 1; moduleNumber <= 16; moduleNumber++)
                {
                    var m = this.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16 && o.ModuleNumber == moduleNumber);
                    if (m == null)
                    {
                        m = new GalaxyHardwareModule()
                        {
                            GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16,
                            ModuleNumber = moduleNumber
                        };

                        // Create nodes for each possible remote input module
                        for (var x = GalaxySMS.Common.Constants.GalaxyRemoteInputModuleLimits.LowestDefinableInputNumber; x <= GalaxySMS.Common.Constants.GalaxyRemoteInputModuleLimits.HighestDefinableInputNumber; x++)
                        {
                            //m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = true });
                            m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = false });
                        }

                        this.GalaxyHardwareModules.Add(m);
                    }
                }
            }
            else if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays)
            {   // Create a single module for the remote inputs
                foreach (var o in this.GalaxyHardwareModules.ToList())
                {
                    if (o.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8)
                    {
                        this.GalaxyHardwareModules.Remove(o);
                    }
                }
                for (short moduleNumber = 1; moduleNumber <= 3; moduleNumber++)
                {
                    var m = this.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8 && o.ModuleNumber == moduleNumber);
                    if (m == null)
                    {
                        m = new GalaxyHardwareModule()
                        {
                            GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8,
                            ModuleNumber = moduleNumber
                        };

                        var startingNodeNumber = (short)(moduleNumber * GalaxyRemoteRelayModuleLimits.MaximumRelaysPerModule - GalaxyRemoteRelayModuleLimits.MaximumRelaysPerModule);
                        // Create nodes for each possible remote output module
                        for (short x = GalaxySMS.Common.Constants.GalaxyRemoteRelayModuleLimits.LowestDefinableRelayNumber; x <= GalaxySMS.Common.Constants.GalaxyRemoteRelayModuleLimits.MaximumRelaysPerModule; x++)
                        {
                            m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = (short)(startingNodeNumber + x), IsNodeActive = true });
                        }

                        this.GalaxyHardwareModules.Add(m);
                    }
                }
            }
            else if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays)
            {   // Create a single module for the remote inputs
                foreach (var o in this.GalaxyHardwareModules.ToList())
                {
                    if (o.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8)
                    {
                        this.GalaxyHardwareModules.Remove(o);
                    }
                }

                for (short moduleNumber = 1; moduleNumber <= 15; moduleNumber++)
                {
                    var m = this.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8 && o.ModuleNumber == moduleNumber);
                    if (m == null)
                    {
                        m = new GalaxyHardwareModule()
                        {
                            GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8,
                            ModuleNumber = moduleNumber
                        };

                        var startingNodeNumber = (short)(moduleNumber * GalaxyRemoteRelayModuleLimits.MaximumRelaysPerModule - GalaxyRemoteRelayModuleLimits.MaximumRelaysPerModule);
                        // Create nodes for each possible remote output module
                        for (short x = GalaxySMS.Common.Constants.GalaxyRemoteRelayModuleLimits.LowestDefinableRelayNumber; x <= GalaxySMS.Common.Constants.GalaxyRemoteRelayModuleLimits.MaximumRelaysPerModule; x++)
                        {
                            m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = (short)(startingNodeNumber + x), IsNodeActive = true });
                        }
                        //// Create nodes for each possible remote output module
                        //for (var x = GalaxySMS.Common.Constants.GalaxyRemoteRelayModuleLimits.LowestDefinableRelayNumber; x <= GalaxySMS.Common.Constants.GalaxyRemoteRelayModuleLimits.MaximumRelaysPerModule; x++)
                        //{
                        //    m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = (short)(x * moduleNumber), IsNodeActive = true });
                        //}

                        this.GalaxyHardwareModules.Add(m);
                    }
                }
            }
            else if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand)
            {   // Create a single module for the remote readers
                foreach (var o in this.GalaxyHardwareModules.ToList())
                {
                    if (o.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM)
                    {
                        this.GalaxyHardwareModules.Remove(o);
                    }
                }

                var m = this.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM && o.ModuleNumber == 1);
                if (m == null)
                {
                    m = new GalaxyHardwareModule()
                    {
                        GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM,
                        ModuleNumber = 1
                    };

                    // Create nodes for each possible remote lock
                    for (var x = GalaxySMS.Common.Constants.AllegionPimLimits.LowestDefinableDoorNumber; x <= GalaxySMS.Common.Constants.AllegionPimLimits.HighestDefinableDoorNumber; x++)
                    {
                        m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = true });
                    }

                    this.GalaxyHardwareModules.Add(m);
                }
            }
            else if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio)
            {   // Create a single module for the remote readers
                foreach (var o in this.GalaxyHardwareModules.ToList())
                {
                    if (o.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub)
                    {
                        this.GalaxyHardwareModules.Remove(o);
                    }
                }

                var m = this.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub && o.ModuleNumber == 1);
                if (m == null)
                {
                    m = new GalaxyHardwareModule()
                    {
                        GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub,
                        ModuleNumber = 1
                    };

                    // Create nodes for each possible remote lock
                    for (var x = GalaxySMS.Common.Constants.AssaAbloyAperioLimits.LowestDefinableDoorNumber; x <= GalaxySMS.Common.Constants.AssaAbloyAperioLimits.HighestDefinableDoorNumber; x++)
                    {
                        m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = true });
                    }

                    this.GalaxyHardwareModules.Add(m);
                }
            }
            else if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis)
            {   // Create a single module for the remote readers
                foreach (var o in this.GalaxyHardwareModules.ToList())
                {
                    if (o.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub)
                    {
                        this.GalaxyHardwareModules.Remove(o);
                    }
                }

                var m = this.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub && o.ModuleNumber == 1);
                if (m == null)
                {
                    m = new GalaxyHardwareModule()
                    {
                        GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub,
                        ModuleNumber = 1
                    };

                    // Create nodes for each possible remote lock
                    for (var x = GalaxySMS.Common.Constants.SaltoSallisLimits.LowestDefinableDoorNumber; x <= GalaxySMS.Common.Constants.SaltoSallisLimits.HighestDefinableDoorNumber; x++)
                    {
                        m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = true });
                    }

                    this.GalaxyHardwareModules.Add(m);
                }
            }
            else if (this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay ||
                this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display)
            {   // Create a single module for the remote readers
                foreach (var o in this.GalaxyHardwareModules.ToList())
                {
                    if (o.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD)
                    {
                        this.GalaxyHardwareModules.Remove(o);
                    }
                }

                var m = this.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD && o.ModuleNumber == 1);
                if (m == null)
                {
                    m = new GalaxyHardwareModule()
                    {
                        GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD,
                        ModuleNumber = 1
                    };

                    // Create nodes for each possible remote display
                    for (var x = GalaxySMS.Common.Constants.CypressLCDLimits.LowestDefinableDisplayNumber; x <= GalaxySMS.Common.Constants.CypressLCDLimits.HighestDefinableDisplayNumber; x++)
                    {
                        m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = true });
                    }

                    this.GalaxyHardwareModules.Add(m);
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Does hardware address match. </summary>
        ///
        /// <param name="accountCode">      The account code. </param>
        /// <param name="clusterNumber">    The cluster number. </param>
        /// <param name="panelNumber">      The panel number. </param>
        /// <param name="boardNumber">      The board number. </param>
        /// <param name="sectionNumber">    The section number. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ///=================================================================================================

        public bool DoesHardwareAddressMatch(int clusterGroupId, int clusterNumber, int panelNumber, int boardNumber, int sectionNumber)
        {
            return !(clusterGroupId != this.ClusterGroupId ||
                     clusterNumber != this.ClusterNumber ||
                     panelNumber != this.PanelNumber ||
                     boardNumber != this.BoardNumber ||
                     sectionNumber != this.SectionNumber);
        }

        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.InterfaceBoardSection, BoardNumber, SectionNumber); } }

    }
}