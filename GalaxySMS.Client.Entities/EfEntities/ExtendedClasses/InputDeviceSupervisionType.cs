////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\InputDeviceSupervisionType.cs
//
// summary:	Implements the input device supervision type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input device supervision type. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class InputDeviceSupervisionType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceSupervisionType() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputDeviceSupervisionType to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceSupervisionType(InputDeviceSupervisionType e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this InputDeviceSupervisionType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            //this.GalaxyInputDevices = new HashSet<GalaxyInputDevice>();
            this.InterfaceBoardSectionModeIds = new HashSet<Guid>();
            this.gcsBinaryResource = new gcsBinaryResource();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this InputDeviceSupervisionType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputDeviceSupervisionType to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(InputDeviceSupervisionType e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceSupervisionTypeUid = e.InputDeviceSupervisionTypeUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.HasSeriesResistor = e.HasSeriesResistor;
            this.HasParallelResistor = e.HasParallelResistor;
            this.IsNormalOpen = e.IsNormalOpen;
            this.TroubleShortThreshold = e.TroubleShortThreshold;
            this.NormalChangeThreshold = e.NormalChangeThreshold;
            this.TroubleOpenThreshold = e.TroubleOpenThreshold;
            this.AlternateVoltagesEnabled = e.AlternateVoltagesEnabled;
            this.AlternateTroubleShortThreshold = e.AlternateTroubleShortThreshold;
            this.AlternateNormalChangeThreshold = e.AlternateNormalChangeThreshold;
            this.AlternateTroubleOpenThreshold = e.AlternateTroubleOpenThreshold;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);

            this.ResourceClassName = e.ResourceClassName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.UniqueResourceName = e.UniqueResourceName;
            
            //if( e.GalaxyInputDevices != null)
            //    this.GalaxyInputDevices = e.GalaxyInputDevices.ToCollection();

            if( e.InterfaceBoardSectionModeIds != null)
                this.InterfaceBoardSectionModeIds = e.InterfaceBoardSectionModeIds.ToCollection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this InputDeviceSupervisionType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputDeviceSupervisionType to process. </param>
        ///
        /// <returns>   A copy of this InputDeviceSupervisionType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceSupervisionType Clone(InputDeviceSupervisionType e)
        {
            return new InputDeviceSupervisionType(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this InputDeviceSupervisionType is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(InputDeviceSupervisionType other)
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

        public bool IsPrimaryKeyEqual(InputDeviceSupervisionType other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceSupervisionTypeUid != this.InputDeviceSupervisionTypeUid)
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