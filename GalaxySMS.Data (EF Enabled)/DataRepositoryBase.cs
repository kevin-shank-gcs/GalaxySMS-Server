using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Data;

namespace GalaxySMS.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, GalaxySMSContext>
        where T : class, IIdentifiableEntity, new()
    {
    }
}
