﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IViewModel.cs
//
// summary:	Declares the IViewModel interface
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace GCS.Core.Common.Contracts
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for view model. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IViewModel
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the view. </summary>
        ///
        /// <value> The view. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IView View { get; set; }
    }
}