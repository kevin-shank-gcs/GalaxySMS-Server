using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the PersonPhotoPDSA_UpdateIsDefaultByPkPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonPhotoPDSA_UpdateIsDefaultByPkPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonPhotoPDSA_UpdateIsDefaultByPkPDSA Entity
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
    /// Clones the current PersonPhotoPDSA_UpdateIsDefaultByPkPDSA
    /// </summary>
    /// <returns>A cloned PersonPhotoPDSA_UpdateIsDefaultByPkPDSA object</returns>
    public PersonPhotoPDSA_UpdateIsDefaultByPkPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonPhotoPDSA_UpdateIsDefaultByPkPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonPhotoPDSA_UpdateIsDefaultByPkPDSA entity to clone</param>
    /// <returns>A cloned PersonPhotoPDSA_UpdateIsDefaultByPkPDSA object</returns>
    public PersonPhotoPDSA_UpdateIsDefaultByPkPDSA CloneEntity(PersonPhotoPDSA_UpdateIsDefaultByPkPDSA entityToClone)
    {
      PersonPhotoPDSA_UpdateIsDefaultByPkPDSA newEntity = new PersonPhotoPDSA_UpdateIsDefaultByPkPDSA();


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
      
      props.Add(PDSAProperty.Create(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.PersonPhotoUid, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_PersonPhotoUid_Header", "Person Photo Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_PersonPhotoUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.IsDefault, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_IsDefault_Header", "Is Default"), false, typeof(bool), 0, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_IsDefault_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.UpdateName, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_UpdateName_Header", "Update Name"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.UpdateDate, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_UpdateDate_Header", "Update Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.MinValue, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.ConcurrencyValue, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_ConcurrencyValue_Header", "Concurrency Value"), false, typeof(short), 0, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PersonPhotoPDSA_UpdateIsDefaultByPkPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (Properties == null)
      {
        InitProperties();
      }
      
      Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.PersonPhotoUid).Value = Entity.PersonPhotoUid;
      Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.IsDefault).Value = Entity.IsDefault;
      Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.UpdateName).Value = Entity.UpdateName;
      Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.PersonPhotoUid).IsNull == false)
        Entity.PersonPhotoUid = Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.PersonPhotoUid).GetAsGuid();
      if(Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.IsDefault).IsNull == false)
        Entity.IsDefault = Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.IsDefault).GetAsBool();
      if(Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(PersonPhotoPDSA_UpdateIsDefaultByPkPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonPhotoPDSA_UpdateIsDefaultByPkPDSA class.
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
    /// Returns '@IsDefault'
    /// </summary>
    public static string IsDefault = "@IsDefault";
    /// <summary>
    /// Returns '@UpdateName'
    /// </summary>
    public static string UpdateName = "@UpdateName";
    /// <summary>
    /// Returns '@UpdateDate'
    /// </summary>
    public static string UpdateDate = "@UpdateDate";
    /// <summary>
    /// Returns '@ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "@ConcurrencyValue";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
