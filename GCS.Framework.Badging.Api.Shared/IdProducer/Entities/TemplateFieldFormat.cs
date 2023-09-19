using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    //public class TemplateFieldFormat
    //{
    //    public int ID { get; set; }
    //    public int TemplateFieldTypeID { get; set; }
    //    public string Name_en { get; set; }
    //    public string Name_fr { get; set; }
    //    public string FormatData { get; set; }
    //}

    public class TemplateFieldFormatResponse
    {
        public TemplateFieldFormat[] TemplateFieldFormats { get; set; }
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorCodeStr { get; set; }
        public string ErrorMessage { get; set; }
        public string UserWhoMadeCall { get; set; }
    }

    public class TemplateFieldFormat
    {
        public int ID { get; set; }
        public int TemplateFieldTypeID { get; set; }
        public string Name_en { get; set; }
        public string Name_fr { get; set; }
        public string FormatData { get; set; }
        public bool MarkedForDeletion { get; set; }
    }

}
