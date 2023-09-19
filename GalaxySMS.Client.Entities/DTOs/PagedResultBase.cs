﻿using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public class PagedResultBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the page that is contained in this result. </summary>
        ///
        /// <value> The page. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PageNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the size of the page. </summary>
        ///
        /// <value> The size of the page. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PageSize { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of total items across all pages of the data set. </summary>
        ///
        /// <value> The total number of item count. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int TotalItemCount { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of total pages. </summary>
        ///
        /// <value> The total number of page count. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int TotalPageCount { get; set; }
    }

}
