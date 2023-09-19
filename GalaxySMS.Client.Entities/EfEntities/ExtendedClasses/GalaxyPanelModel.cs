////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyPanelModel.cs
//
// summary:	Implements the galaxy panel model class
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
    /// <summary>   A data Model for the galaxy panel. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyPanelModel
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelModel()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyPanelModel to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelModel(GalaxyPanelModel e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyPanelModel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            //this.GalaxyPanels = new HashSet<GalaxyPanel>();
            //this.GalaxyPanelModelGalaxyPanelCommands = new HashSet<GalaxyPanelModelGalaxyPanelCommand>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyPanelModel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyPanelModel to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(GalaxyPanelModel e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.TypeCode = e.TypeCode;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.GalaxyPanels = e.GalaxyPanels.ToCollection();
            //this.GalaxyPanelModelGalaxyPanelCommands = e.GalaxyPanelModelGalaxyPanelCommands.ToCollection();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this GalaxyPanelModel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyPanelModel to process. </param>
        ///
        /// <returns>   A copy of this GalaxyPanelModel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelModel Clone(GalaxyPanelModel e)
        {
            return new GalaxyPanelModel(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this GalaxyPanelModel is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(GalaxyPanelModel other)
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

        public bool IsPrimaryKeyEqual(GalaxyPanelModel other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelModelUid != this.GalaxyPanelModelUid)
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