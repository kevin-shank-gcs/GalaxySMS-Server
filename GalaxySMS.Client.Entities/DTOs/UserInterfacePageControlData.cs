////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserInterfacePageControlData.cs
//
// summary:	Implements the user interface page control data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user interface page control data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserInterfacePageControlData : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserInterfacePageControlData()
        {
            ControlProperties = new ObservableCollection<UserDefinedProperty>();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the control properties. </summary>
        ///
        /// <value> The control properties. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private ObservableCollection<UserDefinedProperty> _controlProperties { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the control properties. </summary>
        ///
        /// <value> The control properties. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ObservableCollection<UserDefinedProperty> ControlProperties
        {
            get { return _controlProperties; }
            set
            {
                if (_controlProperties != value)
                {
                    _controlProperties = value;
                    OnPropertyChanged(() => ControlProperties, false);
                }
            }
        }

    }
}
