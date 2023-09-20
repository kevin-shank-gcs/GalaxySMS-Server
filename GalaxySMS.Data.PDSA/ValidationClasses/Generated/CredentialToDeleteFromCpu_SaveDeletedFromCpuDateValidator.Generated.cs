using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA Entity
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
    /// Clones the current CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA
    /// </summary>
    /// <returns>A cloned CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA object</returns>
    public CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA
    /// </summary>
    /// <param name="entityToClone">The CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA entity to clone</param>
    /// <returns>A cloned CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA object</returns>
    public CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA CloneEntity(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA entityToClone)
    {
      CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA newEntity = new CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA();


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
      
      props.Add(PDSAProperty.Create(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.CardBinaryData, GetResourceMessage("GCS_CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA_CardBinaryData_Header", "Card Binary Data"), false, typeof(byte[]), 32, GetResourceMessage("GCS_CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA_CardBinaryData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.DeletedFromCpuDate, GetResourceMessage("GCS_CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA_DeletedFromCpuDate_Header", "Deleted From Cpu Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA_DeletedFromCpuDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.MinValue, @"", ""));
      props.Add(PDSAProperty.Create(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.CardBinaryData).Value = Entity.CardBinaryData;
      Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.DeletedFromCpuDate).Value = Entity.DeletedFromCpuDate;
      Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.CardBinaryData).IsNull == false)
        Entity.CardBinaryData = Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.CardBinaryData).GetAsByteArray();
      if(Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.DeletedFromCpuDate).IsNull == false)
        Entity.DeletedFromCpuDate = Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.DeletedFromCpuDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialToDeleteFromCpu_SaveDeletedFromCpuDatePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@CardBinaryData'
    /// </summary>
    public static string CardBinaryData = "@CardBinaryData";
    /// <summary>
    /// Returns '@DeletedFromCpuDate'
    /// </summary>
    public static string DeletedFromCpuDate = "@DeletedFromCpuDate";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
