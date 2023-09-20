using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
    public class RequestEntityModel
    {
        public bool IncludePhoto { get; set; }
        public bool IncludeChildren { get; set; }
    }
}
