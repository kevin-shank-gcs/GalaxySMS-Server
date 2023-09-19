using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Framework.Security;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class gcsEntityIdProducer
    {
        public gcsEntityIdProducer()
        {
            Initialize();
        }

        public gcsEntityIdProducer(gcsEntityIdProducer e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsEntityIdProducer e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.EntityId = e.EntityId;
            this.Url = e.Url;
            this.DevUrl = e.DevUrl;
            this.WebClientUrl = e.WebClientUrl;
            this.SignalRUrl = e.SignalRUrl;
            this.SubscriptionId = e.SubscriptionId;
            this.idProducerUserName = e.idProducerUserName;
            this.idProducerPassword = e.idProducerPassword;
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

        public gcsEntityIdProducer Clone(gcsEntityIdProducer e)
        {
            return new gcsEntityIdProducer(e);
        }

        public bool Equals(gcsEntityIdProducer other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsEntityIdProducer other)
        {
            if (other == null)
                return false;

            if (other.EntityId != this.EntityId)
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
