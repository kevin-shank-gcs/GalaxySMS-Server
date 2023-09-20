////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AssaAbloyDsr\AssaDsrEntityBase.cs
//
// summary:	Implements the assa dsr entity base class
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
    /// <summary>   An assa dsr entity base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AssaDsrEntityBase : DtoObjectBase
    {
        /// <summary>   The identifier. </summary>
        private string _id;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier. </summary>
        ///
        /// <value> The identifier. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(() => Id, false);
                }
            }
        }

    }
}
