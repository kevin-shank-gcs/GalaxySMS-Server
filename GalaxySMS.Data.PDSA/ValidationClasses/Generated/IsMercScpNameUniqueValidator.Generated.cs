using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsMercScpNameUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsMercScpNameUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsMercScpNameUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsMercScpNameUniquePDSA Entity
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
    /// Clones the current IsMercScpNameUniquePDSA
    /// </summary>
    /// <returns>A cloned IsMercScpNameUniquePDSA object</returns>
    public IsMercScpNameUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsMercScpNameUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsMercScpNameUniquePDSA entity to clone</param>
    /// <returns>A cloned IsMercScpNameUniquePDSA object</returns>
    public IsMercScpNameUniquePDSA CloneEntity(IsMercScpNameUniquePDSA entityToClone)
    {
      IsMercScpNameUniquePDSA newEntity = new IsMercScpNameUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsMercScpNameUniquePDSAValidator.ParameterNames.MercScpUid, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_MercScpUid_Header", "Merc Scp Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_MercScpUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpNameUniquePDSAValidator.ParameterNames.MercScpGroupUid, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_MercScpGroupUid_Header", "Merc Scp Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_MercScpGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpNameUniquePDSAValidator.ParameterNames.ScpName, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_ScpName_Header", "Scp Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_ScpName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpNameUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpNameUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsMercScpNameUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.MercScpUid).Value = Entity.MercScpUid;
      this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.MercScpGroupUid).Value = Entity.MercScpGroupUid;
      this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.ScpName).Value = Entity.ScpName;
      this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.MercScpUid).IsNull == false)
        Entity.MercScpUid = this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.MercScpUid).GetAsGuid();
      if(this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.MercScpGroupUid).IsNull == false)
        Entity.MercScpGroupUid = this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.MercScpGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.ScpName).IsNull == false)
        Entity.ScpName = this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.ScpName).GetAsString();
      if(this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsMercScpNameUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsMercScpNameUniquePDSA class.
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
    /// Returns '@MercScpUid'
    /// </summary>
    public static string MercScpUid = "@MercScpUid";
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
    /// <summary>
    /// Returns '@ScpName'
    /// </summary>
    public static string ScpName = "@ScpName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsMercScpNameUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@MercScpUid'
    /// </summary>
    public static string MercScpUid = "@MercScpUid";
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
    /// <summary>
    /// Returns '@ScpName'
    /// </summary>
    public static string ScpName = "@ScpName";
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
