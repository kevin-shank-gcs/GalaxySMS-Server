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
    public partial class AccessPortalCommand
    {
        public AccessPortalCommand()
        {
            Initialize();
        }

        public AccessPortalCommand(AccessPortalCommand e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.AccessPortalTypeAccessPortalCommands = new HashSet<AccessPortalTypeAccessPortalCommand>();
            this.AccessPortalTypeIds = new HashSet<Guid>();
            this.AccessPortalCommandChoices = new HashSet<AccessPortalCommandChoice>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AccessPortalCommand e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalCommandUid = e.AccessPortalCommandUid;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.AccessPortalTypeAccessPortalCommands = e.AccessPortalTypeAccessPortalCommands.ToCollection();
            if (e.AccessPortalTypeIds != null)
                this.AccessPortalTypeIds = e.AccessPortalTypeIds.ToCollection();

            if (e.AccessPortalCommandChoices != null)
                this.AccessPortalCommandChoices = e.AccessPortalCommandChoices.ToCollection();

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

        public AccessPortalCommand Clone(AccessPortalCommand e)
        {
            return new AccessPortalCommand(e);
        }

        public bool Equals(AccessPortalCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalCommand other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalCommandUid != this.AccessPortalCommandUid)
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
