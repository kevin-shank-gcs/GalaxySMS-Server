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
	public partial class AccessPortalContactSupervisionType
    {
        public AccessPortalContactSupervisionType()
        {
            Initialize();
        }

        public AccessPortalContactSupervisionType(AccessPortalContactSupervisionType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.AccessPortalProperties = new HashSet<AccessPortalProperties>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AccessPortalContactSupervisionType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalContactSupervisionTypeUid = e.AccessPortalContactSupervisionTypeUid;
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
            //this.AccessPortalProperties = e.AccessPortalProperties.ToCollection();
            if( e.gcsBinaryResource != null )
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

        public AccessPortalContactSupervisionType Clone(AccessPortalContactSupervisionType e)
        {
            return new AccessPortalContactSupervisionType(e);
        }

        public bool Equals(AccessPortalContactSupervisionType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalContactSupervisionType other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalContactSupervisionTypeUid != this.AccessPortalContactSupervisionTypeUid)
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