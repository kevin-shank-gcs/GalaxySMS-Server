////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\InputOutputGroupAssignment.cs
//
// summary:	Implements the input output group assignment class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input output group assignment. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class InputOutputGroupAssignment
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputOutputGroupAssignment()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputOutputGroupAssignment to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputOutputGroupAssignment(InputOutputGroupAssignment e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this InputOutputGroupAssignment. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this InputOutputGroupAssignment. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputOutputGroupAssignment to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(InputOutputGroupAssignment e)
        {
            Initialize();
            if (e == null)
                return;
            this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.AccessPortalAlertEventUid = e.AccessPortalAlertEventUid;
            this.InputDeviceAlertEventUid = e.InputDeviceAlertEventUid;
            this.GalaxyPanelAlertEventUid = e.GalaxyPanelAlertEventUid;
            this.OffsetIndex = e.OffsetIndex;
            this.Tag = e.Tag;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //if (e.InputOutputGroup != null)
            //    this.InputOutputGroup = new InputOutputGroup(e.InputOutputGroup);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this InputOutputGroupAssignment. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputOutputGroupAssignment to process. </param>
        ///
        /// <returns>   A copy of this InputOutputGroupAssignment. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputOutputGroupAssignment Clone(InputOutputGroupAssignment e)
        {
            return new InputOutputGroupAssignment(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this InputOutputGroupAssignment is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(InputOutputGroupAssignment other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(InputOutputGroupAssignment other)
        {
            if (other == null)
                return false;

            if (other.InputOutputGroupAssignmentUid != this.InputOutputGroupAssignmentUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
