////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\BadgeTemplate.cs
//
// summary:	Implements the badge template class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A badge template. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class BadgeTemplate
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgeTemplate() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The BadgeTemplate to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgeTemplate(BadgeTemplate e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this BadgeTemplate. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this BadgeTemplate. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The BadgeTemplate to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(BadgeTemplate e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.BadgeTemplateUid = e.BadgeTemplateUid;
            this.EntityId = e.EntityId;
            this.BadgeSystemTypeUid = e.BadgeSystemTypeUid;
            this.TemplateName = e.TemplateName;
            this.Description = e.Description;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.TemplateId = e.TemplateId;

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this BadgeTemplate. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The BadgeTemplate to process. </param>
        ///
        /// <returns>   A copy of this BadgeTemplate. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgeTemplate Clone(BadgeTemplate e)
        {
            return new BadgeTemplate(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this BadgeTemplate is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(BadgeTemplate other)
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

        public bool IsPrimaryKeyEqual(BadgeTemplate other)
        {
            if (other == null)
                return false;

            if (other.BadgeTemplateUid != this.BadgeTemplateUid)
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
