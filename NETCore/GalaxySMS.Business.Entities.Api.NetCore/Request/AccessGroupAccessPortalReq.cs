//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class AccessGroupAccessPortalReq : RequestBase
    {
        //private bool _isSystemAccessGroup;

        //public System.Guid AccessGroupAccessPortalUid { get; set; }
        //public System.Guid AccessGroupUid { get; set; }
        public System.Guid AccessPortalUid { get; set; }
        public System.Guid? TimeScheduleUid { get; set; }

//        public string AccessGroupName { get; set; }
//        public string AccessPortalName { get; set; }

//        public string TimeScheduleName { get; set; }

//        public bool IsSystemAccessGroup
//        {
//            get
//            {
//                switch (AccessGroupNumber)
//                {
//                    case GalaxySMS.Common.Constants.AccessGroupLimits.None:
//                    case GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess:
//                    case GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup:
//                        return true;
//                    default:
//                        return _isSystemAccessGroup;
//                }
//            }
//            set { _isSystemAccessGroup = value; }
//        }

//        public int AccessGroupNumber { get; set; }

    }
}
