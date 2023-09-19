////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DragDrop\DropIndicationDetails.cs
//
// summary:	Implements the drop indication details class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace GCS.Core.Common.UI.DragDrop
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the drop indication. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DropIndicationDetails : ViewModelBase
    {
        /// <summary>   The current dragged item. </summary>
        private object currentDraggedItem;
        /// <summary>   The current drop position. </summary>
        private DropPosition currentDropPosition;
        /// <summary>   The current dragged over item. </summary>
        private object currentDraggedOverItem;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current dragged over item. </summary>
        ///
        /// <value> The current dragged over item. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object CurrentDraggedOverItem
        {
            get
            {
                return currentDraggedOverItem;
            }
            set
            {
                if (this.currentDraggedOverItem != value)
                {
                    currentDraggedOverItem = value;
                    OnPropertyChanged("CurrentDraggedOverItem");
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the zero-based index of the drop. </summary>
        ///
        /// <value> The drop index. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DropIndex { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current drop position. </summary>
        ///
        /// <value> The current drop position. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DropPosition CurrentDropPosition
        {
            get
            {
                return this.currentDropPosition;
            }
            set
            {
                if (this.currentDropPosition != value)
                {
                    this.currentDropPosition = value;
                    OnPropertyChanged("CurrentDropPosition");
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current dragged item. </summary>
        ///
        /// <value> The current dragged item. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object CurrentDraggedItem
        {
            get
            {
                return this.currentDraggedItem;
            }
            set
            {
                if (this.currentDraggedItem != value)
                {
                    this.currentDraggedItem = value;
                    OnPropertyChanged("CurrentDraggedItem");
                }
            }
        }
    }
}
