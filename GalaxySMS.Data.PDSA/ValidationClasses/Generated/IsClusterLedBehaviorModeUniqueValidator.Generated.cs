using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsClusterLedBehaviorModeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsClusterLedBehaviorModeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsClusterLedBehaviorModeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsClusterLedBehaviorModeUniquePDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        base.Entity = value;
      }
    }
    #endregion
  
    #region Clone Entity Class
    /// <summary>
    /// Clones the current IsClusterLedBehaviorModeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsClusterLedBehaviorModeUniquePDSA object</returns>
    public IsClusterLedBehaviorModeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsClusterLedBehaviorModeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsClusterLedBehaviorModeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsClusterLedBehaviorModeUniquePDSA object</returns>
    public IsClusterLedBehaviorModeUniquePDSA CloneEntity(IsClusterLedBehaviorModeUniquePDSA entityToClone)
    {
      IsClusterLedBehaviorModeUniquePDSA newEntity = new IsClusterLedBehaviorModeUniquePDSA();

      newEntity.Result = entityToClone.Result;

      return newEntity;
    }
    #endregion

    #region CreateProperties Method
    /// <summary>
    /// Creates the collection of PDSAProperty objects. These are used to control validation and null handling.
    /// </summary>
    /// <returns>A collection of PDSAProperty objects</returns>
    public override PDSAProperties CreateProperties()
    {
      PDSAProperties props = new PDSAProperties();
      
      props.Add(PDSAProperty.Create(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.ClusterLedBehaviorModeUid, GetResourceMessage("GCS_IsClusterLedBehaviorModeUniquePDSA_ClusterLedBehaviorModeUid_Header", "Cluster Led Behavior Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsClusterLedBehaviorModeUniquePDSA_ClusterLedBehaviorModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.LedBehaviorCode, GetResourceMessage("GCS_IsClusterLedBehaviorModeUniquePDSA_LedBehaviorCode_Header", "Led Behavior Code"), false, typeof(short), 0, GetResourceMessage("GCS_IsClusterLedBehaviorModeUniquePDSA_LedBehaviorCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsClusterLedBehaviorModeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterLedBehaviorModeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsClusterLedBehaviorModeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterLedBehaviorModeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion
    
    #region InitProperties Method
    /// <summary>
    /// Called by the constructor to create the PDSAProperties collection of all properties that will be validated.
    /// </summary>
    protected override void InitProperties()
    {
      // Set the Properties collection to the collection of Entity Properties
      Properties = CreateProperties();
    }
    #endregion

    #region EntityDataToProperties Method
    /// <summary>
    /// Moves the Entity class data into the Properties collection.
    /// </summary>
    protected override void EntityDataToProperties()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }
      
      this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.ClusterLedBehaviorModeUid).Value = Entity.ClusterLedBehaviorModeUid;
      this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.LedBehaviorCode).Value = Entity.LedBehaviorCode;
      this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }

      if(this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.ClusterLedBehaviorModeUid).IsNull == false)
        Entity.ClusterLedBehaviorModeUid = this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.ClusterLedBehaviorModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.LedBehaviorCode).IsNull == false)
        Entity.LedBehaviorCode = this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.LedBehaviorCode).GetAsShort();
      if(this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsClusterLedBehaviorModeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterLedBehaviorModeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Result'
    /// </summary>
    public static string Result = "Result";
    /// <summary>
    /// Returns '@ClusterLedBehaviorModeUid'
    /// </summary>
    public static string ClusterLedBehaviorModeUid = "@ClusterLedBehaviorModeUid";
    /// <summary>
    /// Returns '@LedBehaviorCode'
    /// </summary>
    public static string LedBehaviorCode = "@LedBehaviorCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterLedBehaviorModeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterLedBehaviorModeUid'
    /// </summary>
    public static string ClusterLedBehaviorModeUid = "@ClusterLedBehaviorModeUid";
    /// <summary>
    /// Returns '@LedBehaviorCode'
    /// </summary>
    public static string LedBehaviorCode = "@LedBehaviorCode";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
