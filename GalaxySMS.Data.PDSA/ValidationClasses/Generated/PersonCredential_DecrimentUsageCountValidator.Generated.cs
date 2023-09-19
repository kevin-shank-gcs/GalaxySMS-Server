using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the PersonCredential_DecrimentUsageCountPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonCredential_DecrimentUsageCountPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonCredential_DecrimentUsageCountPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonCredential_DecrimentUsageCountPDSA Entity
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
    /// Clones the current PersonCredential_DecrimentUsageCountPDSA
    /// </summary>
    /// <returns>A cloned PersonCredential_DecrimentUsageCountPDSA object</returns>
    public PersonCredential_DecrimentUsageCountPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonCredential_DecrimentUsageCountPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonCredential_DecrimentUsageCountPDSA entity to clone</param>
    /// <returns>A cloned PersonCredential_DecrimentUsageCountPDSA object</returns>
    public PersonCredential_DecrimentUsageCountPDSA CloneEntity(PersonCredential_DecrimentUsageCountPDSA entityToClone)
    {
      PersonCredential_DecrimentUsageCountPDSA newEntity = new PersonCredential_DecrimentUsageCountPDSA();


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
      
      props.Add(PDSAProperty.Create(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.PersonCredentialUid, GetResourceMessage("GCS_PersonCredential_DecrimentUsageCountPDSA_PersonCredentialUid_Header", "Person Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonCredential_DecrimentUsageCountPDSA_PersonCredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.StartingUsageCount, GetResourceMessage("GCS_PersonCredential_DecrimentUsageCountPDSA_StartingUsageCount_Header", "Starting Usage Count"), false, typeof(short), 0, GetResourceMessage("GCS_PersonCredential_DecrimentUsageCountPDSA_StartingUsageCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PersonCredential_DecrimentUsageCountPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PersonCredential_DecrimentUsageCountPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.PersonCredentialUid).Value = Entity.PersonCredentialUid;
      Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.StartingUsageCount).Value = Entity.StartingUsageCount;
      Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.PersonCredentialUid).IsNull == false)
        Entity.PersonCredentialUid = Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.PersonCredentialUid).GetAsGuid();
      if(Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.StartingUsageCount).IsNull == false)
        Entity.StartingUsageCount = Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.StartingUsageCount).GetAsShort();
      if(Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(PersonCredential_DecrimentUsageCountPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonCredential_DecrimentUsageCountPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonCredentialUid'
    /// </summary>
    public static string PersonCredentialUid = "@PersonCredentialUid";
    /// <summary>
    /// Returns '@StartingUsageCount'
    /// </summary>
    public static string StartingUsageCount = "@StartingUsageCount";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
