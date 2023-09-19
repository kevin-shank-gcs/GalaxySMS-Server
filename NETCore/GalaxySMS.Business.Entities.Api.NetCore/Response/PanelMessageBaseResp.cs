using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class PanelMessageBaseResp : BoardSectionNodeHardwareAddressResp //INotifyPropertyChanged
    {
        public PanelMessageBaseResp()
        {
            SessionIdsToSendTo = new List<Guid>();
            CreatedDateTime = DateTimeOffset.Now;
        }

        public PanelMessageBaseResp(PanelMessageBaseResp o) : base(o)
        {
            if (o != null)
            {
                SecondsFromBeginningOfWeek = o.SecondsFromBeginningOfWeek;
                Sequence = o.Sequence;
                AckNack = o.AckNack;
                RawData = o.RawData;
                SessionIdsToSendTo = o.SessionIdsToSendTo.ToList();
                CreatedDateTime = o.CreatedDateTime;
                IpAddress = o.IpAddress;
            }
            else
            {
                SessionIdsToSendTo = new List<Guid>();
                CreatedDateTime = DateTimeOffset.Now;
                IpAddress = string.Empty;
            }
        }
        public Int32 SecondsFromBeginningOfWeek { get; set; }
        public Int32 Sequence { get; set; }
        public Int16 Distribute { get; set; }
        public AckNack AckNack { get; set; }
        public Byte[] RawData { get; set; }
        public List<Guid> SessionIdsToSendTo { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string IpAddress { get; set; }
    }
}
