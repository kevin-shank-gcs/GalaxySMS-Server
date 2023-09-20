using GalaxySMS.Business.Entities;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.ServiceModel;
using System.ServiceModel;

namespace GalaxySMS.Business.Contracts
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [FaultContract(typeof(AuthorizationValidationException))]
        [FaultContract(typeof(ExceptionDetailEx))]
        Account GetCustomerAccountInfo(string loginEmail);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        [FaultContract(typeof(AuthorizationValidationException))]
        void UpdateCustomerAccountInfo(Account account);

    }
}
