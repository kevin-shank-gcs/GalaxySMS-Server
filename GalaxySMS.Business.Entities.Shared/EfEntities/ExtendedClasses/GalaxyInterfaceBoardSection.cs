using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyInterfaceBoardSection
    {
        public GalaxyInterfaceBoardSection()
        {
            Initialize();
        }

        public GalaxyInterfaceBoardSection(GalaxyInterfaceBoardSection e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyHardwareModules = new HashSet<GalaxyHardwareModule>();
            this.ConcurrencyValue = 0;
        }

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
            this.IsDirty = e.IsDirty;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyHardwareModules = e.GalaxyHardwareModules.ToCollection();

            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ModeCode = e.ModeCode;

            this.GalaxyPanelUid = e.GalaxyPanelUid;
        }


        public bool IsAnythingDirty
        {
            get
            {
                foreach (var o in GalaxyHardwareModules)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
                return IsDirty;
            }
        }

        public GalaxyInterfaceBoardSection Clone(GalaxyInterfaceBoardSection e)
        {
            return new GalaxyInterfaceBoardSection(e);
        }

        public bool Equals(GalaxyInterfaceBoardSection other)
        {

            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSection other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardSectionUid != this.GalaxyInterfaceBoardSectionUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool IsModeUnused
        {
            get
            {
                return InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_Unused ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_Unused ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused;
            }
        }

        public bool IsModeValidForBoardType(Guid boardTypeUid)
        {
            if (boardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
            {
                return this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_Unused ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_CredentialReaderOnly;
            }
            else if (boardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
            {
                return this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Shell ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_VeridtCac;
            }
            else if (boardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
            {
                return this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_Unused ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_CredentialReaderOnly;
            }
            //else if( boardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600)
            //{
            //    return this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Shell ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused ||
            //        InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac;
            //}
            else if (boardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600)
            {
                return this.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs ||
                    InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Outputs;
            }
            return false;

        }

        public Guid GalaxyPanelUid { get; set; }
    }
}
