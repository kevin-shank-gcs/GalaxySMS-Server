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
    public partial class InputDeviceCommandActionReq
    {
        public InputDeviceCommandActionReq()
        {
            Init();
        }

        public InputDeviceCommandActionReq(InputDeviceCommandActionReq o)
        {
            Init();
            InputDeviceUid = o.InputDeviceUid;
            CommandAction = o.CommandAction;
        }

        public void Init()
        {
            CommandAction = InputDeviceCommandActionCode.None;
            InputDeviceUid = Guid.Empty;
        }

        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.InputDeviceCommandActionCode))]
        public InputDeviceCommandActionCode CommandAction { get; set; }

        [Required]
        public Guid InputDeviceUid { get; set; }

        //        public Guid CommandUid {get;set;}

    }
}
