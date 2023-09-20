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
    public partial class gcsUserBasic
    {
        public gcsUserBasic()
        {
            Initialize();
        }

        public gcsUserBasic(gcsUser e)
        {
            Initialize(e);
        }
        public gcsUserBasic(gcsUserBasic e)
        {
            Initialize(e);
        }


        public void Initialize()
        {
        }

        public void Initialize(gcsUser e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserId = e.UserId;
            this.FirstName = e.FirstName;
            this.LastName = e.LastName;
            this.DisplayName = e.DisplayName;
            this.IsActive = e.IsActive;
            this.UserActivationDate = e.UserActivationDate;
            this.UserExpirationDate = e.UserExpirationDate;
            this.UserImage = e.UserImage;
            this.UserName = e.UserName;
            this.InsertDate = e.InsertDate;
        }

        public void Initialize(gcsUserBasic e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserId = e.UserId;
            this.FirstName = e.FirstName;
            this.LastName = e.LastName;
            this.DisplayName = e.DisplayName;
            this.IsActive = e.IsActive;
            this.UserActivationDate = e.UserActivationDate;
            this.UserExpirationDate = e.UserExpirationDate;
            this.UserImage = e.UserImage;
            this.UserName = e.UserName;
            this.InsertDate = e.InsertDate;
        }

        public gcsUserBasic Clone(gcsUserBasic e)
        {
            return new gcsUserBasic(e);
        }

        public bool Equals(gcsUserBasic other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserBasic other)
        {
            if (other == null)
                return false;

            if (other.UserId != this.UserId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
