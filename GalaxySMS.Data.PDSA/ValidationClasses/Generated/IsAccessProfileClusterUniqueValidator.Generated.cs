using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessProfileClusterUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessProfileClusterUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessProfileClusterUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessProfileClusterUniquePDSA Entity
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
    /// Clones the current IsAccessProfileClusterUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessProfileClusterUniquePDSA object</returns>
    public IsAccessProfileClusterUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessProfileClusterUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessProfileClusterUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessProfileClusterUniquePDSA object</returns>
    public IsAccessProfileClusterUniquePDSA CloneEntity(IsAccessProfileClusterUniquePDSA entityToClone)
    {
      IsAccessProfileClusterUniquePDSA newEntity = new IsAccessProfileClusterUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.AccessProfileClusterUid, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_AccessProfileClusterUid_Header", "Access Profile Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_AccessProfileClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.AccessProfileUid, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_AccessProfileUid_Header", "Access Profile Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_AccessProfileUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessProfileClusterUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.AccessProfileClusterUid).Value = Entity.AccessProfileClusterUid;
      this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.AccessProfileUid).Value = Entity.AccessProfileUid;
      this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.AccessProfileClusterUid).IsNull == false)
        Entity.AccessProfileClusterUid = this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.AccessProfileClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.AccessProfileUid).IsNull == false)
        Entity.AccessProfileUid = this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.AccessProfileUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessProfileClusterUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessProfileClusterUniquePDSA class.
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
    /// Returns '@AccessProfileClusterUid'
    /// </summary>
    public static string AccessProfileClusterUid = "@AccessProfileClusterUid";
    /// <summary>
    /// Returns '@AccessProfileUid'
    /// </summary>
    public static string AccessProfileUid = "@AccessProfileUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessProfileClusterUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessProfileClusterUid'
    /// </summary>
    public static string AccessProfileClusterUid = "@AccessProfileClusterUid";
    /// <summary>
    /// Returns '@AccessProfileUid'
    /// </summary>
    public static string AccessProfileUid = "@AccessProfileUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
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
