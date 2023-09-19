using System;
using System.Collections.Generic;
using System.Data;

using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;


using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Utils;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class is used when you need to add, edit, delete, select and validate data for the GalaxyPanelModelGalaxyPanelCommandPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class GalaxyPanelModelGalaxyPanelCommandPDSAManager
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

    /// <summary>
    /// Call this method to initialize an GalaxyPanelModelGalaxyPanelCommandPDSA object with any default values
    /// </summary>
    /// <param name="entity">An GalaxyPanelModelGalaxyPanelCommandPDSA object</param>
    public void InitEntityObject(GalaxyPanelModelGalaxyPanelCommandPDSA entity)
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

    /// <summary>
    /// Call this method to initialize the 'Entity' object from an object that can be mapped 
    /// </summary>
    public void InitEntityObject(GalaxyPanelModelGalaxyPanelCommand entity)
    {
      SimpleMapper.PropertyMap(entity, Entity);
    }

    #endregion
       
    #region ConvertPDSACollection
    /// <summary>
    /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent GalaxyPanelModelGalaxyPanelCommand objects 
    /// </summary>
    public IEnumerable<GalaxyPanelModelGalaxyPanelCommand> ConvertPDSACollection(GalaxyPanelModelGalaxyPanelCommandPDSACollection pdsaCollection)
    {	
	 var results = new List<GalaxyPanelModelGalaxyPanelCommand>();
      foreach (var pdsaEntity in pdsaCollection)
      {
        var convertedEntity = new GalaxyPanelModelGalaxyPanelCommand();
        SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
        results.Add(convertedEntity);
      }
      return results;
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

