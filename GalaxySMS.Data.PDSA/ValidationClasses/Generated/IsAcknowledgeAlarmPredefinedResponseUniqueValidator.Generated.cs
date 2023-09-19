using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAcknowledgeAlarmPredefinedResponseUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAcknowledgeAlarmPredefinedResponseUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAcknowledgeAlarmPredefinedResponseUniquePDSA Entity
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
    /// Clones the current IsAcknowledgeAlarmPredefinedResponseUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAcknowledgeAlarmPredefinedResponseUniquePDSA object</returns>
    public IsAcknowledgeAlarmPredefinedResponseUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAcknowledgeAlarmPredefinedResponseUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAcknowledgeAlarmPredefinedResponseUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAcknowledgeAlarmPredefinedResponseUniquePDSA object</returns>
    public IsAcknowledgeAlarmPredefinedResponseUniquePDSA CloneEntity(IsAcknowledgeAlarmPredefinedResponseUniquePDSA entityToClone)
    {
      IsAcknowledgeAlarmPredefinedResponseUniquePDSA newEntity = new IsAcknowledgeAlarmPredefinedResponseUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.AcknowledgeAlarmPredefinedResponseUid, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_AcknowledgeAlarmPredefinedResponseUid_Header", "Acknowledge Alarm Predefined Response Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_AcknowledgeAlarmPredefinedResponseUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.Response, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_Response_Header", "Response"), false, typeof(string), 8000, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_Response_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAcknowledgeAlarmPredefinedResponseUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.AcknowledgeAlarmPredefinedResponseUid).Value = Entity.AcknowledgeAlarmPredefinedResponseUid;
      this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.Response).Value = Entity.Response;
      this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.AcknowledgeAlarmPredefinedResponseUid).IsNull == false)
        Entity.AcknowledgeAlarmPredefinedResponseUid = this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.AcknowledgeAlarmPredefinedResponseUid).GetAsGuid();
      if(this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.Response).IsNull == false)
        Entity.Response = this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.Response).GetAsString();
      if(this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAcknowledgeAlarmPredefinedResponseUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAcknowledgeAlarmPredefinedResponseUniquePDSA class.
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
    /// Returns '@AcknowledgeAlarmPredefinedResponseUid'
    /// </summary>
    public static string AcknowledgeAlarmPredefinedResponseUid = "@AcknowledgeAlarmPredefinedResponseUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@Response'
    /// </summary>
    public static string Response = "@Response";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAcknowledgeAlarmPredefinedResponseUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AcknowledgeAlarmPredefinedResponseUid'
    /// </summary>
    public static string AcknowledgeAlarmPredefinedResponseUid = "@AcknowledgeAlarmPredefinedResponseUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@Response'
    /// </summary>
    public static string Response = "@Response";
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
