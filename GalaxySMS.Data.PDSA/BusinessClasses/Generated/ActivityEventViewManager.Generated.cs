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
  /// This class should be used when you need to select data for the ActivityEventViewPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ActivityEventViewPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the ActivityEventViewPDSAManager class
    /// </summary>
    public ActivityEventViewPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the ActivityEventViewPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public ActivityEventViewPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the ActivityEventViewPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public ActivityEventViewPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private ActivityEventViewPDSA _Entity = null;
    private ActivityEventViewPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public ActivityEventViewPDSA Entity
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
    public ActivityEventViewPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new ActivityEventViewPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public ActivityEventViewPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public ActivityEventViewPDSAData DataObject { get; set; }
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
        Entity = new ActivityEventViewPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new ActivityEventViewPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new ActivityEventViewPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "ActivityEventViewPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public ActivityEventViewPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      ActivityEventViewPDSA ret = new ActivityEventViewPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ActivityDateTime))
        ret.ActivityDateTime = PDSAProperty.ConvertToDateTimeOffset(values[ActivityEventViewPDSAValidator.ColumnNames.ActivityDateTime]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ActivityDateTimeUTC))
        ret.ActivityDateTimeUTC = PDSAProperty.ConvertToDateTimeOffset(values[ActivityEventViewPDSAValidator.ColumnNames.ActivityDateTimeUTC]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.EventTypeMessage))
        ret.EventTypeMessage = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.EventTypeMessage]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ForeColor))
        ret.ForeColor = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.ForeColor]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ForeColorHex))
        ret.ForeColorHex = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.ForeColorHex]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.DeviceName))
        ret.DeviceName = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.DeviceName]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.SiteName))
        ret.SiteName = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.SiteName]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[ActivityEventViewPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.DeviceUid))
        ret.DeviceUid = PDSAProperty.ConvertToGuid(values[ActivityEventViewPDSAValidator.ColumnNames.DeviceUid]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.EventTypeUid))
        ret.EventTypeUid = PDSAProperty.ConvertToGuid(values[ActivityEventViewPDSAValidator.ColumnNames.EventTypeUid]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.DeviceType))
        ret.DeviceType = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.DeviceType]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.LastName))
        ret.LastName = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.LastName]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.FirstName))
        ret.FirstName = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.FirstName]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.IsTraced))
        ret.IsTraced = Convert.ToBoolean(values[ActivityEventViewPDSAValidator.ColumnNames.IsTraced]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.CredentialDescription))
        ret.CredentialDescription = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.CredentialDescription]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.PersonUid))
        ret.PersonUid = PDSAProperty.ConvertToGuid(values[ActivityEventViewPDSAValidator.ColumnNames.PersonUid]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.CredentialUid))
        ret.CredentialUid = PDSAProperty.ConvertToGuid(values[ActivityEventViewPDSAValidator.ColumnNames.CredentialUid]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ClusterUid))
        ret.ClusterUid = PDSAProperty.ConvertToGuid(values[ActivityEventViewPDSAValidator.ColumnNames.ClusterUid]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ClusterNumber))
        ret.ClusterNumber = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.ClusterNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ClusterName))
        ret.ClusterName = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.ClusterName]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ClusterGroupId))
        ret.ClusterGroupId = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.ClusterGroupId]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.PanelNumber))
        ret.PanelNumber = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.PanelNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.InputOutputGroupName))
        ret.InputOutputGroupName = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.InputOutputGroupName]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.InputOutputGroupNumber))
        ret.InputOutputGroupNumber = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.InputOutputGroupNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.CpuNumber))
        ret.CpuNumber = Convert.ToInt16(values[ActivityEventViewPDSAValidator.ColumnNames.CpuNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.BoardNumber))
        ret.BoardNumber = Convert.ToInt16(values[ActivityEventViewPDSAValidator.ColumnNames.BoardNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.SectionNumber))
        ret.SectionNumber = Convert.ToInt16(values[ActivityEventViewPDSAValidator.ColumnNames.SectionNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ModuleNumber))
        ret.ModuleNumber = Convert.ToInt16(values[ActivityEventViewPDSAValidator.ColumnNames.ModuleNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.NodeNumber))
        ret.NodeNumber = Convert.ToInt16(values[ActivityEventViewPDSAValidator.ColumnNames.NodeNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ActivityEventUid))
        ret.ActivityEventUid = PDSAProperty.ConvertToGuid(values[ActivityEventViewPDSAValidator.ColumnNames.ActivityEventUid]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.AlarmPriority))
        ret.AlarmPriority = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.AlarmPriority]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.ResponseRequired))
        ret.ResponseRequired = Convert.ToBoolean(values[ActivityEventViewPDSAValidator.ColumnNames.ResponseRequired]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.AcknowledgedTime))
        ret.AcknowledgedTime = PDSAProperty.ConvertToDateTimeOffset(values[ActivityEventViewPDSAValidator.ColumnNames.AcknowledgedTime]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.AcknowledgeComment))
        ret.AcknowledgeComment = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.AcknowledgeComment]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.IsAcknowledgeable))
        ret.IsAcknowledgeable = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.IsAcknowledgeable]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.IsAcknowledged))
        ret.IsAcknowledged = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.IsAcknowledged]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.AcknowledgedByUser))
        ret.AcknowledgedByUser = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.AcknowledgedByUser]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.EntityName))
        ret.EntityName = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.EntityName]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.EntityType))
        ret.EntityType = PDSAString.ConvertToStringTrim(values[ActivityEventViewPDSAValidator.ColumnNames.EntityType]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.AckCount))
        ret.AckCount = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.AckCount]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.TotalRecordCount))
        ret.TotalRecordCount = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.TotalRecordCount]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.PageNumber))
        ret.PageNumber = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.PageNumber]);

      if (values.ContainsKey(ActivityEventViewPDSAValidator.ColumnNames.PageSize))
        ret.PageSize = Convert.ToInt32(values[ActivityEventViewPDSAValidator.ColumnNames.PageSize]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of ActivityEventViewPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>ActivityEventViewPDSACollection</returns>
    public ActivityEventViewPDSACollection BuildCollection()
    {
      ActivityEventViewPDSACollection coll = new ActivityEventViewPDSACollection();
      ActivityEventViewPDSA entity = null;
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
    /// <returns>A collection of ActivityEventViewPDSA objects</returns>
    public ActivityEventViewPDSACollection BuildCollection(DataSet ds)
    {
      ActivityEventViewPDSACollection coll = new ActivityEventViewPDSACollection();

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
    /// <returns>A collection of ActivityEventViewPDSA objects</returns>
    public ActivityEventViewPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of ActivityEventViewPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(ActivityEventViewPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = ActivityEventViewPDSAData.SelectFilters.Search;

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
    /// ActivityEventViewPDSA.SearchEntity = mgr.InitSearchFilter(ActivityEventViewPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A ActivityEventViewPDSA object</param>
    /// <returns>An ActivityEventViewPDSA object</returns>
    public ActivityEventViewPDSA InitSearchFilter(ActivityEventViewPDSA searchEntity)
    {
      searchEntity.ActivityDateTime  = DateTimeOffset.Now;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = ActivityEventViewPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current ActivityEventViewPDSA
    /// </summary>
    /// <returns>A cloned ActivityEventViewPDSA object</returns>
    public ActivityEventViewPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ActivityEventViewPDSA
    /// </summary>
    /// <param name="entityToClone">The ActivityEventViewPDSA entity to clone</param>
    /// <returns>A cloned ActivityEventViewPDSA object</returns>
    public ActivityEventViewPDSA CloneEntity(ActivityEventViewPDSA entityToClone)
    {
      ActivityEventViewPDSA newEntity = new ActivityEventViewPDSA();

      newEntity.ActivityDateTime = entityToClone.ActivityDateTime;
      newEntity.ActivityDateTimeUTC = entityToClone.ActivityDateTimeUTC;
      newEntity.EventTypeMessage = entityToClone.EventTypeMessage;
      newEntity.ForeColor = entityToClone.ForeColor;
      newEntity.ForeColorHex = entityToClone.ForeColorHex;
      newEntity.DeviceName = entityToClone.DeviceName;
      newEntity.SiteName = entityToClone.SiteName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.DeviceUid = entityToClone.DeviceUid;
      newEntity.EventTypeUid = entityToClone.EventTypeUid;
      newEntity.DeviceType = entityToClone.DeviceType;
      newEntity.LastName = entityToClone.LastName;
      newEntity.FirstName = entityToClone.FirstName;
      newEntity.IsTraced = entityToClone.IsTraced;
      newEntity.CredentialDescription = entityToClone.CredentialDescription;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.InputOutputGroupName = entityToClone.InputOutputGroupName;
      newEntity.InputOutputGroupNumber = entityToClone.InputOutputGroupNumber;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.ActivityEventUid = entityToClone.ActivityEventUid;
      newEntity.AlarmPriority = entityToClone.AlarmPriority;
      newEntity.ResponseRequired = entityToClone.ResponseRequired;
      newEntity.AcknowledgedTime = entityToClone.AcknowledgedTime;
      newEntity.AcknowledgeComment = entityToClone.AcknowledgeComment;
      newEntity.IsAcknowledgeable = entityToClone.IsAcknowledgeable;
      newEntity.IsAcknowledged = entityToClone.IsAcknowledged;
      newEntity.AcknowledgedByUser = entityToClone.AcknowledgedByUser;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityType = entityToClone.EntityType;
      newEntity.AckCount = entityToClone.AckCount;
      newEntity.TotalRecordCount = entityToClone.TotalRecordCount;
      newEntity.PageNumber = entityToClone.PageNumber;
      newEntity.PageSize = entityToClone.PageSize;

      return newEntity;
    }
    #endregion
  }
}
