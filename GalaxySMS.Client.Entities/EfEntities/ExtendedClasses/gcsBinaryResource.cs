////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\gcsBinaryResource.cs
//
// summary:	Implements the gcs binary resource class
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
    /// <summary>   The gcs binary resource. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsBinaryResource
    {
        /// <summary>   True if this gcsBinaryResource has been modified. </summary>
        private bool _hasBeenModified;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsBinaryResource()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsBinaryResource to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsBinaryResource(gcsBinaryResource e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsBinaryResource. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsBinaryResource. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsBinaryResource to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(gcsBinaryResource e)
        {
            Initialize();
            if (e == null)
                return;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.DataType = e.DataType;
            this.Category = e.Category;
            this.Tag = e.Tag;
            this.BinaryResource = e.BinaryResource;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this gcsBinaryResource. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsBinaryResource to process. </param>
        ///
        /// <returns>   A copy of this gcsBinaryResource. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsBinaryResource Clone(gcsBinaryResource e)
        {
            return new gcsBinaryResource(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this gcsBinaryResource is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(gcsBinaryResource other)
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

        public bool IsPrimaryKeyEqual(gcsBinaryResource other)
        {
            if (other == null)
                return false;

            if (other.BinaryResourceUid != this.BinaryResourceUid)
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this gcsBinaryResource has been modified.
        /// </summary>
        ///
        /// <value> True if this gcsBinaryResource has been modified, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool HasBeenModified
        {
            get { return _hasBeenModified; }
            set
            {
                if (_hasBeenModified != value)
                {
                    _hasBeenModified = value;
                    OnPropertyChanged(() => HasBeenModified);
                }
            }
        }
    }
}
