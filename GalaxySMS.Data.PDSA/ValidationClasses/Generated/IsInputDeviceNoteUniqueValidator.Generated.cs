using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsInputDeviceNoteUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsInputDeviceNoteUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsInputDeviceNoteUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsInputDeviceNoteUniquePDSA Entity
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
    /// Clones the current IsInputDeviceNoteUniquePDSA
    /// </summary>
    /// <returns>A cloned IsInputDeviceNoteUniquePDSA object</returns>
    public IsInputDeviceNoteUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsInputDeviceNoteUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsInputDeviceNoteUniquePDSA entity to clone</param>
    /// <returns>A cloned IsInputDeviceNoteUniquePDSA object</returns>
    public IsInputDeviceNoteUniquePDSA CloneEntity(IsInputDeviceNoteUniquePDSA entityToClone)
    {
      IsInputDeviceNoteUniquePDSA newEntity = new IsInputDeviceNoteUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.InputDeviceNoteUid, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_InputDeviceNoteUid_Header", "Input Device Note Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_InputDeviceNoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.InputDeviceUid, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_InputDeviceUid_Header", "Input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.NoteUid, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_NoteUid_Header", "Note Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_NoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputDeviceNoteUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.InputDeviceNoteUid).Value = Entity.InputDeviceNoteUid;
      this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.NoteUid).Value = Entity.NoteUid;
      this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.InputDeviceNoteUid).IsNull == false)
        Entity.InputDeviceNoteUid = this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.InputDeviceNoteUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.InputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.NoteUid).IsNull == false)
        Entity.NoteUid = this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.NoteUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsInputDeviceNoteUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputDeviceNoteUniquePDSA class.
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
    /// Returns '@InputDeviceNoteUid'
    /// </summary>
    public static string InputDeviceNoteUid = "@InputDeviceNoteUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
    /// <summary>
    /// Returns '@NoteUid'
    /// </summary>
    public static string NoteUid = "@NoteUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputDeviceNoteUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputDeviceNoteUid'
    /// </summary>
    public static string InputDeviceNoteUid = "@InputDeviceNoteUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
    /// <summary>
    /// Returns '@NoteUid'
    /// </summary>
    public static string NoteUid = "@NoteUid";
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
