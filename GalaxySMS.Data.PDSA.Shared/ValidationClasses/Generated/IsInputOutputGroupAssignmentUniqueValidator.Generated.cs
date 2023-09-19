using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsInputOutputGroupAssignmentUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsInputOutputGroupAssignmentUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsInputOutputGroupAssignmentUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsInputOutputGroupAssignmentUniquePDSA Entity
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
    /// Clones the current IsInputOutputGroupAssignmentUniquePDSA
    /// </summary>
    /// <returns>A cloned IsInputOutputGroupAssignmentUniquePDSA object</returns>
    public IsInputOutputGroupAssignmentUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsInputOutputGroupAssignmentUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsInputOutputGroupAssignmentUniquePDSA entity to clone</param>
    /// <returns>A cloned IsInputOutputGroupAssignmentUniquePDSA object</returns>
    public IsInputOutputGroupAssignmentUniquePDSA CloneEntity(IsInputOutputGroupAssignmentUniquePDSA entityToClone)
    {
      IsInputOutputGroupAssignmentUniquePDSA newEntity = new IsInputOutputGroupAssignmentUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupAssignmentUid, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_InputOutputGroupAssignmentUid_Header", "Input Output Group Assignment Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_InputOutputGroupAssignmentUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupUid, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.OffsetIndex, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_OffsetIndex_Header", "Offset Index"), false, typeof(short), 0, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_OffsetIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputOutputGroupAssignmentUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupAssignmentUid).Value = Entity.InputOutputGroupAssignmentUid;
      this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.OffsetIndex).Value = Entity.OffsetIndex;
      this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupAssignmentUid).IsNull == false)
        Entity.InputOutputGroupAssignmentUid = this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupAssignmentUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.InputOutputGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.OffsetIndex).IsNull == false)
        Entity.OffsetIndex = this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.OffsetIndex).GetAsShort();
      if(this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsInputOutputGroupAssignmentUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputOutputGroupAssignmentUniquePDSA class.
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
    /// Returns '@InputOutputGroupAssignmentUid'
    /// </summary>
    public static string InputOutputGroupAssignmentUid = "@InputOutputGroupAssignmentUid";
    /// <summary>
    /// Returns '@InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "@InputOutputGroupUid";
    /// <summary>
    /// Returns '@OffsetIndex'
    /// </summary>
    public static string OffsetIndex = "@OffsetIndex";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputOutputGroupAssignmentUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputOutputGroupAssignmentUid'
    /// </summary>
    public static string InputOutputGroupAssignmentUid = "@InputOutputGroupAssignmentUid";
    /// <summary>
    /// Returns '@InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "@InputOutputGroupUid";
    /// <summary>
    /// Returns '@OffsetIndex'
    /// </summary>
    public static string OffsetIndex = "@OffsetIndex";
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
