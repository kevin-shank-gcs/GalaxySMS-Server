using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyAccessGroupAccessPortalMappingValidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyAccessGroupAccessPortalMappingValidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyAccessGroupAccessPortalMappingValidPDSA Entity
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
    /// Clones the current IsGalaxyAccessGroupAccessPortalMappingValidPDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyAccessGroupAccessPortalMappingValidPDSA object</returns>
    public IsGalaxyAccessGroupAccessPortalMappingValidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyAccessGroupAccessPortalMappingValidPDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyAccessGroupAccessPortalMappingValidPDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyAccessGroupAccessPortalMappingValidPDSA object</returns>
    public IsGalaxyAccessGroupAccessPortalMappingValidPDSA CloneEntity(IsGalaxyAccessGroupAccessPortalMappingValidPDSA entityToClone)
    {
      IsGalaxyAccessGroupAccessPortalMappingValidPDSA newEntity = new IsGalaxyAccessGroupAccessPortalMappingValidPDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.AccessGroupUid, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_AccessGroupUid_Header", "Access Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyAccessGroupAccessPortalMappingValidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.AccessGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyAccessGroupAccessPortalMappingValidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyAccessGroupAccessPortalMappingValidPDSA class.
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
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyAccessGroupAccessPortalMappingValidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
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
