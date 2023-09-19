using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsLiquidCrystalDisplayEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsLiquidCrystalDisplayEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsLiquidCrystalDisplayEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsLiquidCrystalDisplayEntityMapUniquePDSA Entity
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
    /// Clones the current IsLiquidCrystalDisplayEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsLiquidCrystalDisplayEntityMapUniquePDSA object</returns>
    public IsLiquidCrystalDisplayEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsLiquidCrystalDisplayEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsLiquidCrystalDisplayEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsLiquidCrystalDisplayEntityMapUniquePDSA object</returns>
    public IsLiquidCrystalDisplayEntityMapUniquePDSA CloneEntity(IsLiquidCrystalDisplayEntityMapUniquePDSA entityToClone)
    {
      IsLiquidCrystalDisplayEntityMapUniquePDSA newEntity = new IsLiquidCrystalDisplayEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayEntityMapUid, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_LiquidCrystalDisplayEntityMapUid_Header", "Liquid Crystal Display Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_LiquidCrystalDisplayEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_LiquidCrystalDisplayUid_Header", "Liquid Crystal Display Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_LiquidCrystalDisplayUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayEntityMapUid).Value = Entity.LiquidCrystalDisplayEntityMapUid;
      this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).Value = Entity.LiquidCrystalDisplayUid;
      this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayEntityMapUid).IsNull == false)
        Entity.LiquidCrystalDisplayEntityMapUid = this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).IsNull == false)
        Entity.LiquidCrystalDisplayUid = this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).GetAsGuid();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsLiquidCrystalDisplayEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsLiquidCrystalDisplayEntityMapUniquePDSA class.
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
    /// Returns '@LiquidCrystalDisplayEntityMapUid'
    /// </summary>
    public static string LiquidCrystalDisplayEntityMapUid = "@LiquidCrystalDisplayEntityMapUid";
    /// <summary>
    /// Returns '@LiquidCrystalDisplayUid'
    /// </summary>
    public static string LiquidCrystalDisplayUid = "@LiquidCrystalDisplayUid";
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

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsLiquidCrystalDisplayEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@LiquidCrystalDisplayEntityMapUid'
    /// </summary>
    public static string LiquidCrystalDisplayEntityMapUid = "@LiquidCrystalDisplayEntityMapUid";
    /// <summary>
    /// Returns '@LiquidCrystalDisplayUid'
    /// </summary>
    public static string LiquidCrystalDisplayUid = "@LiquidCrystalDisplayUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
