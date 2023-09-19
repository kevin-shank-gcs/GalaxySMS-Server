using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
                LanguageUid =o.LanguageUid;
                CurrentEntityId = o.CurrentEntityId;
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
            }
        }

        public Guid AccessPortalUid { get; set; }

        public Guid PersonUid { get; set; }
   
        public Guid CredentialUid { get; set; }
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
            }
        }

        public Guid GalaxyPanelUid { get; set; }

        public bool IncludeLoggingOnOffEvents { get; set; }
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
                InputDeviceUid =o.InputDeviceUid;
            }
        }

        public Guid InputDeviceUid { get; set; }
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
                OutputDeviceUid =o.OutputDeviceUid;
            }
        }

        public Guid OutputDeviceUid { get; set; }
    }

}
