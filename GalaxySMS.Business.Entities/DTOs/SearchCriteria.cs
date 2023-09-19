using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{ 
    public class SearchCriteria
    {
        public SearchCriteria()
        {
        }
        public TextSearchType TextSearchType { get; set; }
        public string SearchPropertyName { get; set; }
    }
}
