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
	public partial class PersonCredentialCommandScript
    {
        public PersonCredentialCommandScript()
        {
            Initialize();
        }

        public PersonCredentialCommandScript(PersonCredentialCommandScript e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonCredentialCommandScript e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonCredentialCommandScriptUid = e.PersonCredentialCommandScriptUid;
            this.PersonCredentialUid = e.PersonCredentialUid;
            this.CommandScriptUid = e.CommandScriptUid;
            this.DelayedCommandScriptUid = e.DelayedCommandScriptUid;
            this.DelayTime = e.DelayTime;
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

        public PersonCredentialCommandScript Clone(PersonCredentialCommandScript e)
        {
            return new PersonCredentialCommandScript(e);
        }

        public bool Equals(PersonCredentialCommandScript other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonCredentialCommandScript other)
        {
            if (other == null)
                return false;

            if (other.PersonCredentialCommandScriptUid != this.PersonCredentialCommandScriptUid)
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
