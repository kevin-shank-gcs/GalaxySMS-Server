////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\PersonSearchParameters.cs
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

#if NetCoreApi
#else
    [DataContract]
#endif
    public class ActivityHistoryEventSearchParameters : GetParameters
    {
        public ActivityHistoryEventSearchParameters()
        {
            EventTypeUids = new HashSet<Guid>();
            Priorities = new HashSet<int>();
        }

        public ActivityHistoryEventSearchParameters(ActivityHistoryEventSearchParameters o) : base(o)
        {
            if (o != null)
            {
                AccessPortalUid = o.AccessPortalUid;
                GalaxyPanelUid = o.GalaxyPanelUid;
                InputDeviceUid = o.InputDeviceUid;
                OutputDeviceUid = o.OutputDeviceUid;
                IncludeLoggingOnOffEvents = o.IncludeLoggingOnOffEvents;
                CredentialUid = o.CredentialUid;
                StartDateTime = o.StartDateTime;
                EndDateTime = o.EndDateTime;
                MaxResults = o.MaxResults;
                LanguageUid = o.LanguageUid;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CurrentEntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid UserId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OutputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IncludeLoggingOnOffEvents { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageSize { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxResults { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid LanguageUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
//        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
//        public DateTimeOffset EndDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> EventTypeUids { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAcknowledgeable { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActionRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsTraced { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int StartPriority { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int EndPriority { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<int> Priorities { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool JustNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SortProperty { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool DescendingOrder { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ForCurrentUser  { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IncludeAcknowlegements { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class EventSearchParameters
    {
        public EventSearchParameters()
        {
            EventTypeUids = new HashSet<Guid>();
            Priorities = new HashSet<int>();
        }

        public EventSearchParameters(EventSearchParameters o) 
        {
            if (o != null)
            {
                SortBy = o.SortBy;
                OrderBy= o.OrderBy;
                PageNumber = o.PageNumber;
                PageSize = o.PageSize;
                StartDateTime = o.StartDateTime;
                EndDateTime = o.EndDateTime;
                ClusterUid = o.ClusterUid;
                DeviceUid = o.DeviceUid;
                PersonUid = o.PersonUid;
                EventTypeUids = o.EventTypeUids;
                IsAcknowledgeable = o.IsAcknowledgeable;
                IsActionRequired = o.IsActionRequired;
                IsTraced = o.IsTraced;
                StartPriority = o.StartPriority;
                EndPriority = o.EndPriority;
                Priorities = o.Priorities;
                JustNumber = o.JustNumber;
                StartDateTime = o.StartDateTime;
                EndDateTime = o.EndDateTime;
                IncludeLoggingOnOffEvents = o.IncludeLoggingOnOffEvents;
                IncludeAcknowledgements = o.IncludeAcknowledgements;
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

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid AccessPortalUid { get; set; }


//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid GalaxyPanelUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid InputDeviceUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid OutputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid CredentialUid { get; set; }

#if NetCoreApi
#else
                [DataMember]
#endif
        public bool IncludeLoggingOnOffEvents { get; set; }


#if NetCoreApi
#else
                [DataMember]
#endif
        public bool IncludeAcknowledgements { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int MaxResults { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid LanguageUid { get; set; }

#if NetCoreApi
        //[CompareDates(nameof(EndDateTime))]
#else
        [DataMember]
#endif
        //public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }

#if NetCoreApi
        [CompareDates(nameof(StartDateTime))]
#else
        [DataMember]
#endif
        //        public DateTimeOffset EndDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> EventTypeUids { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAcknowledgeable { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActionRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsTraced { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int StartPriority { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int EndPriority { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<int> Priorities { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool JustNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageSize { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ActivityHistoryEventSortOrder SortBy { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public OrderBy OrderBy { get; set; }
        
    }
}
