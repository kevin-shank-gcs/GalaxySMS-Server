using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyInputDeviceTimeScheduleUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyInputDeviceTimeScheduleUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyInputDeviceTimeScheduleUniquePDSA Entity
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
    /// Clones the current IsGalaxyInputDeviceTimeScheduleUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyInputDeviceTimeScheduleUniquePDSA object</returns>
    public IsGalaxyInputDeviceTimeScheduleUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyInputDeviceTimeScheduleUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyInputDeviceTimeScheduleUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyInputDeviceTimeScheduleUniquePDSA object</returns>
    public IsGalaxyInputDeviceTimeScheduleUniquePDSA CloneEntity(IsGalaxyInputDeviceTimeScheduleUniquePDSA entityToClone)
    {
      IsGalaxyInputDeviceTimeScheduleUniquePDSA newEntity = new IsGalaxyInputDeviceTimeScheduleUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.GalaxyInputDeviceScheduleUid, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_GalaxyInputDeviceScheduleUid_Header", "Galaxy Input Device Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_GalaxyInputDeviceScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.InputDeviceUid, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_InputDeviceUid_Header", "Input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.Tag, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_Tag_Header", "Tag"), false, typeof(string), 8000, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInputDeviceTimeScheduleUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.GalaxyInputDeviceScheduleUid).Value = Entity.GalaxyInputDeviceScheduleUid;
      this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.Tag).Value = Entity.Tag;
      this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.GalaxyInputDeviceScheduleUid).IsNull == false)
        Entity.GalaxyInputDeviceScheduleUid = this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.GalaxyInputDeviceScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.InputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.Tag).IsNull == false)
        Entity.Tag = this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.Tag).GetAsString();
      if(this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyInputDeviceTimeScheduleUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInputDeviceTimeScheduleUniquePDSA class.
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
    /// Returns '@GalaxyInputDeviceScheduleUid'
    /// </summary>
    public static string GalaxyInputDeviceScheduleUid = "@GalaxyInputDeviceScheduleUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInputDeviceTimeScheduleUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyInputDeviceScheduleUid'
    /// </summary>
    public static string GalaxyInputDeviceScheduleUid = "@GalaxyInputDeviceScheduleUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
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
