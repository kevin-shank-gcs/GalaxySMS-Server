extern alias NetCoreCommon;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Controllers.Api
{
    /// <summary>
    /// controller for upload large file
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : ControllerBaseEx
    {

        public class FIleUploadAPI
        {
            public IFormFile files { get; set; }
        }

        public FileUploadController(IConfiguration config,
            IMapper mapper,
            ILogger<FileUploadController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {
        }

        ///// <summary>
        ///// Action for upload large file
        ///// </summary>
        ///// <remarks>
        ///// Request to this action will not trigger any model binding or model validation,
        ///// because this is a no-argument action
        ///// </remarks>
        ///// <returns></returns>
        //[HttpPost]
        //[Route(nameof(UploadLargeFile))]
        //public async Task<IActionResult> UploadLargeFile()
        //{
        //    var request = HttpContext.Request;

        //    // validation of Content-Type
        //    // 1. first, it must be a form-data request
        //    // 2. a boundary should be found in the Content-Type
        //    if (!request.HasFormContentType ||
        //        !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
        //        string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
        //    {
        //        return new UnsupportedMediaTypeResult();
        //    }

        //    var reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body);
        //    var section = await reader.ReadNextSectionAsync();

        //    // This sample try to get the first file from request and save it
        //    // Make changes according to your needs in actual use
        //    while (section != null)
        //    {
        //        var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
        //            out var contentDisposition);

        //        if (hasContentDispositionHeader && contentDisposition.DispositionType.Equals("form-data") &&
        //            !string.IsNullOrEmpty(contentDisposition.FileName.Value))
        //        {
        //            // Don't trust any file name, file extension, and file data from the request unless you trust them completely
        //            // Otherwise, it is very likely to cause problems such as virus uploading, disk filling, etc
        //            // In short, it is necessary to restrict and verify the upload
        //            // Here, we just use the temporary folder and a random file name

        //            // Get the temporary folder, and combine a random file name with it
        //            var fileName = Path.GetRandomFileName();
        //            var saveToPath = Path.Combine(Path.GetTempPath(), fileName);

        //            using (var targetStream = System.IO.File.Create(saveToPath))
        //            {
        //                await section.Body.CopyToAsync(targetStream);
        //            }

        //            return Ok();
        //        }

        //        section = await reader.ReadNextSectionAsync();
        //    }

        //    // If the code runs to this location, it means that no files have been saved
        //    return BadRequest("No files data in the request.");
        //}

        [HttpPost]
        public async Task<string> Post(FIleUploadAPI files)
        {
            if (files.files.Length > 0)
            {
                try
                {
                    //if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    //{
                    //    Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                    //}
                    //using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + files.files.FileName))
                    //{
                    //    files.files.CopyTo(filestream);
                    //    filestream.Flush();
                    //    return "\\uploads\\" + files.files.FileName;
                    //}
                    return "\\uploads\\" + files.files.FileName;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }

        }
    }
}
