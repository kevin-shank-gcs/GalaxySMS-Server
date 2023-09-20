////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\EntityBase.cs
//
// summary:	Implements the entity base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using GCS.Core.Common.Extensions;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An entity base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public abstract class EntityBase
#if NetCoreApi
#else
        : DataContractBase
#endif
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityBase()
        {
            EntityGuid = Guid.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The EntityBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityBase(EntityBase o)
        {
            if (o != null)
            {
                EntityGuid = o.EntityGuid;
            }
            else
            {
                EntityGuid = Guid.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the entity. </summary>
        ///
        /// <value> Unique identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityGuid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this EntityBase is dirty. </summary>
        ///
        /// <value> True if this EntityBase is dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif

        public bool IsDirty { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this EntityBase is panel data dirty.
        /// </summary>
        ///
        /// <value> True if this EntityBase is panel data dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsPanelDataDirty { get; set; }

        public int IndexValue { get; set; } = -1;
        public string OwnerPropertyName { get; set; } = string.Empty;
        public string MyPropertyName { get; set; } = string.Empty;

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An entity base simple. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public abstract class EntityBaseSimple
#if NetCoreApi
#else
    : DataContractBase
#endif

    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityBaseSimple()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The EntityBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityBaseSimple(EntityBase o)
        {
            //if (o != null)
            //{
            //}
            //else
            //{
            //}
        }

        public int ConcurrencyValue { get; set; }
    }
}
