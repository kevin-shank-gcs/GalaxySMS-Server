using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsClusterInputOutputGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsClusterInputOutputGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsClusterInputOutputGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsClusterInputOutputGroupUniquePDSA Entity
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
    /// Clones the current IsClusterInputOutputGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsClusterInputOutputGroupUniquePDSA object</returns>
    public IsClusterInputOutputGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsClusterInputOutputGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsClusterInputOutputGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsClusterInputOutputGroupUniquePDSA object</returns>
    public IsClusterInputOutputGroupUniquePDSA CloneEntity(IsClusterInputOutputGroupUniquePDSA entityToClone)
    {
      IsClusterInputOutputGroupUniquePDSA newEntity = new IsClusterInputOutputGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.ClusterInputOutputGroupUid, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_ClusterInputOutputGroupUid_Header", "Cluster Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_ClusterInputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.Tag, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_Tag_Header", "Tag"), false, typeof(string), 8000, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsClusterInputOutputGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.ClusterInputOutputGroupUid).Value = Entity.ClusterInputOutputGroupUid;
      this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.Tag).Value = Entity.Tag;
      this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.ClusterInputOutputGroupUid).IsNull == false)
        Entity.ClusterInputOutputGroupUid = this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.ClusterInputOutputGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.Tag).IsNull == false)
        Entity.Tag = this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.Tag).GetAsString();
      if(this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsClusterInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterInputOutputGroupUniquePDSA class.
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
    /// Returns '@ClusterInputOutputGroupUid'
    /// </summary>
    public static string ClusterInputOutputGroupUid = "@ClusterInputOutputGroupUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterInputOutputGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterInputOutputGroupUid'
    /// </summary>
    public static string ClusterInputOutputGroupUid = "@ClusterInputOutputGroupUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
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
