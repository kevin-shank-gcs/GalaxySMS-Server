using System;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class DtTest : EntityBase, IIdentifiableEntity, IEquatable<DtTest>
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public int Id { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? Dt { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? Dto { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? DtUtc { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? DtoUtc { get; set; }

        public DtTest()
        {
            Initialize();
        }

        public DtTest(DtTest e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(DtTest e)
        {
            Initialize();
            if (e == null)
                return;
            this.Id = e.Id;
            this.Dt = e.Dt;
            this.Dto = e.Dto;
            this.DtUtc = e.DtUtc;
            this.DtoUtc = e.DtoUtc;
        }

        public DtTest Clone(DtTest e)
        {
            return new DtTest(e);
        }

        public bool Equals(DtTest other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DtTest other)
        {
            if (other == null)
                return false;

            if (other.Id != this.Id)
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
