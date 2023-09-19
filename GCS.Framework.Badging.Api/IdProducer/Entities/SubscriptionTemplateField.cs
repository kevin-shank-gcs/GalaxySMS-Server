using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    //public class SubscriptionTemplateField
    //{
    //    public int ID { get; set; }
    //    public int SubscriptionID { get; set; }
    //    public int TemplateFieldTypeID { get; set; }
    //    public int? TemplateFieldFormatID { get; set; }
    //    public string FieldName { get; set; }
    //    public string DisplayName { get; set; }
    //    public bool IsRequired { get; set; }
    //    public int MaxLength { get; set; }
    //    public string Value { get; set; }
    //}


    public class SubscriptionTemplateFieldsResponse : MethodResponse
    {
        public SubscriptionTemplateField[] SubscriptionTemplateFields { get; set; }
        //public bool IsSuccessful { get; set; }
        //public int ErrorCode { get; set; }
        //public string ErrorCodeStr { get; set; }
        //public string ErrorMessage { get; set; }
        //public string UserWhoMadeCall { get; set; }
    }


//#if Build2020Mar26

//    public class SubscriptionTemplateField
//    {
//        public int ID { get; set; }
//        public int SubscriptionID { get; set; }
//        public int TemplateFieldTypeID { get; set; }
//        public int? TemplateFieldFormatID { get; set; }
//        public object TableName { get; set; }
//        public string FieldName { get; set; }
//        public string DisplayName { get; set; }
//        // Not supported in 2020Mar26 build
//        //public bool IsRequired { get; set; }
//        public bool IsRequiredForPrinting { get; set; }
//        public bool IsRequiredForSaving { get; set; }
//        public int MaxLength { get; set; }
//        public object FormControlTypeID { get; set; }
//        public object IsProprietary { get; set; }
//        public bool IsSystemField { get; set; }

//        // Not supported in 2020Mar26 build
//        //public bool HideFromTemplateEditor { get; set; }
//        public bool IsReadOnly {get;set;}
//        public bool IsMappedToRemoteField { get; set; }
//        public object[] TemplateFieldValues { get; set; }
//        public object[] TemplateFieldChoices { get; set; }
//        public object[] UserSearchFieldValues { get; set; }
//        public bool MarkedForDeletion { get; set; }
//    }
//#else
    public class SubscriptionTemplateField
    {
        public int ID { get; set; }
        public int SubscriptionID { get; set; }
        public int TemplateFieldTypeID { get; set; }
        public int? TemplateFieldFormatID { get; set; }
        public object TableName { get; set; }
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public bool IsRequired { get; set; }
        public int MaxLength { get; set; }
        public object FormControlTypeID { get; set; }
        public object IsProprietary { get; set; }
        public bool HideFromTemplateEditor { get; set; }
        public bool IsReadOnly {get;set;}
//        public bool IsMappedToRemoveField {get;set;}
        public object[] TemplateFieldValues { get; set; }
        public object[] TemplateFieldChoices { get; set; }
        public object[] UserSearchFieldValues { get; set; }
        public bool MarkedForDeletion { get; set; }
    }

//#endif

}
