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
  /// This class is used when you need to add, edit, delete, select and validate data for the InputDevicePDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputDevicePDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the InputDevicePDSAManager class
    /// </summary>
    public InputDevicePDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the InputDevicePDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public InputDevicePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the InputDevicePDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public InputDevicePDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private InputDevicePDSA _Entity = null;
    private InputDevicePDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public InputDevicePDSA Entity
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
    public InputDevicePDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new InputDevicePDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public InputDevicePDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public InputDevicePDSAData DataObject { get; set; }
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
        Entity = new InputDevicePDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new InputDevicePDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new InputDevicePDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "InputDevicePDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public InputDevicePDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      InputDevicePDSA ret = new InputDevicePDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InputDeviceUid))
        ret.InputDeviceUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.InputDeviceUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.SiteUid))
        ret.SiteUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.SiteUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.BinaryResourceUid))
        ret.BinaryResourceUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.BinaryResourceUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InputName))
        ret.InputName = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.InputName]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.Location))
        ret.Location = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.Location]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ServiceComment))
        ret.ServiceComment = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.ServiceComment]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.CriticalityComment))
        ret.CriticalityComment = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.CriticalityComment]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.Comment))
        ret.Comment = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.Comment]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.EMailEventsEnabled))
        ret.EMailEventsEnabled = Convert.ToBoolean(values[InputDevicePDSAValidator.ColumnNames.EMailEventsEnabled]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.TransmitEventsEnabled))
        ret.TransmitEventsEnabled = Convert.ToBoolean(values[InputDevicePDSAValidator.ColumnNames.TransmitEventsEnabled]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.FileOutputEnabled))
        ret.FileOutputEnabled = Convert.ToBoolean(values[InputDevicePDSAValidator.ColumnNames.FileOutputEnabled]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.IsTemplate))
        ret.IsTemplate = Convert.ToBoolean(values[InputDevicePDSAValidator.ColumnNames.IsTemplate]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = Convert.ToDateTime(values[InputDevicePDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = Convert.ToDateTime(values[InputDevicePDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[InputDevicePDSAValidator.ColumnNames.ConcurrencyValue]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.IsActive))
        ret.IsActive = Convert.ToBoolean(values[InputDevicePDSAValidator.ColumnNames.IsActive]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.RegionUid))
        ret.RegionUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.RegionUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.RegionName))
        ret.RegionName = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.RegionName]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.SiteName))
        ret.SiteName = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.SiteName]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ClusterGroupId))
        ret.ClusterGroupId = Convert.ToInt32(values[InputDevicePDSAValidator.ColumnNames.ClusterGroupId]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ClusterNumber))
        ret.ClusterNumber = Convert.ToInt32(values[InputDevicePDSAValidator.ColumnNames.ClusterNumber]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.PanelNumber))
        ret.PanelNumber = Convert.ToInt32(values[InputDevicePDSAValidator.ColumnNames.PanelNumber]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.BoardNumber))
        ret.BoardNumber = Convert.ToInt16(values[InputDevicePDSAValidator.ColumnNames.BoardNumber]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.SectionNumber))
        ret.SectionNumber = Convert.ToInt16(values[InputDevicePDSAValidator.ColumnNames.SectionNumber]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ModuleNumber))
        ret.ModuleNumber = Convert.ToInt16(values[InputDevicePDSAValidator.ColumnNames.ModuleNumber]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.NodeNumber))
        ret.NodeNumber = Convert.ToInt16(values[InputDevicePDSAValidator.ColumnNames.NodeNumber]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ClusterTypeUid))
        ret.ClusterTypeUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.ClusterTypeUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.TypeCode))
        ret.TypeCode = Convert.ToInt32(values[InputDevicePDSAValidator.ColumnNames.TypeCode]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ClusterTypeCode))
        ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.ClusterTypeCode]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.GalaxyPanelModelUid))
        ret.GalaxyPanelModelUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.GalaxyPanelModelUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.GalaxyPanelTypeCode))
        ret.GalaxyPanelTypeCode = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.GalaxyPanelTypeCode]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InterfaceBoardTypeUid))
        ret.InterfaceBoardTypeUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.InterfaceBoardTypeUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InterfaceBoardTypeCode))
        ret.InterfaceBoardTypeCode = Convert.ToInt16(values[InputDevicePDSAValidator.ColumnNames.InterfaceBoardTypeCode]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InterfaceBoardModel))
        ret.InterfaceBoardModel = PDSAString.ConvertToStringTrim(values[InputDevicePDSAValidator.ColumnNames.InterfaceBoardModel]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
        ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.InterfaceBoardSectionModeCode))
        ret.InterfaceBoardSectionModeCode = Convert.ToInt16(values[InputDevicePDSAValidator.ColumnNames.InterfaceBoardSectionModeCode]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid))
        ret.GalaxyHardwareModuleTypeUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ModuleTypeCode))
        ret.ModuleTypeCode = Convert.ToInt16(values[InputDevicePDSAValidator.ColumnNames.ModuleTypeCode]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.IsNodeActive))
        ret.IsNodeActive = Convert.ToBoolean(values[InputDevicePDSAValidator.ColumnNames.IsNodeActive]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.ClusterUid))
        ret.ClusterUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.ClusterUid]);

      if (values.ContainsKey(InputDevicePDSAValidator.ColumnNames.GalaxyPanelUid))
        ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[InputDevicePDSAValidator.ColumnNames.GalaxyPanelUid]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of InputDevicePDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>InputDevicePDSACollection</returns>
    public InputDevicePDSACollection BuildCollection()
    {
      InputDevicePDSACollection coll = new InputDevicePDSACollection();
      InputDevicePDSA entity = null;
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
    /// <returns>A collection of InputDevicePDSA objects</returns>
    public InputDevicePDSACollection BuildCollection(DataSet ds)
    {
      InputDevicePDSACollection coll = new InputDevicePDSACollection();

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
    /// <returns>A collection of InputDevicePDSA objects</returns>
    public InputDevicePDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of InputDevicePDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(InputDevicePDSACollection), BuildCollection());
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
      DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.Search;

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
    /// InputDevicePDSA.SearchEntity = mgr.InitSearchFilter(InputDevicePDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A InputDevicePDSA object</param>
    /// <returns>An InputDevicePDSA object</returns>
    public InputDevicePDSA InitSearchFilter(InputDevicePDSA searchEntity)
    {
      searchEntity.InputName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.InputDevice table
    /// </summary>
    /// <param name="entity">An InputDevicePDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(InputDevicePDSA entity)
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
    /// Updates an entity in the GCS.InputDevice table
    /// </summary>
    /// <param name="entity">An InputDevicePDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(InputDevicePDSA entity)
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
    /// Deletes an entity from the GCS.InputDevice table
    /// </summary>
    /// <param name="entity">An InputDevicePDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(InputDevicePDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.InputDeviceUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetInputDevicePDSAsByFK_InputDeviceBinaryResourceEntity Method
    public InputDevicePDSACollection GetInputDevicePDSAsByFK_InputDeviceBinaryResourceEntity(gcsBinaryResourcePDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByBinaryResourceUid;
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
        return new InputDevicePDSACollection();
    }
    #endregion

    #region GetInputDevicePDSAsByFK_InputDeviceBinaryResource Method
    public InputDevicePDSACollection GetInputDevicePDSAsByFK_InputDeviceBinaryResource(Guid binaryResourceUid)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByBinaryResourceUid;
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

