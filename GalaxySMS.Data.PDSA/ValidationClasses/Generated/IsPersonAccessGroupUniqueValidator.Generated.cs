using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonAccessGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonAccessGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonAccessGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonAccessGroupUniquePDSA Entity
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
    /// Clones the current IsPersonAccessGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonAccessGroupUniquePDSA object</returns>
    public IsPersonAccessGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonAccessGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonAccessGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonAccessGroupUniquePDSA object</returns>
    public IsPersonAccessGroupUniquePDSA CloneEntity(IsPersonAccessGroupUniquePDSA entityToClone)
    {
      IsPersonAccessGroupUniquePDSA newEntity = new IsPersonAccessGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.PersonAccessGroupUid, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_PersonAccessGroupUid_Header", "Person Access Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_PersonAccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_PersonClusterPermissionUid_Header", "Person Cluster Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_PersonClusterPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.OrderNumber, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_OrderNumber_Header", "Order Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_OrderNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonAccessGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.PersonAccessGroupUid).Value = Entity.PersonAccessGroupUid;
      this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).Value = Entity.PersonClusterPermissionUid;
      this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.OrderNumber).Value = Entity.OrderNumber;
      this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.PersonAccessGroupUid).IsNull == false)
        Entity.PersonAccessGroupUid = this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.PersonAccessGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).IsNull == false)
        Entity.PersonClusterPermissionUid = this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.OrderNumber).IsNull == false)
        Entity.OrderNumber = this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.OrderNumber).GetAsShort();
      if(this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonAccessGroupUniquePDSA class.
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
    /// Returns '@PersonAccessGroupUid'
    /// </summary>
    public static string PersonAccessGroupUid = "@PersonAccessGroupUid";
    /// <summary>
    /// Returns '@PersonClusterPermissionUid'
    /// </summary>
    public static string PersonClusterPermissionUid = "@PersonClusterPermissionUid";
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
    /// Contains static string properties that represent the name of each property in the IsPersonAccessGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonAccessGroupUid'
    /// </summary>
    public static string PersonAccessGroupUid = "@PersonAccessGroupUid";
    /// <summary>
    /// Returns '@PersonClusterPermissionUid'
    /// </summary>
    public static string PersonClusterPermissionUid = "@PersonClusterPermissionUid";
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
