using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalTimeScheduleUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalTimeScheduleUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalTimeScheduleUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalTimeScheduleUniquePDSA Entity
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
    /// Clones the current IsAccessPortalTimeScheduleUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalTimeScheduleUniquePDSA object</returns>
    public IsAccessPortalTimeScheduleUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalTimeScheduleUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalTimeScheduleUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalTimeScheduleUniquePDSA object</returns>
    public IsAccessPortalTimeScheduleUniquePDSA CloneEntity(IsAccessPortalTimeScheduleUniquePDSA entityToClone)
    {
      IsAccessPortalTimeScheduleUniquePDSA newEntity = new IsAccessPortalTimeScheduleUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalTimeScheduleUid, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_AccessPortalTimeScheduleUid_Header", "Access Portal Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_AccessPortalTimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalScheduleTypeUid, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_AccessPortalScheduleTypeUid_Header", "Access Portal Schedule Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_AccessPortalScheduleTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalTimeScheduleUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalTimeScheduleUid).Value = Entity.AccessPortalTimeScheduleUid;
      this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalScheduleTypeUid).Value = Entity.AccessPortalScheduleTypeUid;
      this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalTimeScheduleUid).IsNull == false)
        Entity.AccessPortalTimeScheduleUid = this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalTimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalScheduleTypeUid).IsNull == false)
        Entity.AccessPortalScheduleTypeUid = this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.AccessPortalScheduleTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalTimeScheduleUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalTimeScheduleUniquePDSA class.
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
    /// Returns '@AccessPortalTimeScheduleUid'
    /// </summary>
    public static string AccessPortalTimeScheduleUid = "@AccessPortalTimeScheduleUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@AccessPortalScheduleTypeUid'
    /// </summary>
    public static string AccessPortalScheduleTypeUid = "@AccessPortalScheduleTypeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalTimeScheduleUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalTimeScheduleUid'
    /// </summary>
    public static string AccessPortalTimeScheduleUid = "@AccessPortalTimeScheduleUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@AccessPortalScheduleTypeUid'
    /// </summary>
    public static string AccessPortalScheduleTypeUid = "@AccessPortalScheduleTypeUid";
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
