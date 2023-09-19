////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyHardwareModule.cs
//
// summary:	Implements the galaxy hardware module class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy hardware module. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyHardwareModule
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyHardwareModule()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyHardwareModule to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyHardwareModule(GalaxyHardwareModule e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyHardwareModule. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.GalaxyInterfaceBoardSectionNodes = new ObservableCollection<GalaxyInterfaceBoardSectionNode>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyHardwareModule. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyHardwareModule to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(GalaxyHardwareModule e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyHardwareModuleTypeUid = e.GalaxyHardwareModuleTypeUid;
            this.ModuleNumber = e.ModuleNumber;
            this.IsModuleActive = e.IsModuleActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyInterfaceBoardSectionNodes = e.GalaxyInterfaceBoardSectionNodes.ToObservableCollection();

            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.SerialChannelInputModuleData = e.SerialChannelInputModuleData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this GalaxyHardwareModule. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyHardwareModule to process. </param>
        ///
        /// <returns>   A copy of this GalaxyHardwareModule. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyHardwareModule Clone(GalaxyHardwareModule e)
        {
            return new GalaxyHardwareModule(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this GalaxyHardwareModule is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(GalaxyHardwareModule other)
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

        public bool IsPrimaryKeyEqual(GalaxyHardwareModule other)
        {
            if (other == null)
                return false;

            if (other.GalaxyHardwareModuleUid != this.GalaxyHardwareModuleUid)
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
        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.InterfaceBoardSectionModule, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, ModuleNumber); } }

    }
}