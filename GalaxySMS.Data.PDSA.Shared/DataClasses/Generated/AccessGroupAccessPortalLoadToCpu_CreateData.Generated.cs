using System;
using System.Data;
using System.Text;

using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;

namespace GalaxySMS.DataLayer
{
  /// <summary>
  /// This class calls the stored procedure AccessGroupAccessPortalLoadToCpu_CreatePDSAData
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class AccessGroupAccessPortalLoadToCpu_CreatePDSAData : PDSAStoredProcExecute
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AccessGroupAccessPortalLoadToCpu_CreatePDSAData class
    /// </summary>
    public AccessGroupAccessPortalLoadToCpu_CreatePDSAData() : base()
    {
      Entity = new AccessGroupAccessPortalLoadToCpu_CreatePDSA();
      ValidatorObject = new  AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AccessGroupAccessPortalLoadToCpu_CreatePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AccessGroupAccessPortalLoadToCpu_CreatePDSA</param>
    public AccessGroupAccessPortalLoadToCpu_CreatePDSAData(AccessGroupAccessPortalLoadToCpu_CreatePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessGroupAccessPortalLoadToCpu_CreatePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessGroupAccessPortalLoadToCpu_CreatePDSA</param>
    public AccessGroupAccessPortalLoadToCpu_CreatePDSAData(PDSADataProvider dataProvider,
      AccessGroupAccessPortalLoadToCpu_CreatePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessGroupAccessPortalLoadToCpu_CreatePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessGroupAccessPortalLoadToCpu_CreatePDSA</param>
    /// <param name="validator">An instance of a AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator</param>
    public AccessGroupAccessPortalLoadToCpu_CreatePDSAData(PDSADataProvider dataProvider,
      AccessGroupAccessPortalLoadToCpu_CreatePDSA entity, AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator validator)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = validator;

      Init();
    }
    #endregion

    #region Public Property
    /// <summary>
    /// Get/Set the Entity class that will be used to get and set parameters and columns for this data class.
    /// </summary>
    public AccessGroupAccessPortalLoadToCpu_CreatePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "AccessGroupAccessPortalLoadToCpu_CreatePDSAData";
      StoredProcName = "AccessGroupAccessPortalLoadToCpu_Create";
      SchemaName = "GCS";

      // Move validator Properties collection into the Parameters collection
      PropertiesToParameters(ValidatorObject.Properties);

      // Create Parameters
      InitParameters();
    }
    #endregion
    
   #region InitParameters Method
    /// <summary>
    /// Creates all the parameters for the stored procedure.
    /// </summary>
    protected override void InitParameters()
    {
      PDSADataParameter param;

      // Clear all parameters each time
      AllParameters.Clear();

      // Create each parameter object and add to Parameters Collection
      param = new PDSADataParameter();
      param.ParameterName = AccessGroupAccessPortalLoadToCpu_CreatePDSAData.ParameterNames.CpuUid;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AccessGroupAccessPortalLoadToCpu_CreatePDSAData.ParameterNames.AccessGroupAccessPortalUid;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AccessGroupAccessPortalLoadToCpu_CreatePDSAData.ParameterNames.RETURNVALUE;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.ReturnValue;
      AllParameters.Add(param);


      AddReturnValueParameterToCollection();
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator.ParameterNames.CpuUid).SetAsNull == false)
        AllParameters.GetByName(AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      else
        AllParameters.GetByName(AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator.ParameterNames.CpuUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator.ParameterNames.AccessGroupAccessPortalUid).SetAsNull == false)
        AllParameters.GetByName(AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator.ParameterNames.AccessGroupAccessPortalUid).Value = Entity.AccessGroupAccessPortalUid;
      else
        AllParameters.GetByName(AccessGroupAccessPortalLoadToCpu_CreatePDSAValidator.ParameterNames.AccessGroupAccessPortalUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion
    
    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(AccessGroupAccessPortalLoadToCpu_CreatePDSAData.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(AccessGroupAccessPortalLoadToCpu_CreatePDSAData.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
    }
    #endregion
        
    #region SetDirtyFlag Methods
    /// <summary>
    /// This is called with a 'false' value after each successful Insert/Update method call.
    /// </summary>
    /// <param name="isDirty">Called with 'false' by default</param>
    protected override void SetDirtyFlag(bool isDirty)
    {
      Entity.IsDirty = isDirty;
    }
    #endregion
       
    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroupAccessPortalLoadToCpu_CreatePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@AccessGroupAccessPortalUid'
    /// </summary>
    public static string AccessGroupAccessPortalUid = "@AccessGroupAccessPortalUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
