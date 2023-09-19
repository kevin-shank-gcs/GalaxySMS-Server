using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    public enum TemplateFieldTypeId :int {Text=1, Photograph, Signature, Numeric, Date, IssuanceNumber}
    public class TemplateFieldType
    {
        public int ID { get; set; }
        public string Name_en { get; set; }
        public string Name_fr { get; set; }

    }
}
