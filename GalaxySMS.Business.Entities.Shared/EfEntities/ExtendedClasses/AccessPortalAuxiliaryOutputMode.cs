using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
	public partial class AccessPortalAuxiliaryOutputMode
    {
        public AccessPortalAuxiliaryOutputMode()
        {
            Initialize();
        }

        public AccessPortalAuxiliaryOutputMode(AccessPortalAuxiliaryOutputMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
            AccessPortalAuxiliaryOutputModeEditorData = new HashSet<AccessPortalAuxiliaryOutputModeEditorData>();
        }

        public void Initialize(AccessPortalAuxiliaryOutputMode e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalAuxiliaryOutputModeUid = e.AccessPortalAuxiliaryOutputModeUid;
            this.Code = e.Code;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
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
            if (e.AccessPortalAuxiliaryOutputModeEditorData != null)
                this.AccessPortalAuxiliaryOutputModeEditorData =
                    e.AccessPortalAuxiliaryOutputModeEditorData.ToCollection();
        }

        public AccessPortalAuxiliaryOutputMode Clone(AccessPortalAuxiliaryOutputMode e)
        {
            return new AccessPortalAuxiliaryOutputMode(e);
        }

        public bool Equals(AccessPortalAuxiliaryOutputMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalAuxiliaryOutputMode other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAuxiliaryOutputModeUid != this.AccessPortalAuxiliaryOutputModeUid)
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAuxiliaryOutputModeEditorData> AccessPortalAuxiliaryOutputModeEditorData { get; set; }
    }

}
