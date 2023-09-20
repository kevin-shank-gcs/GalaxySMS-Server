using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonalAccessGroupAccessPortalUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonalAccessGroupAccessPortalUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonalAccessGroupAccessPortalUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonalAccessGroupAccessPortalUniquePDSA Entity
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
    /// Clones the current IsPersonalAccessGroupAccessPortalUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonalAccessGroupAccessPortalUniquePDSA object</returns>
    public IsPersonalAccessGroupAccessPortalUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonalAccessGroupAccessPortalUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonalAccessGroupAccessPortalUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonalAccessGroupAccessPortalUniquePDSA object</returns>
    public IsPersonalAccessGroupAccessPortalUniquePDSA CloneEntity(IsPersonalAccessGroupAccessPortalUniquePDSA entityToClone)
    {
      IsPersonalAccessGroupAccessPortalUniquePDSA newEntity = new IsPersonalAccessGroupAccessPortalUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.PersonalAccessGroupAccessPortalUid, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_PersonalAccessGroupAccessPortalUid_Header", "Personal Access Group Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_PersonalAccessGroupAccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_PersonClusterPermissionUid_Header", "Person Cluster Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_PersonClusterPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonalAccessGroupAccessPortalUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.PersonalAccessGroupAccessPortalUid).Value = Entity.PersonalAccessGroupAccessPortalUid;
      this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).Value = Entity.PersonClusterPermissionUid;
      this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.PersonalAccessGroupAccessPortalUid).IsNull == false)
        Entity.PersonalAccessGroupAccessPortalUid = this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.PersonalAccessGroupAccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).IsNull == false)
        Entity.PersonClusterPermissionUid = this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonalAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonalAccessGroupAccessPortalUniquePDSA class.
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
    /// Returns '@PersonalAccessGroupAccessPortalUid'
    /// </summary>
    public static string PersonalAccessGroupAccessPortalUid = "@PersonalAccessGroupAccessPortalUid";
    /// <summary>
    /// Returns '@PersonClusterPermissionUid'
    /// </summary>
    public static string PersonClusterPermissionUid = "@PersonClusterPermissionUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonalAccessGroupAccessPortalUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonalAccessGroupAccessPortalUid'
    /// </summary>
    public static string PersonalAccessGroupAccessPortalUid = "@PersonalAccessGroupAccessPortalUid";
    /// <summary>
    /// Returns '@PersonClusterPermissionUid'
    /// </summary>
    public static string PersonClusterPermissionUid = "@PersonClusterPermissionUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
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
