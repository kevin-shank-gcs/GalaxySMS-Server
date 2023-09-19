////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\HardDriveInfo.cs
//
// summary:	Implements the hard drive information class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the hard drive. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class HardDriveInfo
    {
        /// <summary>   The model no. </summary>
        private string modelNo = null;
        /// <summary>   The serial no. </summary>
        private string serialNo = null;
        /// <summary>   The type. </summary>
        private string type = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the model no. </summary>
        ///
        /// <value> The model no. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the serial no. </summary>
        ///
        /// <value> The serial no. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type. </summary>
        ///
        /// <value> The type. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
