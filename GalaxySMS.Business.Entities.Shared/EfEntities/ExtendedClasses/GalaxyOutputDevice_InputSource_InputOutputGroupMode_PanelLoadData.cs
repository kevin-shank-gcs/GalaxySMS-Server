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

    public partial class GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData
    {
        public GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData()
        {
            Initialize();
        }

        public GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData(GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.GalaxyOutputDeviceInputSourceInputOutputGroupUid = e.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
            this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
            this.IOGroupNumber = e.IOGroupNumber;
            this.IOGroupName = e.IOGroupName;


        }

        public GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData Clone(GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData e)
        {
            return new GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData(e);
        }

        public bool Equals(GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputDeviceInputSourceInputOutputGroupUid != this.GalaxyOutputDeviceInputSourceInputOutputGroupUid)
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
