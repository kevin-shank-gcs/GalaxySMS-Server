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

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class InputDevicePutReq : PutRequestBase
    {

        public System.Guid InputDeviceUid { get; set; }

        public System.Guid EntityId { get; set; }

        public System.Guid SiteUid { get; set; }

        public string InputName { get; set; }

        public string Location { get; set; }

        public string ServiceComment { get; set; }

        public string CriticalityComment { get; set; }

        public string Comment { get; set; }

        public bool EMailEventsEnabled { get; set; }

        public bool TransmitEventsEnabled { get; set; }

        public bool FileOutputEnabled { get; set; }

//        public bool IsActive { get; set; }


        public bool IsTemplate { get; set; }

  //      public BinaryResourceReq gcsBinaryResource { get; set; }
        public byte[] PhotoImage { get; set; }

        public GalaxyInputDevicePutReq GalaxyInputDevice { get; set; }

        //public ICollection<InputDeviceEventPropertyPutReq> InputDeviceEventProperties { get; set; }

        public ICollection<NotePutReq> Notes { get; set; }

        public ICollection<Guid> EntityIds { get; set; }
        public ICollection<Guid> RoleIds { get; set; }

        public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }


    }
}
