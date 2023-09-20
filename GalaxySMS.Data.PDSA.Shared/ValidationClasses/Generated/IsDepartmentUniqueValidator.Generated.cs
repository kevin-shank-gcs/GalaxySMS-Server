using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsDepartmentUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsDepartmentUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsDepartmentUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsDepartmentUniquePDSA Entity
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
    /// Clones the current IsDepartmentUniquePDSA
    /// </summary>
    /// <returns>A cloned IsDepartmentUniquePDSA object</returns>
    public IsDepartmentUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsDepartmentUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsDepartmentUniquePDSA entity to clone</param>
    /// <returns>A cloned IsDepartmentUniquePDSA object</returns>
    public IsDepartmentUniquePDSA CloneEntity(IsDepartmentUniquePDSA entityToClone)
    {
      IsDepartmentUniquePDSA newEntity = new IsDepartmentUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsDepartmentUniquePDSAValidator.ParameterNames.DepartmentUid, GetResourceMessage("GCS_IsDepartmentUniquePDSA_DepartmentUid_Header", "Department Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsDepartmentUniquePDSA_DepartmentUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsDepartmentUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsDepartmentUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsDepartmentUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsDepartmentUniquePDSAValidator.ParameterNames.DepartmentName, GetResourceMessage("GCS_IsDepartmentUniquePDSA_DepartmentName_Header", "Department Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsDepartmentUniquePDSA_DepartmentName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsDepartmentUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsDepartmentUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsDepartmentUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsDepartmentUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsDepartmentUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsDepartmentUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.DepartmentUid).Value = Entity.DepartmentUid;
      this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.DepartmentName).Value = Entity.DepartmentName;
      this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.DepartmentUid).IsNull == false)
        Entity.DepartmentUid = this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.DepartmentUid).GetAsGuid();
      if(this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.DepartmentName).IsNull == false)
        Entity.DepartmentName = this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.DepartmentName).GetAsString();
      if(this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsDepartmentUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsDepartmentUniquePDSA class.
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
    /// Returns '@DepartmentUid'
    /// </summary>
    public static string DepartmentUid = "@DepartmentUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@DepartmentName'
    /// </summary>
    public static string DepartmentName = "@DepartmentName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsDepartmentUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@DepartmentUid'
    /// </summary>
    public static string DepartmentUid = "@DepartmentUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@DepartmentName'
    /// </summary>
    public static string DepartmentName = "@DepartmentName";
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
