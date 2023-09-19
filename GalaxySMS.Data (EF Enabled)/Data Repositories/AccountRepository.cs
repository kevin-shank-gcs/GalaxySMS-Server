using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;

namespace GalaxySMS.Data
{
    [Export(typeof(IAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountRepository : DataRepositoryBase<Account>, IAccountRepository
    {
        protected override Account AddEntity(GalaxySMSContext entityContext, Account entity)
        {
            return entityContext.AccountSet.Add(entity);
        }

        protected override Account UpdateEntity(GalaxySMSContext entityContext, Account entity)
        {
            return (from e in entityContext.AccountSet
                    where e.AccountId == entity.AccountId
                    select e).FirstOrDefault();
        }
        protected override void DeleteEntity(GalaxySMSContext entityContext, Account entity)
        {

        }

        protected override IEnumerable<Account> GetEntities(GalaxySMSContext entityContext)
        {
            return from e in entityContext.AccountSet
                   select e;
        }

        protected override Account GetEntityByIntId(GalaxySMSContext entityContext, int id)
        {
            var query = (from e in entityContext.AccountSet
                         where e.AccountId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        protected override Account GetEntityByGuidId(GalaxySMSContext entityContext, Guid guid)
        {
            var query = (from e in entityContext.AccountSet
                         where e.AccountGuid == guid
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public Account GetByLogin(string login)
        {
            using (GalaxySMSContext entityContext = new GalaxySMSContext())
            {
                return (from a in entityContext.AccountSet
                        where a.LoginEmail == login
                        select a).FirstOrDefault();
            }
        }
    }
}
