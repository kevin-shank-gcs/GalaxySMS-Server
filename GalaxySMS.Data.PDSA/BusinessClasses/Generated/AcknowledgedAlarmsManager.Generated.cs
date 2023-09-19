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
  /// This class should be used when you need to select data for the AcknowledgedAlarmsPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AcknowledgedAlarmsPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AcknowledgedAlarmsPDSAManager class
    /// </summary>
    public AcknowledgedAlarmsPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the AcknowledgedAlarmsPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public AcknowledgedAlarmsPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the AcknowledgedAlarmsPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public AcknowledgedAlarmsPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private AcknowledgedAlarmsPDSA _Entity = null;
    private AcknowledgedAlarmsPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public AcknowledgedAlarmsPDSA Entity
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
    public AcknowledgedAlarmsPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new AcknowledgedAlarmsPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public AcknowledgedAlarmsPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public AcknowledgedAlarmsPDSAData DataObject { get; set; }
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
        Entity = new AcknowledgedAlarmsPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new AcknowledgedAlarmsPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new AcknowledgedAlarmsPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "AcknowledgedAlarmsPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public AcknowledgedAlarmsPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      AcknowledgedAlarmsPDSA ret = new AcknowledgedAlarmsPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid))
        ret.ActivityEventUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId))
        ret.ClusterGroupId = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber))
        ret.ClusterNumber = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber))
        ret.PanelNumber = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.CpuId))
        ret.CpuId = Convert.ToInt16(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.CpuId]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber))
        ret.BoardNumber = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber))
        ret.SectionNumber = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber))
        ret.ModuleNumber = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber))
        ret.NodeNumber = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel))
        ret.CpuModel = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x))
        ret.DateTime_x = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex))
        ret.BufferIndex = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType))
        ret.PanelActivityType = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber))
        ret.InputOutputGroupNumber = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode))
        ret.MultiFactorMode = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription))
        ret.DeviceDescription = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription))
        ret.EventDescription = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId))
        ret.DeviceEntityId = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid))
        ret.DeviceUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid))
        ret.CpuUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName))
        ret.ClusterName = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent))
        ret.IsAlarmEvent = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority))
        ret.AlarmPriority = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.Instructions))
        ret.Instructions = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.Instructions]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.ResponseRequired))
        ret.ResponseRequired = Convert.ToBoolean(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.ResponseRequired]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid))
        ret.InstructionsNoteUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid))
        ret.AudioBinaryResourceUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.RawData))
        ret.RawData = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.RawData]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.Color))
        ret.Color = Convert.ToInt32(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.Color]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid))
        ret.PersonUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid))
        ret.CredentialUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.ColorHex))
        ret.ColorHex = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.ColorHex]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription))
        ret.PersonDescription = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription))
        ret.CredentialDescription = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription]);

      if (values.ContainsKey(AcknowledgedAlarmsPDSAValidator.ColumnNames.Trace))
        ret.Trace = Convert.ToBoolean(values[AcknowledgedAlarmsPDSAValidator.ColumnNames.Trace]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of AcknowledgedAlarmsPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>AcknowledgedAlarmsPDSACollection</returns>
    public AcknowledgedAlarmsPDSACollection BuildCollection()
    {
      AcknowledgedAlarmsPDSACollection coll = new AcknowledgedAlarmsPDSACollection();
      AcknowledgedAlarmsPDSA entity = null;
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
    /// <returns>A collection of AcknowledgedAlarmsPDSA objects</returns>
    public AcknowledgedAlarmsPDSACollection BuildCollection(DataSet ds)
    {
      AcknowledgedAlarmsPDSACollection coll = new AcknowledgedAlarmsPDSACollection();

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
    /// <returns>A collection of AcknowledgedAlarmsPDSA objects</returns>
    public AcknowledgedAlarmsPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of AcknowledgedAlarmsPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(AcknowledgedAlarmsPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = AcknowledgedAlarmsPDSAData.SelectFilters.Search;

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
    /// AcknowledgedAlarmsPDSA.SearchEntity = mgr.InitSearchFilter(AcknowledgedAlarmsPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A AcknowledgedAlarmsPDSA object</param>
    /// <returns>An AcknowledgedAlarmsPDSA object</returns>
    public AcknowledgedAlarmsPDSA InitSearchFilter(AcknowledgedAlarmsPDSA searchEntity)
    {

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = AcknowledgedAlarmsPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current AcknowledgedAlarmsPDSA
    /// </summary>
    /// <returns>A cloned AcknowledgedAlarmsPDSA object</returns>
    public AcknowledgedAlarmsPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AcknowledgedAlarmsPDSA
    /// </summary>
    /// <param name="entityToClone">The AcknowledgedAlarmsPDSA entity to clone</param>
    /// <returns>A cloned AcknowledgedAlarmsPDSA object</returns>
    public AcknowledgedAlarmsPDSA CloneEntity(AcknowledgedAlarmsPDSA entityToClone)
    {
      AcknowledgedAlarmsPDSA newEntity = new AcknowledgedAlarmsPDSA();

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
