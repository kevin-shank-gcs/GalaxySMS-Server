using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class CardaxSettings
    {
        class CardaxSettingsValidator : AbstractValidator<CardaxSettings>
        {
            public CardaxSettingsValidator()
            {
                RuleFor(obj => (int)obj.Start).InclusiveBetween(0, 254);
                RuleFor(obj => (int)obj.End).InclusiveBetween(1, 255);
                RuleFor(obj => (int)obj.Start).LessThan(obj => obj.End);
            }
        }

        protected override IValidator GetValidator()
        {
            return new CardaxSettingsValidator();
        }
    }
}
