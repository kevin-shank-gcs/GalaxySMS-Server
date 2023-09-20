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
            EntityName = e.EntityName;
            IsActive = e.IsActive;
            if (e.gcsBinaryResource != null && e.gcsBinaryResource.BinaryResource != null)
            {
                var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(e.gcsBinaryResource.BinaryResource);
                var scaledImg = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageWithAspectRatio(img, 200, 0);
                Thumbnail = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImg);
            }
        }

        private void Init()
        {
            UserApplications = new HashSet<UserApplication>();
        }

        public Guid EntityId { get; set; }

        public string EntityName { get; set; }

        public ICollection<UserApplication> UserApplications { get; set; }

        public bool IsActive { get; set; }

        public byte[] Thumbnail { get; set; }
    }
}
