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
	public partial class PersonAccessControlProperty
    {
        public PersonAccessControlProperty()
        {
            Initialize();
        }

        public PersonAccessControlProperty(PersonAccessControlProperty e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonAccessControlProperty e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessProfileUid = e.AccessProfileUid;
            this.PersonUid = e.PersonUid;
            this.PINExempt = e.PINExempt;
            this.PassbackExempt = e.PassbackExempt;
            this.CanToggleLockState = e.CanToggleLockState;
            this.IsActive = e.IsActive;
            this.PIN = e.PIN;
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

        public PersonAccessControlProperty Clone(PersonAccessControlProperty e)
        {
            return new PersonAccessControlProperty(e);
        }

        public bool Equals(PersonAccessControlProperty other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonAccessControlProperty other)
        {
            if (other == null)
                return false;

            if (other.PersonUid != this.PersonUid)
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
