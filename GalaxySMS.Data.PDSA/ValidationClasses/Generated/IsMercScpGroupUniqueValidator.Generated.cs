using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsMercScpGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsMercScpGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsMercScpGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsMercScpGroupUniquePDSA Entity
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
    /// Clones the current IsMercScpGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsMercScpGroupUniquePDSA object</returns>
    public IsMercScpGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsMercScpGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsMercScpGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsMercScpGroupUniquePDSA object</returns>
    public IsMercScpGroupUniquePDSA CloneEntity(IsMercScpGroupUniquePDSA entityToClone)
    {
      IsMercScpGroupUniquePDSA newEntity = new IsMercScpGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_MercScpGroupUid_Header", "Merc Scp Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_MercScpGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpGroupUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpGroupUniquePDSAValidator.ParameterNames.Name, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_Name_Header", "Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_Name_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsMercScpGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).Value = Entity.MercScpGroupUid;
      this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.Name).Value = Entity.Name;
      this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).IsNull == false)
        Entity.MercScpGroupUid = this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.Name).IsNull == false)
        Entity.Name = this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.Name).GetAsString();
      if(this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsMercScpGroupUniquePDSA class.
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
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
    /// Contains static string properties that represent the name of each property in the IsMercScpGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
