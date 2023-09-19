
namespace GCS.Framework.Utilities.Computer
{
    public class HardDriveInformation
    {
        private string modelNo = null;
        private string serialNo = null;
        private string type = null;

        public string ModelNo
        {
            get
            {
                return modelNo;
            }
            set
            {
                modelNo = value;
            }
        }
        public string SerialNo
        {
            get
            {
                return serialNo;
            }
            set
            {
                serialNo = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
    } 
}
