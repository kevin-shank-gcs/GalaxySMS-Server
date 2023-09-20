using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class UserEntity : EntityBase
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
            UserApplications = new HashSet<UserApplication>();
            ChildUserEntities = new HashSet<UserEntity>();
        }

        public Guid EntityId { get; set; }

        public Guid? ParentEntityId { get; set; }

        public string EntityName { get; set; }

        public string EntityDescription { get; set; }

        public ICollection<UserApplication> UserApplications { get; set; }

        public bool IsActive { get; set; }

        public byte[] Thumbnail { get; set; }

        public ICollection<UserEntity> ChildUserEntities { get; set; }

    }
}
