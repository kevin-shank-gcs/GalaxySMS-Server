using System;
using System.Collections.Generic;
using GalaxySMS.Business.Entities;

namespace GalaxySMS.Business.Entities
{
    public interface IHasNotes
    {
        ICollection<Note> Notes {get;set; }
    }
}