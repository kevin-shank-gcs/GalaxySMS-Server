using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    public class PreviewData //: ResponseBase
    {
        public string FrontPreviewImage { get; set; }
        public string BackPreviewImage { get; set; }
    }


    public class PreviewDataResponse
    {
        public string[] Base64Images { get; set; }
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorCodeStr { get; set; }
        public string ErrorMessage { get; set; }
        public string UserWhoMadeCall { get; set; }
    }

}
