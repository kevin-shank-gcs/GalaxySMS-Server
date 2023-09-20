using System;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Utils;
using System.Collections.Generic;
using GalaxySMS.Business.Entities;

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
        public IEnumerable<PersonSummary> ConvertPDSACollection(PersonSummary_SearchWithParamsPDSACollection pdsaCollection)
        {
            var results = new List<PersonSummary>();
            foreach (var pdsaEntity in pdsaCollection)
            {
                var convertedEntity = new PersonSummary();
                SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                results.Add(convertedEntity);
            }
            return results;
        }

        #endregion
        #endregion
    }
}
