using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsUserRequirement
    {
        public gcsUserRequirement()
        {
            Initialize();
        }

        public gcsUserRequirement(gcsUserRequirement e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsUserRequirement e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserRequirementsId = e.UserRequirementsId;
            this.EntityId = e.EntityId;
            this.PasswordCannotContainName = e.PasswordCannotContainName;
            this.PasswordMinimumLength = e.PasswordMinimumLength;
            this.PasswordMaximumLength = e.PasswordMaximumLength;
            this.PasswordMinimumChangeCharacters = e.PasswordMinimumChangeCharacters;
            this.MinimumPasswordAge = e.MinimumPasswordAge;
            this.MaximumPasswordAge = e.MaximumPasswordAge;
            this.MaintainPasswordHistoryCount = e.MaintainPasswordHistoryCount;
            this.DefaultExpirationDays = e.DefaultExpirationDays;
            this.LockoutUserIfInactiveForDays = e.LockoutUserIfInactiveForDays;
            this.AllowPasswordChangeAttempt = e.AllowPasswordChangeAttempt;
            this.RequireLowerCaseLetterCount = e.RequireLowerCaseLetterCount;
            this.RequireUpperCaseLetterCount = e.RequireUpperCaseLetterCount;
            this.RequireNumericDigitCount = e.RequireNumericDigitCount;
            this.RequireSpecialCharacterCount = e.RequireSpecialCharacterCount;
            this.UseCustomRegEx = e.UseCustomRegEx;
            this.PasswordCustomRegEx = e.PasswordCustomRegEx;
            this.RegularExpressionDescription = e.RegularExpressionDescription;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserRequirement Clone(gcsUserRequirement e)
        {
            return new gcsUserRequirement(e);
        }

        public bool Equals(gcsUserRequirement other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserRequirement other)
        {
            if (other == null)
                return false;

            if (other.UserRequirementsId != this.UserRequirementsId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
