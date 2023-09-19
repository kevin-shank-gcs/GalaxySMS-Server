////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IHasAddress.cs
//
// summary:	Declares the IHasAddress interface
///=================================================================================================

using System;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public interface IHasAddress
    {
        Address Address { get; set; }
        Guid? AddressUid { get; set; }

    }
}