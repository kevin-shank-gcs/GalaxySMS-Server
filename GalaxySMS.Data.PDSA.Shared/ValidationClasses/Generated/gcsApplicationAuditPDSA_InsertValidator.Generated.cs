using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsApplicationAuditPDSA_InsertPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsApplicationAuditPDSA_InsertPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsApplicationAuditPDSA_InsertPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsApplicationAuditPDSA_InsertPDSA Entity
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
    /// Clones the current gcsApplicationAuditPDSA_InsertPDSA
    /// </summary>
    /// <returns>A cloned gcsApplicationAuditPDSA_InsertPDSA object</returns>
    public gcsApplicationAuditPDSA_InsertPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsApplicationAuditPDSA_InsertPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsApplicationAuditPDSA_InsertPDSA entity to clone</param>
    /// <returns>A cloned gcsApplicationAuditPDSA_InsertPDSA object</returns>
    public gcsApplicationAuditPDSA_InsertPDSA CloneEntity(gcsApplicationAuditPDSA_InsertPDSA entityToClone)
    {
      gcsApplicationAuditPDSA_InsertPDSA newEntity = new gcsApplicationAuditPDSA_InsertPDSA();


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
      
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditId, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_AuditId_Header", "Audit Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_AuditId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationAuditTypeId, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_ApplicationAuditTypeId_Header", "Application Audit Type Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_ApplicationAuditTypeId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.TransactionId, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_TransactionId_Header", "Transaction Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_TransactionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationId, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_ApplicationId_Header", "Application Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationName, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_ApplicationName_Header", "Application Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_ApplicationName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationVersion, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_ApplicationVersion_Header", "Application Version"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_ApplicationVersion_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.MachineName, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_MachineName_Header", "Machine Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_MachineName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.LoginName, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_LoginName_Header", "Login Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_LoginName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.WindowsUserName, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_WindowsUserName_Header", "Windows User Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_WindowsUserName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditDetails, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_AuditDetails_Header", "Audit Details"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_AuditDetails_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditXml, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_AuditXml_Header", "Audit Xml"), false, typeof(string), 0, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_AuditXml_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.InsertName, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_InsertName_Header", "Insert Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsApplicationAuditPDSA_InsertPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditId).Value = Entity.AuditId;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationAuditTypeId).Value = Entity.ApplicationAuditTypeId;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.TransactionId).Value = Entity.TransactionId;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationId).Value = Entity.ApplicationId;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationName).Value = Entity.ApplicationName;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationVersion).Value = Entity.ApplicationVersion;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.MachineName).Value = Entity.MachineName;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.LoginName).Value = Entity.LoginName;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.WindowsUserName).Value = Entity.WindowsUserName;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditDetails).Value = Entity.AuditDetails;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditXml).Value = Entity.AuditXml;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.InsertName).Value = Entity.InsertName;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditId).IsNull == false)
        Entity.AuditId = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditId).GetAsGuid();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationAuditTypeId).IsNull == false)
        Entity.ApplicationAuditTypeId = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationAuditTypeId).GetAsGuid();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.TransactionId).IsNull == false)
        Entity.TransactionId = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.TransactionId).GetAsGuid();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationId).GetAsGuid();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationName).IsNull == false)
        Entity.ApplicationName = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationName).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationVersion).IsNull == false)
        Entity.ApplicationVersion = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.ApplicationVersion).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.MachineName).IsNull == false)
        Entity.MachineName = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.MachineName).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.LoginName).IsNull == false)
        Entity.LoginName = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.LoginName).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.WindowsUserName).IsNull == false)
        Entity.WindowsUserName = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.WindowsUserName).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditDetails).IsNull == false)
        Entity.AuditDetails = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditDetails).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditXml).IsNull == false)
        Entity.AuditXml = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.AuditXml).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(gcsApplicationAuditPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsApplicationAuditPDSA_InsertPDSA class.
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
    /// Returns '@ApplicationAuditTypeId'
    /// </summary>
    public static string ApplicationAuditTypeId = "@ApplicationAuditTypeId";
    /// <summary>
    /// Returns '@TransactionId'
    /// </summary>
    public static string TransactionId = "@TransactionId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@ApplicationName'
    /// </summary>
    public static string ApplicationName = "@ApplicationName";
    /// <summary>
    /// Returns '@ApplicationVersion'
    /// </summary>
    public static string ApplicationVersion = "@ApplicationVersion";
    /// <summary>
    /// Returns '@MachineName'
    /// </summary>
    public static string MachineName = "@MachineName";
    /// <summary>
    /// Returns '@LoginName'
    /// </summary>
    public static string LoginName = "@LoginName";
    /// <summary>
    /// Returns '@WindowsUserName'
    /// </summary>
    public static string WindowsUserName = "@WindowsUserName";
    /// <summary>
    /// Returns '@AuditDetails'
    /// </summary>
    public static string AuditDetails = "@AuditDetails";
    /// <summary>
    /// Returns '@AuditXml'
    /// </summary>
    public static string AuditXml = "@AuditXml";
    /// <summary>
    /// Returns '@InsertName'
    /// </summary>
    public static string InsertName = "@InsertName";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
