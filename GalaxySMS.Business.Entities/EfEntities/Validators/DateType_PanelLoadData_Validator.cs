﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace GalaxySMS.Business.Entities
{
    public partial class DateType_PanelLoadData
    {
        class DateType_PanelLoadDataValidator : AbstractValidator<DateType_PanelLoadData>
        {
            public DateType_PanelLoadDataValidator()
            {
                RuleFor(obj => obj.ClusterName).NotEmpty().Length(1, 65);
                RuleFor(obj => obj.ClusterGroupId).Length(0, 16);
                RuleFor(obj => (int)obj.ClusterNumber).InclusiveBetween(1, 65535);

            }
        }

        protected override IValidator GetValidator()
        {
            return new DateType_PanelLoadDataValidator();
        }
    }
}
