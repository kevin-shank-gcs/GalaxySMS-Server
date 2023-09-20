//extern alias NetCoreCommon;
using AutoMapper;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Cdn.Support;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalaxySMS.Cdn.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Countries. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController] // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UploadController : ControllerBaseEx
    {
        public UploadController(IConfiguration config,
            IMapper mapper,
            ILogger<UploadController> logger,
            LinkGenerator linkGenerator) : base(config, mapper, logger, linkGenerator)
        {

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult> VerifyPhotosExist()
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<string>> Post(PushBlobToCdnParameters parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                switch (Globals.Instance.CdnConnectionInfo.StorageType)
                {
                    case CdnConnectionInfo.CdnType.FileSystem:
                        return SaveBlobToFileSystem(parameters);
                }

                // return Url how the item can be retrieved

                return Ok();

            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }

        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Delete(DeleteBlobFromCdnParameters parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (Globals.Instance.CdnConnectionInfo.StorageType != CdnConnectionInfo.CdnType.FileSystem)
                    return BadRequest();

                DeleteFilesFromFolder(parameters);

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");

            }
        }
        
        private string SaveBlobToFileSystem(PushBlobToCdnParameters parameters)
        {
            try
            {
                if (Globals.Instance.CdnConnectionInfo.StorageType != CdnConnectionInfo.CdnType.FileSystem)
                    return string.Empty;

                var fullFolder =
                    $"{Globals.Instance.CdnConnectionInfo.FileSystemPath}\\{parameters.DataType.ToString().ToLower()}\\{parameters.TypeOfOwner.ToString().ToLower()}\\{parameters.OwnerUid}";

                //// Clean up any existing files that may need cleaned up
                //var deleteParams = new DeleteBlobFromCdnParameters() { DataType = parameters.DataType, Filename = parameters.Filename.Split('.')[0], OwnerUid = parameters.OwnerUid, TypeOfOwner = parameters.TypeOfOwner };
                //DeleteFilesFromFolder(deleteParams);


                var publicUrl =
                    $"{Globals.Instance.CdnConnectionInfo.PublicUrl}/{parameters.DataType.ToString().ToLower()}/{parameters.TypeOfOwner.ToString().ToLower()}/{parameters.OwnerUid}/{parameters.Filename}";
                if (!System.IO.Directory.Exists(fullFolder))
                    System.IO.Directory.CreateDirectory(fullFolder);
                var fullFileName = $"{fullFolder}\\{parameters.Filename}";
                System.IO.File.WriteAllBytes(fullFileName, parameters.Data);
                return publicUrl;
            }
            catch (Exception e)
            {
                Logger.LogError($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
            }

            return string.Empty;
        }

        private void DeleteFilesFromFolder(DeleteBlobFromCdnParameters parameters)
        {
            var fullFolder =
                $"{Globals.Instance.CdnConnectionInfo.FileSystemPath}\\{parameters.DataType.ToString().ToLower()}\\{parameters.TypeOfOwner.ToString().ToLower()}\\{parameters.OwnerUid}";
            if (System.IO.Directory.Exists(fullFolder))
            {
                if (string.IsNullOrEmpty(parameters.Filename))
                    ClearAndDeleteFolder(fullFolder);
                else
                {
                    var pattern = $"{parameters.Filename}*.*";
                    var matches = Directory.GetFiles(fullFolder, pattern);
                    foreach (var file in matches)
                        System.IO.File.Delete(file);
                }
            }
        }

        private void ClearAndDeleteFolder(string folderName)
        {
            DirectoryInfo dir = new DirectoryInfo(folderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearAndDeleteFolder(di.FullName);
                di.Delete();
            }
            dir.Delete(true);
        }
    }
}
