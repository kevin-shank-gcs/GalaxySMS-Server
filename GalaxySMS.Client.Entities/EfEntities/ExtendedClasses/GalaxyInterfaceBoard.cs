////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyInterfaceBoard.cs
//
// summary:	Implements the galaxy interface board class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Constants;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy interface board. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyInterfaceBoard
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoard()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInterfaceBoard to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoard(GalaxyInterfaceBoard e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyInterfaceBoard. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.InterfaceBoardSections = new ObservableCollection<GalaxyInterfaceBoardSection>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyInterfaceBoard. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInterfaceBoard to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(GalaxyInterfaceBoard e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.BoardNumber = e.BoardNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            if (e.InterfaceBoardSections != null)
                this.InterfaceBoardSections = e.InterfaceBoardSections.ToObservableCollection();

            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.ClusterUid = e.ClusterUid;
            this.PanelName = e.PanelName;
            this.ClusterName = e.ClusterName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this GalaxyInterfaceBoard. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInterfaceBoard to process. </param>
        ///
        /// <returns>   A copy of this GalaxyInterfaceBoard. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoard Clone(GalaxyInterfaceBoard e)
        {
            return new GalaxyInterfaceBoard(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this GalaxyInterfaceBoard is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(GalaxyInterfaceBoard other)
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

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoard other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardUid != this.GalaxyInterfaceBoardUid)
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
        /// <summary>   Creates the sections. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="type"> The type. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CreateSections(InterfaceBoardType type)
        {
            if (this.InterfaceBoardTypeUid != type.InterfaceBoardTypeUid)
            {
                this.InterfaceBoardTypeUid = type.InterfaceBoardTypeUid;
            }

            if (this.InterfaceBoardSections == null)
                this.InterfaceBoardSections = new ObservableCollection<GalaxyInterfaceBoardSection>();

            if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600)
            {
                // Section 1 is outputs, Section 2 is inputs
                for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
                {
                    if (this.InterfaceBoardSections.Count > 2)
                        this.InterfaceBoardSections = new ObservableCollection<GalaxyInterfaceBoardSection>();

                    // Validate the sections are the correct type. If not, remove them and start over
                    var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s != null)
                    {
                        if (s.SectionNumber == 1 && s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Outputs)
                            this.InterfaceBoardSections.Remove(s);
                        if (s.SectionNumber == 2 && s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs)
                            this.InterfaceBoardSections.Remove(s);
                    }

                    s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

                    if (s == null)
                    {
                        s = new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = sectionNumber,
                            IsSectionActive = true,
                        };
                        if (sectionNumber == 1)
                        {
                            s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Outputs;
                            var m = s.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputOutputModule);
                            if (m == null)
                            {
                                m = new GalaxyHardwareModule()
                                {
                                    GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputOutputModule,
                                    ModuleNumber = 1
                                };

                                // Create nodes for each possible remote input module
                                for (var x = GalaxySMS.Common.Constants.GalaxyDigitalInputOutputModuleLimits.LowestDefinableOututNumber; x <= GalaxySMS.Common.Constants.GalaxyDigitalInputOutputModuleLimits.HighestDefinableOutputNumber; x++)
                                {
                                    m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = true });
                                }

                                s.GalaxyHardwareModules.Add(m);
                            }
                            this.InterfaceBoardSections.Add(s);
                        }
                        else if (sectionNumber == 2)
                        {
                            s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs;
                            var m = s.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputInputModule);
                            if (m == null)
                            {
                                m = new GalaxyHardwareModule()
                                {
                                    GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputInputModule,
                                    ModuleNumber = 1
                                };

                                // Create nodes for each possible remote input module
                                for (var x = GalaxySMS.Common.Constants.GalaxyDigitalInputOutputModuleLimits.LowestDefinableInputNumber; x <= GalaxySMS.Common.Constants.GalaxyDigitalInputOutputModuleLimits.HighestDefinableInputNumber; x++)
                                {
                                    m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = x, IsNodeActive = true });
                                }

                                s.GalaxyHardwareModules.Add(m);
                            }

                            this.InterfaceBoardSections.Add(s);
                        }
                    }
                }
            }
            else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
            {
                for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
                {
                    var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

                    if (s != null)
                    {
                        if (!GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
                            this.InterfaceBoardSections.Remove(s);
                        //if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal)
                        //    this.InterfaceBoardSections.Remove(s);
                    }

                    s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s == null)
                    {
                        s = new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = sectionNumber,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid =
                                GalaxySMS.Common.Constants.DualReaderInterface600ModeIds
                                    .ReaderInterfaceMode_AccessPortal
                        };

                        var m = new GalaxyHardwareModule()
                        {
                            GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule,
                            ModuleNumber = 1
                        };

                        m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = 1, IsNodeActive = true });
                        s.GalaxyHardwareModules.Add(m);

                        this.InterfaceBoardSections.Add(s);
                    }
                }
            }
            else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
            {
                for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
                {
                    var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

                    if (s != null)
                    {
                        if (!GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
                            this.InterfaceBoardSections.Remove(s);

                        //if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal)
                        //    this.InterfaceBoardSections.Remove(s);
                    }

                    s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s == null)
                    {
                        s = new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = sectionNumber,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid =
                               GalaxySMS.Common.Constants.DualReaderInterface635ModeIds
                                   .ReaderInterfaceMode_AccessPortal
                        };

                        var m = new GalaxyHardwareModule()
                        {
                            GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule,
                            ModuleNumber = 1
                        };

                        m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = 1, IsNodeActive = true });
                        s.GalaxyHardwareModules.Add(m);

                        this.InterfaceBoardSections.Add(s);
                    }
                }
            }
            //else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600)
            //{
            //    for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
            //    {
            //        var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

            //        if (s != null)
            //        {
            //            if (!GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
            //                this.InterfaceBoardSections.Remove(s);
            //            //if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused)
            //            //    this.InterfaceBoardSections.Remove(s);
            //        }

            //        s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

            //        if (s == null)
            //        {
            //            this.InterfaceBoardSections.Add(new GalaxyInterfaceBoardSection()
            //            {
            //                SectionNumber = sectionNumber,
            //                IsSectionActive = true,
            //                InterfaceBoardSectionModeUid =
            //                    GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused
            //            });
            //        }
            //    }

            //}
            else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
            {
                for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
                {
                    var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

                    if (s != null)
                    {
                        if (!GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
                            this.InterfaceBoardSections.Remove(s);
                        //if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused)
                        //    this.InterfaceBoardSections.Remove(s);
                    }

                    s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

                    if (s == null)
                    {
                        this.InterfaceBoardSections.Add(new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = sectionNumber,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid =
                                GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused
                        });
                    }
                }
            }
            //else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager)
            //{
            //    for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
            //    {
            //        var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

            //        if (s != null)
            //        {
            //            if (!GalaxySMS.Common.Constants.CardTourManagerBoardInterfaceSectionModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
            //                this.InterfaceBoardSections.Remove(s);
            //            //if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.CardTourManagerBoardInterfaceSectionModeIds.CTMSectionMode_CTM)
            //            //    this.InterfaceBoardSections.Remove(s);
            //        }

            //        s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
            //        if (s == null)
            //        {
            //            this.InterfaceBoardSections.Add(new GalaxyInterfaceBoardSection()
            //            {
            //                SectionNumber = sectionNumber,
            //                IsSectionActive = true,
            //                InterfaceBoardSectionModeUid =
            //                    GalaxySMS.Common.Constants.CardTourManagerBoardInterfaceSectionModeIds.CTMSectionMode_CTM
            //            });
            //        }
            //    }
            //}
            else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface)
            {
                for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
                {
                    var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);

                    if (s != null)
                    {
                        if (!GalaxySMS.Common.Constants.OtisElevatorManagerBoardInterfaceSectionModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
                            this.InterfaceBoardSections.Remove(s);
                        //if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.OtisElevatorManagerBoardInterfaceSectionModeIds.OtisElevatorManagerSectionMode_OEI)
                        //    this.InterfaceBoardSections.Remove(s);
                    }

                    s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s == null)
                    {
                        this.InterfaceBoardSections.Add(new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = sectionNumber,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid =
                                GalaxySMS.Common.Constants.OtisElevatorManagerBoardInterfaceSectionModeIds.OtisElevatorManagerSectionMode_OEI
                        });
                    }
                }
            }
            else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface)
            {
                for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
                {
                    var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s != null)
                    {
                        if (!GalaxySMS.Common.Constants.KoneElevatorManagerBoardInterfaceSectionModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
                            this.InterfaceBoardSections.Remove(s);
                        //if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.KoneElevatorManagerBoardInterfaceSectionModeIds.KoneElevatorManagerSectionMode_KEI)
                        //    this.InterfaceBoardSections.Remove(s);
                    }

                    s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s == null)
                    {
                        this.InterfaceBoardSections.Add(new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = sectionNumber,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid =
                                GalaxySMS.Common.Constants.KoneElevatorManagerBoardInterfaceSectionModeIds.KoneElevatorManagerSectionMode_KEI
                        });
                    }
                }
            }
            else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu)
            {
                for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
                {
                    var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s != null)
                    {
                        if (!GalaxySMS.Common.Constants.VeridtCpuBoardInterfaceSectionModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
                            this.InterfaceBoardSections.Remove(s);
                    }

                    s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s == null)
                    {
                        this.InterfaceBoardSections.Add(new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = sectionNumber,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid =
                                GalaxySMS.Common.Constants.VeridtCpuBoardInterfaceSectionModeIds.VeridtCpuBoardInterfaceSectionMode_Cpu
                        });
                    }
                }
            }
            else if (type.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule)
            {
                for (short sectionNumber = 1; sectionNumber <= type.NumberOfSections; sectionNumber++)
                {
                    var s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s != null)
                    {
                        if (!GalaxySMS.Common.Constants.VeridtReaderModuleBoardInterfaceSectionModeIds.Values.Contains(s.InterfaceBoardSectionModeUid))
                            this.InterfaceBoardSections.Remove(s);
                    }

                    s = this.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == sectionNumber);
                    if (s == null)
                    {
                        this.InterfaceBoardSections.Add(new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = sectionNumber,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid =
                                GalaxySMS.Common.Constants.VeridtReaderModuleBoardInterfaceSectionModeIds.VeridtReaderModuleBoardInterfaceSectionMode_Reader
                        });
                    }
                }
            }
        }

        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.InterfaceBoard, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber); } }

    }
}