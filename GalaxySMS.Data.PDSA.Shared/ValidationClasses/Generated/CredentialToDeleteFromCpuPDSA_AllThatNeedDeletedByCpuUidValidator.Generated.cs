using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA Entity
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
    /// Clones the current CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA
    /// </summary>
    /// <returns>A cloned CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA object</returns>
    public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA
    /// </summary>
    /// <param name="entityToClone">The CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA entity to clone</param>
    /// <returns>A cloned CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA object</returns>
    public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA CloneEntity(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA entityToClone)
    {
      CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA newEntity = new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA();

      newEntity.CredentialToDeleteFromCpuUid = entityToClone.CredentialToDeleteFromCpuUid;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.CardBinaryData = entityToClone.CardBinaryData;
      newEntity.DeletedFromDatabaseDate = entityToClone.DeletedFromDatabaseDate;
      newEntity.DeletedFromCpuDate = entityToClone.DeletedFromCpuDate;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ServerAddress = entityToClone.ServerAddress;
      newEntity.IsConnected = entityToClone.IsConnected;

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
      
      props.Add(PDSAProperty.Create(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.ServerAddress, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA_ServerAddress_Header", "Server Address"), false, typeof(string), 8000, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA_ServerAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.IsConnected, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA_IsConnected_Header", "Is Connected"), false, typeof(bool), 0, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA_IsConnected_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.ServerAddress).Value = Entity.ServerAddress;
      this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.IsConnected).Value = Entity.IsConnected;
      this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.ServerAddress).IsNull == false)
        Entity.ServerAddress = this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.ServerAddress).GetAsString();
      if(this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.IsConnected).IsNull == false)
        Entity.IsConnected = this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.IsConnected).GetAsBool();
      if(this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'CredentialToDeleteFromCpuUid'
    /// </summary>
    public static string CredentialToDeleteFromCpuUid = "CredentialToDeleteFromCpuUid";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'CardBinaryData'
    /// </summary>
    public static string CardBinaryData = "CardBinaryData";
    /// <summary>
    /// Returns 'DeletedFromDatabaseDate'
    /// </summary>
    public static string DeletedFromDatabaseDate = "DeletedFromDatabaseDate";
    /// <summary>
    /// Returns 'DeletedFromCpuDate'
    /// </summary>
    public static string DeletedFromCpuDate = "DeletedFromCpuDate";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ServerAddress'
    /// </summary>
    public static string ServerAddress = "ServerAddress";
    /// <summary>
    /// Returns 'IsConnected'
    /// </summary>
    public static string IsConnected = "IsConnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA class.
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
    /// Returns '@ServerAddress'
    /// </summary>
    public static string ServerAddress = "@ServerAddress";
    /// <summary>
    /// Returns '@IsConnected'
    /// </summary>
    public static string IsConnected = "@IsConnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
