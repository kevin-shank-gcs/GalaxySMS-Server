using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class InterfaceBoardSectionMode
    {
        public InterfaceBoardSectionMode()
        {
            Initialize();
        }

        public InterfaceBoardSectionMode(InterfaceBoardSectionMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.GalaxyCpuModelInterfaceBoardSectionModes = new HashSet<GalaxyCpuModelInterfaceBoardSectionMode>();
            this.GalaxyPanelModelUids = new HashSet<Guid>();
            this.gcsBinaryResource = new gcsBinaryResource();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InterfaceBoardSectionMode e)
        {
            Initialize();
            if (e == null)
                return;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.ModeCode = e.ModeCode;
            //this.GalaxyCpuModelInterfaceBoardSectionModes = e.GalaxyCpuModelInterfaceBoardSectionModes.ToCollection();
            if (e.GalaxyPanelModelUids != null)
                this.GalaxyPanelModelUids = e.GalaxyPanelModelUids.ToCollection();

            // Common table properties
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            // IHasDisplayResource & IHasDescriptionResource members
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.BinaryResourceUid = e.BinaryResourceUid;
            if (e.gcsBinaryResource != null)
                this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
        }

        public InterfaceBoardSectionMode Clone(InterfaceBoardSectionMode e)
        {
            return new InterfaceBoardSectionMode(e);
        }

        public bool Equals(InterfaceBoardSectionMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InterfaceBoardSectionMode other)
        {
            if (other == null)
                return false;

            if (other.InterfaceBoardSectionModeUid != this.InterfaceBoardSectionModeUid)
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
