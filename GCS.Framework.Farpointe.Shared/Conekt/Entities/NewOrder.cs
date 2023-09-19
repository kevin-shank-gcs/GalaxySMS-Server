using System;
using System.Collections.Generic;
using System.Text;

namespace GCS.Framework.Farpointe.Conekt.Entities
{

    //public enum FormatNames
    //{
    //    26BitWiegand,
    //    FH10301,
    //    FH10313Q,
    //    FH10302,
    //    FH10304,
    //    Galaxy34,
    //    Galaxy48,
    //    Galaxy40
    //}

    public class NewOrder
    {
        public string configurationSettingsId { get; set; }
        public int credentialCount { get; set; }
        public string purchaseOrder { get; set; }
        public string formatName { get; set; }
        public CredentialData credentialContents { get; set; }
    }

    public class CredentialData
    {
        public int startIndex { get; set; }
        public int Prefix { get; set; }
    }


    public class NewOrderResponse
    {
        public int orderId { get; set; }
    }

}
