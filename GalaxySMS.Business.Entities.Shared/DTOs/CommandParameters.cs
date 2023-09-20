using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

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
	public class CommandParameters : ICommandParameters
    {
        public CommandParameters()
        {

        }

        public CommandParameters(ICommandParameters p)
        {
            OperationUid = p.OperationUid;
            BackgroundJobId = p.BackgroundJobId;
            //SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            DoNotValidateAuthorization = p.DoNotValidateAuthorization;
            if (p.Parameters != null)
                Parameters = p.Parameters.ToList();
        }

        public CommandParameters(ICallParametersBase p)
        {
            OperationUid = p.OperationUid;
            BackgroundJobId = p.BackgroundJobId;
            //SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            DoNotValidateAuthorization = p.DoNotValidateAuthorization;
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif 
        public Guid BackgroundJobId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SessionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CurrentEntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CurrentSiteUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset RequestDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<KeyValuePair<string, string>> Parameters { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool DoNotValidateAuthorization { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool NotifySignalRSession { get; set; }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class CommandParameters<T> : CommandParameters, ICommandParameters<T> where T : class, new()
    {
        public CommandParameters() : base()
        {
            Data = new T();
        }

        public CommandParameters(ICallParametersBase p) : base(p)
        {
            Data = new T();
        }

        public CommandParameters(ICommandParameters p) : base(p)
        {
            Data = new T();
        }

        public CommandParameters(ICommandParameters p, T data) : base(p)
        {
            Data = data;
        }
        public CommandParameters(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public T Data { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class CommandResponse : ICommandResponse
    {
        public CommandResponse()
        {

        }

        public CommandResponse(ICommandParameters p)
        {
            OperationUid = p.OperationUid;
            //SessionId = p.SessionId;
            //CurrentEntityId = p.CurrentEntityId;
            //CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            //DoNotValidateAuthorization = p.DoNotValidateAuthorization;
            if (p.Parameters != null)
                Parameters = p.Parameters.ToList();
            PanelsSentTo = new HashSet<PanelCommandResponseInfo>();
        }

        public CommandResponse(ICallParametersBase p)
        {
            OperationUid = p.OperationUid;
            //SessionId = p.SessionId;
            //CurrentEntityId = p.CurrentEntityId;
            //CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            //DoNotValidateAuthorization = p.DoNotValidateAuthorization;
            PanelsSentTo = new HashSet<PanelCommandResponseInfo>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid SessionId { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid CurrentEntityId { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid CurrentSiteUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset RequestDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<KeyValuePair<string, string>> Parameters { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public bool DoNotValidateAuthorization { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int ApproximateDuration { get; set; } = 5;


#if NetCoreApi
#else
        [DataMember]
#endif
        public int TimeoutSeconds { get; set; } = 1;

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PanelCommandResponseInfo> PanelsSentTo { get; set; }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class PanelCommandResponseInfo
    {
        public PanelCommandResponseInfo()
        {
            Cpus = new HashSet<CpuCommandResponseInfo>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsPanelOnline { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CpuCommandResponseInfo> Cpus { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class CpuCommandResponseInfo
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsCpuOnline { get; set; }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class CommandResponse<T> : CommandResponse, ICommandResponse<T> where T : class, new()
    {
        public CommandResponse() : base()
        {
            Data = new T();
        }

        public CommandResponse(ICallParametersBase p) : base(p)
        {
            Data = new T();
        }

        public CommandResponse(ICommandParameters p) : base(p)
        {
            Data = new T();
        }

        public CommandResponse(ICommandParameters p, T data) : base(p)
        {
            Data = data;
        }
        public CommandResponse(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public T Data { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class LoadDataCommandResponse<T> : CommandResponse, ICommandResponse<T> where T : class, new()
    {
        public LoadDataCommandResponse() : base()
        {
            Data = new T();
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }

        public LoadDataCommandResponse(ICallParametersBase p) : base(p)
        {
            Data = new T();
        }

        public LoadDataCommandResponse(ICommandParameters p) : base(p)
        {
            Data = new T();
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }

        public LoadDataCommandResponse(ICommandParameters p, T data) : base(p)
        {
            Data = data;
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }
        public LoadDataCommandResponse(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
            NotificationCounts = new LoadDataToPanelNotificationCounts();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public T Data { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public LoadDataToPanelNotificationCounts NotificationCounts { get; set; }
    }

}
