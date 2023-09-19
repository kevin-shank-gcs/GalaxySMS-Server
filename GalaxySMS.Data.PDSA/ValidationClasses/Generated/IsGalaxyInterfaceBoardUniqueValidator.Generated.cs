using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyInterfaceBoardUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyInterfaceBoardUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyInterfaceBoardUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyInterfaceBoardUniquePDSA Entity
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
    /// Clones the current IsGalaxyInterfaceBoardUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyInterfaceBoardUniquePDSA object</returns>
    public IsGalaxyInterfaceBoardUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyInterfaceBoardUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyInterfaceBoardUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyInterfaceBoardUniquePDSA object</returns>
    public IsGalaxyInterfaceBoardUniquePDSA CloneEntity(IsGalaxyInterfaceBoardUniquePDSA entityToClone)
    {
      IsGalaxyInterfaceBoardUniquePDSA newEntity = new IsGalaxyInterfaceBoardUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardUid, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_GalaxyInterfaceBoardUid_Header", "Galaxy Interface Board Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_GalaxyInterfaceBoardUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyPanelUid, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.BoardNumber, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_BoardNumber_Header", "Board Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).Value = Entity.GalaxyInterfaceBoardUid;
      this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).IsNull == false)
        Entity.GalaxyInterfaceBoardUid = this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyPanelUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.BoardNumber).GetAsShort();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInterfaceBoardUniquePDSA class.
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
    /// Returns '@GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "@GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInterfaceBoardUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "@GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
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
