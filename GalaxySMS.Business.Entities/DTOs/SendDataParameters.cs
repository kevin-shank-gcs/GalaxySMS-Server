using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Business.Entities
{

    public interface ISendDataParameters
    {
        //Guid SessionId { get; set; }
        DateTimeOffset RequestDateTime { get; set; }
        BoardSectionNodeHardwareAddress SendToAddress { get; set; }
        IApplicationUserSessionDataHeader ApplicationUserSessionHeader { get; set; }
    }

    public interface ISendDataParameters<T> : ISendDataParameters where T : class, new()
    {
        T Data { get; set; }
        bool PopulateDataFromDatabase { get; set; }
        IList<T> Collection { get; set; }
    }

    [DataContract]
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

        [DataMember]
        public DateTimeOffset RequestDateTime { get; set; }

        [DataMember]
        public BoardSectionNodeHardwareAddress SendToAddress { get; set; }

        // This is not a DataMember. It does not come from the WCF client. This is only used when the object originates from another WCF service
        // such as in the case of a CRUD service creating the object and passing its session header along with the object
        public IApplicationUserSessionDataHeader ApplicationUserSessionHeader { get; set; }

        #endregion
    }

    [DataContract]
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

        [DataMember]
        public T Data { get; set; }
        [DataMember]
        public IList<T> Collection { get; set; }
        [DataMember]
        public bool PopulateDataFromDatabase { get; set; }
    }

}
