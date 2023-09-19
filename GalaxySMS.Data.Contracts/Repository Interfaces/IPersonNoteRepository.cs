using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonNoteRepository : IDataRepository<PersonNote>
    {
        IEnumerable<PersonNote> GetAllPersonNotesForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonNote> GetAllPersonNotesForNote(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

