using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxySMS.Common.Shared.Enums
{
    public enum SqlTransactionIsolationLevels
    {
        ReadUncommitted,
        ReadCommitted,
        RepeatableRead,
        Snapshot,
        Serializable
    }
}
