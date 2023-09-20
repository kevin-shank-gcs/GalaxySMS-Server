////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\Validators\gcsEntity_Validator.cs
//
// summary:	Implements the gcs entity validator class
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Core;
    using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs entity. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsEntity
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The gcs entity validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        class gcsEntityValidator : AbstractValidator<gcsEntity>
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public gcsEntityValidator()
            {
                //RuleFor(obj => obj.EntityName).NotEmpty().WithLocalizedName(() => Properties.Resources.ValidationMessage_EntityName).WithLocalizedMessage(() => Properties.Resources.ValidationMessage_FieldCannotBeEmpty);
                RuleFor(obj => obj.EntityName).MaximumLength(65).NotEmpty();
                RuleFor(obj => obj.EntityDescription).MaximumLength(255);
                RuleFor(obj => obj.EntityKey).NotEmpty();
                RuleFor(obj => obj.UserRequirements).NotNull();
                RuleFor(obj => obj.UserRequirements).SetValidator(new gcsUserRequirement.gcsUserRequirementValidator());
                //RuleFor(obj => obj.ParentEntityId).NotEqual(obj=>obj.EntityId).WithLocalizedMessage(()=>Properties.Resources.ValidationMessage_ParentEntityCannotEqualEntityItself);
                //RuleFor(obj => obj.ParentEntityId).NotEqual( GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id).WithLocalizedMessage(()=>Properties.Resources.ValidationMessage_ParentEntityCannotEqualSystemEntity);

                RuleFor(obj => obj.ParentEntityId).NotEqual(obj=>obj.EntityId).WithMessage(x=>Properties.Resources.ValidationMessage_ParentEntityCannotEqualEntityItself);
                RuleFor(obj => obj.ParentEntityId).NotEqual( GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id).WithMessage(x=>Properties.Resources.ValidationMessage_ParentEntityCannotEqualSystemEntity);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The validator. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override IValidator GetValidator()
        {
            return new gcsEntityValidator();
        }
    }

}

