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
using GCS.Core.Common.Logger;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class should be used when you need to select data for the DeviceAlertEventSettingsViewPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DeviceAlertEventSettingsViewPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the DeviceAlertEventSettingsViewPDSAManager class
    /// </summary>
    public DeviceAlertEventSettingsViewPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the DeviceAlertEventSettingsViewPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public DeviceAlertEventSettingsViewPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the DeviceAlertEventSettingsViewPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public DeviceAlertEventSettingsViewPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private DeviceAlertEventSettingsViewPDSA _Entity = null;
    private DeviceAlertEventSettingsViewPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public DeviceAlertEventSettingsViewPDSA Entity
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
    public DeviceAlertEventSettingsViewPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new DeviceAlertEventSettingsViewPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public DeviceAlertEventSettingsViewPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public DeviceAlertEventSettingsViewPDSAData DataObject { get; set; }
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
        Entity = new DeviceAlertEventSettingsViewPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new DeviceAlertEventSettingsViewPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new DeviceAlertEventSettingsViewPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "DeviceAlertEventSettingsViewPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public DeviceAlertEventSettingsViewPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      DeviceAlertEventSettingsViewPDSA ret = new DeviceAlertEventSettingsViewPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Pk))
        ret.Pk = PDSAProperty.ConvertToGuid(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Pk]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityName))
        ret.EntityName = PDSAString.ConvertToStringTrim(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityName]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceId))
        ret.DeviceId = PDSAProperty.ConvertToGuid(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceId]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceName))
        ret.DeviceName = PDSAString.ConvertToStringTrim(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceName]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EventType))
        ret.EventType = PDSAString.ConvertToStringTrim(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EventType]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceType))
        ret.DeviceType = PDSAString.ConvertToStringTrim(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceType]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterName))
        ret.ClusterName = PDSAString.ConvertToStringTrim(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterName]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.TimeSchedule))
        ret.TimeSchedule = PDSAString.ConvertToStringTrim(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.TimeSchedule]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventTypeUid))
        ret.AlertEventTypeUid = PDSAProperty.ConvertToGuid(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventTypeUid]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterUid))
        ret.ClusterUid = PDSAProperty.ConvertToGuid(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterUid]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid))
        ret.AcknowledgeTimeScheduleUid = PDSAProperty.ConvertToGuid(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.IsActive))
        ret.IsActive = Convert.ToBoolean(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.IsActive]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Flag))
        ret.Flag = Convert.ToInt32(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Flag]);

      if (values.ContainsKey(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventsFlag))
        ret.AlertEventsFlag = Convert.ToInt32(values[DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventsFlag]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of DeviceAlertEventSettingsViewPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>DeviceAlertEventSettingsViewPDSACollection</returns>
    public DeviceAlertEventSettingsViewPDSACollection BuildCollection()
    {
      DeviceAlertEventSettingsViewPDSACollection coll = new DeviceAlertEventSettingsViewPDSACollection();
      DeviceAlertEventSettingsViewPDSA entity = null;
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
          System.Diagnostics.Debug.WriteLine($"Exception in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{ex}");
#else
          //System.Diagnostics.Debug.WriteLine(ex.Message);
          this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{ex}", ex);
          var innerEx = ex.InnerException;
          while (innerEx != null)
          {
            this.Log().Error($"InnerException in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{innerEx}", innerEx);
           //System.Diagnostics.Debug.WriteLine(innerEx.Message);
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
    /// <returns>A collection of DeviceAlertEventSettingsViewPDSA objects</returns>
    public DeviceAlertEventSettingsViewPDSACollection BuildCollection(DataSet ds)
    {
      DeviceAlertEventSettingsViewPDSACollection coll = new DeviceAlertEventSettingsViewPDSACollection();

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
    /// <returns>A collection of DeviceAlertEventSettingsViewPDSA objects</returns>
    public DeviceAlertEventSettingsViewPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of DeviceAlertEventSettingsViewPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(DeviceAlertEventSettingsViewPDSACollection), BuildCollection());
    }
    #endregion

    #region GetDataSet Method
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
      DataObject.SelectFilter = DeviceAlertEventSettingsViewPDSAData.SelectFilters.Search;

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
    /// DeviceAlertEventSettingsViewPDSA.SearchEntity = mgr.InitSearchFilter(DeviceAlertEventSettingsViewPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A DeviceAlertEventSettingsViewPDSA object</param>
    /// <returns>An DeviceAlertEventSettingsViewPDSA object</returns>
    public DeviceAlertEventSettingsViewPDSA InitSearchFilter(DeviceAlertEventSettingsViewPDSA searchEntity)
    {
      searchEntity.EntityName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = DeviceAlertEventSettingsViewPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current DeviceAlertEventSettingsViewPDSA
    /// </summary>
    /// <returns>A cloned DeviceAlertEventSettingsViewPDSA object</returns>
    public DeviceAlertEventSettingsViewPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DeviceAlertEventSettingsViewPDSA
    /// </summary>
    /// <param name="entityToClone">The DeviceAlertEventSettingsViewPDSA entity to clone</param>
    /// <returns>A cloned DeviceAlertEventSettingsViewPDSA object</returns>
    public DeviceAlertEventSettingsViewPDSA CloneEntity(DeviceAlertEventSettingsViewPDSA entityToClone)
    {
      DeviceAlertEventSettingsViewPDSA newEntity = new DeviceAlertEventSettingsViewPDSA();

      newEntity.Pk = entityToClone.Pk;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.DeviceId = entityToClone.DeviceId;
      newEntity.DeviceName = entityToClone.DeviceName;
      newEntity.EventType = entityToClone.EventType;
      newEntity.DeviceType = entityToClone.DeviceType;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.TimeSchedule = entityToClone.TimeSchedule;
      newEntity.AlertEventTypeUid = entityToClone.AlertEventTypeUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.AcknowledgeTimeScheduleUid = entityToClone.AcknowledgeTimeScheduleUid;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.Flag = entityToClone.Flag;
      newEntity.AlertEventsFlag = entityToClone.AlertEventsFlag;

      return newEntity;
    }
    #endregion
  }
}
