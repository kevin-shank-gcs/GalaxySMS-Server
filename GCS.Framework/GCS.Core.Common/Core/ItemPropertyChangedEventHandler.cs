////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\ItemPropertyChangedEventHandler.cs
//
// summary:	Implements the item property changed event handler class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Delegate for handling ItemPropertyChanged events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    /// <param name="sender">   Source of the event. </param>
    /// <param name="e">        The ItemPropertyChangedEventArgs&lt;T&gt; to process. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public delegate void ItemPropertyChangedEventHandler<T>(object sender, ItemPropertyChangedEventArgs<T> e)
            where T : INotifyPropertyChanged;
}
