using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalElevatorControlType
    {
        public AccessPortalElevatorControlType()
        {
            Initialize();
        }

        public AccessPortalElevatorControlType(AccessPortalElevatorControlType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AccessPortalProperties = new HashSet<AccessPortalProperties>();
            this.GalaxyPanelModelUids = new HashSet<Guid>();
        }

        public void Initialize(AccessPortalElevatorControlType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalElevatorControlTypeUid = e.AccessPortalElevatorControlTypeUid;
            this.Code = e.Code;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AccessPortalProperties = e.AccessPortalProperties.ToCollection();
            this.GalaxyPanelModelUids = e.GalaxyPanelModelUids.ToCollection();

            if ( e.gcsBinaryResource != null )
                this.gcsBinaryResource = e.gcsBinaryResource;

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

        public AccessPortalElevatorControlType Clone(AccessPortalElevatorControlType e)
        {
            return new AccessPortalElevatorControlType(e);
        }

        public bool Equals(AccessPortalElevatorControlType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalElevatorControlType other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalElevatorControlTypeUid != this.AccessPortalElevatorControlTypeUid)
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