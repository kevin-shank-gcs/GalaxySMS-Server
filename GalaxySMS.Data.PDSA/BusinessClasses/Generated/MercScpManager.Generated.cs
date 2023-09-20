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
using GCS.Core.Common.Logger;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class is used when you need to add, edit, delete, select and validate data for the MercScpPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class MercScpPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the MercScpPDSAManager class
    /// </summary>
    public MercScpPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the MercScpPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public MercScpPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the MercScpPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public MercScpPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private MercScpPDSA _Entity = null;
    private MercScpPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public MercScpPDSA Entity
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
    public MercScpPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new MercScpPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public MercScpPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public MercScpPDSAData DataObject { get; set; }
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
        Entity = new MercScpPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new MercScpPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new MercScpPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "MercScpPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public MercScpPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      MercScpPDSA ret = new MercScpPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.MercScpUid))
        ret.MercScpUid = PDSAProperty.ConvertToGuid(values[MercScpPDSAValidator.ColumnNames.MercScpUid]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.MercScpTypeUid))
        ret.MercScpTypeUid = PDSAProperty.ConvertToGuid(values[MercScpPDSAValidator.ColumnNames.MercScpTypeUid]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.MercScpGroupUid))
        ret.MercScpGroupUid = PDSAProperty.ConvertToGuid(values[MercScpPDSAValidator.ColumnNames.MercScpGroupUid]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.ScpName))
        ret.ScpName = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.ScpName]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.Location))
        ret.Location = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.Location]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.Description))
        ret.Description = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.Description]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.MacAddress))
        ret.MacAddress = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.MacAddress]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.Serialnumber))
        ret.Serialnumber = Convert.ToUInt64(values[MercScpPDSAValidator.ColumnNames.Serialnumber]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.ConnectionType))
        ret.ConnectionType = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.ConnectionType]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.IpAddress))
        ret.IpAddress = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.IpAddress]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.IpPort))
        ret.IpPort = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.IpPort]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.AesPassword))
        ret.AesPassword = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.AesPassword]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.ScpReplyTimeout))
        ret.ScpReplyTimeout = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.ScpReplyTimeout]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.TcpConnectRetryInterval))
        ret.TcpConnectRetryInterval = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.TcpConnectRetryInterval]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.RetryCountBeforeOffline))
        ret.RetryCountBeforeOffline = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.RetryCountBeforeOffline]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.OfflineTime))
        ret.OfflineTime = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.OfflineTime]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.PollDelay))
        ret.PollDelay = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.PollDelay]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.TimeZoneId))
        ret.TimeZoneId = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.TimeZoneId]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.UseDaylightSavingsTime))
        ret.UseDaylightSavingsTime = Convert.ToBoolean(values[MercScpPDSAValidator.ColumnNames.UseDaylightSavingsTime]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.TransactionCount))
        ret.TransactionCount = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.TransactionCount]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.TransactionUnreportedLimit))
        ret.TransactionUnreportedLimit = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.TransactionUnreportedLimit]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.DualPortEnabled))
        ret.DualPortEnabled = Convert.ToBoolean(values[MercScpPDSAValidator.ColumnNames.DualPortEnabled]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.ConnectionTypeAlt))
        ret.ConnectionTypeAlt = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.ConnectionTypeAlt]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.RetryCountBeforeOfflineAlt))
        ret.RetryCountBeforeOfflineAlt = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.RetryCountBeforeOfflineAlt]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.PollDelayAlt))
        ret.PollDelayAlt = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.PollDelayAlt]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.IpAddressAlt))
        ret.IpAddressAlt = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.IpAddressAlt]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.IpPortAlt))
        ret.IpPortAlt = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.IpPortAlt]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.AllowConnection))
        ret.AllowConnection = Convert.ToBoolean(values[MercScpPDSAValidator.ColumnNames.AllowConnection]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = PDSAProperty.ConvertToDateTimeOffset(values[MercScpPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = PDSAProperty.ConvertToDateTimeOffset(values[MercScpPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[MercScpPDSAValidator.ColumnNames.ConcurrencyValue]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[MercScpPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.PageNumber))
        ret.PageNumber = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.PageNumber]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.PageSize))
        ret.PageSize = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.PageSize]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.SortColumn))
        ret.SortColumn = PDSAString.ConvertToStringTrim(values[MercScpPDSAValidator.ColumnNames.SortColumn]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.DescendingOrder))
        ret.DescendingOrder = Convert.ToBoolean(values[MercScpPDSAValidator.ColumnNames.DescendingOrder]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.SiteUid))
        ret.SiteUid = PDSAProperty.ConvertToGuid(values[MercScpPDSAValidator.ColumnNames.SiteUid]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.TotalRowCount))
        ret.TotalRowCount = Convert.ToInt32(values[MercScpPDSAValidator.ColumnNames.TotalRowCount]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.Online))
        ret.Online = Convert.ToBoolean(values[MercScpPDSAValidator.ColumnNames.Online]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.LastConnected))
        ret.LastConnected = PDSAProperty.ConvertToDateTimeOffset(values[MercScpPDSAValidator.ColumnNames.LastConnected]);

      if (values.ContainsKey(MercScpPDSAValidator.ColumnNames.LastDisconnected))
        ret.LastDisconnected = PDSAProperty.ConvertToDateTimeOffset(values[MercScpPDSAValidator.ColumnNames.LastDisconnected]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of MercScpPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>MercScpPDSACollection</returns>
    public MercScpPDSACollection BuildCollection()
    {
      MercScpPDSACollection coll = new MercScpPDSACollection();
      MercScpPDSA entity = null;
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
    /// <returns>A collection of MercScpPDSA objects</returns>
    public MercScpPDSACollection BuildCollection(DataSet ds)
    {
      MercScpPDSACollection coll = new MercScpPDSACollection();

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
    /// <returns>A collection of MercScpPDSA objects</returns>
    public MercScpPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of MercScpPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(MercScpPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = MercScpPDSAData.SelectFilters.Search;

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
    /// MercScpPDSA.SearchEntity = mgr.InitSearchFilter(MercScpPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A MercScpPDSA object</param>
    /// <returns>An MercScpPDSA object</returns>
    public MercScpPDSA InitSearchFilter(MercScpPDSA searchEntity)
    {
      searchEntity.ScpName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = MercScpPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.MercScp table
    /// </summary>
    /// <param name="entity">An MercScpPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(MercScpPDSA entity)
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
    /// Updates an entity in the GCS.MercScp table
    /// </summary>
    /// <param name="entity">An MercScpPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(MercScpPDSA entity)
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
    /// Deletes an entity from the GCS.MercScp table
    /// </summary>
    /// <param name="entity">An MercScpPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(MercScpPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.MercScpUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetMercScpPDSAsByFK_MercScpMercScpGroupEntity Method
    public MercScpPDSACollection GetMercScpPDSAsByFK_MercScpMercScpGroupEntity(MercScpGroupPDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = MercScpPDSAData.SelectFilters.ByMercScpGroupUid;
           }
           else
           {
           }
           
           Entity.MercScpGroupUid = entity.MercScpGroupUid;
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
        return new MercScpPDSACollection();
    }
    #endregion

    #region GetMercScpPDSAsByFK_MercScpMercScpGroup Method
    public MercScpPDSACollection GetMercScpPDSAsByFK_MercScpMercScpGroup(Guid mercScpGroupUid)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = MercScpPDSAData.SelectFilters.ByMercScpGroupUid;
        }
        else
        {
        }
        
        Entity.MercScpGroupUid = mercScpGroupUid;
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

