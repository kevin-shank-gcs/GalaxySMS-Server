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
    public partial class PersonInputOutputGroupReq
    {

        //public System.Guid PersonInputOutputGroupUid { get; set; }
        //public System.Guid PersonClusterPermissionUid { get; set; }
        
        public System.Guid InputOutputGroupUid { get; set; }

        [Required]
        [Range(1,4)]
        public short OrderNumber { get; set; }

        //[Range(GalaxySMS.Common.Constants.InputOutputGroupLimits.None, GalaxySMS.Common.Constants.InputOutputGroupLimits.HighestNumber)]
        //public int InputOutputGroupNumber { get; set; }
        
        //[StringLength(65)]
        //public string InputOutputGroupName { get; set; }
        //public string InsertName { get; set; }
        //public System.DateTimeOffset InsertDate { get; set; }
        //public string UpdateName { get; set; }
        //public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        //public Nullable<short> ConcurrencyValue { get; set; }

        //    	public InputOutputGroup InputOutputGroup { get; set; }

    }
}
