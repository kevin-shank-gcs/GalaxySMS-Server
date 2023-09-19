using GalaxySMS.Business.Entities;
#if NETCOREAPP
using GalaxySMS.Client.Contracts.NetCore;
#else
using GalaxySMS.Client.Contracts;
#endif
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.ServiceModel;
using System;
using System.ServiceModel;
//using System.Threading.Channels;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    public class ValidationManager : ManagerBase
    {
        #region Private fields
        #endregion

        #region Public properties

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidationManager()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidationManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }
        #endregion

        #region Public Methods

        public async Task<ValidationProblemDetails> ValidateRequest(GuidValidationRequest requestData)
        {
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.ValidateByGuidAsync(requestData);
                        return data;
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            return null;
        }

        #endregion

    }
}
