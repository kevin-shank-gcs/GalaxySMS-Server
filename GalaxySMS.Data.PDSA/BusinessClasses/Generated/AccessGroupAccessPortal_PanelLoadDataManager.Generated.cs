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
  /// This class should be used when you need to select data for the AccessGroupAccessPortal_PanelLoadDataPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroupAccessPortal_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AccessGroupAccessPortal_PanelLoadDataPDSAManager class
    /// </summary>
    public AccessGroupAccessPortal_PanelLoadDataPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the AccessGroupAccessPortal_PanelLoadDataPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public AccessGroupAccessPortal_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the AccessGroupAccessPortal_PanelLoadDataPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public AccessGroupAccessPortal_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private AccessGroupAccessPortal_PanelLoadDataPDSA _Entity = null;
    private AccessGroupAccessPortal_PanelLoadDataPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public AccessGroupAccessPortal_PanelLoadDataPDSA Entity
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
    public AccessGroupAccessPortal_PanelLoadDataPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new AccessGroupAccessPortal_PanelLoadDataPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public AccessGroupAccessPortal_PanelLoadDataPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public AccessGroupAccessPortal_PanelLoadDataPDSAData DataObject { get; set; }
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
        Entity = new AccessGroupAccessPortal_PanelLoadDataPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new AccessGroupAccessPortal_PanelLoadDataPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new AccessGroupAccessPortal_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "AccessGroupAccessPortal_PanelLoadDataPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public AccessGroupAccessPortal_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      AccessGroupAccessPortal_PanelLoadDataPDSA ret = new AccessGroupAccessPortal_PanelLoadDataPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupAccessPortalUid))
        ret.AccessGroupAccessPortalUid = PDSAProperty.ConvertToGuid(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupAccessPortalUid]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupName))
        ret.AccessGroupName = PDSAString.ConvertToStringTrim(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupName]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName))
        ret.TimeScheduleName = PDSAString.ConvertToStringTrim(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalName))
        ret.AccessPortalName = PDSAString.ConvertToStringTrim(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalName]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
        ret.ClusterGroupId = Convert.ToInt32(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
        ret.ClusterNumber = Convert.ToInt32(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber))
        ret.PanelNumber = Convert.ToInt32(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.BoardNumber))
        ret.BoardNumber = Convert.ToInt16(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.BoardNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SectionNumber))
        ret.SectionNumber = Convert.ToInt16(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SectionNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ModuleNumber))
        ret.ModuleNumber = Convert.ToInt16(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ModuleNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.NodeNumber))
        ret.NodeNumber = Convert.ToInt16(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.NodeNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupNumber))
        ret.AccessGroupNumber = Convert.ToInt32(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber))
        ret.PanelScheduleNumber = Convert.ToInt32(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ActivationDate))
        ret.ActivationDate = Convert.ToDateTime(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ActivationDate]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ExpirationDate))
        ret.ExpirationDate = Convert.ToDateTime(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ExpirationDate]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IsEnabled))
        ret.IsEnabled = Convert.ToBoolean(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IsEnabled]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalUid))
        ret.AccessPortalUid = PDSAProperty.ConvertToGuid(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalUid]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid))
        ret.TimeScheduleUid = PDSAProperty.ConvertToGuid(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupUid))
        ret.AccessGroupUid = PDSAProperty.ConvertToGuid(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupUid]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardTypeTypeCode))
        ret.AccessPortalBoardTypeTypeCode = Convert.ToInt16(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardTypeTypeCode]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CurrentTimeForCluster))
        ret.CurrentTimeForCluster = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CurrentTimeForCluster]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
        ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid))
        ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuNumber))
        ret.CpuNumber = Convert.ToInt32(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuUid))
        ret.CpuUid = PDSAString.ConvertToStringTrim(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuUid]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid))
        ret.AccessGroupLoadToCpuUid = PDSAString.ConvertToStringTrim(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ServerAddress))
        ret.ServerAddress = PDSAString.ConvertToStringTrim(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ServerAddress]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleName))
        ret.DefaultTimeScheduleName = PDSAString.ConvertToStringTrim(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleName]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleNumber))
        ret.DefaultTimeScheduleNumber = Convert.ToInt32(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleNumber]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IsConnected))
        ret.IsConnected = Convert.ToInt32(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IsConnected]);

      if (values.ContainsKey(AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IsNodeActive))
        ret.IsNodeActive = Convert.ToBoolean(values[AccessGroupAccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IsNodeActive]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of AccessGroupAccessPortal_PanelLoadDataPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>AccessGroupAccessPortal_PanelLoadDataPDSACollection</returns>
    public AccessGroupAccessPortal_PanelLoadDataPDSACollection BuildCollection()
    {
      AccessGroupAccessPortal_PanelLoadDataPDSACollection coll = new AccessGroupAccessPortal_PanelLoadDataPDSACollection();
      AccessGroupAccessPortal_PanelLoadDataPDSA entity = null;
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
    /// <returns>A collection of AccessGroupAccessPortal_PanelLoadDataPDSA objects</returns>
    public AccessGroupAccessPortal_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
    {
      AccessGroupAccessPortal_PanelLoadDataPDSACollection coll = new AccessGroupAccessPortal_PanelLoadDataPDSACollection();

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
    /// <returns>A collection of AccessGroupAccessPortal_PanelLoadDataPDSA objects</returns>
    public AccessGroupAccessPortal_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of AccessGroupAccessPortal_PanelLoadDataPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(AccessGroupAccessPortal_PanelLoadDataPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = AccessGroupAccessPortal_PanelLoadDataPDSAData.SelectFilters.Search;

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
    /// AccessGroupAccessPortal_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(AccessGroupAccessPortal_PanelLoadDataPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A AccessGroupAccessPortal_PanelLoadDataPDSA object</param>
    /// <returns>An AccessGroupAccessPortal_PanelLoadDataPDSA object</returns>
    public AccessGroupAccessPortal_PanelLoadDataPDSA InitSearchFilter(AccessGroupAccessPortal_PanelLoadDataPDSA searchEntity)
    {
      searchEntity.AccessGroupName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = AccessGroupAccessPortal_PanelLoadDataPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current AccessGroupAccessPortal_PanelLoadDataPDSA
    /// </summary>
    /// <returns>A cloned AccessGroupAccessPortal_PanelLoadDataPDSA object</returns>
    public AccessGroupAccessPortal_PanelLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroupAccessPortal_PanelLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroupAccessPortal_PanelLoadDataPDSA entity to clone</param>
    /// <returns>A cloned AccessGroupAccessPortal_PanelLoadDataPDSA object</returns>
    public AccessGroupAccessPortal_PanelLoadDataPDSA CloneEntity(AccessGroupAccessPortal_PanelLoadDataPDSA entityToClone)
    {
      AccessGroupAccessPortal_PanelLoadDataPDSA newEntity = new AccessGroupAccessPortal_PanelLoadDataPDSA();

      newEntity.AccessGroupAccessPortalUid = entityToClone.AccessGroupAccessPortalUid;
      newEntity.AccessGroupName = entityToClone.AccessGroupName;
      newEntity.TimeScheduleName = entityToClone.TimeScheduleName;
      newEntity.AccessPortalName = entityToClone.AccessPortalName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.AccessGroupNumber = entityToClone.AccessGroupNumber;
      newEntity.PanelScheduleNumber = entityToClone.PanelScheduleNumber;
      newEntity.ActivationDate = entityToClone.ActivationDate;
      newEntity.ExpirationDate = entityToClone.ExpirationDate;
      newEntity.IsEnabled = entityToClone.IsEnabled;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
      newEntity.AccessGroupUid = entityToClone.AccessGroupUid;
      newEntity.AccessPortalBoardTypeTypeCode = entityToClone.AccessPortalBoardTypeTypeCode;
      newEntity.CurrentTimeForCluster = entityToClone.CurrentTimeForCluster;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.AccessGroupLoadToCpuUid = entityToClone.AccessGroupLoadToCpuUid;
      newEntity.ServerAddress = entityToClone.ServerAddress;
      newEntity.DefaultTimeScheduleName = entityToClone.DefaultTimeScheduleName;
      newEntity.DefaultTimeScheduleNumber = entityToClone.DefaultTimeScheduleNumber;
      newEntity.IsConnected = entityToClone.IsConnected;
      newEntity.IsNodeActive = entityToClone.IsNodeActive;

      return newEntity;
    }
    #endregion
  }
}
