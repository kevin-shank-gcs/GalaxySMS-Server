using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA Entity
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
    /// Clones the current PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA
    /// </summary>
    /// <returns>A cloned PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA object</returns>
    public PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA entity to clone</param>
    /// <returns>A cloned PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA object</returns>
    public PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA CloneEntity(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA entityToClone)
    {
      PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA newEntity = new PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA();


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
      
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.PersonPhotoScaledUid, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA_PersonPhotoScaledUid_Header", "Person Photo Scaled Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA_PersonPhotoScaledUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.PublicUrl, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA_PublicUrl_Header", "Public Url"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA_PublicUrl_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.ConcurrencyValue, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA_ConcurrencyValue_Header", "Concurrency Value"), false, typeof(short), 0, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.PersonPhotoScaledUid).Value = Entity.PersonPhotoScaledUid;
      Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.PublicUrl).Value = Entity.PublicUrl;
      Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.PersonPhotoScaledUid).IsNull == false)
        Entity.PersonPhotoScaledUid = Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.PersonPhotoScaledUid).GetAsGuid();
      if(Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.PublicUrl).IsNull == false)
        Entity.PublicUrl = Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.PublicUrl).GetAsString();
      if(Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonPhotoScaledPDSA_UpdatePublicUrlByPkPDSA class.
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
    /// Returns '@PublicUrl'
    /// </summary>
    public static string PublicUrl = "@PublicUrl";
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
