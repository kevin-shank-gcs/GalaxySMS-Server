using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class ArrayResponse<T> : PagedResultBase
    {
        public T[] Items { get; set; }
    }

}
