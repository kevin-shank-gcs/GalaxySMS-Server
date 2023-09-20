using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{

    public partial class NotePutReq : PutRequestBase
    {

        [Required]
        public System.Guid NoteUid { get; set; }


        [Required]
        [StringLength(65)]
        public string Category { get; set; }


        public string NoteText { get; set; }


        public byte[] Photo { get; set; }


        public byte[] Document { get; set; }

    }
}
