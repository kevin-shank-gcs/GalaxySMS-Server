using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class CredentialFormatEntityMap
    {
        public CredentialFormatEntityMap()
        {
            Initialize();
        }

        public CredentialFormatEntityMap(CredentialFormatEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(CredentialFormatEntityMap e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialFormatEntityMapUid = e.CredentialFormatEntityMapUid;
            this.CredentialFormatUid = e.CredentialFormatUid;
            this.EntityId = e.EntityId;
            this.IsAllowed = e.IsAllowed;
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

        public CredentialFormatEntityMap Clone(CredentialFormatEntityMap e)
        {
            return new CredentialFormatEntityMap(e);
        }

        public bool Equals(CredentialFormatEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialFormatEntityMap other)
        {
            if (other == null)
                return false;

            if (other.CredentialFormatEntityMapUid != this.CredentialFormatEntityMapUid)
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
