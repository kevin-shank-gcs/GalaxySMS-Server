////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AssaAbloyDsr\AccessPointType.cs
//
// summary:	Implements the access point type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities.AssaAbloyDsr
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access point type. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessPointType : DtoObjectBase
    {
        /// <summary>   The identifier field. </summary>
        private string idField;

        /// <summary>   The display name field. </summary>
        private string displayNameField;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier. </summary>
        ///
        /// <value> The identifier. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                OnPropertyChanged(() => id, true);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the display. </summary>
        ///
        /// <value> The name of the display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string displayName
        {
            get
            {
                return this.displayNameField;
            }
            set
            {
                this.displayNameField = value;
                OnPropertyChanged(() => displayName, true);
            }
        }

    }

}
