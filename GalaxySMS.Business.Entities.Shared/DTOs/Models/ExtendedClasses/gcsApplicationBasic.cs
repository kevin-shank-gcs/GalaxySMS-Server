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
    public partial class gcsApplicationBasic
    {
        public gcsApplicationBasic()
        {
            Initialize();
        }

        public gcsApplicationBasic(gcsApplication e)
        {
            Initialize(e);
        }
        public gcsApplicationBasic(gcsApplicationBasic e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //Roles = new HashSet<gcsEntityRoleBasic>();
        }

        public void Initialize(gcsApplication e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationId = e.ApplicationId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationDescription = e.ApplicationDescription;
        }
        public void Initialize(gcsApplicationBasic e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationId = e.ApplicationId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationDescription = e.ApplicationDescription;
            //if( e.Roles != null)
            //    this.Roles = e.Roles.ToCollection();
        }

        public gcsApplicationBasic Clone(gcsApplicationBasic e)
        {
            return new gcsApplicationBasic(e);
        }

        public bool Equals(gcsApplicationBasic other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsApplicationBasic other)
        {
            if (other == null)
                return false;

            if (other.ApplicationId != this.ApplicationId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.ApplicationName;
        }
    }
}
