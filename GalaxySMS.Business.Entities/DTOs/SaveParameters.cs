using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Business.Entities
{
    public class SaveParameters : ISaveParameters
    {
        public SaveParameters()
        {

        }

        public SaveParameters(ISaveParameters p)
        {
            OperationUid = p.OperationUid;
            SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            SavePhoto = false;
            ThrowExceptionIfDuplicate = true;
        }

        public SaveParameters(IGetParametersBase p)
        {
            OperationUid = p.OperationUid;
            SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            SavePhoto = false;
            ThrowExceptionIfDuplicate = true;
        }
        public Guid OperationUid { get; set; }

        public Guid SessionId { get; set; }
        public Guid CurrentEntityId { get; set; }
        public Guid CurrentSiteUid { get; set; }
        public DateTimeOffset RequestDateTime { get; set; }
        public bool SavePhoto { get; set; }
        public bool ThrowExceptionIfDuplicate { get; set; }

    }
    public class SaveParameters<T> : SaveParameters, ISaveParameters<T> where T : class, new()
    {
        public SaveParameters() : base()
        {
            Data = new T();
        }

        public SaveParameters(IGetParametersBase p) : base(p)
        {
            //SessionId = p.SessionId;
            //CurrentEntityId = p.CurrentEntityId;
            //CurrentSiteUId = p.CurrentSiteUId;
            //RequestDateTime = p.RequestDateTime;
            //SavePhoto = false;
            Data = new T();
            //ThrowExceptionIfDuplicate = true;
        }

        public SaveParameters(ISaveParameters p) : base(p)
        {
            //SessionId = p.SessionId;
            //CurrentEntityId = p.CurrentEntityId;
            //CurrentSiteUId = p.CurrentSiteUId;
            //RequestDateTime = p.RequestDateTime;
            //SavePhoto = p.SavePhoto;
            Data = new T();
            //ThrowExceptionIfDuplicate = true;
        }

        public SaveParameters(T data, IGetParametersBase p) : base(p)
        {
            //SessionId = p.SessionId;
            //CurrentEntityId = p.CurrentEntityId;
            //CurrentSiteUId = p.CurrentSiteUId;
            //RequestDateTime = p.RequestDateTime;
            //SavePhoto = false;
            Data = data;
            //ThrowExceptionIfDuplicate = true;
        }

        public SaveParameters(T data, ISaveParameters p) : base(p)
        {
            //SessionId = p.SessionId;
            //CurrentEntityId = p.CurrentEntityId;
            //CurrentSiteUId = p.CurrentSiteUId;
            //RequestDateTime = p.RequestDateTime;
            //SavePhoto = p.SavePhoto;
            Data = data;
            //ThrowExceptionIfDuplicate = true;
        }

        public T Data { get; set; }
        //public Guid SessionId { get; set; }
        //public Guid CurrentEntityId { get; set; }
        //public Guid CurrentSiteUId { get; set; }
        //public DateTimeOffset RequestDateTime { get; set; }
        //public bool SavePhoto { get; set; }
        //public bool ThrowExceptionIfDuplicate { get; set; }
    }
}
