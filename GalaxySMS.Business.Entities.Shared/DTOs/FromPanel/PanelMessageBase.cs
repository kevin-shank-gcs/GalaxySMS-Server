using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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

    public class PanelMessageBase : BoardSectionNodeHardwareAddress //INotifyPropertyChanged
    {
        public PanelMessageBase()
        {
            SessionIdsToSendTo = new List<Guid>();
            CreatedDateTime = DateTimeOffset.Now;
        }

        public PanelMessageBase(PanelMessageBase o) : base(o)
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
                OperationUid = o.OperationUid;
            }
            else
            {
                SessionIdsToSendTo = new List<Guid>();
                CreatedDateTime = DateTimeOffset.Now;
                IpAddress = string.Empty;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 SecondsFromBeginningOfWeek { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 Sequence { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int16 Distribute { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AckNack AckNack { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte[] RawData { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> SessionIdsToSendTo { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset CreatedDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string IpAddress { get; set; }

        //#region INotifyPropertyChanged Members

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    var deleg = PropertyChanged;
        //    if (deleg != null)
        //    {
        //        deleg(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        //// Pre .NET v4.5 technique
        ////public void NotifyPropertyChanged(String info)
        ////{
        ////    if (PropertyChanged != null)
        ////    {
        ////        PropertyChanged(this, new PropertyChangedEventArgs(info));
        ////    }
        ////}
        //#endregion

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class PanelMessageBaseSimple : CpuHardwareAddressSimple //INotifyPropertyChanged
    {
        public PanelMessageBaseSimple()
        {
            SessionIdsToSendTo = new List<Guid>();
            //CreatedDateTime = DateTimeOffset.UtcNow;
        }
        public PanelMessageBaseSimple(PanelMessageBase o) : base(o)
        {
            if (o != null)
            {
                //SecondsFromBeginningOfWeek = o.SecondsFromBeginningOfWeek;
                //Sequence = o.Sequence;
                AckNack = o.AckNack;
                //RawData = o.RawData;
                SessionIdsToSendTo = o.SessionIdsToSendTo.ToList();
                //CreatedDateTime = o.CreatedDateTime;
                //IpAddress = o.IpAddress;
                OperationUid = o.OperationUid;
            }
            else
            {
                SessionIdsToSendTo = new List<Guid>();
                //CreatedDateTime = DateTimeOffset.UtcNow;
                //IpAddress = string.Empty;
            }
        }


        public PanelMessageBaseSimple(PanelMessageBaseSimple o) : base(o)
        {
            if (o != null)
            {
                //SecondsFromBeginningOfWeek = o.SecondsFromBeginningOfWeek;
                //Sequence = o.Sequence;
                AckNack = o.AckNack;
                //RawData = o.RawData;
                SessionIdsToSendTo = o.SessionIdsToSendTo.ToList();
                //CreatedDateTime = o.CreatedDateTime;
                //IpAddress = o.IpAddress;
                OperationUid = o.OperationUid;
            }
            else
            {
                SessionIdsToSendTo = new List<Guid>();
                //CreatedDateTime = DateTimeOffset.UtcNow;
                //IpAddress = string.Empty;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AckNack AckNack { get; set; }

        public bool Successful => AckNack == AckNack.Ack;

#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> SessionIdsToSendTo { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public DateTimeOffset CreatedDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string IpAddress { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

    }

}
