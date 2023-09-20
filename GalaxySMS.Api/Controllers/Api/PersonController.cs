extern alias NetCoreCommon;
using AutoMapper;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Api.Support;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.File;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Clusters. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonController : ControllerBaseEx
    {
        public PersonController(IConfiguration config,
            IMapper mapper,
            ILogger<PersonController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// searches for the persons by a variety of search criteria
        /// </summary>
        ///
        /// <remarks>Valid SearchType values: AllRecords (0), ByPersonUid (1), ByPersonId (2), ByPersonActiveStatusTypeUid (3), ByDepartmentUid (4), ByPersonRecordTypeUid (5), ByLastFirstName (6), ByFields (7), ByCredentialNumber (8), ByCredentialFieldValues (9), ByCredentialFieldValue (10), ByOriginId (11), ByLastUpdatedDate (12), ByAccessProfileUid (13), ByAnyNameField (14)</remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="entityId">     (Optional) The unique ID of the entity to request person data for. If not specified or '00000000-0000-0000-0000-000000000000' is specified, the currentEntityId for the user session will be used. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="sortBy">       The property to sort the results by</param>
        /// <param name="orderBy">      The order to return results in, either ascending (asc) or descending (desc)</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.PersonSummaryBasic[]&gt;&gt; </returns>
        ///=================================================================================================
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]


        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.PersonSummaryBasic>>> Search([FromBody] RequestModels.PersonSummarySearchParametersReq parameters, Guid entityId, int pageSize, int pageNumber, GalaxySMS.Common.Enums.PersonSortOrder sortBy = Common.Enums.PersonSortOrder.LastNameFirstName, GalaxySMS.Common.Enums.OrderBy orderBy = Common.Enums.OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                //  var results = await mgr.SearchAsync(Mapper.Map<WcfEntities.PersonSummarySearchParameters>(parameters));
                var wcfParams = Mapper.Map<WcfEntities.PersonSummarySearchParameters>(parameters);
                wcfParams.PageNumber = pageNumber;
                wcfParams.PageSize = pageSize;
                wcfParams.UniqueId = entityId;
                wcfParams.CurrentEntityId = entityId;
                wcfParams.PersonUid = parameters.Uid;
                wcfParams.GetGuid = parameters.Uid;
                wcfParams.OmitPhotoBinaryData = true;
                wcfParams.PhotoPixelWidth = 0;
                wcfParams.DescendingOrder = orderBy == Common.Enums.OrderBy.Desc;
                wcfParams.SortBy = sortBy;

                var results = await mgr.SearchPagedResultsAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = new ApiEntities.ArrayResponse<ApiEntities.PersonSummaryBasic>();
                resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.PersonSummaryBasic>>(results);
                //resp.Items = Mapper.Map<ApiEntities.PersonSummaryBasic[]>(results);
                //resp.Count = resp.Items.Length;

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// (An Action that handles HTTP GET requests) (Restricted to AuthenticationSchemes =
        /// JwtBearerDefaults.AuthenticationScheme) searches for the first exception.
        /// </summary>
        ///
        /// <remarks>   Kevin, 10/28/2022. </remarks>
        ///
        /// <param name="entityId">             The unique ID of the entity to request person data for.
        ///                                     If not specified or '00000000-0000-0000-0000-000000000000' is
        ///                                     specified, the currentEntityId for the user session will be
        ///                                     used. </param>
        /// <param name="pageSize">             Size of the page. 0 = no paging. </param>
        /// <param name="pageNumber">           The page number. </param>
        /// <param name="q">                    The question text. </param>
        /// <param name="departmentUids">       The department uids. </param>
        /// <param name="accessProfileUids">    The access profile uids. </param>
        /// <param name="clusterUids">          The cluster uids. </param>
        /// <param name="personUids">           The person uids. </param>
        /// <param name="gender">               The gender. </param>
        /// <param name="isActive">             The is active. </param>
        /// <param name="activationStart">      The activation start. </param>
        /// <param name="activationEnd">        The activation end. </param>
        /// <param name="expirationStart">      The expiration start. </param>
        /// <param name="expirationEnd">        The expiration end. </param>
        /// <param name="dateOfBirth">          The date of birth. </param>
        /// <param name="haveCredentials">      The have credentials. </param>
        /// <param name="canToggleLock">        The can toggle lock. </param>
        /// <param name="includeLastUsage">     True to include, false to exclude the last usage. </param>
        /// <param name="personIds">            List of identifiers for the persons. </param>
        /// <param name="phones">               The phones. </param>
        /// <param name="emails">               The emails. </param>
        /// <param name="hasEmails">            The has emails. </param>
        /// <param name="hasPhones">            The has phones. </param>
        /// <param name="sortBy">               (Optional) The property to sort the results by. </param>
        /// <param name="orderBy">              (Optional) The order to return results in, either
        ///                                     ascending (asc) or descending (desc) </param>
        ///
        /// <returns>   The found exception. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Any parameter which is a comma-separated list of values, the query will treat the values in an OR relationship
        // If multiple parameters are provided, the query will treat these in an AND relationship
        // Text values will be treated as partial matches

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.PersonSummaryBasic>>> SearchEx(Guid entityId, int pageSize, int pageNumber, string q,
            string departmentUids, string accessProfileUids, string clusterUids, string personTypeUids, string personUids, string gender, Guid? genderUid, bool? isActive,
            DateTimeOffset? activationStart, DateTimeOffset? activationEnd, DateTimeOffset? expirationStart, DateTimeOffset? expirationEnd, DateTime? dateOfBirth,
            bool? haveCredentials, bool? canToggleLock, string personIds, string phones, string emails, bool? hasEmails, bool? hasPhones, string credentialNumbers, bool includeLastUsage = false,
            GalaxySMS.Common.Enums.PersonSortOrder sortBy = Common.Enums.PersonSortOrder.LastNameFirstName, GalaxySMS.Common.Enums.OrderBy orderBy = Common.Enums.OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                //  var results = await mgr.SearchAsync(Mapper.Map<WcfEntities.PersonSummarySearchParameters>(parameters));
                var wcfParams = new WcfEntities.PersonSummarySearchParameters
                {
                    SearchType = PersonSearchType.AdvancedSearch,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    UniqueId = entityId,
                    CurrentEntityId = entityId,
                    OmitPhotoBinaryData = true,
                    PhotoPixelWidth = 0,
                    DescendingOrder = orderBy == Common.Enums.OrderBy.Desc,
                    SortBy = sortBy,
                    QueryText = q,
                    DepartmentUids = departmentUids.ToIEnumerableGuid(',')?.ToCollection(),
                    AccessProfileUids = accessProfileUids.ToIEnumerableGuid(',')?.ToCollection(),
                    ClusterUids = clusterUids.ToIEnumerableGuid(',')?.ToCollection(),
                    PersonUids = personUids.ToIEnumerableGuid(',')?.ToCollection(),
                    PersonTypeUids = personTypeUids.ToIEnumerableGuid(',')?.ToCollection(),
                    GenderUid = genderUid,
                    Gender = gender,
                    IsActive = isActive,
                    ActivationStart = activationStart,
                    ActivationEnd = activationEnd,
                    ExpirationStart = expirationStart,
                    ExpirationEnd = expirationEnd,
                    DateOfBirth = dateOfBirth,
                    HaveCredentials = haveCredentials,
                    CanToggleLock = canToggleLock,
                    Phones = phones.ToIEnumerableString(',')?.ToCollection(),
                    Emails = emails.ToIEnumerableString(',')?.ToCollection(),
                    HasEmail = hasEmails,
                    HasPhones = hasPhones,
                    PersonIds = personIds.ToIEnumerableString(',')?.ToCollection(),
                    IncludeLastUsageData = includeLastUsage
                };
                if (!string.IsNullOrEmpty(credentialNumbers))
                {
                    wcfParams.SearchCredential = new WcfEntities.Credential()
                    {
                        CredentialPartsString = credentialNumbers,
                    };
                }
                if (wcfParams.PersonUids.Count() == 1)
                {
                    wcfParams.PersonUid = wcfParams.PersonUids.First();
                    wcfParams.GetGuid = wcfParams.PersonUid;
                }

                var results = await mgr.SearchPagedResultsAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = new ApiEntities.ArrayResponse<ApiEntities.PersonSummaryBasic>();
                resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.PersonSummaryBasic>>(results);
                //resp.Items = Mapper.Map<ApiEntities.PersonSummaryBasic[]>(results);
                //resp.Count = resp.Items.Length;

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get a Person by PersonUid value. </summary>
        ///  
        ///  <param name="personUid">       The person UID. </param>
        ///  <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.Cluster&gt;&gt; </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{personUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.PersonResp>> Get(Guid personUid, bool includePhoto = true, bool includeChildren = false)//, bool omitPhotoBinaryData = true)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = personUid,
                    IncludePhoto = includePhoto,
                    IncludeMemberCollections = includeChildren,
                    IncludeScaledPhotos = true,
                    OmitPhotoBinaryData = true//omitPhotoBinaryData
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetPersonAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                    return Ok(Mapper.Map<RequestModels.PersonPutReq>(result));

                var model = Mapper.Map<ResponseModels.PersonResp>(result);
                return Ok(model);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get person editor data. Data can be excluded by specifying true for the appropriate parameters. </summary>
        /// 
        ///  <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///  <param name="entityId">     (Optional) The unique ID of the entity to request data for. If not specified or '00000000-0000-0000-0000-000000000000' is specified, the currentEntityId for the user session will be used. </param>
        ///  <param name="includeProperties"> (Optional) Comma-separated string of property names to include in the response</param>
        ///  <returns>   The editor data. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("editordata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ResponseModels.PersonEditingDataBasicResp>> GetEditorData(Guid entityId, bool includePhoto = true, int photoPixelWidth = 200, string includeProperties = null)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParameters = new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    UniqueId = entityId,
                    CurrentEntityId = entityId,
                    IncludeMemberCollections = true
                };


                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    var responseProperties =
                        typeof(WcfEntities.PersonEditingData).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
                    responseProperties.AddRange(typeof(WcfEntities.Country).GetComplexProperties());
                    responseProperties.AddRange(typeof(WcfEntities.AccessProfile).GetComplexProperties());
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }

                    var includePersonaAccessGroupData = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == "PersonalAccessGroupData".ToLower());
                    if (includePersonaAccessGroupData == null)
                    {
                        wcfParameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.ClusterSelectionItem.TimeSchedules));
                        wcfParameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.ClusterSelectionItem.AccessPortals));
                    }

                    // forceably exclude InputDevices & OutputDevices. These are of no use 
                    wcfParameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.ClusterSelectionItem.InputDevices));
                    wcfParameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.ClusterSelectionItem.OutputDevices));
                    //var excludeCountryProperties = typeof(WcfEntities.Country).GetComplexProperties();
                    //foreach (var p in excludeCountryProperties)
                    //{
                    //    if (!wcfParameters.IsExcluded(p.Name))
                    //        wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    //}
                }

                var result = await mgr.GetPersonEditingDataAsync(wcfParameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ResponseModels.PersonEditingDataBasicResp>(result);
                return Ok(model);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        //public async Task<ActionResult<ApiEntities.PersonEditingDataBasic>> GetEditorData(Guid entityId, bool includePhoto = true, int photoPixelWidth = 200, string includeProperties = null)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var wcfParameters = new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = includePhoto,
        //            PhotoPixelWidth = photoPixelWidth,
        //            UniqueId = entityId,
        //            CurrentEntityId = entityId,
        //            IncludeMemberCollections = true
        //        };


        //        if (!string.IsNullOrEmpty(includeProperties))
        //        {
        //            var includeProps = includeProperties.Split(',');
        //            var responseProperties =
        //                typeof(WcfEntities.PersonEditingData).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
        //            responseProperties.AddRange(typeof(WcfEntities.Country).GetComplexProperties());
        //            responseProperties.AddRange(typeof(WcfEntities.AccessProfile).GetComplexProperties());
        //            foreach (var p in responseProperties)
        //            {
        //                var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
        //                if (included == null)
        //                    wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
        //            }

        //            // forceably exclude InputDevices & OutputDevices. These are of no use 
        //            wcfParameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.ClusterSelectionItem.InputDevices));
        //            wcfParameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.ClusterSelectionItem.OutputDevices));
        //            //var excludeCountryProperties = typeof(WcfEntities.Country).GetComplexProperties();
        //            //foreach (var p in excludeCountryProperties)
        //            //{
        //            //    if (!wcfParameters.IsExcluded(p.Name))
        //            //        wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
        //            //}
        //        }

        //        var result = await mgr.GetPersonEditingDataAsync(wcfParameters);

        //        if (mgr.HasErrors)
        //        {
        //            var errString = mgr.GetErrorsString();
        //            if (errString.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
        //                return this.StatusCode(StatusCodes.Status401Unauthorized, errString);
        //            if (errString.Contains(MagicExceptionStrings.forbidden, StringComparison.OrdinalIgnoreCase))
        //                return this.StatusCode(StatusCodes.Status403Forbidden, errString);
        //            return this.StatusCode(StatusCodes.Status500InternalServerError, errString);
        //        }

        //        if (result == null)
        //            return NotFound();
        //        var model = Mapper.Map<ApiEntities.PersonEditingDataBasic>(result);
        //        return Ok(model);
        //    }
        //    catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

        //        if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
        //            return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

        //        if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
        //            return NotFound();

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //    catch (FaultException ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
        //            return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get person user interface data. </summary>
        ///
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        /// <param name="entityId">     (Optional) The unique ID of the entity to request data for. If not specified or '00000000-0000-0000-0000-000000000000' is specified, the currentEntityId for the user session will be used. </param>
        ///
        /// <returns>   The UI data. </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("userinterfacedata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.UserInterfacePageControlDataBasic>> GetUserInterfaceData(Guid entityId, bool includePhoto = true, int photoPixelWidth = 200)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetPersonUserInterfacePageControlDataAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    UniqueId = entityId,
                    CurrentEntityId = entityId
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.UserInterfacePageControlDataBasic>(result);
                return Ok(model);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new person.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Person&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PersonPutReq>> Post(RequestModels.SaveParams<RequestModels.PersonReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                if (parameters.Data.PersonCredentials != null)
                {
                    var credentialIndex = 0;
                    foreach (var pc in parameters.Data.PersonCredentials)
                    {
                        if (pc.Credential != null)
                        {
                            var validationProblemDetails = await ValidateCredentialElements(pc.Credential, parameters.Data.EntityId, credentialIndex);
                            if (validationProblemDetails != null)
                                return ValidationProblem(validationProblemDetails);
                        }
                        credentialIndex++;
                    }
                }

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.Person>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Person>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SavePersonAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<PersonPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Person",
                        new { personUid = savedItem.PersonUid });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
                    return BadRequest(ex.Message);


                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DataValidationException).ToString()))
                    return BadRequest(ex.Message);

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Update an existing Person item. Can also create a new Person.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Person&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<PersonPutReq>> Put(RequestModels.SaveParams<RequestModels.PersonPutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                //if (parameters.Data.PersonUid == Guid.Empty)
                //    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update Person with PersonUid value of {parameters.Data.PersonUid}");
                var validationPersonProblemDetails = await ValidatePersonElements(parameters.Data);
                if (validationPersonProblemDetails != null)
                    return ValidationProblem(validationPersonProblemDetails);

                //if (parameters.Data.PersonUid == Guid.Empty)
                //    return this.StatusCode(StatusCodes.Status400BadRequest, $"Cannot update Person with PersonUid value of {parameters.Data.PersonUid}");

                //if (parameters.Data.PersonEmailAddresses != null && parameters.Data.PersonEmailAddresses.Count > 1)
                //{
                //    var missingUidItems = parameters.Data.PersonEmailAddresses.Where(o => o.PersonEmailAddressUid == Guid.Empty);
                //    if (missingUidItems.Any())
                //        return this.StatusCode(StatusCodes.Status400BadRequest, $"PersonEmailAddress items are missing PersonEmailAddressUid values");
                //}

                //if (parameters.Data.PersonPhoneNumbers != null && parameters.Data.PersonPhoneNumbers.Count > 1)
                //{
                //    var missingUidItems = parameters.Data.PersonPhoneNumbers.Where(o => o.PersonPhoneNumberUid == Guid.Empty);
                //    if (missingUidItems.Any())
                //        return this.StatusCode(StatusCodes.Status400BadRequest, $"PersonPhoneNumbers items are missing PersonPhoneNumberUid values");
                //}

                if (parameters.Data.PersonCredentials != null)
                {
                    var credentialIndex = 0;
                    foreach (var pc in parameters.Data.PersonCredentials)
                    {
                        if (pc.Credential != null)
                        {
                            var validationProblemDetails = await ValidateCredentialElements(pc.Credential, parameters.Data.EntityId, credentialIndex);
                            if (validationProblemDetails != null)
                                return ValidationProblem(validationProblemDetails);
                        }
                        credentialIndex++;
                    }
                }

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.Person>(parameters.Data);

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Person>(wcfEntity, wcfSaveParameters);


                var kvpSaveEmailOption = wcfParams.Options.FirstOrDefault(o => o.Key == nameof(SavePersonEmailAddressOption));

                bool bDeleteMissingEmailItems = !string.IsNullOrEmpty(kvpSaveEmailOption.Key) &&
                                                !string.IsNullOrEmpty(kvpSaveEmailOption.Value) &&
                                                kvpSaveEmailOption.Value == SavePersonEmailAddressOption.DeleteMissingItems.ToString();
                if (!bDeleteMissingEmailItems)
                {
                    wcfParams.Options.Add(new KeyValuePair<string, string>(nameof(SavePersonEmailAddressOption), SavePersonEmailAddressOption.DeleteMissingItems.ToString()));
                }

                var kvpSavePhoneOption = wcfParams.Options.FirstOrDefault(o => o.Key == nameof(SavePersonPhoneNumberOption));

                bool bDeleteMissingPhoneItems = !string.IsNullOrEmpty(kvpSavePhoneOption.Key) &&
                                                !string.IsNullOrEmpty(kvpSavePhoneOption.Value) &&
                                                kvpSavePhoneOption.Value == SavePersonPhoneNumberOption.DeleteMissingItems.ToString();
                if (!bDeleteMissingPhoneItems)
                {
                    wcfParams.Options.Add(new KeyValuePair<string, string>(nameof(SavePersonPhoneNumberOption), SavePersonPhoneNumberOption.DeleteMissingItems.ToString()));
                }

                var results = await mgr.SavePersonAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<PersonPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Person",
                        new { personUid = savedItem.PersonUid });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
                    return BadRequest(ex.Message);


                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DataValidationException).ToString()))
                    return BadRequest(ex.Message);

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }


        private async Task<ValidationProblemDetails> ValidateCredentialElements(CredentialReq data, Guid personEntityId, int credentialIndex)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            var credFormatParams = new WcfEntities.GetParametersWithPhoto()
            {
                CurrentEntityId = personEntityId,
                UniqueId = data.CredentialFormatUid,
                IncludeMemberCollections = true
            };
            credFormatParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.CredentialFormat.CredentialFormatParities));
            if (data.CredentialFormatUid == Guid.Empty)
            {
                if (data.Standard26Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Standard26Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Standard26Bit;
                }
                else if (data.Corporate1K35Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Corporate1K35Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Corporate1K35Bit;
                }
                else if (data.Corporate1K48Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Corporate1K48Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Corporate1K48Bit;
                }
                else if (data.H1030237Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.H1030237Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.H1030237Bit;
                }
                else if (data.H1030437Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.H1030437Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.H1030437Bit;
                }
                else if (data.Cypress37Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Cypress37Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Cypress37Bit;
                }
                else if (data.PIV75Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.PIV75Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.PIV75Bit;
                }
                else if (data.SoftwareHouse37Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.SoftwareHouse37Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.SoftwareHouse37Bit;
                }
                else if (data.XceedId40Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.XceedId40Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.XceedId40Bit;
                }
                else if (data.Bqt36Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Bqt36Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Bqt36Bit;
                }
            }
            var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
            var credentialFormat = await mgr.GetCredentialFormatAsync(credFormatParams);
            if (credentialFormat == null)
                errorsArray.Add($"CredentialFormat {data.CredentialFormatUid} is not valid or permitted.");

            if (credentialFormat != null && credentialFormat.UseCardNumber && string.IsNullOrEmpty(data.CardNumber))
                errorsArray.Add($"The CardNumber field is required.");
            else
            {
                if (credentialFormat != null)
                {
                    switch (credentialFormat.CredentialFormatCode)
                    {
                        case CredentialFormatCodes.NumericCardCode:
                        case CredentialFormatCodes.MagneticStripeBarcodeAba:
                        case CredentialFormatCodes.GalaxyKeypad:
                        case CredentialFormatCodes.USGovernmentID:
                        case CredentialFormatCodes.BtFarpointeConektMobile:
                        case CredentialFormatCodes.BtHidMobileAccess:
                        case CredentialFormatCodes.BtStidMobileId:
                        case CredentialFormatCodes.BtAllegion:
                        case CredentialFormatCodes.BtBasIp:
                        case CredentialFormatCodes.BasIpQr:
                            if (string.IsNullOrEmpty(data.CardNumber))
                                errorsArray.Add($"The CardNumber field is required.");
                            break;
                        case CredentialFormatCodes.Standard26Bit:
                            if (data.Standard26Bit == null)
                                errorsArray.Add($"The {nameof(data.Standard26Bit)} property is required.");
                            else
                            {
                                if (data.Standard26Bit.FacilityCode + data.Standard26Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Standard26Bit.FacilityCode)} and {nameof(data.Standard26Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.Corporate1K35Bit:
                            if (data.Corporate1K35Bit == null)
                                errorsArray.Add($"The {nameof(data.Corporate1K35Bit)} property is required.");
                            else
                            {
                                if (data.Corporate1K35Bit.CompanyCode + data.Corporate1K35Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Corporate1K35Bit.CompanyCode)} and {nameof(data.Corporate1K35Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.PIV75Bit:
                            if (data.PIV75Bit == null)
                                errorsArray.Add($"The {nameof(data.PIV75Bit)} property is required.");
                            else
                            {
                                if (data.PIV75Bit.AgencyCode + data.PIV75Bit.SiteCode + data.PIV75Bit.CredentialCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.PIV75Bit.AgencyCode)}. {nameof(data.PIV75Bit.SiteCode)} and {nameof(data.PIV75Bit.CredentialCode)} cannot all be 0.");
                            }
                            break;
                        case CredentialFormatCodes.Bqt36Bit:
                            if (data.Bqt36Bit == null)
                                errorsArray.Add($"The {nameof(data.Bqt36Bit)} property is required.");
                            else
                            {
                                if (data.Bqt36Bit.FacilityCode + data.Bqt36Bit.IdCode + data.Bqt36Bit.IssueCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Bqt36Bit.FacilityCode)}, {nameof(data.Bqt36Bit.IdCode)} and {nameof(data.Bqt36Bit.IssueCode)}cannot all be 0.");
                            }
                            break;
                        case CredentialFormatCodes.XceedId40Bit:
                            if (data.XceedId40Bit == null)
                                errorsArray.Add($"The {nameof(data.XceedId40Bit)} property is required.");
                            else
                            {
                                if (data.XceedId40Bit.SiteCode + data.XceedId40Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.XceedId40Bit.SiteCode)} and {nameof(data.XceedId40Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.Corporate1K48Bit:
                            if (data.Corporate1K48Bit == null)
                                errorsArray.Add($"The {nameof(data.Corporate1K48Bit)} property is required.");
                            else
                            {
                                if (data.Corporate1K48Bit.CompanyCode + data.Corporate1K48Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Corporate1K48Bit.CompanyCode)} and {nameof(data.Corporate1K48Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.Cypress37Bit:
                            if (data.Cypress37Bit == null)
                                errorsArray.Add($"The {nameof(data.Cypress37Bit)} property is required.");
                            else
                            {
                                if (data.Cypress37Bit.FacilityCode + data.Cypress37Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Cypress37Bit.FacilityCode)} and {nameof(data.Cypress37Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.H1030437Bit:
                            if (data.H1030437Bit == null)
                                errorsArray.Add($"The {nameof(data.H1030437Bit)} property is required.");
                            else
                            {
                                if (data.H1030437Bit.FacilityCode + data.H1030437Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.H1030437Bit.FacilityCode)} and {nameof(data.H1030437Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.H1030237Bit:
                            if (data.H1030237Bit == null)
                                errorsArray.Add($"The {nameof(data.H1030237Bit)} property is required.");
                            else
                            {
                                if (data.H1030237Bit.IdCode == 0)
                                    errorsArray.Add($"The field {nameof(data.H1030237Bit.IdCode)} cannot be 0.");
                            }
                            break;
                        case CredentialFormatCodes.SoftwareHouse37Bit:
                            if (data.SoftwareHouse37Bit == null)
                                errorsArray.Add($"The {nameof(data.SoftwareHouse37Bit)} property is required.");
                            else
                            {
                                if (data.SoftwareHouse37Bit.FacilityCode + data.SoftwareHouse37Bit.IdCode + data.SoftwareHouse37Bit.SiteCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.SoftwareHouse37Bit.SiteCode)}, {nameof(data.SoftwareHouse37Bit.FacilityCode)} and {nameof(data.SoftwareHouse37Bit.IdCode)} cannot all be 0.");
                            }
                            break;
                        case CredentialFormatCodes.None:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            if (errorsArray.Any())
            {
                validationProblems.Add($"{nameof(WcfEntities.PersonCredential.Credential)}[{credentialIndex}]", errorsArray.ToArray());
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }

        //private async Task<ValidationProblemDetails> GetNoRowsUpdatedValidationError()
        //{
        //    var validationProblems = new Dictionary<string, string[]>();
        //    var errorsArray = new List<string>();

        //    errorsArray.Add($"Cannot update record. The {nameof(PersonPutReq.ConcurrencyValue)} field value is wrong.");
        //    validationProblems.Add(nameof(PersonPutReq.ConcurrencyValue), errorsArray.ToArray());

        //    return new ValidationProblemDetails(validationProblems);
        //}

        private async Task<ValidationProblemDetails> ValidatePersonElements(PersonPutReq data)
        {
            //var validationProblems = new Dictionary<string, string[]>();
            //var errorsArray = new List<string>();

            //if (data.PersonUid == Guid.Empty)
            //    errorsArray.Add($"Cannot update Person with PersonUid value of {data.PersonUid}.");
            //if (string.IsNullOrEmpty(data.LastName))
            //    errorsArray.Add($"The {nameof(data.LastName)} field is required.");

            //if (errorsArray.Any())
            //{
            //    validationProblems.Add(nameof(PersonPutReq), errorsArray.ToArray());
            //    return new ValidationProblemDetails(validationProblems);
            //}

            //return null;
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            if (data.PersonUid == Guid.Empty)
            {
                errorsArray.Add($"Cannot update Person with PersonUid value of {data.PersonUid}.");
                validationProblems.Add(nameof(data.PersonUid), errorsArray.ToArray());
            }

            if (string.IsNullOrEmpty(data.LastName))
            {
                errorsArray.Clear();
                errorsArray.Add($"The {nameof(data.LastName)} field is required.");
                validationProblems.Add(nameof(data.LastName), errorsArray.ToArray());
            }


            if (validationProblems.Any())
            {
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }


        private async Task<ValidationProblemDetails> ValidateCredentialElements(CredentialPutReq data, Guid personEntityId, int credentialIndex)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            var credFormatParams = new WcfEntities.GetParametersWithPhoto()
            {
                CurrentEntityId = personEntityId,
                UniqueId = data.CredentialFormatUid,
                IncludeMemberCollections = true
            };
            credFormatParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.CredentialFormat.CredentialFormatParities));
            if (data.CredentialFormatUid == Guid.Empty)
            {
                if (data.Standard26Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Standard26Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Standard26Bit;
                }
                else if (data.Corporate1K35Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Corporate1K35Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Corporate1K35Bit;
                }
                else if (data.Corporate1K48Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Corporate1K48Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Corporate1K48Bit;
                }
                else if (data.H1030237Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.H1030237Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.H1030237Bit;
                }
                else if (data.H1030437Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.H1030437Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.H1030437Bit;
                }
                else if (data.Cypress37Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Cypress37Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Cypress37Bit;
                }
                else if (data.PIV75Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.PIV75Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.PIV75Bit;
                }
                else if (data.SoftwareHouse37Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.SoftwareHouse37Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.SoftwareHouse37Bit;
                }
                else if (data.XceedId40Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.XceedId40Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.XceedId40Bit;
                }
                else if (data.Bqt36Bit != null)
                {
                    credFormatParams.GetString = CredentialFormatCodes.Bqt36Bit.ToString();
                    credFormatParams.GetInt16 = (Int16)CredentialFormatCodes.Bqt36Bit;
                }
            }
            var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
            var credentialFormat = await mgr.GetCredentialFormatAsync(credFormatParams);
            if (credentialFormat == null)
                errorsArray.Add($"CredentialFormat {data.CredentialFormatUid} is not valid or permitted.");

            if (credentialFormat != null && credentialFormat.UseCardNumber && string.IsNullOrEmpty(data.CardNumber))
                errorsArray.Add($"The CardNumber field is required.");
            else
            {
                if (credentialFormat != null)
                {
                    switch (credentialFormat.CredentialFormatCode)
                    {
                        case CredentialFormatCodes.NumericCardCode:
                        case CredentialFormatCodes.MagneticStripeBarcodeAba:
                        case CredentialFormatCodes.GalaxyKeypad:
                        case CredentialFormatCodes.USGovernmentID:
                        case CredentialFormatCodes.BtFarpointeConektMobile:
                        case CredentialFormatCodes.BtHidMobileAccess:
                        case CredentialFormatCodes.BtStidMobileId:
                        case CredentialFormatCodes.BtAllegion:
                        case CredentialFormatCodes.BtBasIp:
                        case CredentialFormatCodes.BasIpQr:
                            if (string.IsNullOrEmpty(data.CardNumber))
                                errorsArray.Add($"The CardNumber field is required.");
                            break;
                        case CredentialFormatCodes.Standard26Bit:
                            if (data.Standard26Bit == null)
                                errorsArray.Add($"The {nameof(data.Standard26Bit)} property is required.");
                            else
                            {
                                if (data.Standard26Bit.FacilityCode + data.Standard26Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Standard26Bit.FacilityCode)} and {nameof(data.Standard26Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.Corporate1K35Bit:
                            if (data.Corporate1K35Bit == null)
                                errorsArray.Add($"The {nameof(data.Corporate1K35Bit)} property is required.");
                            else
                            {
                                if (data.Corporate1K35Bit.CompanyCode + data.Corporate1K35Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Corporate1K35Bit.CompanyCode)} and {nameof(data.Corporate1K35Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.PIV75Bit:
                            if (data.PIV75Bit == null)
                                errorsArray.Add($"The {nameof(data.PIV75Bit)} property is required.");
                            else
                            {
                                if (data.PIV75Bit.AgencyCode + data.PIV75Bit.SiteCode + data.PIV75Bit.CredentialCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.PIV75Bit.AgencyCode)}. {nameof(data.PIV75Bit.SiteCode)} and {nameof(data.PIV75Bit.CredentialCode)} cannot all be 0.");
                            }
                            break;
                        case CredentialFormatCodes.Bqt36Bit:
                            if (data.Bqt36Bit == null)
                                errorsArray.Add($"The {nameof(data.Bqt36Bit)} property is required.");
                            else
                            {
                                if (data.Bqt36Bit.FacilityCode + data.Bqt36Bit.IdCode + data.Bqt36Bit.IssueCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Bqt36Bit.FacilityCode)}, {nameof(data.Bqt36Bit.IdCode)} and {nameof(data.Bqt36Bit.IssueCode)}cannot all be 0.");
                            }
                            break;
                        case CredentialFormatCodes.XceedId40Bit:
                            if (data.XceedId40Bit == null)
                                errorsArray.Add($"The {nameof(data.XceedId40Bit)} property is required.");
                            else
                            {
                                if (data.XceedId40Bit.SiteCode + data.XceedId40Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.XceedId40Bit.SiteCode)} and {nameof(data.XceedId40Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.Corporate1K48Bit:
                            if (data.Corporate1K48Bit == null)
                                errorsArray.Add($"The {nameof(data.Corporate1K48Bit)} property is required.");
                            else
                            {
                                if (data.Corporate1K48Bit.CompanyCode + data.Corporate1K48Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Corporate1K48Bit.CompanyCode)} and {nameof(data.Corporate1K48Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.Cypress37Bit:
                            if (data.Cypress37Bit == null)
                                errorsArray.Add($"The {nameof(data.Cypress37Bit)} property is required.");
                            else
                            {
                                if (data.Cypress37Bit.FacilityCode + data.Cypress37Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.Cypress37Bit.FacilityCode)} and {nameof(data.Cypress37Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.H1030437Bit:
                            if (data.H1030437Bit == null)
                                errorsArray.Add($"The {nameof(data.H1030437Bit)} property is required.");
                            else
                            {
                                if (data.H1030437Bit.FacilityCode + data.H1030437Bit.IdCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.H1030437Bit.FacilityCode)} and {nameof(data.H1030437Bit.IdCode)} cannot both be 0.");
                            }
                            break;
                        case CredentialFormatCodes.H1030237Bit:
                            if (data.H1030237Bit == null)
                                errorsArray.Add($"The {nameof(data.H1030237Bit)} property is required.");
                            else
                            {
                                if (data.H1030237Bit.IdCode == 0)
                                    errorsArray.Add($"The field {nameof(data.H1030237Bit.IdCode)} cannot be 0.");
                            }
                            break;
                        case CredentialFormatCodes.SoftwareHouse37Bit:
                            if (data.SoftwareHouse37Bit == null)
                                errorsArray.Add($"The {nameof(data.SoftwareHouse37Bit)} property is required.");
                            else
                            {
                                if (data.SoftwareHouse37Bit.FacilityCode + data.SoftwareHouse37Bit.IdCode + data.SoftwareHouse37Bit.SiteCode == 0)
                                    errorsArray.Add($"The fields {nameof(data.SoftwareHouse37Bit.SiteCode)}, {nameof(data.SoftwareHouse37Bit.FacilityCode)} and {nameof(data.SoftwareHouse37Bit.IdCode)} cannot all be 0.");
                            }
                            break;
                        case CredentialFormatCodes.None:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            if (errorsArray.Any())
            {
                validationProblems.Add($"{nameof(WcfEntities.PersonCredential.Credential)}[{credentialIndex}]", errorsArray.ToArray());
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Delete a specific Person by PersonUid.
        /// </summary>
        ///
        /// <param name="personUid"> Identifier for the Person to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{personUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid personUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetPersonAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = personUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeletePersonByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = personUid });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok();
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("photo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.SaveDefaultPhotoResponse>> PostPhoto([FromForm] PersonPhotoUploadReq data)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                Logger.LogDebug($"PostPhoto PersonUid:{data.PersonUid}");
                if (data.PhotoFile != null)
                {
                    var validationProblems = new Dictionary<string, string[]>();
                    var errorsArray = new List<string>();


                    //https://dotnetthoughts.net/file-upload-extension-validation-in-aspnet-core/
                    // nuget package myrmec
                    //var forms = await this.HttpContext.Request.ReadFormAsync();
                    //var sniffer = new Sniffer();
                    //var supportedFiles = new List<Record>
                    //{
                    //    new Record("jpg,jpeg", "ff,d8,ff,db"),
                    //    new Record("png", "89,50,4e,47,0d,0a,1a,0a"),
                    //    new Record("avif", "25 50 44 46"),
                    //    new Record("webp", "47 49 46 38 39 61")
                    //};

                    //sniffer.Populate(supportedFiles);

                    //if (!data.PhotoFile.ContentType.IsAcceptableImageContentType())
                    //    return BadRequest($"Cannot accept file type: {data.PhotoFile.ContentType}");

                    //if (data.PhotoFile.Length <= 0)
                    //    return BadRequest($"Zero length file");

                    //if (data.PhotoFile.Length > Globals.Instance.MaxUploadFileSize)
                    //    return BadRequest($"File exceeds maximum allowed length: {Globals.Instance.MaxUploadFileSize} bytes");
                    if (!data.PhotoFile.ContentType.IsAcceptableImageContentType())
                        errorsArray.Add($"Cannot accept file type: {data.PhotoFile.ContentType}");
                    else
                    {

                        if (data.PhotoFile.Length <= 0)
                            errorsArray.Add($"Cannot accept an empty or zero-length file");

                        if (data.PhotoFile.Length > Globals.Instance.MaxUploadFileSize)
                            errorsArray.Add($"File exceeds maximum allowed length: {Globals.Instance.MaxUploadFileSize} bytes");
                    }

                    if (errorsArray.Any())
                    {
                        validationProblems.Add(nameof(data.PhotoFile), errorsArray.ToArray());
                        return ValidationProblem(new ValidationProblemDetails(validationProblems));
                    }

                    Logger.LogDebug($"PostPhoto PersonUid:{data.PersonUid}, ContentType: {data.PhotoFile?.ContentType}, {data.PhotoFile?.FileName}, length:{data.PhotoFile?.Length}, name:{data.PhotoFile?.Name}");
                    var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                    var saveParams = new WcfEntities.SaveParameters<WcfEntities.SavePhotoParameters>();
                    saveParams.Data.OwnerUid = data.PersonUid;
                    saveParams.Data.OriginalFilename = Path.GetFileName(data.PhotoFile.FileName);
                    saveParams.Data.OriginalContentType = data.PhotoFile.ContentType;
                    saveParams.Data.GenerateRandomFilename = true;
                    saveParams.Data.Tag = data.Tag;
                    if (data.IsDefault == null)
                        data.IsDefault = true;
                    saveParams.Data.IsDefault = data.IsDefault.Value;
                    saveParams.Data.ScaleImages.Add(new WcfEntities.ScaleImageParameters()
                    {
                        Tag = ScaledImageTagString.Original,
                        ScaleToWidth = 0
                    });

                    saveParams.Data.ScaleImages.Add(new WcfEntities.ScaleImageParameters()
                    {
                        Tag = ScaledImageTagString.Default,
                        ScaleToWidth = 224
                    });

                    saveParams.Data.ScaleImages.Add(new WcfEntities.ScaleImageParameters()
                    {
                        Tag = ScaledImageTagString.Small,
                        ScaleToWidth = 48
                    });

                    saveParams.Data.UseMagick = true;

                    using var fileStream = data.PhotoFile.OpenReadStream();
                    saveParams.Data.FileBinaryData = new byte[data.PhotoFile.Length];
                    fileStream.Read(saveParams.Data.FileBinaryData, 0, (int)data.PhotoFile.Length);
                    var results = await mgr.SavePersonPhotoAsync(saveParams);

                    if (mgr.HasErrors)
                    {
                        return GetStatusCodeResult(mgr);
                    }

                    if (results != null)
                    {
                        if (!string.IsNullOrEmpty(results?.Default) && !string.IsNullOrEmpty(results?.Original) && !string.IsNullOrEmpty(results?.Small))
                        {
                            var savedItem = Mapper.Map<ApiEntities.SaveDefaultPhotoResponse>(results);
                            var url = LinkGenerator.GetPathByAction("Get",
                                "Person",
                                new { personUid = data.PersonUid });
                            //if (savedItem.UpdateDate > savedItem.InsertDate)
                            //    return Ok(savedItem);
                            return Created(url, savedItem);
                        }
                        else
                        {
                            //var responseData = new { PhotoName = results.Original };
                            //var url = string.Empty;

                            //return Created(url, responseData);
                            var savedItem = Mapper.Map<ApiEntities.SaveDefaultPhotoResponse>(results);
                            var url = string.Empty;
                            //if (savedItem.UpdateDate > savedItem.InsertDate)
                            //    return Ok(savedItem);
                            return Created(url, savedItem);
                        }
                    }

                    return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
                }
                else
                    return BadRequest($"No file specified");

            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        [HttpDelete("{personUid}/photo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePhoto(Guid personUid, string filename)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);
                if (personUid == Guid.Empty)
                {
                    var validationProblems = new Dictionary<string, string[]>();
                    var errorsArray = new List<string>();
                    errorsArray.Add($"The personUid value is invalid");
                    validationProblems.Add(nameof(personUid), errorsArray.ToArray());
                    return ValidationProblem(new ValidationProblemDetails(validationProblems));
                }

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetPersonAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = personUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeletePersonPhotoAsync(new WcfEntities.DeleteParameters() { UniqueId = personUid, StringValue = filename });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok();
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{personUid}/access")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<PersonPutReq>> PostAccess(Guid personUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                Logger.LogDebug($"PostAccess PersonUid:{personUid}");

                var validationProblems = new Dictionary<string, string[]>();
                var errorsArray = new List<string>();
                if (personUid == Guid.Empty)
                    errorsArray.Add($"Invalid personUid value");

                if (errorsArray.Any())
                {
                    validationProblems.Add(nameof(personUid), errorsArray.ToArray());
                    return ValidationProblem(new ValidationProblemDetails(validationProblems));
                }

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var saveParams = new WcfEntities.SaveParameters<WcfEntities.SavePersonPropertiesParameters>();
                saveParams.Data.PersonUid = personUid;
                saveParams.Data.PersonAccessControlProperties.BoolProperties.Add(new WcfEntities.PropertyValue<bool>()
                { PropertyName = nameof(WcfEntities.Person.PersonAccessControlProperty.IsActive), Value = true });
                var result = await mgr.UpdatePersonPropertiesAsync(saveParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result != null)
                {
                    return Ok(Mapper.Map<PersonPutReq>(result));
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        [HttpDelete("{personUid}/access")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAccess(Guid personUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                Logger.LogDebug($"PostAccess PersonUid:{personUid}");

                var validationProblems = new Dictionary<string, string[]>();
                var errorsArray = new List<string>();
                if (personUid == Guid.Empty)
                    errorsArray.Add($"Invalid personUid value");

                if (errorsArray.Any())
                {
                    validationProblems.Add(nameof(personUid), errorsArray.ToArray());
                    return ValidationProblem(new ValidationProblemDetails(validationProblems));
                }

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var saveParams = new WcfEntities.SaveParameters<WcfEntities.SavePersonPropertiesParameters>();
                saveParams.Data.PersonUid = personUid;
                saveParams.Data.PersonAccessControlProperties.BoolProperties.Add(new WcfEntities.PropertyValue<bool>()
                { PropertyName = nameof(WcfEntities.Person.PersonAccessControlProperty.IsActive), Value = false });
                var result = await mgr.UpdatePersonPropertiesAsync(saveParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result != null)
                {
                    return Ok(result);
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get person information for persons that have a photo with no public url. </summary>
        /// 
        ///  <param name="entityId">     The unique ID of the entity to request data for. If '00000000-0000-0000-0000-000000000000' is specified, the currentEntityId for the user session will be used. </param>
        ///  <returns>   The editor data. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("nophotourl/{entityId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.PersonInfoWithMissingPhotoUrl[]>> GetPersonsWithNoPhotoUrl(Guid entityId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var result = await mgr.GetPersonInfoWithNoPhotoPublicUrlAsync(entityId);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.PersonInfoWithMissingPhotoUrl[]>(result);
                return Ok(model);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{personUid}/photostocdn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.PersonSavePhotoResponse[]>> PostPhotosToCdn(Guid personUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                Logger.LogDebug($"PostPhotosToCdn PersonUid:{personUid}");

                var validationProblems = new Dictionary<string, string[]>();
                var errorsArray = new List<string>();
                if (personUid == Guid.Empty)
                    errorsArray.Add($"Invalid personUid value");

                var mgr = Helpers.GetManager<PersonManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var result = await mgr.SendPersonPhotosToCdnAsync(personUid);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result != null)
                {
                    return Ok(result);
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

    }
}
