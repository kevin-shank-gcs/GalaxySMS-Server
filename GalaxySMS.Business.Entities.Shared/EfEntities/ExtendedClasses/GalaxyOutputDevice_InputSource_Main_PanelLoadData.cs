using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

    public partial class GalaxyOutputDevice_InputSource_Main_PanelLoadData
    {
        public GalaxyOutputDevice_InputSource_Main_PanelLoadData()
        {
            Initialize();
        }

        public GalaxyOutputDevice_InputSource_Main_PanelLoadData(GalaxyOutputDevice_InputSource_Main_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.Assignments = new HashSet<GalaxyOutputDevice_InputSource_Assignments_PanelLoadData>();
            this.InputOutputGroups = new HashSet<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData>();
        }

        public void Initialize(GalaxyOutputDevice_InputSource_Main_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.OutputDeviceUid = e.OutputDeviceUid;
            this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
            this.GalaxyOutputInputSourceTriggerConditionUid = e.GalaxyOutputInputSourceTriggerConditionUid;
            this.GalaxyOutputInputSourceModeUid = e.GalaxyOutputInputSourceModeUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.SourceNumber = e.SourceNumber;
            this.InputOutputGroupMode = e.InputOutputGroupMode;
            this.TriggerConditionCode = e.TriggerConditionCode;
            this.TriggerConditionDisplay = e.TriggerConditionDisplay;
            this.SourceModeCode = e.SourceModeCode;
            this.SourceModeDisplay = e.SourceModeDisplay;
            this.IOGroupNumber = e.IOGroupNumber;
            this.IOGroupDisplay = e.IOGroupDisplay;

            if (e.Assignments != null)
                this.Assignments = e.Assignments.ToCollection();
            if (e.InputOutputGroups != null)
                this.InputOutputGroups = e.InputOutputGroups.ToCollection();


        }

        public GalaxyOutputDevice_InputSource_Main_PanelLoadData Clone(GalaxyOutputDevice_InputSource_Main_PanelLoadData e)
        {
            return new GalaxyOutputDevice_InputSource_Main_PanelLoadData(e);
        }

        public bool Equals(GalaxyOutputDevice_InputSource_Main_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputDevice_InputSource_Main_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.OutputDeviceUid != this.OutputDeviceUid)
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
    }
}
