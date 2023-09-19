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
    public partial class InputCommand
    {
        public InputCommand()
        {
            Initialize();
        }

        public InputCommand(InputCommand e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyPanelModelIds = new HashSet<Guid>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InputCommand e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputCommandUid = e.InputCommandUid;
            this.CommandCode = e.CommandCode;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.GalaxyPanelModelIds != null)
                this.GalaxyPanelModelIds = e.GalaxyPanelModelIds.ToCollection();

            // IHasDisplayResource & IHasDescriptionResource members
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;

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

        public InputCommand Clone(InputCommand e)
        {
            return new InputCommand(e);
        }

        public bool Equals(InputCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputCommand other)
        {
            if (other == null)
                return false;

            if (other.InputCommandUid != this.InputCommandUid)
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
