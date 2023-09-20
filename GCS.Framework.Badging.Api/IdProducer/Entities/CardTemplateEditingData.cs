using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    public class CardTemplateEditingData
    {
        public CardTemplateEditingData()
        {
            TemplateName = String.Empty;;
            TemplateContent = string.Empty;
            TemplateFields = new List<SubscriptionTemplateField>();
            TemplateFieldFormats =new List<TemplateFieldFormat>();
        }
        public string TemplateName {get;set;}
        public string TemplateContent { get; set; }
        public IEnumerable<SubscriptionTemplateField> TemplateFields { get; set; }
        public IEnumerable<TemplateFieldFormat> TemplateFieldFormats { get; set; }
        public string TemplateFieldsString {get;set;}
        public string TemplateFieldFormatsString {get;set;}
        
    }
}
