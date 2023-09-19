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
    public partial class DateType_GetClustersThatUseDateType
    {
        class DateType_GetClustersThatUseDateTypeValidator : AbstractValidator<DateType_GetClustersThatUseDateType>
        {
            public DateType_GetClustersThatUseDateTypeValidator()
            {
                RuleFor(obj => obj.ClusterName).NotEmpty().Length(1, 65);
                RuleFor(obj => obj.ClusterGroupId).InclusiveBetween(0, 65535);
                RuleFor(obj => (int)obj.ClusterNumber).InclusiveBetween(1, 65535);

            }
        }

        protected override IValidator GetValidator()
        {
            return new DateType_GetClustersThatUseDateTypeValidator();
        }
    }
}
