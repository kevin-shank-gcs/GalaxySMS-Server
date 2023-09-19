using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class InputOutputGroupCommandActionReq
    {
        public InputOutputGroupCommandActionReq()
        {
            Init();
        }

        public InputOutputGroupCommandActionReq(InputOutputGroupCommandActionReq o)
        {
            Init();
            InputOutputGroupUid = o.InputOutputGroupUid;
            CommandAction = o.CommandAction;
            //AccessPortalHardwareInformation = o.AccessPortalHardwareInformation;
 //           InputOutputGroupNumber = o.InputOutputGroupNumber;
//            CommandUid = o.CommandUid;
        }

        public void Init()
        {
            CommandAction = InputOutputGroupCommandActionCode.None;
            InputOutputGroupUid = Guid.Empty;
        }

        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.InputOutputGroupCommandActionCode))]
        public InputOutputGroupCommandActionCode CommandAction { get; set; }

        [Required]
        public Guid InputOutputGroupUid { get; set; }

        //[Required]
        //[Range(Common.Constants.InputOutputGroupLimits.None, Common.Constants.InputOutputGroupLimits.HighestNumber)]
        //public Byte InputOutputGroupNumber {get; set;}

        
       // public Guid CommandUid {get;set;}

    }
}
