using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonClusterPermission
    {
        public PersonClusterPermission()
        {
            Initialize();
        }

        public PersonClusterPermission(PersonClusterPermission e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.PersonAccessGroups = new HashSet<PersonAccessGroup>();
            this.PersonInputOutputGroups = new HashSet<PersonInputOutputGroup>();
        }

        public void Initialize(PersonClusterPermission e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
            this.PersonUid = e.PersonUid;
            this.ClusterUid = e.ClusterUid;
            this.PersonCredentialUid = e.PersonCredentialUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.CredentialClusterTourUid = e.CredentialClusterTourUid;
            this.CredentialBits = e.CredentialBits;
            this.PersonAccessGroups = e.PersonAccessGroups.ToCollection();
            this.PersonInputOutputGroups = e.PersonInputOutputGroups.ToCollection();
        }

        public bool IsAnythingDirty
        {
            get
            {
                foreach (var o in PersonAccessGroups)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
                foreach (var o in PersonInputOutputGroups)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
                if (PersonPersonalAccessGroup != null)
                    if (PersonPersonalAccessGroup.IsAnythingDirty)
                        return true;
                return IsDirty;
            }
        }

        public PersonClusterPermission Clone(PersonClusterPermission e)
        {
            return new PersonClusterPermission(e);
        }

        public bool Equals(PersonClusterPermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonClusterPermission other)
        {
            if (other == null)
                return false;

            if (other.PersonClusterPermissionUid != this.PersonClusterPermissionUid)
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
