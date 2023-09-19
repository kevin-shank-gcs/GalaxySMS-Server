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
    public partial class GalaxyInterfaceBoardSectionCommand
    {
        public GalaxyInterfaceBoardSectionCommand()
        {
            Initialize();
        }

        public GalaxyInterfaceBoardSectionCommand(GalaxyInterfaceBoardSectionCommand e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.InterfaceBoardSectionModeIds = new HashSet<Guid>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyInterfaceBoardSectionCommand e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyInterfaceBoardSectionCommandUid = e.GalaxyInterfaceBoardSectionCommandUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.CommandCode = e.CommandCode;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if( e.InterfaceBoardSectionModeIds != null)
                InterfaceBoardSectionModeIds = e.InterfaceBoardSectionModeIds.ToCollection();
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

        public GalaxyInterfaceBoardSectionCommand Clone(GalaxyInterfaceBoardSectionCommand e)
        {
            return new GalaxyInterfaceBoardSectionCommand(e);
        }

        public bool Equals(GalaxyInterfaceBoardSectionCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSectionCommand other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardSectionCommandUid != this.GalaxyInterfaceBoardSectionCommandUid)
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
