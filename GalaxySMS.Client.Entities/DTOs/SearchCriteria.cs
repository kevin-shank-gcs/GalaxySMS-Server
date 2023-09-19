////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\SearchCriteria.cs
//
// summary:	Implements the search criteria class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{ 
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A search criteria. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SearchCriteria : DtoObjectBase
    {
        /// <summary>   Name of the search property. </summary>
        private string _searchPropertyName;
        /// <summary>   Type of the text search. </summary>
        private TextSearchType _textSearchType;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the text search. </summary>
        ///
        /// <value> The type of the text search. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public TextSearchType TextSearchType
        {
            get { return _textSearchType; }
            set
            {
                if (_textSearchType != value)
                {
                    _textSearchType = value;
                    OnPropertyChanged(() => TextSearchType);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the search property. </summary>
        ///
        /// <value> The name of the search property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string SearchPropertyName
        {
            get { return _searchPropertyName; }
            set
            {
                if (_searchPropertyName != value)
                {
                    _searchPropertyName = value;
                    OnPropertyChanged(() => SearchPropertyName);
                }
            }
        }
    }
}
