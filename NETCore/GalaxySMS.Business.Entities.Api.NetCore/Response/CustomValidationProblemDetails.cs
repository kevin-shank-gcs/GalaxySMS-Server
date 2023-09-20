using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities.Api.NetCore.Response
{


    public class CustomValidationProblemDetails
    {
        public object errors { get; set; }
        public string title { get; set; }
        public int status { get; set; }
    }

}
