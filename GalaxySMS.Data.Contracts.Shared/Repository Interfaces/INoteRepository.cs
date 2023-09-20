using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface INoteRepository : IDataRepository<Note>
    {
        IEnumerable<Note> GetAllNotesForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Note> GetAllNotesForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

