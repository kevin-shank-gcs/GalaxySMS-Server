////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserEntity.cs
//
// summary:	Implements the user entity class
///=================================================================================================

using System;
using System.Collections.Generic;
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
    public class UserEntity //: EntityBase
    {
        public UserEntity()
        {
            Init();
        }

        public UserEntity(gcsEntity e)
        {
            Init();
            EntityId = e.EntityId;
            ParentEntityId = e.ParentEntityId;
            EntityName = e.EntityName;
            EntityDescription = e.EntityDescription;
            IsActive = e.IsActive;
            if (e.gcsBinaryResource != null && e.gcsBinaryResource.BinaryResource != null)
            {
                var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(e.gcsBinaryResource.BinaryResource);
                var scaledImg = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageWithAspectRatio(img, 200, 0);
                Thumbnail = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImg);
            }
        }

        protected void Init()
        {
            UserRoles = new HashSet<UserRole>();
            ChildUserEntities = new HashSet<UserEntity>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid? ParentEntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityDescription { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<UserApplication> UserApplications { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserRole> UserRoles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Thumbnail { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserEntity> ChildUserEntities { get; set; }
    }
}
