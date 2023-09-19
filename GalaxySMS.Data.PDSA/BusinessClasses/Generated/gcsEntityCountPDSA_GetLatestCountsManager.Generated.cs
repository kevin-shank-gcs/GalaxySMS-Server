using System;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Logger;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class is used to call the stored procedure gcsEntityCountPDSA_GetLatestCountsPDSA
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsEntityCountPDSA_GetLatestCountsPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcsEntityCountPDSA_GetLatestCountsPDSAManager class
    /// </summary>
    public gcsEntityCountPDSA_GetLatestCountsPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the gcsEntityCountPDSA_GetLatestCountsPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public gcsEntityCountPDSA_GetLatestCountsPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      Init();
    }
    #endregion

    #region Private variables
    private gcsEntityCountPDSA_GetLatestCountsPDSA _Entity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column returned from the stored procedure.
    /// Setting this property will also set the Entity class into the DataObject class too.
    /// </summary>
    public gcsEntityCountPDSA_GetLatestCountsPDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        if (Validator != null)
          Validator.Entity = value;
        if (DataObject != null)
          DataObject.Entity = value;
      }
    }
    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public gcsEntityCountPDSA_GetLatestCountsPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the logic for loading the Entity class with data returned from this stored procedure.
    /// </summary>
    public gcsEntityCountPDSA_GetLatestCountsPDSAData DataObject { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initialize this class to a valid start state
    /// </summary>
    protected override void Init()
    {
      // Create Entity Class if not created
      if(Entity == null)
        Entity = new gcsEntityCountPDSA_GetLatestCountsPDSA();

      // Create Validator Class if not created
      if(Validator == null)
        Validator = new gcsEntityCountPDSA_GetLatestCountsPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new gcsEntityCountPDSA_GetLatestCountsPDSAData(DataProvider, Entity, Validator);

           DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "gcsEntityCountPDSA_GetLatestCountsPDSAManager";
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of gcsEntityCountPDSA_GetLatestCountsPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>gcsEntityCountPDSA_GetLatestCountsPDSACollection</returns>
    public gcsEntityCountPDSA_GetLatestCountsPDSACollection BuildCollection()
    {
      gcsEntityCountPDSA_GetLatestCountsPDSACollection coll = new gcsEntityCountPDSA_GetLatestCountsPDSACollection();
      gcsEntityCountPDSA_GetLatestCountsPDSA entity = null;
      DataSet ds;

      try
      {
        DataObject.Entity = Entity;
        ds = DataObject.GetDataSet();

        if (ds.Tables.Count > 0)
        {
          foreach (DataRow dr in ds.Tables[ds.Tables.Count - 1].Rows)
          {
            entity = DataObject.CreateEntityFromDataRow(dr);
          
            // You can set any additional properties here
          
            coll.Add(entity);
          }
        }
      }
      catch (Exception ex)
      {
        // This is here for design time exceptions
        System.Diagnostics.Debug.WriteLine(ex.Message);
        var innerEx = ex.InnerException;
        while( innerEx != null)
        {
            System.Diagnostics.Debug.WriteLine(innerEx.Message);
            innerEx = innerEx.InnerException;
        }
      }

      return coll;
    }

    /// <summary>
    /// Build collection from a DataSet returned from a stored procedure
    /// </summary>
    /// <param name="ds">A DataSet</param>
    /// <returns>A collection of gcsEntityCountPDSA_GetLatestCountsPDSA objects</returns>
    public gcsEntityCountPDSA_GetLatestCountsPDSACollection BuildCollection(DataSet ds)
    {
      gcsEntityCountPDSA_GetLatestCountsPDSACollection coll = new gcsEntityCountPDSA_GetLatestCountsPDSACollection();

      if (ds != null)
      {
        if (ds.Tables.Count > 0)
        {
          foreach (DataRow item in ds.Tables[0].Rows)
          {
            coll.Add(DataObject.CreateEntityFromDataRow(item));
          }
        }
      }

      return coll;
    }
    
    /// <summary>
    /// Build collection from a DataTable returned from a stored procedure
    /// </summary>
    /// <param name="dt">A DataTable</param>
    /// <returns>A collection of gcsEntityCountPDSA_GetLatestCountsPDSA objects</returns>
    public gcsEntityCountPDSA_GetLatestCountsPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of gcsEntityCountPDSA_GetLatestCountsPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(gcsEntityCountPDSA_GetLatestCountsPDSACollection), BuildCollection());
    }
    #endregion
    
    #region GetDataSet Methods
    /// <summary>
    /// Get DataSet with all rows or with any filters you have set
    /// </summary>
    /// <returns>A DatSet object</returns>
    public DataSet GetDataSet()
    {
      return DataObject.GetDataSet();
    }
    #endregion  
  }
}
