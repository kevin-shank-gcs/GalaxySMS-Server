using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IMercScpIdReportRepository : IDataRepository<MercScpIdReport>
    {
        IEnumerable<MercScpIdReport> GetAllMercScpIdReportsForMacAddress(IApplicationUserSessionDataHeader sessionData, string macAddress);
        IEnumerable<MercScpIdReport> GetAllMercScpIdReportsForModelAndSerialNumber(IApplicationUserSessionDataHeader sessionData, string model, string serialNumber);
    }
}

