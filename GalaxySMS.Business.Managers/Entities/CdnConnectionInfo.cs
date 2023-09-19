namespace GalaxySMS.Business.Managers
{
    public class CdnConnectionInfo
    {
        public enum CdnType
        {
            FileSystem,
            //AwsS3
        }

        public CdnType StorageType { get; set; }
        public string FileSystemPath { get; set; }
        public string PublicUrl { get; set; }

    }
}
