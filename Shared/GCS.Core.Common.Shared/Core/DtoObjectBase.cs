﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\DtoObjectBase.cs
//
// summary:	Implements the dto object base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A dto object base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public abstract class DtoObjectBase : ObjectBase
    {
    }
}
