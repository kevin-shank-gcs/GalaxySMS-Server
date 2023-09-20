using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{

    public partial class NotePutReq : PutRequestBase
    {

        public System.Guid NoteUid { get; set; }


        public string Category { get; set; }


        public string NoteText { get; set; }


        public byte[] Photo { get; set; }


        public byte[] Document { get; set; }

    }
}
