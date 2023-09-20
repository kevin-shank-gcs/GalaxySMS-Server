using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{

    [DataContract]
    public class DataPacketBase : EntityBase
    {
        public DataPacketBase() :base()
        {
            DateTimeCreated = DateTimeOffset.Now;
            WhichDirection = DataDirection.Unknown;
        }

        public DataPacketBase(DataPacketBase p) : base(p)
        {
            if (p != null)
            {
                DateTimeCreated = p.DateTimeCreated;
                WhichDirection = p.WhichDirection;
            }
            else
            {
                DateTimeCreated = DateTimeOffset.Now;
                WhichDirection = DataDirection.Unknown;
            }
        }

        
        [DataMember]
        public DateTimeOffset DateTimeCreated { get; set; }

        [DataMember]
        public DataDirection WhichDirection { get; set; }

    }
}
