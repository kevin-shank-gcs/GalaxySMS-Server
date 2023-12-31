using System;
using System.Collections.Generic;
using System.Data;
using GalaxySMS.Business.Entities;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;


using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Utils;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class is used when you need to add, edit, delete, select and validate data for the gcsEnumValuePDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class gcsEnumValuePDSAManager
  {
    #region Your Custom Properties and Methods
    
    #endregion
  
    #region InitEntityObject Method
    /// <summary>
    /// Call this method to initialize the 'Entity' object with any default values
    /// </summary>
    public void InitEntityObject()
    {
      InitEntityObject(Entity);
    }

    public void InitEntityObject(gcsEnumValue entity)
    {
        SimpleMapper.PropertyMap(entity, Entity);
    }

    public IEnumerable<gcsEnumValue> ConvertPDSACollection(gcsEnumValuePDSACollection pdsaCollection)
    {
        List<gcsEnumValue> results = new List<gcsEnumValue>();
        foreach (var pdsaEntity in pdsaCollection)
        {
            var convertedEntity = new gcsEnumValue();
            SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
            results.Add(convertedEntity);
        }
        return results;
    }

    /// <summary>
    /// Call this method to initialize an gcsEnumValuePDSA object with any default values
    /// </summary>
    /// <param name="entity">An gcsEnumValuePDSA object</param>
    public void InitEntityObject(gcsEnumValuePDSA entity)
    {
      // TODO: Set any defaults here
      // Below is an Example 
      // entity.StartDate = DateTimeOffset.Now;

      entity.InsertName = this.PDSALoginName;
      entity.InsertDate = DateTimeOffset.Now;
      entity.UpdateName = this.PDSALoginName;
      entity.UpdateDate = DateTimeOffset.Now;
      entity.ConcurrencyValue = 1;
    }
    #endregion
       
    #region TrackChanges Method
    /// <summary>
    /// Implement your change tracking logic here
    /// </summary>
    /// <param name="action">Can be 'Insert', 'Update', 'Delete', or anything you want</param>
    public void TrackChanges(string action)
    {
    }
    #endregion
  }
}

