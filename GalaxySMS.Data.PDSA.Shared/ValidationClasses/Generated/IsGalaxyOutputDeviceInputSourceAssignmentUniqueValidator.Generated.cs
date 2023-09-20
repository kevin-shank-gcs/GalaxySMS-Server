using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA Entity
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
    /// Clones the current IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA object</returns>
    public IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA object</returns>
    public IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA CloneEntity(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA entityToClone)
    {
      IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA newEntity = new IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceAssignmentUid, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_GalaxyOutputDeviceInputSourceAssignmentUid_Header", "Galaxy Output Device Input Source Assignment Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_GalaxyOutputDeviceInputSourceAssignmentUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceUid, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_GalaxyOutputDeviceInputSourceUid_Header", "Galaxy Output Device Input Source Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_GalaxyOutputDeviceInputSourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupAssignmentUid, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_InputOutputGroupAssignmentUid_Header", "Input Output Group Assignment Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_InputOutputGroupAssignmentUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceAssignmentUid).Value = Entity.GalaxyOutputDeviceInputSourceAssignmentUid;
      this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceUid).Value = Entity.GalaxyOutputDeviceInputSourceUid;
      this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupAssignmentUid).Value = Entity.InputOutputGroupAssignmentUid;
      this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceAssignmentUid).IsNull == false)
        Entity.GalaxyOutputDeviceInputSourceAssignmentUid = this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceAssignmentUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceUid).IsNull == false)
        Entity.GalaxyOutputDeviceInputSourceUid = this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupAssignmentUid).IsNull == false)
        Entity.InputOutputGroupAssignmentUid = this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupAssignmentUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA class.
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
    /// Returns '@GalaxyOutputDeviceInputSourceAssignmentUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceAssignmentUid = "@GalaxyOutputDeviceInputSourceAssignmentUid";
    /// <summary>
    /// Returns '@GalaxyOutputDeviceInputSourceUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceUid = "@GalaxyOutputDeviceInputSourceUid";
    /// <summary>
    /// Returns '@InputOutputGroupAssignmentUid'
    /// </summary>
    public static string InputOutputGroupAssignmentUid = "@InputOutputGroupAssignmentUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyOutputDeviceInputSourceAssignmentUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyOutputDeviceInputSourceAssignmentUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceAssignmentUid = "@GalaxyOutputDeviceInputSourceAssignmentUid";
    /// <summary>
    /// Returns '@GalaxyOutputDeviceInputSourceUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceUid = "@GalaxyOutputDeviceInputSourceUid";
    /// <summary>
    /// Returns '@InputOutputGroupAssignmentUid'
    /// </summary>
    public static string InputOutputGroupAssignmentUid = "@InputOutputGroupAssignmentUid";
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
