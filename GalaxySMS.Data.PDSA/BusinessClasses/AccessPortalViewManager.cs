using System;
using System.Collections.Generic;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class should be used when you need to select data for the AccessPortalViewPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class AccessPortalViewPDSAManager
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
    /// Call this method to initialize an AccessPortalViewPDSA object with any default values
    /// </summary>
    /// <param name="entity">An AccessPortalViewPDSA object</param>
    public void InitEntityObject(AccessPortalViewPDSA entity)
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
  }
}
