using GalaxySMS.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.ServiceModel;

#if NETCOREAPP
using GalaxySMS.Business.Entities.NetStd2;
namespace GalaxySMS.Client.Contracts.NetCore
#else
namespace GalaxySMS.Client.Contracts
#endif
{
    [ServiceContract]
    public interface IAccountService : IServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [FaultContract(typeof(AuthorizationValidationException))]
        [FaultContract(typeof(ExceptionDetailEx))]
        Account GetCustomerAccountInfo(string loginEmail);

        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        void UpdateCustomerAccountInfo(Account account);

        #region Async operations

        [OperationContract]
        Task<Account> GetCustomerAccountInfoAsync(string loginEmail);

        [OperationContract]
        Task UpdateCustomerAccountInfoAsync(Account account);

        #endregion
    }
}
