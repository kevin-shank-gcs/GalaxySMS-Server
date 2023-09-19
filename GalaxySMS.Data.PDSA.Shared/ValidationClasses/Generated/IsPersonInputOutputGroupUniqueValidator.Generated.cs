using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonInputOutputGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonInputOutputGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonInputOutputGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonInputOutputGroupUniquePDSA Entity
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
    /// Clones the current IsPersonInputOutputGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonInputOutputGroupUniquePDSA object</returns>
    public IsPersonInputOutputGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonInputOutputGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonInputOutputGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonInputOutputGroupUniquePDSA object</returns>
    public IsPersonInputOutputGroupUniquePDSA CloneEntity(IsPersonInputOutputGroupUniquePDSA entityToClone)
    {
      IsPersonInputOutputGroupUniquePDSA newEntity = new IsPersonInputOutputGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.PersonInputOutputGroupUid, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_PersonInputOutputGroupUid_Header", "Person Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_PersonInputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_PersonClusterPermissionUid_Header", "Person Cluster Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_PersonClusterPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.OrderNumber, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_OrderNumber_Header", "Order Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_OrderNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonInputOutputGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.PersonInputOutputGroupUid).Value = Entity.PersonInputOutputGroupUid;
      this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).Value = Entity.PersonClusterPermissionUid;
      this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.OrderNumber).Value = Entity.OrderNumber;
      this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.PersonInputOutputGroupUid).IsNull == false)
        Entity.PersonInputOutputGroupUid = this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.PersonInputOutputGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).IsNull == false)
        Entity.PersonClusterPermissionUid = this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.OrderNumber).IsNull == false)
        Entity.OrderNumber = this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.OrderNumber).GetAsShort();
      if(this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonInputOutputGroupUniquePDSA class.
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
    /// Returns '@PersonInputOutputGroupUid'
    /// </summary>
    public static string PersonInputOutputGroupUid = "@PersonInputOutputGroupUid";
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
    /// Contains static string properties that represent the name of each property in the IsPersonInputOutputGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonInputOutputGroupUid'
    /// </summary>
    public static string PersonInputOutputGroupUid = "@PersonInputOutputGroupUid";
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
