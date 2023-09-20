using GCS.Core.Common.Contracts;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

#if NetCoreApi
#else
    [DataContract]
#endif
    public class PagedResultBase : IPagedResultBase
    {
        public PagedResultBase()
        {
            
        }

        public PagedResultBase(IPagedResultBase o)
        {
            if (o != null)
            {
                this.PageItemCount = o.PageItemCount;
                this.PageSize = o.PageSize;
                this.PageNumber = o.PageNumber;
                this.TotalItemCount = o.TotalItemCount;
                this.TotalPageCount = o.TotalPageCount;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the page that is contained in this result. </summary>
        ///
        /// <value> The page. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageNumber { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageItemCount { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the size of the page. </summary>
        ///
        /// <value> The size of the page. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageSize { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of total items across all pages of the data set. </summary>
        ///
        /// <value> The total number of item count. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalItemCount { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of total pages. </summary>
        ///
        /// <value> The total number of page count. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalPageCount { get; set; }
    }

}
