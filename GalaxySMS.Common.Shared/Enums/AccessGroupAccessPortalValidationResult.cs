using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    public enum AccessGroupAccessPortalValidationResult
    {
        Unknown = 0,
        Valid = 1,
        AccessGroupNotFound = 2,
        AccessPortalNotFoundOrOnCluster = 3,
        TimeScheduleNotFoundOrMappedToCluster =4,
        AccessGroupAndAccessPortalOnDifferentClusters=5,
        AccessGroupAndTimeScheduleOnDifferentClusters = 6,
    }
}
