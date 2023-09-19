using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using System.Runtime.CompilerServices;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
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
            }
            else
            {
                SessionIdsToSendTo = new List<Guid>();
                CreatedDateTime = DateTimeOffset.Now;
            }
        }

        [DataMember]
        public Int32 SecondsFromBeginningOfWeek { get; set; }

        [DataMember]
        public Int32 Sequence { get; set; }

        [DataMember]
        public Int16 Distribute { get; set; }

        [DataMember]
        public AckNack AckNack { get; set; }

        [DataMember]
        public Byte[] RawData { get; set; }

        [DataMember]
        public List<Guid> SessionIdsToSendTo { get; set; }

        [DataMember]
        public DateTimeOffset CreatedDateTime { get; set; }
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
    }
}
