using System;

namespace GCS.Framework.Utilities.Computer
{
    public class LogicalDriveInformation
    {
        private string volumeSerialNo = null;
        private string volumeName = null;
        private string systemName = null;
        private string name = null;
        private string caption = null;
        private string description = null;
        private string filesystem = null;

        public string VolumeSerialNumberDecimal
        {
            get
            {
                UInt64 iNumber = UInt64.Parse(VolumeSerialNumber, System.Globalization.NumberStyles.HexNumber);
                return iNumber.ToString();
            }
        }

        public string VolumeSerialNumber
        {
            get
            {
                return volumeSerialNo;
            }
            set
            {
                volumeSerialNo = value;
            }
        }

        public string VolumeName
        {
            get
            {
                return volumeName;
            }
            set
            {
                volumeName = value;
            }
        }

        public string SystemName
        {
            get
            {
                return systemName;
            }
            set
            {
                systemName = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string FileSystem
        {
            get
            {
                return filesystem;
            }
            set
            {
                filesystem = value;
            }
        }


    }

}
