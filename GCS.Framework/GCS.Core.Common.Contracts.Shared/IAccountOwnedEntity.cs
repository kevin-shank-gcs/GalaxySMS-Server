////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IAccountOwnedEntity.cs
//
// summary:	Declares the IAccountOwnedEntity interface
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;

namespace GCS.Core.Common.Contracts
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for account owned entity. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IAccountOwnedEntity
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the account identifier that owns this item. </summary>
        ///
        /// <value> The identifier of the owner account. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int OwnerAccountId { get; }
    }
}
