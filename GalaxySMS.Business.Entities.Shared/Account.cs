using System;
using System.Collections.Generic;
using System.Linq;
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
    public class Account : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
#if NetCoreApi
#else
    [DataMember]
#endif
    public Guid AccountGuid { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public int AccountId { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string LoginEmail { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string FirstName { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string LastName { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string Address { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string City { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string State { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string ZipCode { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string CreditCard { get; set; }

#if NetCoreApi
#else
    [DataMember]
#endif
    public string ExpDate { get; set; }

    #region IIdentifiableEntity members

    public int EntityId
    {
        get { return AccountId; }
        set { AccountId = value; }
    }

    public Guid EntityGuid
    {
        get { return AccountGuid; }
        set { AccountGuid = value; }

    }

    #endregion

    #region IAccountOwnedEntity

    public int OwnerAccountId
    {
        get { return AccountId; }
    }

    #endregion


    }
}
