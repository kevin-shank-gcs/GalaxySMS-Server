﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IHasBinaryResource.cs
//
// summary:	Declares the IHasBinaryResource interface
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for has binary resource. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IHasBinaryResource
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        String Name { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs binary resource. </summary>
        ///
        /// <value> The gcs binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        gcsBinaryResource gcsBinaryResource { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource UID. </summary>
        ///
        /// <value> The binary resource UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        Guid? BinaryResourceUid { get; set; }
    }
}