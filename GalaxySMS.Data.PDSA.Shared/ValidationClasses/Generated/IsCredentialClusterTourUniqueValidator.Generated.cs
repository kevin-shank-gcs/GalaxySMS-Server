using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialClusterTourUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialClusterTourUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialClusterTourUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialClusterTourUniquePDSA Entity
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
    /// Clones the current IsCredentialClusterTourUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialClusterTourUniquePDSA object</returns>
    public IsCredentialClusterTourUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialClusterTourUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialClusterTourUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialClusterTourUniquePDSA object</returns>
    public IsCredentialClusterTourUniquePDSA CloneEntity(IsCredentialClusterTourUniquePDSA entityToClone)
    {
      IsCredentialClusterTourUniquePDSA newEntity = new IsCredentialClusterTourUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.CredentialClusterTourUid, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_CredentialClusterTourUid_Header", "Credential Cluster Tour Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_CredentialClusterTourUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.Name, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_Name_Header", "Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_Name_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialClusterTourUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.CredentialClusterTourUid).Value = Entity.CredentialClusterTourUid;
      this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.Name).Value = Entity.Name;
      this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.CredentialClusterTourUid).IsNull == false)
        Entity.CredentialClusterTourUid = this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.CredentialClusterTourUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.Name).IsNull == false)
        Entity.Name = this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.Name).GetAsString();
      if(this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialClusterTourUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialClusterTourUniquePDSA class.
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
    /// Returns '@CredentialClusterTourUid'
    /// </summary>
    public static string CredentialClusterTourUid = "@CredentialClusterTourUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@Name'
    /// </summary>
    public static string Name = "@Name";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialClusterTourUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CredentialClusterTourUid'
    /// </summary>
    public static string CredentialClusterTourUid = "@CredentialClusterTourUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@Name'
    /// </summary>
    public static string Name = "@Name";
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
