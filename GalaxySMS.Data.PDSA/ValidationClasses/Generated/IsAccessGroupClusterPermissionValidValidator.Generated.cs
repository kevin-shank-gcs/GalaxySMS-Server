using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessGroupClusterPermissionValidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessGroupClusterPermissionValidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessGroupClusterPermissionValidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessGroupClusterPermissionValidPDSA Entity
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
    /// Clones the current IsAccessGroupClusterPermissionValidPDSA
    /// </summary>
    /// <returns>A cloned IsAccessGroupClusterPermissionValidPDSA object</returns>
    public IsAccessGroupClusterPermissionValidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessGroupClusterPermissionValidPDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessGroupClusterPermissionValidPDSA entity to clone</param>
    /// <returns>A cloned IsAccessGroupClusterPermissionValidPDSA object</returns>
    public IsAccessGroupClusterPermissionValidPDSA CloneEntity(IsAccessGroupClusterPermissionValidPDSA entityToClone)
    {
      IsAccessGroupClusterPermissionValidPDSA newEntity = new IsAccessGroupClusterPermissionValidPDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.AccessGroupUid, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_AccessGroupUid_Header", "Access Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.OrderNumber, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_OrderNumber_Header", "Order Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_OrderNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessGroupClusterPermissionValidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.OrderNumber).Value = Entity.OrderNumber;
      this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.AccessGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.OrderNumber).IsNull == false)
        Entity.OrderNumber = this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.OrderNumber).GetAsShort();
      if(this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessGroupClusterPermissionValidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessGroupClusterPermissionValidPDSA class.
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
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
    /// <summary>
    /// Returns '@OrderNumber'
    /// </summary>
    public static string OrderNumber = "@OrderNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessGroupClusterPermissionValidPDSA class.
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
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
    /// <summary>
    /// Returns '@OrderNumber'
    /// </summary>
    public static string OrderNumber = "@OrderNumber";
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
