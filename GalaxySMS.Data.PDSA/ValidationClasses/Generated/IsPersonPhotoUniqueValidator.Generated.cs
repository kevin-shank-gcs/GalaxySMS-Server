using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonPhotoUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonPhotoUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonPhotoUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonPhotoUniquePDSA Entity
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
    /// Clones the current IsPersonPhotoUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonPhotoUniquePDSA object</returns>
    public IsPersonPhotoUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonPhotoUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonPhotoUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonPhotoUniquePDSA object</returns>
    public IsPersonPhotoUniquePDSA CloneEntity(IsPersonPhotoUniquePDSA entityToClone)
    {
      IsPersonPhotoUniquePDSA newEntity = new IsPersonPhotoUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonPhotoUniquePDSAValidator.ParameterNames.PersonPhotoUid, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_PersonPhotoUid_Header", "Person Photo Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_PersonPhotoUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPhotoUniquePDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPhotoUniquePDSAValidator.ParameterNames.UniqueFilename, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_UniqueFilename_Header", "Unique Filename"), false, typeof(string), 8000, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_UniqueFilename_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPhotoUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPhotoUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonPhotoUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.PersonPhotoUid).Value = Entity.PersonPhotoUid;
      this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.UniqueFilename).Value = Entity.UniqueFilename;
      this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.PersonPhotoUid).IsNull == false)
        Entity.PersonPhotoUid = this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.PersonPhotoUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.UniqueFilename).IsNull == false)
        Entity.UniqueFilename = this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.UniqueFilename).GetAsString();
      if(this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonPhotoUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonPhotoUniquePDSA class.
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
    /// Returns '@PersonPhotoUid'
    /// </summary>
    public static string PersonPhotoUid = "@PersonPhotoUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
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
    /// Contains static string properties that represent the name of each property in the IsPersonPhotoUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonPhotoUid'
    /// </summary>
    public static string PersonPhotoUid = "@PersonPhotoUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
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
