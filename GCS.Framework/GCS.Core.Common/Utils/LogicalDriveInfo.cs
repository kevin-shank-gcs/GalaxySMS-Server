////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\LogicalDriveInfo.cs
//
// summary:	Implements the logical drive information class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the logical drive. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class LogicalDriveInfo
    {
        /// <summary>   The volume serial no. </summary>
        private string volumeSerialNo = null;
        /// <summary>   Name of the volume. </summary>
        private string volumeName = null;
        /// <summary>   Name of the system. </summary>
        private string systemName = null;
        /// <summary>   The name. </summary>
        private string name = null;
        /// <summary>   The caption. </summary>
        private string caption = null;
        /// <summary>   The description. </summary>
        private string description = null;
        /// <summary>   The filesystem. </summary>
        private string filesystem = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the volume serial number decimal. </summary>
        ///
        /// <value> The volume serial number decimal. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string VolumeSerialNumberDecimal
        {
            get
            {
                UInt64 iNumber = UInt64.Parse(VolumeSerialNumber, System.Globalization.NumberStyles.HexNumber);
                return iNumber.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the volume serial number. </summary>
        ///
        /// <value> The volume serial number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the volume. </summary>
        ///
        /// <value> The name of the volume. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the system. </summary>
        ///
        /// <value> The name of the system. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the caption. </summary>
        ///
        /// <value> The caption. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the file system. </summary>
        ///
        /// <value> The file system. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
