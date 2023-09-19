using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class gcsEntityBasic 
    {
        [DataMember]
        public System.Guid EntityId { get; set; }

        [DataMember]
        public string EntityName { get; set; }

        [DataMember]
        public string EntityDescription { get; set; }

        [DataMember]
        public string EntityKey { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public bool IsActive { get; set; }


        //[DataMember]
        public string Name { get { return EntityName; } set { EntityName = value; } }

        [DataMember]
        public byte[] Photo { get; set; }

        [DataMember]
        public Nullable<System.Guid> ParentEntityId { get; set; }

        [DataMember]
        public string ParentEntityName {get;set;}

        [DataMember]
        public ICollection<gcsEntityBasic> ChildEntities { get; set; }
    }

}
