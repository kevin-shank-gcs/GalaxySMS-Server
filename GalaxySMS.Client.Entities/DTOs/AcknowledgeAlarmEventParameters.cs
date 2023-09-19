////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AcknowledgeAlarmEventParameters.cs
//
// summary:	Implements the acknowledge alarm event parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An acknowledge alarm event parameters. </summary>
    ///
    /// <remarks>   Kevin, 4/29/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AcknowledgeAlarmEventParameters: ObjectBase
    {
        /// <summary>   The unique UID. </summary>
        private Guid _UniqueUid;
        /// <summary>   The activity event UID. </summary>
        private Guid _ActivityEventUid;
        /// <summary>   The response. </summary>
        private string _Response;
        /// <summary>   Category the panel activity event belongs to. </summary>
        private PanelActivityEventCategory panelActivityEventCategory;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique UID. </summary>
        ///
        /// <value> The unique UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid UniqueUid
        {
            get { return _UniqueUid; }
            set
            {
                if (_UniqueUid != value)
                {
                    _UniqueUid = value;
                    OnPropertyChanged(() => UniqueUid, false);
                }
            }
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the activity event UID. </summary>
        ///
        /// <value> The activity event UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ActivityEventUid
        {
            get { return _ActivityEventUid; }
            set
            {
                if (_ActivityEventUid != value)
                {
                    _ActivityEventUid = value;
                    OnPropertyChanged(() => ActivityEventUid, false);
                }
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the response. </summary>
        ///
        /// <value> The response. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]

        public string Response
        {
            get { return _Response; }
            set
            {
                if (_Response != value)
                {
                    _Response = value;
                    OnPropertyChanged(() => Response, true);
                }
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category the activity event belongs to. </summary>
        ///
        /// <value> The activity event category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PanelActivityEventCategory ActivityEventCategory
        {
            get { return panelActivityEventCategory; }
            set
            {
                if (panelActivityEventCategory != value)
                {
                    panelActivityEventCategory = value;
                    OnPropertyChanged(() => ActivityEventCategory, false);
                }
            }
        }


    }

    [DataContract]
    public class UnacknowledgeAlarmEventParameters : ObjectBase
    {
        /// <summary>   The unique UID. </summary>
        private Guid _UniqueUid;
        /// <summary>   The activity event UID. </summary>
        private Guid _ActivityEventUid;
        /// <summary>   Category the panel activity event belongs to. </summary>
        private PanelActivityEventCategory panelActivityEventCategory;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique UID. </summary>
        ///
        /// <value> The unique UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid UniqueUid
        {
            get { return _UniqueUid; }
            set
            {
                if (_UniqueUid != value)
                {
                    _UniqueUid = value;
                    OnPropertyChanged(() => UniqueUid, false);
                }
            }
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the activity event UID. </summary>
        ///
        /// <value> The activity event UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ActivityEventUid
        {
            get { return _ActivityEventUid; }
            set
            {
                if (_ActivityEventUid != value)
                {
                    _ActivityEventUid = value;
                    OnPropertyChanged(() => ActivityEventUid, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category the activity event belongs to. </summary>
        ///
        /// <value> The activity event category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PanelActivityEventCategory ActivityEventCategory
        {
            get { return panelActivityEventCategory; }
            set
            {
                if (panelActivityEventCategory != value)
                {
                    panelActivityEventCategory = value;
                    OnPropertyChanged(() => ActivityEventCategory, false);
                }
            }
        }


    }
}
