using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GalaxySMS.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class OutputDeviceCommandActionReq
    {
        public OutputDeviceCommandActionReq()
        {
            Init();
        }

        public OutputDeviceCommandActionReq(OutputDeviceCommandActionReq o)
        {
            Init();
            OutputDeviceUid = o.OutputDeviceUid;
            CommandAction = o.CommandAction;
        }

        public void Init()
        {
            CommandAction = OutputDeviceCommandActionCode.None;
            OutputDeviceUid = Guid.Empty;
        }

        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.OutputDeviceCommandActionCode))]
        public OutputDeviceCommandActionCode CommandAction { get; set; }

        [Required]
        public Guid OutputDeviceUid { get; set; }

    }
}
