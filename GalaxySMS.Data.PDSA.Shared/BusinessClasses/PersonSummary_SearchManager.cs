using System;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using System.Collections.Generic;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Utils;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class is used to call the stored procedure PersonSummary_SearchPDSA
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class PersonSummary_SearchPDSAManager
  {
    #region Your Custom Properties and Methods
        #region ConvertPDSACollection
    /// <summary>
    /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent PersonExpirationMode objects
    /// </summary>
    public IEnumerable<PersonSummary> ConvertPDSACollection(PersonSummaryPDSACollection pdsaCollection)
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
