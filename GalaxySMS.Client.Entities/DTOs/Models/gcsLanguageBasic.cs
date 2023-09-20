using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class gcsLanguageBasic //: EntityBaseSimple
    {

        [DataMember]
        public System.Guid LanguageId { get; set; }

        [DataMember]
        public string CultureName { get; set; }

        [DataMember]
        public string LanguageName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDisplay { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public byte[] FlagImage { get; set; }

        [DataMember]
        public Nullable<int> DisplayOrder { get; set; }
    }
}
