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
  /// This class should be used when you need to select data for the GalaxyCpuInformationPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyCpuInformationPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the GalaxyCpuInformationPDSAManager class
    /// </summary>
    public GalaxyCpuInformationPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the GalaxyCpuInformationPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public GalaxyCpuInformationPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the GalaxyCpuInformationPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public GalaxyCpuInformationPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private GalaxyCpuInformationPDSA _Entity = null;
    private GalaxyCpuInformationPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public GalaxyCpuInformationPDSA Entity
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
    public GalaxyCpuInformationPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new GalaxyCpuInformationPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public GalaxyCpuInformationPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public GalaxyCpuInformationPDSAData DataObject { get; set; }
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
        Entity = new GalaxyCpuInformationPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new GalaxyCpuInformationPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new GalaxyCpuInformationPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "GalaxyCpuInformationPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public GalaxyCpuInformationPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      GalaxyCpuInformationPDSA ret = new GalaxyCpuInformationPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterUid))
        ret.ClusterUid = PDSAProperty.ConvertToGuid(values[GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterUid]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid))
        ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[GalaxyCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuUid))
        ret.CpuUid = PDSAProperty.ConvertToGuid(values[GalaxyCpuInformationPDSAValidator.ColumnNames.CpuUid]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterGroupId))
        ret.ClusterGroupId = Convert.ToInt32(values[GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterGroupId]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterNumber))
        ret.ClusterNumber = Convert.ToInt32(values[GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterNumber]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelNumber))
        ret.PanelNumber = Convert.ToInt32(values[GalaxyCpuInformationPDSAValidator.ColumnNames.PanelNumber]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuNumber))
        ret.CpuNumber = Convert.ToInt16(values[GalaxyCpuInformationPDSAValidator.ColumnNames.CpuNumber]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.SerialNumber))
        ret.SerialNumber = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.SerialNumber]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.IpAddress))
        ret.IpAddress = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.IpAddress]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn))
        ret.DefaultEventLoggingOn = Convert.ToBoolean(values[GalaxyCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventDataLoading))
        ret.PreventDataLoading = Convert.ToBoolean(values[GalaxyCpuInformationPDSAValidator.ColumnNames.PreventDataLoading]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading))
        ret.PreventFlashLoading = Convert.ToBoolean(values[GalaxyCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.LastLogIndex))
        ret.LastLogIndex = Convert.ToInt32(values[GalaxyCpuInformationPDSAValidator.ColumnNames.LastLogIndex]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterName))
        ret.ClusterName = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterName]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelName))
        ret.PanelName = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.PanelName]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode))
        ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive))
        ret.ClusterTypeIsActive = Convert.ToBoolean(values[GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.CredentialDataLength))
        ret.CredentialDataLength = Convert.ToInt16(values[GalaxyCpuInformationPDSAValidator.ColumnNames.CredentialDataLength]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelLocation))
        ret.PanelLocation = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.PanelLocation]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode))
        ret.PanelModelTypeCode = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive))
        ret.PanelModelIsActive = Convert.ToBoolean(values[GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuIsActive))
        ret.CpuIsActive = Convert.ToBoolean(values[GalaxyCpuInformationPDSAValidator.ColumnNames.CpuIsActive]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteUid))
        ret.SiteUid = PDSAProperty.ConvertToGuid(values[GalaxyCpuInformationPDSAValidator.ColumnNames.SiteUid]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteName))
        ret.SiteName = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.SiteName]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[GalaxyCpuInformationPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityName))
        ret.EntityName = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.EntityName]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityType))
        ret.EntityType = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.EntityType]);

      if (values.ContainsKey(GalaxyCpuInformationPDSAValidator.ColumnNames.TimeZoneId))
        ret.TimeZoneId = PDSAString.ConvertToStringTrim(values[GalaxyCpuInformationPDSAValidator.ColumnNames.TimeZoneId]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of GalaxyCpuInformationPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>GalaxyCpuInformationPDSACollection</returns>
    public GalaxyCpuInformationPDSACollection BuildCollection()
    {
      GalaxyCpuInformationPDSACollection coll = new GalaxyCpuInformationPDSACollection();
      GalaxyCpuInformationPDSA entity = null;
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
    /// <returns>A collection of GalaxyCpuInformationPDSA objects</returns>
    public GalaxyCpuInformationPDSACollection BuildCollection(DataSet ds)
    {
      GalaxyCpuInformationPDSACollection coll = new GalaxyCpuInformationPDSACollection();

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
    /// <returns>A collection of GalaxyCpuInformationPDSA objects</returns>
    public GalaxyCpuInformationPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of GalaxyCpuInformationPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(GalaxyCpuInformationPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = GalaxyCpuInformationPDSAData.SelectFilters.Search;

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
    /// GalaxyCpuInformationPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyCpuInformationPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A GalaxyCpuInformationPDSA object</param>
    /// <returns>An GalaxyCpuInformationPDSA object</returns>
    public GalaxyCpuInformationPDSA InitSearchFilter(GalaxyCpuInformationPDSA searchEntity)
    {

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = GalaxyCpuInformationPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current GalaxyCpuInformationPDSA
    /// </summary>
    /// <returns>A cloned GalaxyCpuInformationPDSA object</returns>
    public GalaxyCpuInformationPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyCpuInformationPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyCpuInformationPDSA entity to clone</param>
    /// <returns>A cloned GalaxyCpuInformationPDSA object</returns>
    public GalaxyCpuInformationPDSA CloneEntity(GalaxyCpuInformationPDSA entityToClone)
    {
      GalaxyCpuInformationPDSA newEntity = new GalaxyCpuInformationPDSA();

      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.SerialNumber = entityToClone.SerialNumber;
      newEntity.IpAddress = entityToClone.IpAddress;
      newEntity.DefaultEventLoggingOn = entityToClone.DefaultEventLoggingOn;
      newEntity.PreventDataLoading = entityToClone.PreventDataLoading;
      newEntity.PreventFlashLoading = entityToClone.PreventFlashLoading;
      newEntity.LastLogIndex = entityToClone.LastLogIndex;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.PanelName = entityToClone.PanelName;
      newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
      newEntity.ClusterTypeIsActive = entityToClone.ClusterTypeIsActive;
      newEntity.CredentialDataLength = entityToClone.CredentialDataLength;
      newEntity.PanelLocation = entityToClone.PanelLocation;
      newEntity.PanelModelTypeCode = entityToClone.PanelModelTypeCode;
      newEntity.PanelModelIsActive = entityToClone.PanelModelIsActive;
      newEntity.CpuIsActive = entityToClone.CpuIsActive;
      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.SiteName = entityToClone.SiteName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityType = entityToClone.EntityType;
      newEntity.TimeZoneId = entityToClone.TimeZoneId;

      return newEntity;
    }
    #endregion
  }
}
