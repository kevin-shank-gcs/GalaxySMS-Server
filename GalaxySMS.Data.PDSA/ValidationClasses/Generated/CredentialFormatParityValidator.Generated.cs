using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the CredentialFormatParityPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialFormatParityPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CredentialFormatParityPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CredentialFormatParityPDSA Entity
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
    /// Clones the current CredentialFormatParityPDSA
    /// </summary>
    /// <returns>A cloned CredentialFormatParityPDSA object</returns>
    public CredentialFormatParityPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CredentialFormatParityPDSA
    /// </summary>
    /// <param name="entityToClone">The CredentialFormatParityPDSA entity to clone</param>
    /// <returns>A cloned CredentialFormatParityPDSA object</returns>
    public CredentialFormatParityPDSA CloneEntity(CredentialFormatParityPDSA entityToClone)
    {
      CredentialFormatParityPDSA newEntity = new CredentialFormatParityPDSA();

      newEntity.CredentialFormatParityUid = entityToClone.CredentialFormatParityUid;
      newEntity.CredentialFormatUid = entityToClone.CredentialFormatUid;
      newEntity.ParityType = entityToClone.ParityType;
      newEntity.HexMask = entityToClone.HexMask;
      newEntity.BitPosition = entityToClone.BitPosition;
      newEntity.ComputeSequence = entityToClone.ComputeSequence;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;

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
      
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatParityUid, GetResourceMessage("GCS_CredentialFormatParityPDSA_CredentialFormatParityUid_Header", "Credential Format Parity Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_CredentialFormatParityPDSA_CredentialFormatParityUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatUid, GetResourceMessage("GCS_CredentialFormatParityPDSA_CredentialFormatUid_Header", "Credential Format Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_CredentialFormatParityPDSA_CredentialFormatUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.ParityType, GetResourceMessage("GCS_CredentialFormatParityPDSA_ParityType_Header", "Parity Type"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialFormatParityPDSA_ParityType_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.HexMask, GetResourceMessage("GCS_CredentialFormatParityPDSA_HexMask_Header", "Hex Mask"), true, typeof(byte[]), 32, GetResourceMessage("GCS_CredentialFormatParityPDSA_HexMask_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.BitPosition, GetResourceMessage("GCS_CredentialFormatParityPDSA_BitPosition_Header", "Bit Position"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialFormatParityPDSA_BitPosition_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.ComputeSequence, GetResourceMessage("GCS_CredentialFormatParityPDSA_ComputeSequence_Header", "Compute Sequence"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialFormatParityPDSA_ComputeSequence_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_CredentialFormatParityPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_CredentialFormatParityPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_CredentialFormatParityPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialFormatParityPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_CredentialFormatParityPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_CredentialFormatParityPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_CredentialFormatParityPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialFormatParityPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialFormatParityPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_CredentialFormatParityPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialFormatParityPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.CredentialFormatParityUid = Guid.Empty;
      Entity.CredentialFormatUid = Guid.Empty;
      Entity.ParityType = 0;
      Entity.HexMask = null;
      Entity.BitPosition = 0;
      Entity.ComputeSequence = 0;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;

      Entity.ResetAllIsDirtyProperties();
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
        InitProperties();
      
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatParityUid).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatParityUid).Value = Entity.CredentialFormatParityUid;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatUid).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatUid).Value = Entity.CredentialFormatUid;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ParityType).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ParityType).Value = Entity.ParityType;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.HexMask).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.HexMask).Value = Entity.HexMask;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.BitPosition).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.BitPosition).Value = Entity.BitPosition;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ComputeSequence).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ComputeSequence).Value = Entity.ComputeSequence;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatParityUid).IsNull == false)
        Entity.CredentialFormatParityUid = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatParityUid).GetAsGuid();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatUid).IsNull == false)
        Entity.CredentialFormatUid = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.CredentialFormatUid).GetAsGuid();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ParityType).IsNull == false)
        Entity.ParityType = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ParityType).GetAsShort();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.HexMask).IsNull == false)
        Entity.HexMask = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.HexMask).GetAsByteArray();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.BitPosition).IsNull == false)
        Entity.BitPosition = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.BitPosition).GetAsShort();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ComputeSequence).IsNull == false)
        Entity.ComputeSequence = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ComputeSequence).GetAsShort();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(CredentialFormatParityPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialFormatParityPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'CredentialFormatParityUid'
    /// </summary>
    public static string CredentialFormatParityUid = "CredentialFormatParityUid";
    /// <summary>
    /// Returns 'CredentialFormatUid'
    /// </summary>
    public static string CredentialFormatUid = "CredentialFormatUid";
    /// <summary>
    /// Returns 'ParityType'
    /// </summary>
    public static string ParityType = "ParityType";
    /// <summary>
    /// Returns 'HexMask'
    /// </summary>
    public static string HexMask = "HexMask";
    /// <summary>
    /// Returns 'BitPosition'
    /// </summary>
    public static string BitPosition = "BitPosition";
    /// <summary>
    /// Returns 'ComputeSequence'
    /// </summary>
    public static string ComputeSequence = "ComputeSequence";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    }
    #endregion
  }
}
