using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    //public class CardTemplate
    //{
    //    public int ID { get; set; }
    //    public object TemplateImage { get; set; }
    //    public string Base64TemplateImage { get; set; }
    //    public int SubscriptionID { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public bool AutomaticQA { get; set; }
    //    public DateTimeOffset LastModified { get; set; }
    //    public object CardStockID { get; set; }
    //    public bool IsDuplex { get; set; }
    //    public int NbOfColorElementsOnFront { get; set; }
    //    public int NbOfBlackElementsOnfront { get; set; }
    //    public int NbOfColorElementsOnBack { get; set; }
    //    public int NbOfBlackElementsOnBack { get; set; }
    //    public int MagStripeElementLocation { get; set; }
    //    public bool PrePrintedBackgroundFront { get; set; }
    //    public bool PrePrintedBackgroundBack { get; set; }
    //    public bool IsSmartCard { get; set; }
    //    public object CardStockName { get; set; }
    //    public object CardStockSubscriptionCompanyName { get; set; }
    //    public object[] CardTemplateFields { get; set; }
    //    public bool MarkedForDeletion { get; set; }
    //}


    public class CardTemplateResponse
    {
        public CardTemplate CardTemplate { get; set; }
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorCodeStr { get; set; }
        public string ErrorMessage { get; set; }
        public string UserWhoMadeCall { get; set; }
    }

    public class CardTemplate
    {
        public int ID { get; set; }
        public object TemplateImage { get; set; }
        public string Base64TemplateImage { get; set; }
        public int SubscriptionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AutomaticQA { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public object CardStockID { get; set; }
        public bool IsDuplex { get; set; }
        public int NbOfColorElementsOnFront { get; set; }
        public int NbOfBlackElementsOnfront { get; set; }
        public int NbOfColorElementsOnBack { get; set; }
        public int NbOfBlackElementsOnBack { get; set; }
        public int MagStripeElementLocation { get; set; }
        public bool PrePrintedBackgroundFront { get; set; }
        public bool PrePrintedBackgroundBack { get; set; }
        public bool IsSmartCard { get; set; }
        public object CardStockName { get; set; }
        public object CardStockSubscriptionCompanyName { get; set; }
        public object[] CardTemplateFields { get; set; }
        public bool MarkedForDeletion { get; set; }
    }


    public class LoadTemplateResponse
    {
        public string[] Data { get; set; }
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorCodeStr { get; set; }
        public string ErrorMessage { get; set; }
        public string UserWhoMadeCall { get; set; }
    }

}
