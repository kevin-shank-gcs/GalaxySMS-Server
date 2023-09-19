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
	public partial class PersonalAccessGroupAccessPortalTemp
    {
        public PersonalAccessGroupAccessPortalTemp()
        {
            Initialize();
        }

        public PersonalAccessGroupAccessPortalTemp(PersonalAccessGroupAccessPortalTemp e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonalAccessGroupAccessPortalTemp e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonalAccessGroupAccessPortalUid = e.PersonalAccessGroupAccessPortalUid;
            this.PersonPersonalAccessGroupUid = e.PersonPersonalAccessGroupUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

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

        public PersonalAccessGroupAccessPortalTemp Clone(PersonalAccessGroupAccessPortalTemp e)
        {
            return new PersonalAccessGroupAccessPortalTemp(e);
        }

        public bool Equals(PersonalAccessGroupAccessPortalTemp other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonalAccessGroupAccessPortalTemp other)
        {
            if (other == null)
                return false;

            if (other.PersonalAccessGroupAccessPortalUid != this.PersonalAccessGroupAccessPortalUid)
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
