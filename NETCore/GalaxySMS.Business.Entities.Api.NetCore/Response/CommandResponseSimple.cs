using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities.Api.NetCore;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class CommandResponseSimple //: ICommandResponse
    {
        public CommandResponseSimple()
        {

        }

        public CommandResponseSimple(ICommandParameters p)
        {
            OperationUid = p.OperationUid;
            RequestDateTime = p.RequestDateTime;
            PanelsSentTo = new HashSet<PanelCommandResponseInfo>();
        }

        public CommandResponseSimple(ICallParametersBase p)
        {
            OperationUid = p.OperationUid;
            RequestDateTime = p.RequestDateTime;
            PanelsSentTo = new HashSet<PanelCommandResponseInfo>();
        }

        public CommandResponseSimple(CommandResponse p) : base()
        {
            OperationUid = p.OperationUid;
            RequestDateTime = p.RequestDateTime;
            PanelsSentTo = new HashSet<PanelCommandResponseInfo>();
        }

        public Guid OperationUid { get; set; }

        public DateTimeOffset RequestDateTime { get; set; }
        
        public int ApproximateDuration { get; set; } = 1;

        public int TimeoutSeconds { get; set; } = 1;

        public ICollection<PanelCommandResponseInfo> PanelsSentTo { get; set; }

    }

    public class CommandResponseSimple<T> : CommandResponseSimple where T : class, new()
    {
        public CommandResponseSimple() : base()
        {
            Data = new T();
        }

        public CommandResponseSimple(ICallParametersBase p) : base(p)
        {
            Data = new T();
        }

        public CommandResponseSimple(ICommandParameters p) : base(p)
        {
            Data = new T();
        }

        public CommandResponseSimple(CommandResponse p) : base()
        {

        }

        public CommandResponseSimple(ICommandParameters p, T data) : base(p)
        {
            Data = data;
        }
        public CommandResponseSimple(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
        }

        public T Data { get; set; }
    }

    public class LoadDataCommandResponseSimple<T> : CommandResponseSimple where T : class, new()
    {
        public LoadDataCommandResponseSimple() : base()
        {
            Data = new T();
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }

        public LoadDataCommandResponseSimple(ICallParametersBase p) : base(p)
        {
            Data = new T();
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }

        public LoadDataCommandResponseSimple(ICommandParameters p) : base(p)
        {
            Data = new T();
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }

        public LoadDataCommandResponseSimple(CommandResponse p) : base()
        {
            NotificationCounts = new LoadDataToPanelNotificationCounts();

        }

        public LoadDataCommandResponseSimple(ICommandParameters p, T data) : base(p)
        {
            Data = data;
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }
        public LoadDataCommandResponseSimple(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }

        public T Data { get; set; }
        public LoadDataToPanelNotificationCounts NotificationCounts { get; set; }
    }

}
