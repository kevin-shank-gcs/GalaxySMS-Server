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

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class is used when you need to add, edit, delete, select and validate data for the AccessPortalPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AccessPortalPDSAManager class
    /// </summary>
    public AccessPortalPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the AccessPortalPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public AccessPortalPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the AccessPortalPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public AccessPortalPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private AccessPortalPDSA _Entity = null;
    private AccessPortalPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public AccessPortalPDSA Entity
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
    /// Get/Set the Entity class used for searching
    /// </summary>
    public AccessPortalPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new AccessPortalPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public AccessPortalPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public AccessPortalPDSAData DataObject { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initialize this class to a valid start state
    /// </summary>
    protected override void Init()
    {
      // Create Entity Class if not created
      if(Entity == null)
      {
        Entity = new AccessPortalPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new AccessPortalPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new AccessPortalPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "AccessPortalPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public AccessPortalPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      AccessPortalPDSA ret = new AccessPortalPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.AccessPortalUid))
        ret.AccessPortalUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.AccessPortalUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.AccessPortalTypeUid))
        ret.AccessPortalTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.AccessPortalTypeUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.BinaryResourceUid))
        ret.BinaryResourceUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.BinaryResourceUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.SiteUid))
        ret.SiteUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.SiteUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.PortalName))
        ret.PortalName = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.PortalName]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.Location))
        ret.Location = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.Location]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ServiceComment))
        ret.ServiceComment = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.ServiceComment]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.CriticalityComment))
        ret.CriticalityComment = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.CriticalityComment]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.Comment))
        ret.Comment = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.Comment]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.IsTemplate))
        ret.IsTemplate = Convert.ToBoolean(values[AccessPortalPDSAValidator.ColumnNames.IsTemplate]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = Convert.ToDateTime(values[AccessPortalPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = Convert.ToDateTime(values[AccessPortalPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[AccessPortalPDSAValidator.ColumnNames.ConcurrencyValue]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.RegionUid))
        ret.RegionUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.RegionUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.RegionName))
        ret.RegionName = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.RegionName]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.SiteName))
        ret.SiteName = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.SiteName]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ClusterUid))
        ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.ClusterUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.GalaxyPanelUid))
        ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.GalaxyPanelUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ClusterGroupId))
        ret.ClusterGroupId = Convert.ToInt32(values[AccessPortalPDSAValidator.ColumnNames.ClusterGroupId]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ClusterNumber))
        ret.ClusterNumber = Convert.ToInt32(values[AccessPortalPDSAValidator.ColumnNames.ClusterNumber]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.PanelNumber))
        ret.PanelNumber = Convert.ToInt32(values[AccessPortalPDSAValidator.ColumnNames.PanelNumber]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.BoardNumber))
        ret.BoardNumber = Convert.ToInt16(values[AccessPortalPDSAValidator.ColumnNames.BoardNumber]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.SectionNumber))
        ret.SectionNumber = Convert.ToInt16(values[AccessPortalPDSAValidator.ColumnNames.SectionNumber]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ModuleNumber))
        ret.ModuleNumber = Convert.ToInt16(values[AccessPortalPDSAValidator.ColumnNames.ModuleNumber]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.NodeNumber))
        ret.NodeNumber = Convert.ToInt16(values[AccessPortalPDSAValidator.ColumnNames.NodeNumber]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ClusterTypeUid))
        ret.ClusterTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.ClusterTypeUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ClusterTypeCode))
        ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.ClusterTypeCode]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.GalaxyPanelModelUid))
        ret.GalaxyPanelModelUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.GalaxyPanelModelUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.GalaxyPanelTypeCode))
        ret.GalaxyPanelTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.GalaxyPanelTypeCode]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.InterfaceBoardTypeUid))
        ret.InterfaceBoardTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.InterfaceBoardTypeUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.InterfaceBoardTypeCode))
        ret.InterfaceBoardTypeCode = Convert.ToInt16(values[AccessPortalPDSAValidator.ColumnNames.InterfaceBoardTypeCode]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.InterfaceBoardModel))
        ret.InterfaceBoardModel = PDSAString.ConvertToStringTrim(values[AccessPortalPDSAValidator.ColumnNames.InterfaceBoardModel]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
        ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode))
        ret.InterfaceBoardSectionModeCode = Convert.ToInt16(values[AccessPortalPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid))
        ret.GalaxyHardwareModuleTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.ModuleTypeCode))
        ret.ModuleTypeCode = Convert.ToInt16(values[AccessPortalPDSAValidator.ColumnNames.ModuleTypeCode]);

      if (values.ContainsKey(AccessPortalPDSAValidator.ColumnNames.IsNodeActive))
        ret.IsNodeActive = Convert.ToBoolean(values[AccessPortalPDSAValidator.ColumnNames.IsNodeActive]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of AccessPortalPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>AccessPortalPDSACollection</returns>
    public AccessPortalPDSACollection BuildCollection()
    {
      AccessPortalPDSACollection coll = new AccessPortalPDSACollection();
      AccessPortalPDSA entity = null;
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
#if BuildCollection_LogFullException
          System.Diagnostics.Debug.WriteLine($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod()?.Name}:{ex}");
#else
          System.Diagnostics.Debug.WriteLine(ex.Message);
          var innerEx = ex.InnerException;
          while (innerEx != null)
          {
            System.Diagnostics.Debug.WriteLine(innerEx.Message);
            innerEx = innerEx.InnerException;
          }
#endif
	}
      return coll;
    }

    /// <summary>
    /// Build collection from a DataSet returned from a stored procedure
    /// </summary>
    /// <param name="ds">A DataSet</param>
    /// <returns>A collection of AccessPortalPDSA objects</returns>
    public AccessPortalPDSACollection BuildCollection(DataSet ds)
    {
      AccessPortalPDSACollection coll = new AccessPortalPDSACollection();

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
    /// <returns>A collection of AccessPortalPDSA objects</returns>
    public AccessPortalPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of AccessPortalPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(AccessPortalPDSACollection), BuildCollection());
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

    /// <summary>
    /// Get DataSet using the SearchEntity object
    /// </summary>
    /// <returns>A DatSet object</returns>
    public DataSet GetDataSetUsingSearchFilters()
    {
      DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.Search;

      // Create connection
      DataObject.CommandObject.Connection = DataProvider.CreateConnection(DataProvider.ConnectString);

      return DataProvider.GetDataSet(DataObject.CommandObject);
    }
    #endregion

    #region InitSearchFilter Method
    /// <summary>
    /// Re-Initialize a 'SearchEntity' property
    /// </summary>
    public void InitSearchFilter()
    {
      // Initialize Search Entity
      SearchEntity = InitSearchFilter(SearchEntity);
    }

    /// <summary>
    /// Re-Initialize a Search Entity object
    /// Usually you will use this to set the SearchEntity object
    /// 
    /// AccessPortalPDSA.SearchEntity = mgr.InitSearchFilter(AccessPortalPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A AccessPortalPDSA object</param>
    /// <returns>An AccessPortalPDSA object</returns>
    public AccessPortalPDSA InitSearchFilter(AccessPortalPDSA searchEntity)
    {
      searchEntity.PortalName  = string.Empty;
      searchEntity.RegionName  = string.Empty;
      searchEntity.SiteName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.AccessPortal table
    /// </summary>
    /// <param name="entity">An AccessPortalPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(AccessPortalPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.Insert();
      if(ret >= 1)
        TrackChanges("Insert");

      return ret;
    }
    #endregion

    #region Update Method
    /// <summary>
    /// Updates an entity in the GCS.AccessPortal table
    /// </summary>
    /// <param name="entity">An AccessPortalPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(AccessPortalPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.Update();
      if(ret >= 1)
        TrackChanges("Update");

      return ret;
    }
    #endregion

    #region Delete Method
    /// <summary>
    /// Deletes an entity from the GCS.AccessPortal table
    /// </summary>
    /// <param name="entity">An AccessPortalPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(AccessPortalPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.AccessPortalUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetAccessPortalPDSAsByFK_AccessPortalBinaryResourceEntity Method
    public AccessPortalPDSACollection GetAccessPortalPDSAsByFK_AccessPortalBinaryResourceEntity(gcsBinaryResourcePDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByBinaryResourceUid;
           }
           else
           {
           }
           
           Entity.BinaryResourceUid = entity.BinaryResourceUid;
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
            
         return BuildCollection();
      }
      else
        return new AccessPortalPDSACollection();
    }
    #endregion

    #region GetAccessPortalPDSAsByFK_AccessPortalBinaryResource Method
    public AccessPortalPDSACollection GetAccessPortalPDSAsByFK_AccessPortalBinaryResource(Guid binaryResourceUid)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByBinaryResourceUid;
        }
        else
        {
        }
        
        Entity.BinaryResourceUid = binaryResourceUid;
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
            
      return BuildCollection();
    }
    #endregion
    
  }
}

