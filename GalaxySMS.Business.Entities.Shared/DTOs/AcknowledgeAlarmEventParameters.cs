////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AcknowledgeAlarmEventParameters.cs
//
// summary:	Implements the person search parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An acknowledge alarm event parameters. </summary>
    ///
    /// <remarks>   Kevin, 4/29/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public class AcknowledgeAlarmEventParameters
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AcknowledgeAlarmEventParameters()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ///
        /// <param name="o">    The AcknowledgeAlarmEventParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AcknowledgeAlarmEventParameters(AcknowledgeAlarmEventParameters o)
        {
            if (o != null)
            {
                AlarmEventAcknowledgmentUid = o.AlarmEventAcknowledgmentUid;
                ActivityEventUid = o.ActivityEventUid;
                Response = o.Response;
                ActivityEventCategory = o.ActivityEventCategory;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this AcknowledgeAlarmEventParameters. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique UID of the acknowledgement record. </summary>
        ///
        /// <value> The unique UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AlarmEventAcknowledgmentUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the activity event UID. </summary>
        ///
        /// <value> The activity event UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ActivityEventUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the response. </summary>
        ///
        /// <value> The response. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        [MaxLength(1000)]
        public string Response { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category the activity event belongs to. </summary>
        ///
        /// <value> The activity event category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelActivityEventCategory ActivityEventCategory {get;set;}

    }
#if NetCoreApi
#else
    [DataContract]
#endif
    public class UnacknowledgeAlarmEventParameters
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UnacknowledgeAlarmEventParameters()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ///
        /// <param name="o">    The AcknowledgeAlarmEventParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UnacknowledgeAlarmEventParameters(UnacknowledgeAlarmEventParameters o)
        {
            if (o != null)
            {
                AlarmEventAcknowledgmentUid = o.AlarmEventAcknowledgmentUid;
                ActivityEventUid = o.ActivityEventUid;
                ActivityEventCategory = o.ActivityEventCategory;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this AcknowledgeAlarmEventParameters. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique UID of the acknowledgement record. </summary>
        ///
        /// <value> The unique UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AlarmEventAcknowledgmentUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the activity event UID. </summary>
        ///
        /// <value> The activity event UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ActivityEventUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category the activity event belongs to. </summary>
        ///
        /// <value> The activity event category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelActivityEventCategory ActivityEventCategory { get; set; }

    }
}
