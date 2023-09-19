using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsAudit_InsertPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsAudit_InsertPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsAudit_InsertPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsAudit_InsertPDSA Entity
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
    /// Clones the current gcsAudit_InsertPDSA
    /// </summary>
    /// <returns>A cloned gcsAudit_InsertPDSA object</returns>
    public gcsAudit_InsertPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsAudit_InsertPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsAudit_InsertPDSA entity to clone</param>
    /// <returns>A cloned gcsAudit_InsertPDSA object</returns>
    public gcsAudit_InsertPDSA CloneEntity(gcsAudit_InsertPDSA entityToClone)
    {
      gcsAudit_InsertPDSA newEntity = new gcsAudit_InsertPDSA();


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
      
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.AuditId, GetResourceMessage("GCS_gcsAudit_InsertPDSA_AuditId_Header", "Audit Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsAudit_InsertPDSA_AuditId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.TransactionId, GetResourceMessage("GCS_gcsAudit_InsertPDSA_TransactionId_Header", "Transaction Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsAudit_InsertPDSA_TransactionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.TableName, GetResourceMessage("GCS_gcsAudit_InsertPDSA_TableName_Header", "Table Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsAudit_InsertPDSA_TableName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.OperationType, GetResourceMessage("GCS_gcsAudit_InsertPDSA_OperationType_Header", "Operation Type"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsAudit_InsertPDSA_OperationType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyColumn, GetResourceMessage("GCS_gcsAudit_InsertPDSA_PrimaryKeyColumn_Header", "Primary Key Column"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsAudit_InsertPDSA_PrimaryKeyColumn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyValue, GetResourceMessage("GCS_gcsAudit_InsertPDSA_PrimaryKeyValue_Header", "Primary Key Value"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsAudit_InsertPDSA_PrimaryKeyValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.RecordTag, GetResourceMessage("GCS_gcsAudit_InsertPDSA_RecordTag_Header", "Record Tag"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsAudit_InsertPDSA_RecordTag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.AuditXml, GetResourceMessage("GCS_gcsAudit_InsertPDSA_AuditXml_Header", "Audit Xml"), false, typeof(string), 0, GetResourceMessage("GCS_gcsAudit_InsertPDSA_AuditXml_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.ColumnName, GetResourceMessage("GCS_gcsAudit_InsertPDSA_ColumnName_Header", "Column Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsAudit_InsertPDSA_ColumnName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalValue, GetResourceMessage("GCS_gcsAudit_InsertPDSA_OriginalValue_Header", "Original Value"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsAudit_InsertPDSA_OriginalValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.NewValue, GetResourceMessage("GCS_gcsAudit_InsertPDSA_NewValue_Header", "New Value"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsAudit_InsertPDSA_NewValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalBinaryValue, GetResourceMessage("GCS_gcsAudit_InsertPDSA_OriginalBinaryValue_Header", "Original Binary Value"), false, typeof(byte[]), -1, GetResourceMessage("GCS_gcsAudit_InsertPDSA_OriginalBinaryValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.NewBinaryValue, GetResourceMessage("GCS_gcsAudit_InsertPDSA_NewBinaryValue_Header", "New Binary Value"), false, typeof(byte[]), -1, GetResourceMessage("GCS_gcsAudit_InsertPDSA_NewBinaryValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.InsertName, GetResourceMessage("GCS_gcsAudit_InsertPDSA_InsertName_Header", "Insert Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsAudit_InsertPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_gcsAudit_InsertPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_gcsAudit_InsertPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcsAudit_InsertPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsAudit_InsertPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsAudit_InsertPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsAudit_InsertPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsAudit_InsertPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditId).Value = Entity.AuditId;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TransactionId).Value = Entity.TransactionId;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OperationType).Value = Entity.OperationType;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyColumn).Value = Entity.PrimaryKeyColumn;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyValue).Value = Entity.PrimaryKeyValue;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RecordTag).Value = Entity.RecordTag;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditXml).Value = Entity.AuditXml;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalValue).Value = Entity.OriginalValue;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewValue).Value = Entity.NewValue;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalBinaryValue).Value = Entity.OriginalBinaryValue;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewBinaryValue).Value = Entity.NewBinaryValue;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertName).Value = Entity.InsertName;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditId).IsNull == false)
        Entity.AuditId = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditId).GetAsGuid();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TransactionId).IsNull == false)
        Entity.TransactionId = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TransactionId).GetAsGuid();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TableName).IsNull == false)
        Entity.TableName = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TableName).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OperationType).IsNull == false)
        Entity.OperationType = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OperationType).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyColumn).IsNull == false)
        Entity.PrimaryKeyColumn = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyColumn).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyValue).IsNull == false)
        Entity.PrimaryKeyValue = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyValue).GetAsGuid();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RecordTag).IsNull == false)
        Entity.RecordTag = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RecordTag).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditXml).IsNull == false)
        Entity.AuditXml = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditXml).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.ColumnName).IsNull == false)
        Entity.ColumnName = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.ColumnName).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalValue).IsNull == false)
        Entity.OriginalValue = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalValue).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewValue).IsNull == false)
        Entity.NewValue = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewValue).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalBinaryValue).IsNull == false)
        Entity.OriginalBinaryValue = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalBinaryValue).GetAsByteArray();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewBinaryValue).IsNull == false)
        Entity.NewBinaryValue = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewBinaryValue).GetAsByteArray();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsAudit_InsertPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AuditId'
    /// </summary>
    public static string AuditId = "@AuditId";
    /// <summary>
    /// Returns '@TransactionId'
    /// </summary>
    public static string TransactionId = "@TransactionId";
    /// <summary>
    /// Returns '@TableName'
    /// </summary>
    public static string TableName = "@TableName";
    /// <summary>
    /// Returns '@OperationType'
    /// </summary>
    public static string OperationType = "@OperationType";
    /// <summary>
    /// Returns '@PrimaryKeyColumn'
    /// </summary>
    public static string PrimaryKeyColumn = "@PrimaryKeyColumn";
    /// <summary>
    /// Returns '@PrimaryKeyValue'
    /// </summary>
    public static string PrimaryKeyValue = "@PrimaryKeyValue";
    /// <summary>
    /// Returns '@RecordTag'
    /// </summary>
    public static string RecordTag = "@RecordTag";
    /// <summary>
    /// Returns '@AuditXml'
    /// </summary>
    public static string AuditXml = "@AuditXml";
    /// <summary>
    /// Returns '@ColumnName'
    /// </summary>
    public static string ColumnName = "@ColumnName";
    /// <summary>
    /// Returns '@OriginalValue'
    /// </summary>
    public static string OriginalValue = "@OriginalValue";
    /// <summary>
    /// Returns '@NewValue'
    /// </summary>
    public static string NewValue = "@NewValue";
    /// <summary>
    /// Returns '@OriginalBinaryValue'
    /// </summary>
    public static string OriginalBinaryValue = "@OriginalBinaryValue";
    /// <summary>
    /// Returns '@NewBinaryValue'
    /// </summary>
    public static string NewBinaryValue = "@NewBinaryValue";
    /// <summary>
    /// Returns '@InsertName'
    /// </summary>
    public static string InsertName = "@InsertName";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
