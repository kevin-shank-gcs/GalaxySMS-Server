////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\ActivityHistoryEventSearchParameters.cs
//
// summary:	Implements the activity history event search parameters class
///=================================================================================================

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
    /// <summary>   An activity history event search parameters. </summary>
    ///
    /// <seealso cref="T:GalaxySMS.Client.Entities.GetParameters"/>
    ///=================================================================================================

    [DataContract]
    public class ActivityHistoryEventSearchParameters : GetParameters
    {

        /// <summary>   Default constructor. </summary>
        public ActivityHistoryEventSearchParameters()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="o">    The ActivityHistoryEventSearchParameters to process. </param>
        ///=================================================================================================

        public ActivityHistoryEventSearchParameters(ActivityHistoryEventSearchParameters o) : base(o)
        {
            if (o != null)
            {
//                CurrentEntityId = o.CurrentEntityId;
                AccessPortalUid = o.AccessPortalUid;
                GalaxyPanelUid = o.GalaxyPanelUid;
                InputDeviceUid =o.InputDeviceUid;
                OutputDeviceUid = o.OutputDeviceUid;
                IncludeLoggingOnOffEvents = o.IncludeLoggingOnOffEvents;
                //PersonUid = o.PersonUid;
                CredentialUid = o.CredentialUid;
                StartDateTime = o.StartDateTime;
                EndDateTime = o.EndDateTime;
                //PageNumber = o.PageNumber;
                //PageSize = o.PageSize;
                MaxResults = o.MaxResults;
                LanguageUid =o.LanguageUid;
            }
        }

        //public void Init()
        //{
        //    base.Init();
        //}

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid CurrentEntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal UID. </summary>
        ///
        /// <value> The access portal UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid AccessPortalUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel UID. </summary>
        ///
        /// <value> The galaxy panel UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid GalaxyPanelUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input device UID. </summary>
        ///
        /// <value> The input device UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid InputDeviceUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the output device UID. </summary>
        ///
        /// <value> The output device UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid OutputDeviceUid { get; set; }

        //[DataMember]
        //public Guid PersonUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential UID. </summary>
        ///
        /// <value> The credential UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid CredentialUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the logging on off events should be included.
        /// </summary>
        ///
        /// <value> True if include logging on off events, false if not. </value>
        ///=================================================================================================

        [DataMember]
        public bool IncludeLoggingOnOffEvents { get; set; }

        //[DataMember]
        //public int PageNumber { get; set; }

        //[DataMember]
        //public int PageSize { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the maximum results. </summary>
        ///
        /// <value> The maximum results. </value>
        ///=================================================================================================

        [DataMember]
        public int MaxResults { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the language UID. </summary>
        ///
        /// <value> The language UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid LanguageUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the start date time. </summary>
        ///
        /// <value> The start date time. </value>
        ///=================================================================================================

        [DataMember]
        public DateTimeOffset StartDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the end date time. </summary>
        ///
        /// <value> The end date time. </value>
        ///=================================================================================================

        [DataMember]
        public DateTimeOffset EndDateTime { get; set; }


    }
}
