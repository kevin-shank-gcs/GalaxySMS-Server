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
  /// This class should be used when you need to select data for the AccessPortalViewPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalViewPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AccessPortalViewPDSAManager class
    /// </summary>
    public AccessPortalViewPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the AccessPortalViewPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public AccessPortalViewPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the AccessPortalViewPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public AccessPortalViewPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private AccessPortalViewPDSA _Entity = null;
    private AccessPortalViewPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public AccessPortalViewPDSA Entity
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
    public AccessPortalViewPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new AccessPortalViewPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public AccessPortalViewPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public AccessPortalViewPDSAData DataObject { get; set; }
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
        Entity = new AccessPortalViewPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new AccessPortalViewPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new AccessPortalViewPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "AccessPortalViewPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public AccessPortalViewPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      AccessPortalViewPDSA ret = new AccessPortalViewPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.AccessPortalUid))
        ret.AccessPortalUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.AccessPortalUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.AccessPortalTypeUid))
        ret.AccessPortalTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.AccessPortalTypeUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.BinaryResourceUid))
        ret.BinaryResourceUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.BinaryResourceUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.SiteUid))
        ret.SiteUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.SiteUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.PortalName))
        ret.PortalName = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.PortalName]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.Location))
        ret.Location = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.Location]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ServiceComment))
        ret.ServiceComment = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.ServiceComment]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.CriticalityComment))
        ret.CriticalityComment = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.CriticalityComment]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.Comment))
        ret.Comment = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.Comment]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.IsTemplate))
        ret.IsTemplate = Convert.ToBoolean(values[AccessPortalViewPDSAValidator.ColumnNames.IsTemplate]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.IsEnabled))
        ret.IsEnabled = Convert.ToBoolean(values[AccessPortalViewPDSAValidator.ColumnNames.IsEnabled]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalViewPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalViewPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.ConcurrencyValue]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.RegionUid))
        ret.RegionUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.RegionUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.SiteName))
        ret.SiteName = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.SiteName]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.RegionName))
        ret.RegionName = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.RegionName]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ClusterGroupId))
        ret.ClusterGroupId = Convert.ToInt32(values[AccessPortalViewPDSAValidator.ColumnNames.ClusterGroupId]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ClusterNumber))
        ret.ClusterNumber = Convert.ToInt32(values[AccessPortalViewPDSAValidator.ColumnNames.ClusterNumber]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.PanelNumber))
        ret.PanelNumber = Convert.ToInt32(values[AccessPortalViewPDSAValidator.ColumnNames.PanelNumber]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.BoardNumber))
        ret.BoardNumber = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.BoardNumber]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.SectionNumber))
        ret.SectionNumber = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.SectionNumber]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ModuleNumber))
        ret.ModuleNumber = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.ModuleNumber]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.NodeNumber))
        ret.NodeNumber = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.NodeNumber]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ClusterTypeUid))
        ret.ClusterTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.ClusterTypeUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ClusterTypeCode))
        ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.ClusterTypeCode]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.GalaxyPanelModelUid))
        ret.GalaxyPanelModelUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.GalaxyPanelModelUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.GalaxyPanelTypeCode))
        ret.GalaxyPanelTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.GalaxyPanelTypeCode]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardTypeUid))
        ret.InterfaceBoardTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardTypeUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardTypeCode))
        ret.InterfaceBoardTypeCode = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardTypeCode]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardModel))
        ret.InterfaceBoardModel = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardModel]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
        ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode))
        ret.InterfaceBoardSectionModeCode = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid))
        ret.GalaxyHardwareModuleTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ModuleTypeCode))
        ret.ModuleTypeCode = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.ModuleTypeCode]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.IsNodeActive))
        ret.IsNodeActive = Convert.ToBoolean(values[AccessPortalViewPDSAValidator.ColumnNames.IsNodeActive]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.DoorNumber))
        ret.DoorNumber = Convert.ToInt16(values[AccessPortalViewPDSAValidator.ColumnNames.DoorNumber]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
        ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
        ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
        ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
        ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.GalaxyPanelUid))
        ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.GalaxyPanelUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.PanelName))
        ret.PanelName = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.PanelName]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ClusterUid))
        ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AccessPortalViewPDSAValidator.ColumnNames.ClusterUid]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.ClusterName))
        ret.ClusterName = PDSAString.ConvertToStringTrim(values[AccessPortalViewPDSAValidator.ColumnNames.ClusterName]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.LastEventTime))
        ret.LastEventTime = PDSAProperty.ConvertToDateTimeOffset(values[AccessPortalViewPDSAValidator.ColumnNames.LastEventTime]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.LastAccessGrantedTime))
        ret.LastAccessGrantedTime = PDSAProperty.ConvertToDateTimeOffset(values[AccessPortalViewPDSAValidator.ColumnNames.LastAccessGrantedTime]);

      if (values.ContainsKey(AccessPortalViewPDSAValidator.ColumnNames.TotalRowCount))
        ret.TotalRowCount = Convert.ToInt32(values[AccessPortalViewPDSAValidator.ColumnNames.TotalRowCount]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of AccessPortalViewPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>AccessPortalViewPDSACollection</returns>
    public AccessPortalViewPDSACollection BuildCollection()
    {
      AccessPortalViewPDSACollection coll = new AccessPortalViewPDSACollection();
      AccessPortalViewPDSA entity = null;
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
    /// <returns>A collection of AccessPortalViewPDSA objects</returns>
    public AccessPortalViewPDSACollection BuildCollection(DataSet ds)
    {
      AccessPortalViewPDSACollection coll = new AccessPortalViewPDSACollection();

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
    /// <returns>A collection of AccessPortalViewPDSA objects</returns>
    public AccessPortalViewPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of AccessPortalViewPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(AccessPortalViewPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = AccessPortalViewPDSAData.SelectFilters.Search;

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
    /// AccessPortalViewPDSA.SearchEntity = mgr.InitSearchFilter(AccessPortalViewPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A AccessPortalViewPDSA object</param>
    /// <returns>An AccessPortalViewPDSA object</returns>
    public AccessPortalViewPDSA InitSearchFilter(AccessPortalViewPDSA searchEntity)
    {
      searchEntity.PortalName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = AccessPortalViewPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current AccessPortalViewPDSA
    /// </summary>
    /// <returns>A cloned AccessPortalViewPDSA object</returns>
    public AccessPortalViewPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalViewPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalViewPDSA entity to clone</param>
    /// <returns>A cloned AccessPortalViewPDSA object</returns>
    public AccessPortalViewPDSA CloneEntity(AccessPortalViewPDSA entityToClone)
    {
      AccessPortalViewPDSA newEntity = new AccessPortalViewPDSA();

      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.AccessPortalTypeUid = entityToClone.AccessPortalTypeUid;
      newEntity.BinaryResourceUid = entityToClone.BinaryResourceUid;
      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.PortalName = entityToClone.PortalName;
      newEntity.Location = entityToClone.Location;
      newEntity.ServiceComment = entityToClone.ServiceComment;
      newEntity.CriticalityComment = entityToClone.CriticalityComment;
      newEntity.Comment = entityToClone.Comment;
      newEntity.IsTemplate = entityToClone.IsTemplate;
      newEntity.IsEnabled = entityToClone.IsEnabled;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.RegionUid = entityToClone.RegionUid;
      newEntity.SiteName = entityToClone.SiteName;
      newEntity.RegionName = entityToClone.RegionName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.ClusterTypeUid = entityToClone.ClusterTypeUid;
      newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
      newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;
      newEntity.GalaxyPanelTypeCode = entityToClone.GalaxyPanelTypeCode;
      newEntity.InterfaceBoardTypeUid = entityToClone.InterfaceBoardTypeUid;
      newEntity.InterfaceBoardTypeCode = entityToClone.InterfaceBoardTypeCode;
      newEntity.InterfaceBoardModel = entityToClone.InterfaceBoardModel;
      newEntity.InterfaceBoardSectionModeUid = entityToClone.InterfaceBoardSectionModeUid;
      newEntity.InterfaceBoardSectionModeCode = entityToClone.InterfaceBoardSectionModeCode;
      newEntity.GalaxyHardwareModuleTypeUid = entityToClone.GalaxyHardwareModuleTypeUid;
      newEntity.ModuleTypeCode = entityToClone.ModuleTypeCode;
      newEntity.IsNodeActive = entityToClone.IsNodeActive;
      newEntity.DoorNumber = entityToClone.DoorNumber;
      newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;
      newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
      newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
      newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.PanelName = entityToClone.PanelName;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.LastEventTime = entityToClone.LastEventTime;
      newEntity.LastAccessGrantedTime = entityToClone.LastAccessGrantedTime;
      newEntity.TotalRowCount = entityToClone.TotalRowCount;

      return newEntity;
    }
    #endregion
  }
}
