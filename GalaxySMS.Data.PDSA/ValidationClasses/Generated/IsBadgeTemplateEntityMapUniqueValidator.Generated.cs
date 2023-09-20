using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsBadgeTemplateEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsBadgeTemplateEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsBadgeTemplateEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsBadgeTemplateEntityMapUniquePDSA Entity
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
    /// Clones the current IsBadgeTemplateEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsBadgeTemplateEntityMapUniquePDSA object</returns>
    public IsBadgeTemplateEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsBadgeTemplateEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsBadgeTemplateEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsBadgeTemplateEntityMapUniquePDSA object</returns>
    public IsBadgeTemplateEntityMapUniquePDSA CloneEntity(IsBadgeTemplateEntityMapUniquePDSA entityToClone)
    {
      IsBadgeTemplateEntityMapUniquePDSA newEntity = new IsBadgeTemplateEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.BadgeTemplateEntityMapUid, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_BadgeTemplateEntityMapUid_Header", "Badge Template Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_BadgeTemplateEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.BadgeTemplateUid, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_BadgeTemplateUid_Header", "Badge Template Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_BadgeTemplateUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsBadgeTemplateEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.BadgeTemplateEntityMapUid).Value = Entity.BadgeTemplateEntityMapUid;
      this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.BadgeTemplateUid).Value = Entity.BadgeTemplateUid;
      this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.BadgeTemplateEntityMapUid).IsNull == false)
        Entity.BadgeTemplateEntityMapUid = this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.BadgeTemplateEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.BadgeTemplateUid).IsNull == false)
        Entity.BadgeTemplateUid = this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.BadgeTemplateUid).GetAsGuid();
      if(this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsBadgeTemplateEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsBadgeTemplateEntityMapUniquePDSA class.
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
    /// Returns '@BadgeTemplateEntityMapUid'
    /// </summary>
    public static string BadgeTemplateEntityMapUid = "@BadgeTemplateEntityMapUid";
    /// <summary>
    /// Returns '@BadgeTemplateUid'
    /// </summary>
    public static string BadgeTemplateUid = "@BadgeTemplateUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsBadgeTemplateEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@BadgeTemplateEntityMapUid'
    /// </summary>
    public static string BadgeTemplateEntityMapUid = "@BadgeTemplateEntityMapUid";
    /// <summary>
    /// Returns '@BadgeTemplateUid'
    /// </summary>
    public static string BadgeTemplateUid = "@BadgeTemplateUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
