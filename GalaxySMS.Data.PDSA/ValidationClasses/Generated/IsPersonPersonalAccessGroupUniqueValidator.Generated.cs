using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonPersonalAccessGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonPersonalAccessGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonPersonalAccessGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonPersonalAccessGroupUniquePDSA Entity
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
    /// Clones the current IsPersonPersonalAccessGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonPersonalAccessGroupUniquePDSA object</returns>
    public IsPersonPersonalAccessGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonPersonalAccessGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonPersonalAccessGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonPersonalAccessGroupUniquePDSA object</returns>
    public IsPersonPersonalAccessGroupUniquePDSA CloneEntity(IsPersonPersonalAccessGroupUniquePDSA entityToClone)
    {
      IsPersonPersonalAccessGroupUniquePDSA newEntity = new IsPersonPersonalAccessGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_PersonClusterPermissionUid_Header", "Person Cluster Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_PersonClusterPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonalAccessGroupNumber, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_PersonalAccessGroupNumber_Header", "Personal Access Group Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_PersonalAccessGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).Value = Entity.PersonClusterPermissionUid;
      this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonalAccessGroupNumber).Value = Entity.PersonalAccessGroupNumber;
      this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).IsNull == false)
        Entity.PersonClusterPermissionUid = this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonalAccessGroupNumber).IsNull == false)
        Entity.PersonalAccessGroupNumber = this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonalAccessGroupNumber).GetAsShort();
      if(this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonPersonalAccessGroupUniquePDSA class.
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
    /// Returns '@PersonClusterPermissionUid'
    /// </summary>
    public static string PersonClusterPermissionUid = "@PersonClusterPermissionUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PersonalAccessGroupNumber'
    /// </summary>
    public static string PersonalAccessGroupNumber = "@PersonalAccessGroupNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonPersonalAccessGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonClusterPermissionUid'
    /// </summary>
    public static string PersonClusterPermissionUid = "@PersonClusterPermissionUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PersonalAccessGroupNumber'
    /// </summary>
    public static string PersonalAccessGroupNumber = "@PersonalAccessGroupNumber";
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
