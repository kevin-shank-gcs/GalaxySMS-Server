using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    public partial class DayTypeDateValidationError
    {

        [DataMember] public DateTimeOffset Date { get; set; }

        [DataMember] public Guid DayTypeUid { get; set; }

        [DataMember] public string DayTypeName { get; set; }

        [DataMember] public int Index { get; set; }

    }
}
