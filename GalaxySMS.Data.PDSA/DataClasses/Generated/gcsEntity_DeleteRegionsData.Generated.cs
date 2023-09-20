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
  /// This class calls the stored procedure gcsEntity_DeleteRegionsPDSAData
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcsEntity_DeleteRegionsPDSAData : PDSAStoredProcExecute
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcsEntity_DeleteRegionsPDSAData class
    /// </summary>
    public gcsEntity_DeleteRegionsPDSAData() : base()
    {
      Entity = new gcsEntity_DeleteRegionsPDSA();
      ValidatorObject = new  gcsEntity_DeleteRegionsPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcsEntity_DeleteRegionsPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcsEntity_DeleteRegionsPDSA</param>
    public gcsEntity_DeleteRegionsPDSAData(gcsEntity_DeleteRegionsPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcsEntity_DeleteRegionsPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsEntity_DeleteRegionsPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsEntity_DeleteRegionsPDSA</param>
    public gcsEntity_DeleteRegionsPDSAData(PDSADataProvider dataProvider,
      gcsEntity_DeleteRegionsPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcsEntity_DeleteRegionsPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsEntity_DeleteRegionsPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsEntity_DeleteRegionsPDSA</param>
    /// <param name="validator">An instance of a gcsEntity_DeleteRegionsPDSAValidator</param>
    public gcsEntity_DeleteRegionsPDSAData(PDSADataProvider dataProvider,
      gcsEntity_DeleteRegionsPDSA entity, gcsEntity_DeleteRegionsPDSAValidator validator)
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
    public gcsEntity_DeleteRegionsPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcsEntity_DeleteRegionsPDSAData";
      StoredProcName = "gcsEntity_DeleteRegions";
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
      param.ParameterName = gcsEntity_DeleteRegionsPDSAData.ParameterNames.EntityId;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsEntity_DeleteRegionsPDSAData.ParameterNames.RETURNVALUE;
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
      if (AllParameters.GetByName(gcsEntity_DeleteRegionsPDSAValidator.ParameterNames.EntityId).SetAsNull == false)
        AllParameters.GetByName(gcsEntity_DeleteRegionsPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      else
        AllParameters.GetByName(gcsEntity_DeleteRegionsPDSAValidator.ParameterNames.EntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion
    
    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcsEntity_DeleteRegionsPDSAData.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcsEntity_DeleteRegionsPDSAData.ParameterNames.RETURNVALUE).GetAsInteger();
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
    /// Contains static string properties that represent the name of each property in the gcsEntity_DeleteRegionsPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
