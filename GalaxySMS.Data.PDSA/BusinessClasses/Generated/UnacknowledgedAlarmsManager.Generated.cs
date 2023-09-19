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
  /// This class should be used when you need to select data for the UnacknowledgedAlarmsPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class UnacknowledgedAlarmsPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the UnacknowledgedAlarmsPDSAManager class
    /// </summary>
    public UnacknowledgedAlarmsPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the UnacknowledgedAlarmsPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public UnacknowledgedAlarmsPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the UnacknowledgedAlarmsPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public UnacknowledgedAlarmsPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private UnacknowledgedAlarmsPDSA _Entity = null;
    private UnacknowledgedAlarmsPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public UnacknowledgedAlarmsPDSA Entity
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
    public UnacknowledgedAlarmsPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new UnacknowledgedAlarmsPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public UnacknowledgedAlarmsPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public UnacknowledgedAlarmsPDSAData DataObject { get; set; }
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
        Entity = new UnacknowledgedAlarmsPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new UnacknowledgedAlarmsPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new UnacknowledgedAlarmsPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "UnacknowledgedAlarmsPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public UnacknowledgedAlarmsPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      UnacknowledgedAlarmsPDSA ret = new UnacknowledgedAlarmsPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid))
        ret.ActivityEventUid = PDSAProperty.ConvertToGuid(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId))
        ret.ClusterGroupId = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber))
        ret.ClusterNumber = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber))
        ret.PanelNumber = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuId))
        ret.CpuId = Convert.ToInt16(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuId]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber))
        ret.BoardNumber = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber))
        ret.SectionNumber = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber))
        ret.ModuleNumber = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber))
        ret.NodeNumber = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel))
        ret.CpuModel = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x))
        ret.DateTime_x = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex))
        ret.BufferIndex = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType))
        ret.PanelActivityType = PDSAString.ConvertToStringTrim(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber))
        ret.InputOutputGroupNumber = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode))
        ret.MultiFactorMode = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription))
        ret.DeviceDescription = PDSAString.ConvertToStringTrim(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription))
        ret.EventDescription = PDSAString.ConvertToStringTrim(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId))
        ret.DeviceEntityId = PDSAProperty.ConvertToGuid(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid))
        ret.DeviceUid = PDSAProperty.ConvertToGuid(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid))
        ret.CpuUid = PDSAProperty.ConvertToGuid(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName))
        ret.ClusterName = PDSAString.ConvertToStringTrim(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent))
        ret.IsAlarmEvent = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority))
        ret.AlarmPriority = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Instructions))
        ret.Instructions = PDSAString.ConvertToStringTrim(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.Instructions]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ResponseRequired))
        ret.ResponseRequired = Convert.ToBoolean(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.ResponseRequired]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid))
        ret.InstructionsNoteUid = PDSAProperty.ConvertToGuid(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid))
        ret.AudioBinaryResourceUid = PDSAProperty.ConvertToGuid(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.RawData))
        ret.RawData = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.RawData]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Color))
        ret.Color = Convert.ToInt32(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.Color]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid))
        ret.PersonUid = PDSAProperty.ConvertToGuid(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid))
        ret.CredentialUid = PDSAProperty.ConvertToGuid(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ColorHex))
        ret.ColorHex = PDSAString.ConvertToStringTrim(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.ColorHex]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription))
        ret.PersonDescription = PDSAString.ConvertToStringTrim(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription))
        ret.CredentialDescription = PDSAString.ConvertToStringTrim(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription]);

      if (values.ContainsKey(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Trace))
        ret.Trace = Convert.ToBoolean(values[UnacknowledgedAlarmsPDSAValidator.ColumnNames.Trace]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of UnacknowledgedAlarmsPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>UnacknowledgedAlarmsPDSACollection</returns>
    public UnacknowledgedAlarmsPDSACollection BuildCollection()
    {
      UnacknowledgedAlarmsPDSACollection coll = new UnacknowledgedAlarmsPDSACollection();
      UnacknowledgedAlarmsPDSA entity = null;
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
    /// <returns>A collection of UnacknowledgedAlarmsPDSA objects</returns>
    public UnacknowledgedAlarmsPDSACollection BuildCollection(DataSet ds)
    {
      UnacknowledgedAlarmsPDSACollection coll = new UnacknowledgedAlarmsPDSACollection();

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
    /// <returns>A collection of UnacknowledgedAlarmsPDSA objects</returns>
    public UnacknowledgedAlarmsPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of UnacknowledgedAlarmsPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(UnacknowledgedAlarmsPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = UnacknowledgedAlarmsPDSAData.SelectFilters.Search;

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
    /// UnacknowledgedAlarmsPDSA.SearchEntity = mgr.InitSearchFilter(UnacknowledgedAlarmsPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A UnacknowledgedAlarmsPDSA object</param>
    /// <returns>An UnacknowledgedAlarmsPDSA object</returns>
    public UnacknowledgedAlarmsPDSA InitSearchFilter(UnacknowledgedAlarmsPDSA searchEntity)
    {

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = UnacknowledgedAlarmsPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current UnacknowledgedAlarmsPDSA
    /// </summary>
    /// <returns>A cloned UnacknowledgedAlarmsPDSA object</returns>
    public UnacknowledgedAlarmsPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in UnacknowledgedAlarmsPDSA
    /// </summary>
    /// <param name="entityToClone">The UnacknowledgedAlarmsPDSA entity to clone</param>
    /// <returns>A cloned UnacknowledgedAlarmsPDSA object</returns>
    public UnacknowledgedAlarmsPDSA CloneEntity(UnacknowledgedAlarmsPDSA entityToClone)
    {
      UnacknowledgedAlarmsPDSA newEntity = new UnacknowledgedAlarmsPDSA();

      newEntity.ActivityEventUid = entityToClone.ActivityEventUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.CpuId = entityToClone.CpuId;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.CpuModel = entityToClone.CpuModel;
      newEntity.DateTime_x = entityToClone.DateTime_x;
      newEntity.BufferIndex = entityToClone.BufferIndex;
      newEntity.PanelActivityType = entityToClone.PanelActivityType;
      newEntity.InputOutputGroupNumber = entityToClone.InputOutputGroupNumber;
      newEntity.MultiFactorMode = entityToClone.MultiFactorMode;
      newEntity.DeviceDescription = entityToClone.DeviceDescription;
      newEntity.EventDescription = entityToClone.EventDescription;
      newEntity.DeviceEntityId = entityToClone.DeviceEntityId;
      newEntity.DeviceUid = entityToClone.DeviceUid;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.IsAlarmEvent = entityToClone.IsAlarmEvent;
      newEntity.AlarmPriority = entityToClone.AlarmPriority;
      newEntity.Instructions = entityToClone.Instructions;
      newEntity.ResponseRequired = entityToClone.ResponseRequired;
      newEntity.InstructionsNoteUid = entityToClone.InstructionsNoteUid;
      newEntity.AudioBinaryResourceUid = entityToClone.AudioBinaryResourceUid;
      newEntity.RawData = entityToClone.RawData;
      newEntity.Color = entityToClone.Color;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.ColorHex = entityToClone.ColorHex;
      newEntity.PersonDescription = entityToClone.PersonDescription;
      newEntity.CredentialDescription = entityToClone.CredentialDescription;
      newEntity.Trace = entityToClone.Trace;

      return newEntity;
    }
    #endregion
  }
}
