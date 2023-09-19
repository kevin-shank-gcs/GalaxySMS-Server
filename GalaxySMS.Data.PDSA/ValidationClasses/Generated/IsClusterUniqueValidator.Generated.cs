using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsClusterUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsClusterUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsClusterUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsClusterUniquePDSA Entity
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
    /// Clones the current IsClusterUniquePDSA
    /// </summary>
    /// <returns>A cloned IsClusterUniquePDSA object</returns>
    public IsClusterUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsClusterUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsClusterUniquePDSA entity to clone</param>
    /// <returns>A cloned IsClusterUniquePDSA object</returns>
    public IsClusterUniquePDSA CloneEntity(IsClusterUniquePDSA entityToClone)
    {
      IsClusterUniquePDSA newEntity = new IsClusterUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsClusterUniquePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsClusterUniquePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsClusterUniquePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsClusterUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsClusterUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterUniquePDSAValidator.ParameterNames.ClusterName, GetResourceMessage("GCS_IsClusterUniquePDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsClusterUniquePDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterUniquePDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_IsClusterUniquePDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterUniquePDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsClusterUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsClusterUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterName).Value = Entity.ClusterName;
      this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterName).IsNull == false)
        Entity.ClusterName = this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterName).GetAsString();
      if(this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsClusterUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterUniquePDSA class.
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
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ClusterName'
    /// </summary>
    public static string ClusterName = "@ClusterName";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ClusterName'
    /// </summary>
    public static string ClusterName = "@ClusterName";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
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
