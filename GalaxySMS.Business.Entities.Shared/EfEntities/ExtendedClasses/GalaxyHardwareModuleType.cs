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
	public partial class GalaxyHardwareModuleType
    {
        public GalaxyHardwareModuleType()
        {
            Initialize();
        }

        public GalaxyHardwareModuleType(GalaxyHardwareModuleType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.GalaxyHardwareModules = new HashSet<GalaxyHardwareModule>();
            this.gcsBinaryResource = new gcsBinaryResource();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyHardwareModuleType e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyHardwareModuleTypeUid = e.GalaxyHardwareModuleTypeUid;
            this.ModuleTypeCode = e.ModuleTypeCode;
            this.NumberOfNodes = e.NumberOfNodes;
            //this.GalaxyHardwareModules = e.GalaxyHardwareModules.ToCollection();

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

        public GalaxyHardwareModuleType Clone(GalaxyHardwareModuleType e)
        {
            return new GalaxyHardwareModuleType(e);
        }

        public bool Equals(GalaxyHardwareModuleType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyHardwareModuleType other)
        {
            if (other == null)
                return false;

            if (other.GalaxyHardwareModuleTypeUid != this.GalaxyHardwareModuleTypeUid)
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
