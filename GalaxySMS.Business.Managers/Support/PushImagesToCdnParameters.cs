using System;

namespace GalaxySMS.Business.Managers.Support
{
    public class PushBlobToCdnParameters
    {
        public enum OwnerType
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

        public Guid OwnerUid { get; set; }
        public OwnerType TypeOfOwner { get; set; }
        public BlobDataType DataType { get; set; }

        public byte[] Data { get; set; }
        public string Filename { get; set; }

    }
}
