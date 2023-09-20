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
  /// This class should be used when you need to select data for the UserEntityRoleViewPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class UserEntityRoleViewPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the UserEntityRoleViewPDSAManager class
    /// </summary>
    public UserEntityRoleViewPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the UserEntityRoleViewPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public UserEntityRoleViewPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the UserEntityRoleViewPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public UserEntityRoleViewPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private UserEntityRoleViewPDSA _Entity = null;
    private UserEntityRoleViewPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public UserEntityRoleViewPDSA Entity
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
    public UserEntityRoleViewPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new UserEntityRoleViewPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public UserEntityRoleViewPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public UserEntityRoleViewPDSAData DataObject { get; set; }
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
        Entity = new UserEntityRoleViewPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new UserEntityRoleViewPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new UserEntityRoleViewPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "UserEntityRoleViewPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public UserEntityRoleViewPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      UserEntityRoleViewPDSA ret = new UserEntityRoleViewPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.UserName))
        ret.UserName = PDSAString.ConvertToStringTrim(values[UserEntityRoleViewPDSAValidator.ColumnNames.UserName]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.EntityName))
        ret.EntityName = PDSAString.ConvertToStringTrim(values[UserEntityRoleViewPDSAValidator.ColumnNames.EntityName]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.RoleName))
        ret.RoleName = PDSAString.ConvertToStringTrim(values[UserEntityRoleViewPDSAValidator.ColumnNames.RoleName]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.UserId))
        ret.UserId = PDSAProperty.ConvertToGuid(values[UserEntityRoleViewPDSAValidator.ColumnNames.UserId]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.RoleId))
        ret.RoleId = PDSAProperty.ConvertToGuid(values[UserEntityRoleViewPDSAValidator.ColumnNames.RoleId]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[UserEntityRoleViewPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.ParentEntityId))
        ret.ParentEntityId = PDSAProperty.ConvertToGuid(values[UserEntityRoleViewPDSAValidator.ColumnNames.ParentEntityId]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IsAdministrator))
        ret.IsAdministrator = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IsAdministrator]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.InheritParentRoles))
        ret.InheritParentRoles = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.InheritParentRoles]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IsAdministratorRole))
        ret.IsAdministratorRole = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IsAdministratorRole]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllClusters))
        ret.IncludeAllClusters = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllClusters]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllAccessPortals))
        ret.IncludeAllAccessPortals = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllAccessPortals]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllInputOutputGroups))
        ret.IncludeAllInputOutputGroups = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllInputOutputGroups]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllInputDevices))
        ret.IncludeAllInputDevices = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllInputDevices]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllOutputDevices))
        ret.IncludeAllOutputDevices = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllOutputDevices]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllSites))
        ret.IncludeAllSites = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllSites]);

      if (values.ContainsKey(UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllRegions))
        ret.IncludeAllRegions = Convert.ToBoolean(values[UserEntityRoleViewPDSAValidator.ColumnNames.IncludeAllRegions]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of UserEntityRoleViewPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>UserEntityRoleViewPDSACollection</returns>
    public UserEntityRoleViewPDSACollection BuildCollection()
    {
      UserEntityRoleViewPDSACollection coll = new UserEntityRoleViewPDSACollection();
      UserEntityRoleViewPDSA entity = null;
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
    /// <returns>A collection of UserEntityRoleViewPDSA objects</returns>
    public UserEntityRoleViewPDSACollection BuildCollection(DataSet ds)
    {
      UserEntityRoleViewPDSACollection coll = new UserEntityRoleViewPDSACollection();

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
    /// <returns>A collection of UserEntityRoleViewPDSA objects</returns>
    public UserEntityRoleViewPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of UserEntityRoleViewPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(UserEntityRoleViewPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = UserEntityRoleViewPDSAData.SelectFilters.Search;

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
    /// UserEntityRoleViewPDSA.SearchEntity = mgr.InitSearchFilter(UserEntityRoleViewPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A UserEntityRoleViewPDSA object</param>
    /// <returns>An UserEntityRoleViewPDSA object</returns>
    public UserEntityRoleViewPDSA InitSearchFilter(UserEntityRoleViewPDSA searchEntity)
    {
      searchEntity.UserName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = UserEntityRoleViewPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current UserEntityRoleViewPDSA
    /// </summary>
    /// <returns>A cloned UserEntityRoleViewPDSA object</returns>
    public UserEntityRoleViewPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in UserEntityRoleViewPDSA
    /// </summary>
    /// <param name="entityToClone">The UserEntityRoleViewPDSA entity to clone</param>
    /// <returns>A cloned UserEntityRoleViewPDSA object</returns>
    public UserEntityRoleViewPDSA CloneEntity(UserEntityRoleViewPDSA entityToClone)
    {
      UserEntityRoleViewPDSA newEntity = new UserEntityRoleViewPDSA();

      newEntity.UserName = entityToClone.UserName;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.RoleName = entityToClone.RoleName;
      newEntity.UserId = entityToClone.UserId;
      newEntity.RoleId = entityToClone.RoleId;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ParentEntityId = entityToClone.ParentEntityId;
      newEntity.IsAdministrator = entityToClone.IsAdministrator;
      newEntity.InheritParentRoles = entityToClone.InheritParentRoles;
      newEntity.IsAdministratorRole = entityToClone.IsAdministratorRole;
      newEntity.IncludeAllClusters = entityToClone.IncludeAllClusters;
      newEntity.IncludeAllAccessPortals = entityToClone.IncludeAllAccessPortals;
      newEntity.IncludeAllInputOutputGroups = entityToClone.IncludeAllInputOutputGroups;
      newEntity.IncludeAllInputDevices = entityToClone.IncludeAllInputDevices;
      newEntity.IncludeAllOutputDevices = entityToClone.IncludeAllOutputDevices;
      newEntity.IncludeAllSites = entityToClone.IncludeAllSites;
      newEntity.IncludeAllRegions = entityToClone.IncludeAllRegions;

      return newEntity;
    }
    #endregion
  }
}
