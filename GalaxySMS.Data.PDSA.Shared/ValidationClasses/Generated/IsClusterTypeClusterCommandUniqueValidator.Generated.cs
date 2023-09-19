using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsClusterTypeClusterCommandUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsClusterTypeClusterCommandUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsClusterTypeClusterCommandUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsClusterTypeClusterCommandUniquePDSA Entity
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
    /// Clones the current IsClusterTypeClusterCommandUniquePDSA
    /// </summary>
    /// <returns>A cloned IsClusterTypeClusterCommandUniquePDSA object</returns>
    public IsClusterTypeClusterCommandUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsClusterTypeClusterCommandUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsClusterTypeClusterCommandUniquePDSA entity to clone</param>
    /// <returns>A cloned IsClusterTypeClusterCommandUniquePDSA object</returns>
    public IsClusterTypeClusterCommandUniquePDSA CloneEntity(IsClusterTypeClusterCommandUniquePDSA entityToClone)
    {
      IsClusterTypeClusterCommandUniquePDSA newEntity = new IsClusterTypeClusterCommandUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeClusterCommandUid, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_ClusterTypeClusterCommandUid_Header", "Cluster Type Cluster Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_ClusterTypeClusterCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterCommandUid, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_ClusterCommandUid_Header", "Cluster Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_ClusterCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeUid, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_ClusterTypeUid_Header", "Cluster Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_ClusterTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeClusterCommandUid).Value = Entity.ClusterTypeClusterCommandUid;
      this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterCommandUid).Value = Entity.ClusterCommandUid;
      this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeUid).Value = Entity.ClusterTypeUid;
      this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeClusterCommandUid).IsNull == false)
        Entity.ClusterTypeClusterCommandUid = this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeClusterCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterCommandUid).IsNull == false)
        Entity.ClusterCommandUid = this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeUid).IsNull == false)
        Entity.ClusterTypeUid = this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterTypeClusterCommandUniquePDSA class.
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
    /// Returns '@ClusterTypeClusterCommandUid'
    /// </summary>
    public static string ClusterTypeClusterCommandUid = "@ClusterTypeClusterCommandUid";
    /// <summary>
    /// Returns '@ClusterCommandUid'
    /// </summary>
    public static string ClusterCommandUid = "@ClusterCommandUid";
    /// <summary>
    /// Returns '@ClusterTypeUid'
    /// </summary>
    public static string ClusterTypeUid = "@ClusterTypeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterTypeClusterCommandUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterTypeClusterCommandUid'
    /// </summary>
    public static string ClusterTypeClusterCommandUid = "@ClusterTypeClusterCommandUid";
    /// <summary>
    /// Returns '@ClusterCommandUid'
    /// </summary>
    public static string ClusterCommandUid = "@ClusterCommandUid";
    /// <summary>
    /// Returns '@ClusterTypeUid'
    /// </summary>
    public static string ClusterTypeUid = "@ClusterTypeUid";
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
