using GalaxySMS.Common.Enums;
using System;

namespace GalaxySMS.Api.Models.RequestModels
{

    public class ActivityHistoryEventSearchParametersReq// : GetParameters
    {
        public ActivityHistoryEventSearchParametersReq()
        {

        }

        public ActivityHistoryEventSearchParametersReq(ActivityHistoryEventSearchParametersReq o) //: base(o)
        {
            if (o != null)
            {
                //PersonUid = o.PersonUid;
                //AccessPortalUid = o.AccessPortalUid;
                //GalaxyPanelUid = o.GalaxyPanelUid;
                //InputDeviceUid =o.InputDeviceUid;
                //OutputDeviceUid = o.OutputDeviceUid;
                //IncludeLoggingOnOffEvents = o.IncludeLoggingOnOffEvents;
                //CredentialUid = o.CredentialUid;
                StartDateTime = o.StartDateTime;
                EndDateTime = o.EndDateTime;
                PageNumber = o.PageNumber;
                PageSize = o.PageSize;
                MaxResults = o.MaxResults;
                LanguageUid = o.LanguageUid;
                CurrentEntityId = o.CurrentEntityId;
                OrderBy = o.OrderBy;
            }
        }

        public Guid CurrentEntityId { get; set; }

        //public Guid AccessPortalUid { get; set; }

        //public Guid GalaxyPanelUid { get; set; }

        //public Guid InputDeviceUid { get; set; }

        //public Guid OutputDeviceUid { get; set; }

        //public Guid PersonUid { get; set; }

        //public Guid CredentialUid { get; set; }

        //public bool IncludeLoggingOnOffEvents { get; set; }
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int MaxResults { get; set; }

        public Guid LanguageUid { get; set; }

        public DateTimeOffset StartDateTime { get; set; }

        public DateTimeOffset EndDateTime { get; set; }

        public OrderBy OrderBy { get; set; } = OrderBy.Asc;

    }

    public class AccessPortalActivityHistoryEventSearchParametersReq : ActivityHistoryEventSearchParametersReq
    {
        public AccessPortalActivityHistoryEventSearchParametersReq()
        {

        }

        public AccessPortalActivityHistoryEventSearchParametersReq(AccessPortalActivityHistoryEventSearchParametersReq o) : base(o)
        {
            if (o != null)
            {
                PersonUid = o.PersonUid;
                AccessPortalUid = o.AccessPortalUid;
                CredentialUid = o.CredentialUid;
                SortBy = o.SortBy;
            }
        }

        public Guid AccessPortalUid { get; set; }

        public Guid PersonUid { get; set; }

        public Guid CredentialUid { get; set; }

        public AccessPortalEventSortProperty SortBy { get; set; } = AccessPortalEventSortProperty.ActivityDateTime;
    }

    public class GalaxyPanelActivityHistoryEventSearchParametersReq : ActivityHistoryEventSearchParametersReq
    {
        public GalaxyPanelActivityHistoryEventSearchParametersReq()
        {

        }

        public GalaxyPanelActivityHistoryEventSearchParametersReq(GalaxyPanelActivityHistoryEventSearchParametersReq o) : base(o)
        {
            if (o != null)
            {
                GalaxyPanelUid = o.GalaxyPanelUid;
                IncludeLoggingOnOffEvents = o.IncludeLoggingOnOffEvents;
                SortBy = o.SortBy;
            }
        }

        public Guid GalaxyPanelUid { get; set; }

        public bool IncludeLoggingOnOffEvents { get; set; }
        public GalaxyPanelEventSortProperty SortBy { get; set; } = GalaxyPanelEventSortProperty.ActivityDateTime;

    }
    public class MercScpActivityHistoryEventSearchParametersReq : ActivityHistoryEventSearchParametersReq
    {
        public MercScpActivityHistoryEventSearchParametersReq()
        {

        }

        public MercScpActivityHistoryEventSearchParametersReq(MercScpActivityHistoryEventSearchParametersReq o) : base(o)
        {
            if (o != null)
            {
                MercScpUid = o.MercScpUid;
                IncludeLoggingOnOffEvents = o.IncludeLoggingOnOffEvents;
                SortBy = o.SortBy;
            }
        }

        public Guid MercScpUid { get; set; }

        public bool IncludeLoggingOnOffEvents { get; set; }
        public MercScpEventSortProperty SortBy { get; set; } = MercScpEventSortProperty.ActivityDateTime;

    }

    public class InputDeviceActivityHistoryEventSearchParametersReq : ActivityHistoryEventSearchParametersReq
    {
        public InputDeviceActivityHistoryEventSearchParametersReq()
        {

        }

        public InputDeviceActivityHistoryEventSearchParametersReq(InputDeviceActivityHistoryEventSearchParametersReq o) : base(o)
        {
            if (o != null)
            {
                InputDeviceUid = o.InputDeviceUid;
                SortBy = o.SortBy;
            }
        }

        public Guid InputDeviceUid { get; set; }
        public InputDeviceEventSortProperty SortBy { get; set; } = InputDeviceEventSortProperty.ActivityDateTime;

    }

    public class OutputDeviceActivityHistoryEventSearchParametersReq : ActivityHistoryEventSearchParametersReq
    {
        public OutputDeviceActivityHistoryEventSearchParametersReq()
        {

        }

        public OutputDeviceActivityHistoryEventSearchParametersReq(OutputDeviceActivityHistoryEventSearchParametersReq o) : base(o)
        {
            if (o != null)
            {
                OutputDeviceUid = o.OutputDeviceUid;
                SortBy = o.SortBy;
            }
        }

        public Guid OutputDeviceUid { get; set; }
        public OutputDeviceEventSortProperty SortBy { get; set; } = OutputDeviceEventSortProperty.ActivityDateTime;

    }

}
