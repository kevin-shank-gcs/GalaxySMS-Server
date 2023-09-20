////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\gcsUserRequirement.cs
//
// summary:	Implements the gcs user requirement class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Config;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs user requirement. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsUserRequirement
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserRequirement()
        {
            PasswordCannotContainName = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordCannotContainName", true, true);
            UseCustomRegEx = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordUseCustomRegEx", false, true);
            PasswordCustomRegEx = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordCustomRegEx", string.Empty, true);
            PasswordMinimumLength = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMinimumLength", 1, true);
            PasswordMaximumLength = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMaximumLength", 15, true);
            PasswordMinimumChangeCharacters = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMinimumChangeCharacters", 1, true);
            MaintainPasswordHistoryCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MaintainPasswordHistoryCount", 3, true);
            AllowPasswordChangeAttempt = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "AllowPasswordChangeAttempt", true, true);
            MinimumPasswordAge = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MinimumPasswordAge", 0, true);
            MaximumPasswordAge = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MaximumPasswordAge", 0, true);
            DefaultExpirationDays = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "DefaultExpirationDays", 0, true);
            LockoutUserIfInactiveForDays = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "LockoutUserIfInactiveForDays", 14, true);
            RequireLowerCaseLetterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireLowerCaseLetterCount", 0, true);
            RequireNumericDigitCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireNumericDigitCount", 0, true);
            RequireSpecialCharacterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireSpecialCharacterCount", 0, true);
            RequireUpperCaseLetterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireUpperCaseLetterCount", 0, true);
            RegularExpressionDescription = string.Empty;
            RequireTwoFactorAuthentication = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireTwoFactorAuthentication", false, true);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userRequirement">  The user requirement. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserRequirement(gcsUserRequirement userRequirement)
        {
            if (userRequirement != null)
            {
                UserRequirementsId = userRequirement.UserRequirementsId;
                EntityId = userRequirement.EntityId;
                PasswordCannotContainName = userRequirement.PasswordCannotContainName;
                UseCustomRegEx = userRequirement.UseCustomRegEx;
                PasswordCustomRegEx = userRequirement.PasswordCustomRegEx;
                PasswordMinimumLength = userRequirement.PasswordMinimumLength;
                PasswordMaximumLength = userRequirement.PasswordMaximumLength;
                PasswordMinimumChangeCharacters = userRequirement.PasswordMinimumChangeCharacters;
                MaintainPasswordHistoryCount = userRequirement.MaintainPasswordHistoryCount;
                AllowPasswordChangeAttempt = userRequirement.AllowPasswordChangeAttempt;
                MaximumPasswordAge = userRequirement.MaximumPasswordAge;
                MinimumPasswordAge = userRequirement.MinimumPasswordAge;
                DefaultExpirationDays = userRequirement.DefaultExpirationDays;
                LockoutUserIfInactiveForDays = userRequirement.LockoutUserIfInactiveForDays;
                RequireLowerCaseLetterCount = userRequirement.RequireLowerCaseLetterCount;
                RequireNumericDigitCount = userRequirement.RequireNumericDigitCount;
                RequireSpecialCharacterCount = userRequirement.RequireSpecialCharacterCount;
                RequireUpperCaseLetterCount = userRequirement.RequireUpperCaseLetterCount;
                RegularExpressionDescription = userRequirement.RegularExpressionDescription;
                RequireTwoFactorAuthentication = userRequirement.RequireTwoFactorAuthentication;
                InsertName = userRequirement.InsertName;
                InsertDate = userRequirement.InsertDate;
                UpdateName = userRequirement.UpdateName;
                UpdateDate = userRequirement.UpdateDate;
                ConcurrencyValue = userRequirement.ConcurrencyValue;
            }
        }
    }
}
