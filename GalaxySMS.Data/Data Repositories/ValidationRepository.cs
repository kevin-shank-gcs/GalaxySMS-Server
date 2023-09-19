using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using Exception = System.Exception;

namespace GalaxySMS.Data
{
    [Export(typeof(IValidationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ValidationRepository : IValidationRepository
    {
        public ValidationProblemDetails Validate(GuidValidationRequest data)
        {
            try
            {
                var response = new ValidationProblemDetails();
                var index = 0;
                foreach (var item in data.Items)
                {
                    var errors = new List<string>();
                    switch (item.ValidationRequestType)
                    {
                        case ValidationRequestType.ClusterAndTimeScheduleEntities:
                            var mgr = new DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAManager
                            {
                                Entity =
                                {
                                    ClusterUid = item.ClusterUid,
                                    TimeScheduleUid = item.TimeScheduleUid,
                                    PreventSystemEntityMatches = false
                                }
                            };
                            var results = mgr.BuildCollection();
                            if (results != null && results.Count > 0)
                            {
                                if (results[0].Result == false)
                                {
                                    errors.Add(
                                        $"ClusterUid:{item.ClusterUid} and TimeScheduleUid:{item.TimeScheduleUid} cannot be associated because they are owned by different entities.");
                                    response.Errors.Add($"{item.PropertyName}[{index}]", errors.ToArray());
                                }
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    index++;
                }

                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
