using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsInterfaceBoardSectionModeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsInterfaceBoardSectionModeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsInterfaceBoardSectionModeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsInterfaceBoardSectionModeUniquePDSA Entity
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
    /// Clones the current IsInterfaceBoardSectionModeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsInterfaceBoardSectionModeUniquePDSA object</returns>
    public IsInterfaceBoardSectionModeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsInterfaceBoardSectionModeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsInterfaceBoardSectionModeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsInterfaceBoardSectionModeUniquePDSA object</returns>
    public IsInterfaceBoardSectionModeUniquePDSA CloneEntity(IsInterfaceBoardSectionModeUniquePDSA entityToClone)
    {
      IsInterfaceBoardSectionModeUniquePDSA newEntity = new IsInterfaceBoardSectionModeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_InterfaceBoardSectionModeUid_Header", "Interface Board Section Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_InterfaceBoardSectionModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardTypeUid, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_InterfaceBoardTypeUid_Header", "Interface Board Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_InterfaceBoardTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.ModeCode, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_ModeCode_Header", "Mode Code"), false, typeof(short), 0, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_ModeCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Description, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_Description_Header", "Description"), false, typeof(string), 1000, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsInterfaceBoardSectionModeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).Value = Entity.InterfaceBoardSectionModeUid;
      this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardTypeUid).Value = Entity.InterfaceBoardTypeUid;
      this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.ModeCode).Value = Entity.ModeCode;
      this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Description).Value = Entity.Description;
      this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).IsNull == false)
        Entity.InterfaceBoardSectionModeUid = this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardTypeUid).IsNull == false)
        Entity.InterfaceBoardTypeUid = this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.ModeCode).IsNull == false)
        Entity.ModeCode = this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.ModeCode).GetAsShort();
      if(this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Description).IsNull == false)
        Entity.Description = this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Description).GetAsString();
      if(this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInterfaceBoardSectionModeUniquePDSA class.
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
    /// Returns '@InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "@InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@InterfaceBoardTypeUid'
    /// </summary>
    public static string InterfaceBoardTypeUid = "@InterfaceBoardTypeUid";
    /// <summary>
    /// Returns '@ModeCode'
    /// </summary>
    public static string ModeCode = "@ModeCode";
    /// <summary>
    /// Returns '@Description'
    /// </summary>
    public static string Description = "@Description";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInterfaceBoardSectionModeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "@InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@InterfaceBoardTypeUid'
    /// </summary>
    public static string InterfaceBoardTypeUid = "@InterfaceBoardTypeUid";
    /// <summary>
    /// Returns '@ModeCode'
    /// </summary>
    public static string ModeCode = "@ModeCode";
    /// <summary>
    /// Returns '@Description'
    /// </summary>
    public static string Description = "@Description";
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
