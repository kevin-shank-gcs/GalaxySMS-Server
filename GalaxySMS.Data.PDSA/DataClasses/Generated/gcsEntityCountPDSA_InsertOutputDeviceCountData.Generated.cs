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
  /// This class calls the stored procedure gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData : PDSAStoredProcExecute
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData class
    /// </summary>
    public gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData() : base()
    {
      Entity = new gcsEntityCountPDSA_InsertOutputDeviceCountPDSA();
      ValidatorObject = new  gcsEntityCountPDSA_InsertOutputDeviceCountPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcsEntityCountPDSA_InsertOutputDeviceCountPDSA</param>
    public gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData(gcsEntityCountPDSA_InsertOutputDeviceCountPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcsEntityCountPDSA_InsertOutputDeviceCountPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsEntityCountPDSA_InsertOutputDeviceCountPDSA</param>
    public gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData(PDSADataProvider dataProvider,
      gcsEntityCountPDSA_InsertOutputDeviceCountPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcsEntityCountPDSA_InsertOutputDeviceCountPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsEntityCountPDSA_InsertOutputDeviceCountPDSA</param>
    /// <param name="validator">An instance of a gcsEntityCountPDSA_InsertOutputDeviceCountPDSAValidator</param>
    public gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData(PDSADataProvider dataProvider,
      gcsEntityCountPDSA_InsertOutputDeviceCountPDSA entity, gcsEntityCountPDSA_InsertOutputDeviceCountPDSAValidator validator)
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
    public gcsEntityCountPDSA_InsertOutputDeviceCountPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData";
      StoredProcName = "gcsEntityCountPDSA_InsertOutputDeviceCount";
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
      param.ParameterName = gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData.ParameterNames.EntityId;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData.ParameterNames.RETURNVALUE;
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
      if (AllParameters.GetByName(gcsEntityCountPDSA_InsertOutputDeviceCountPDSAValidator.ParameterNames.EntityId).SetAsNull == false)
        AllParameters.GetByName(gcsEntityCountPDSA_InsertOutputDeviceCountPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      else
        AllParameters.GetByName(gcsEntityCountPDSA_InsertOutputDeviceCountPDSAValidator.ParameterNames.EntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion
    
    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcsEntityCountPDSA_InsertOutputDeviceCountPDSAData.ParameterNames.RETURNVALUE).GetAsInteger();
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
    /// Contains static string properties that represent the name of each property in the gcsEntityCountPDSA_InsertOutputDeviceCountPDSA class.
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
