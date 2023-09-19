using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccountRepository : IDataRepository<Account>
    {
        Account GetByLogin(string login);
    }
}
