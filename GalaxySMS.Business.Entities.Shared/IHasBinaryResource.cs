////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IHasBinaryResource.cs
//
// summary:	Declares the IHasBinaryResource interface
///=================================================================================================

using System;
using GalaxySMS.Business.Entities;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public interface IHasBinaryResource
    {
        String Name { get; set; }
        gcsBinaryResource gcsBinaryResource { get; set; }
        Guid? BinaryResourceUid { get; set; }
    }
}