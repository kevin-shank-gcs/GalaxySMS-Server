using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    [Flags]
    public enum ClusterDataTypesToLoad
    {
        None = 0,
        AbaSettings = 1,
        WiegandSettings = 2,
        CardaxSettings = 4,
        ReaderLockoutSettings = 8,
        LedBehaviorSettings = 16,
        CrisisModeSettings = 32,
        ServerConsultationSettings = 64,
        All = AbaSettings | WiegandSettings | CardaxSettings | ReaderLockoutSettings | LedBehaviorSettings | CrisisModeSettings | ServerConsultationSettings
    }
}
