#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public enum BlobOwnerType
    {
        Person,
        Entity,
        User,
        AccessPortal
    }

    public enum BlobDataType
    {
        Photo,
        Document
    }
}
