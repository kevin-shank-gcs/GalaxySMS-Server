using GCS.Core.Common.Contracts;
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
    public interface ISendDataParameters
    {
        //Guid SessionId { get; set; }
        DateTimeOffset RequestDateTime { get; set; }
        BoardSectionNodeHardwareAddress SendToAddress { get; set; }
        IApplicationUserSessionDataHeader ApplicationUserSessionHeader { get; set; }
        Guid OperationUid { get; set; }
        bool NotifySignalRSession { get; set; }
    }

    public interface ISendDataParameters<T> : ISendDataParameters where T : class, new()
    {
        T Data { get; set; }
        bool PopulateDataFromDatabase { get; set; }
        IList<T> Collection { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SendDataParameters : ISendDataParameters
    {
        public SendDataParameters()
        {
            Initialize();
        }

        public SendDataParameters(ISendDataParameters p)
        {
            Initialize();
            if (p != null)
            {
                this.RequestDateTime = p.RequestDateTime;
                //this.SessionId = p.SessionId;
                if (p.SendToAddress != null)
                    this.SendToAddress = new BoardSectionNodeHardwareAddress(p.SendToAddress);
                this.ApplicationUserSessionHeader = p.ApplicationUserSessionHeader;
                this.OperationUid = p.OperationUid;
                this.NotifySignalRSession = p.NotifySignalRSession;
            }
        }

        private void Initialize()
        {
            //SessionId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            SendToAddress = new BoardSectionNodeHardwareAddress();
            ApplicationUserSessionHeader = null;
        }

        #region Implementation of ISendDataParameters

        //[DataMember]
        //public Guid SessionId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset RequestDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public BoardSectionNodeHardwareAddress SendToAddress { get; set; }

        // This is not a DataMember. It does not come from the WCF client. This is only used when the object originates from another WCF service
        // such as in the case of a CRUD service creating the object and passing its session header along with the object
        public IApplicationUserSessionDataHeader ApplicationUserSessionHeader { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool NotifySignalRSession { get; set; }

        public List<Guid> GetGuidsToSendTo()
        {
            var list = new List<Guid>();
            if (ApplicationUserSessionHeader != null && ApplicationUserSessionHeader.SessionGuid != Guid.Empty && NotifySignalRSession)
                list.Add(ApplicationUserSessionHeader.SessionGuid);
            if( OperationUid != Guid.Empty)
                list.Add(OperationUid);
            return list;
        }
        #endregion
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SendDataParameters<T> : SendDataParameters, ISendDataParameters<T> where T : class, new()
    {
        public SendDataParameters() : base()
        {
            Data = new T();
            PopulateDataFromDatabase = true;
            Collection = new List<T>();
        }

        public SendDataParameters(ISendDataParameters p) : base(p)
        {
            Data = new T();
            PopulateDataFromDatabase = true;
            Collection = new List<T>();
        }

        public SendDataParameters(T data, ISendDataParameters p) : base(p)
        {
            Data = data;
            PopulateDataFromDatabase = true;
            Collection = new List<T>();
        }

        public SendDataParameters(ISendDataParameters<T> p) : base(p)
        {
            Data = p.Data;
            PopulateDataFromDatabase = p.PopulateDataFromDatabase;
            Collection = p.Collection.ToList();
        }

        public SendDataParameters(IEnumerable<T> collection, ISendDataParameters p) : base(p)
        {
            Collection = collection.ToList();
            PopulateDataFromDatabase = true;
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
        public IList<T> Collection { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PopulateDataFromDatabase { get; set; }
    }

}
