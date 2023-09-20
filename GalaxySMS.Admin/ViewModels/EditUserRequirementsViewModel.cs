using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaxySMS.Admin.Properties;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.ViewModels
{
    public class EditUserRequirementsViewModel : ViewModelBase
    {
        public class PasswordValidationTechique
        {
            public enum ValidationTechnique { ExplicitValues, RegularExpression }

            public PasswordValidationTechique()
            {

            }

            public string Description { get; set; }
            public ValidationTechnique ValidateTechinque { get; set; }
            public override string ToString()
            {
                return Description;
            }
        }

        public EditUserRequirementsViewModel(IServiceFactory serviceFactory, gcsUserRequirement requirement)
        {
            _ServiceFactory = serviceFactory;
            _userRequirement = new gcsUserRequirement()
            {
                UserRequirementsId = requirement.EntityId,
                EntityId = requirement.EntityId,
                PasswordCannotContainName = requirement.PasswordCannotContainName,
                UseCustomRegEx = requirement.UseCustomRegEx,
                PasswordCustomRegEx = requirement.PasswordCustomRegEx,
                PasswordMinimumLength = requirement.PasswordMinimumLength,
                PasswordMaximumLength = requirement.PasswordMaximumLength,
                PasswordMinimumChangeCharacters = requirement.PasswordMinimumChangeCharacters,
                MaintainPasswordHistoryCount = requirement.MaintainPasswordHistoryCount,
                AllowPasswordChangeAttempt = requirement.AllowPasswordChangeAttempt,
                MinimumPasswordAge = requirement.MinimumPasswordAge,
                MaximumPasswordAge = requirement.MaximumPasswordAge,
                DefaultExpirationDays = requirement.DefaultExpirationDays,
                LockoutUserIfInactiveForDays = requirement.LockoutUserIfInactiveForDays,
                RequireLowerCaseLetterCount = requirement.RequireLowerCaseLetterCount,
                RequireNumericDigitCount = requirement.RequireNumericDigitCount,
                RequireSpecialCharacterCount = requirement.RequireSpecialCharacterCount,
                RequireUpperCaseLetterCount = requirement.RequireUpperCaseLetterCount,
                RegularExpressionDescription = requirement.RegularExpressionDescription,
                RequireTwoFactorAuthentication = requirement.RequireTwoFactorAuthentication,
                InsertName = requirement.InsertName,
                InsertDate = requirement.InsertDate,
                UpdateName = requirement.UpdateName,
                UpdateDate = requirement.UpdateDate,
                ConcurrencyValue = requirement.ConcurrencyValue
            };

            _userRequirement.CleanAll();

            _passwordTechiques = new ObservableCollection<PasswordValidationTechique>();
            _passwordTechiques.Add(new PasswordValidationTechique()
            {
                ValidateTechinque = PasswordValidationTechique.ValidationTechnique.ExplicitValues,
                Description = Properties.Resources.EditUserRequirementsView_PasswordValidationTechnique_UseExplicitRules
            });

            _passwordTechiques.Add(new PasswordValidationTechique()
            {
                ValidateTechinque = PasswordValidationTechique.ValidationTechnique.RegularExpression,
                Description = Properties.Resources.EditUserRequirementsView_PasswordValidationTechnique_CustomRegularExpression
            });


        }


        IServiceFactory _ServiceFactory;
        gcsUserRequirement _userRequirement;
        private ObservableCollection<PasswordValidationTechique> _passwordTechiques;

        public gcsUserRequirement UserRequirement
        {
            get { return _userRequirement; }
        }

        public ObservableCollection<PasswordValidationTechique> PasswordTechiques
        {
            get { return _passwordTechiques; }
            set
            {
                if (_passwordTechiques != value)
                {
                    _passwordTechiques = value;
                    OnPropertyChanged(() => PasswordTechiques, false);
                }
            }
        }

        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(UserRequirement);
        }
    }
}
