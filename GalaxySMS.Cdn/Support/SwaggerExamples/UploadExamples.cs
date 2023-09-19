using GalaxySMS.Cdn.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace GalaxySMS.Cdn.Support
{
    public class UploadExamples : IExamplesProvider<UploadThis>
    {
        UploadThis IExamplesProvider<UploadThis>.GetExamples()
        {
            var retData = new UploadThis();

            return retData;
        }
    }

}