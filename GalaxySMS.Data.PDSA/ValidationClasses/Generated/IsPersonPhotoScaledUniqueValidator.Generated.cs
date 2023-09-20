using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonPhotoScaledUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonPhotoScaledUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonPhotoScaledUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonPhotoScaledUniquePDSA Entity
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
    /// Clones the current IsPersonPhotoScaledUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonPhotoScaledUniquePDSA object</returns>
    public IsPersonPhotoScaledUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonPhotoScaledUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonPhotoScaledUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonPhotoScaledUniquePDSA object</returns>
    public IsPersonPhotoScaledUniquePDSA CloneEntity(IsPersonPhotoScaledUniquePDSA entityToClone)
    {
      IsPersonPhotoScaledUniquePDSA newEntity = new IsPersonPhotoScaledUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.PersonPhotoScaledUid, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_PersonPhotoScaledUid_Header", "Person Photo Scaled Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_PersonPhotoScaledUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.PersonPhotoUid, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_PersonPhotoUid_Header", "Person Photo Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_PersonPhotoUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.UniqueFilename, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_UniqueFilename_Header", "Unique Filename"), false, typeof(string), 8000, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_UniqueFilename_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonPhotoScaledUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.PersonPhotoScaledUid).Value = Entity.PersonPhotoScaledUid;
      this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.PersonPhotoUid).Value = Entity.PersonPhotoUid;
      this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.UniqueFilename).Value = Entity.UniqueFilename;
      this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.PersonPhotoScaledUid).IsNull == false)
        Entity.PersonPhotoScaledUid = this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.PersonPhotoScaledUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.PersonPhotoUid).IsNull == false)
        Entity.PersonPhotoUid = this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.PersonPhotoUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.UniqueFilename).IsNull == false)
        Entity.UniqueFilename = this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.UniqueFilename).GetAsString();
      if(this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonPhotoScaledUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonPhotoScaledUniquePDSA class.
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
    /// Returns '@PersonPhotoScaledUid'
    /// </summary>
    public static string PersonPhotoScaledUid = "@PersonPhotoScaledUid";
    /// <summary>
    /// Returns '@PersonPhotoUid'
    /// </summary>
    public static string PersonPhotoUid = "@PersonPhotoUid";
    /// <summary>
    /// Returns '@UniqueFilename'
    /// </summary>
    public static string UniqueFilename = "@UniqueFilename";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonPhotoScaledUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonPhotoScaledUid'
    /// </summary>
    public static string PersonPhotoScaledUid = "@PersonPhotoScaledUid";
    /// <summary>
    /// Returns '@PersonPhotoUid'
    /// </summary>
    public static string PersonPhotoUid = "@PersonPhotoUid";
    /// <summary>
    /// Returns '@UniqueFilename'
    /// </summary>
    public static string UniqueFilename = "@UniqueFilename";
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
