using GCS.Core.Common.Extensions;
using System.Collections.Generic;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyOutputDevice
    {
        public GalaxyOutputDevice()
        {
            Initialize();
        }

        public GalaxyOutputDevice(GalaxyOutputDevice e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyOutputDeviceInputSources = new HashSet<GalaxyOutputDeviceInputSource>();
            GalaxyHardwareAddress = new OutputDeviceGalaxyHardwareAddress();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyOutputDevice e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.GalaxyOutputModeUid = e.GalaxyOutputModeUid;
            this.GalaxyOutputInputSourceRelationshipUid = e.GalaxyOutputInputSourceRelationshipUid;
            this.TimeoutDuration = e.TimeoutDuration;
            this.Limit = e.Limit;
            this.InvertOutput = e.InvertOutput;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.GalaxyOutputDeviceInputSources != null)
                this.GalaxyOutputDeviceInputSources = e.GalaxyOutputDeviceInputSources.ToCollection();
            this.GalaxyHardwareAddress = e.GalaxyHardwareAddress;
        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public GalaxyOutputDevice Clone(GalaxyOutputDevice e)
        {
            return new GalaxyOutputDevice(e);
        }

        public bool Equals(GalaxyOutputDevice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputDevice other)
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
