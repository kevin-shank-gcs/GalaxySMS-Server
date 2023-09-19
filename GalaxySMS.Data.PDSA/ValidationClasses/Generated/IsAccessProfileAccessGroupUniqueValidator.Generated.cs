using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessProfileAccessGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessProfileAccessGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessProfileAccessGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessProfileAccessGroupUniquePDSA Entity
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
    /// Clones the current IsAccessProfileAccessGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessProfileAccessGroupUniquePDSA object</returns>
    public IsAccessProfileAccessGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessProfileAccessGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessProfileAccessGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessProfileAccessGroupUniquePDSA object</returns>
    public IsAccessProfileAccessGroupUniquePDSA CloneEntity(IsAccessProfileAccessGroupUniquePDSA entityToClone)
    {
      IsAccessProfileAccessGroupUniquePDSA newEntity = new IsAccessProfileAccessGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.AccessProfileAccessGroupUid, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_AccessProfileAccessGroupUid_Header", "Access Profile Access Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_AccessProfileAccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.AccessProfileClusterUid, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_AccessProfileClusterUid_Header", "Access Profile Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_AccessProfileClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.OrderNumber, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_OrderNumber_Header", "Order Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_OrderNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessProfileAccessGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.AccessProfileAccessGroupUid).Value = Entity.AccessProfileAccessGroupUid;
      this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.AccessProfileClusterUid).Value = Entity.AccessProfileClusterUid;
      this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.OrderNumber).Value = Entity.OrderNumber;
      this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.AccessProfileAccessGroupUid).IsNull == false)
        Entity.AccessProfileAccessGroupUid = this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.AccessProfileAccessGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.AccessProfileClusterUid).IsNull == false)
        Entity.AccessProfileClusterUid = this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.AccessProfileClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.OrderNumber).IsNull == false)
        Entity.OrderNumber = this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.OrderNumber).GetAsShort();
      if(this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessProfileAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessProfileAccessGroupUniquePDSA class.
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
    /// Returns '@AccessProfileAccessGroupUid'
    /// </summary>
    public static string AccessProfileAccessGroupUid = "@AccessProfileAccessGroupUid";
    /// <summary>
    /// Returns '@AccessProfileClusterUid'
    /// </summary>
    public static string AccessProfileClusterUid = "@AccessProfileClusterUid";
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
    /// Contains static string properties that represent the name of each property in the IsAccessProfileAccessGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessProfileAccessGroupUid'
    /// </summary>
    public static string AccessProfileAccessGroupUid = "@AccessProfileAccessGroupUid";
    /// <summary>
    /// Returns '@AccessProfileClusterUid'
    /// </summary>
    public static string AccessProfileClusterUid = "@AccessProfileClusterUid";
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
