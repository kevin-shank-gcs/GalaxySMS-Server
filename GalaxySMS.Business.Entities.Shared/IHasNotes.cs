////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IHasNotes.cs
//
// summary:	Declares the IHasNotes interface
///=================================================================================================

using System;
using System.Collections.Generic;
using GalaxySMS.Business.Entities;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public interface IHasNotes
    {
        ICollection<Note> Notes { get; set; }
    }
}