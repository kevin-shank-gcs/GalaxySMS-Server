
using System;
using GalaxySMS.Business.Entities;
using GalaxySMS.EntityLayer;
using GCS.Core.Common.Utils;
using System.Collections.Generic;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used to call the stored procedure PersonSummary_SearchWithParamsPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// You may add additional methods to this class.
    /// </summary>
    public partial class PersonSummary_SearchWithParamsPDSAManager
    {
        #region Your Custom Properties and Methods
        #region ConvertPDSACollection
        /// <summary>
        /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent PersonExpirationMode objects
        /// </summary>
        public IEnumerable<PersonSummary> ConvertPDSACollection(PersonSummary_SearchWithParamsPDSACollection pdsaCollection, bool bIncludeLastUsageData)
        {
            var results = new List<PersonSummary>();
            foreach (var pdsaEntity in pdsaCollection)
            {
                var convertedEntity = new PersonSummary();
                SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                if (bIncludeLastUsageData && !string.IsNullOrEmpty(pdsaEntity.LastUsageAccessPortal))
                {
                    convertedEntity.LastUsageData = new PersonLastUsageData()
                    {
                        Time = pdsaEntity.LastUsageActivityDateTime,
                        SiteName = pdsaEntity.LastUsageSiteName,
                        ClusterName = pdsaEntity.LastUsageClusterName,
                        AccessPortalName = pdsaEntity.LastUsageAccessPortal,
                        CredentialName = pdsaEntity.LastCredentialName,
                    };
                    if (convertedEntity.LastUsageData.Time == DateTimeOffset.MinValue)
                    {
                        convertedEntity.LastUsageData.Time = null;
                    }
                }
                results.Add(convertedEntity);
            }
            return results;
        }

        #endregion
        #endregion
    }
}
