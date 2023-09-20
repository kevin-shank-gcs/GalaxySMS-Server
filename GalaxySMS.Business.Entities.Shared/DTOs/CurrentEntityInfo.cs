using System;
using System.Collections.Generic;
using System.Text;
using GalaxySMS.Common.Interfaces;

namespace GalaxySMS.Business.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrentEntityInfo : ICurrentEntityInfo
    {
        public Guid CurrentEntityId { get; set; }
        public string CurrentEntityName { get; set; }
        public string CurrentEntityType { get; set; }
    }
}
