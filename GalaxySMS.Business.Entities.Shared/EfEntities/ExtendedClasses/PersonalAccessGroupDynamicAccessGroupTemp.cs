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
	public partial class PersonalAccessGroupDynamicAccessGroupTemp
    {
        public PersonalAccessGroupDynamicAccessGroupTemp()
        {
            Initialize();
        }

        public PersonalAccessGroupDynamicAccessGroupTemp(PersonalAccessGroupDynamicAccessGroupTemp e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonalAccessGroupDynamicAccessGroupTemp e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonalAccessGroupDynamicAccessGroupUid = e.PersonalAccessGroupDynamicAccessGroupUid;
            this.PersonPersonalAccessGroupUid = e.PersonPersonalAccessGroupUid;
            this.AccessGroupUid = e.AccessGroupUid;
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

        public PersonalAccessGroupDynamicAccessGroupTemp Clone(PersonalAccessGroupDynamicAccessGroupTemp e)
        {
            return new PersonalAccessGroupDynamicAccessGroupTemp(e);
        }

        public bool Equals(PersonalAccessGroupDynamicAccessGroupTemp other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonalAccessGroupDynamicAccessGroupTemp other)
        {
            if (other == null)
                return false;

            if (other.PersonalAccessGroupDynamicAccessGroupUid != this.PersonalAccessGroupDynamicAccessGroupUid)
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
