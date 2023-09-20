using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA Entity
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
    /// Clones the current IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA object</returns>
    public IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA object</returns>
    public IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA CloneEntity(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA entityToClone)
    {
      IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA newEntity = new IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyCpuModelInterfaceBoardSectionModeUid, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_GalaxyCpuModelInterfaceBoardSectionModeUid_Header", "Galaxy Cpu Model Interface Board Section Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_GalaxyCpuModelInterfaceBoardSectionModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyCpuModelUid, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_GalaxyCpuModelUid_Header", "Galaxy Cpu Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_GalaxyCpuModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_InterfaceBoardSectionModeUid_Header", "Interface Board Section Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_InterfaceBoardSectionModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyCpuModelInterfaceBoardSectionModeUid).Value = Entity.GalaxyCpuModelInterfaceBoardSectionModeUid;
      this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyCpuModelUid).Value = Entity.GalaxyCpuModelUid;
      this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).Value = Entity.InterfaceBoardSectionModeUid;
      this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyCpuModelInterfaceBoardSectionModeUid).IsNull == false)
        Entity.GalaxyCpuModelInterfaceBoardSectionModeUid = this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyCpuModelInterfaceBoardSectionModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyCpuModelUid).IsNull == false)
        Entity.GalaxyCpuModelUid = this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyCpuModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).IsNull == false)
        Entity.InterfaceBoardSectionModeUid = this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA class.
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
    /// Returns '@GalaxyCpuModelInterfaceBoardSectionModeUid'
    /// </summary>
    public static string GalaxyCpuModelInterfaceBoardSectionModeUid = "@GalaxyCpuModelInterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@GalaxyCpuModelUid'
    /// </summary>
    public static string GalaxyCpuModelUid = "@GalaxyCpuModelUid";
    /// <summary>
    /// Returns '@InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "@InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyCpuModelInterfaceBoardSectionModeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyCpuModelInterfaceBoardSectionModeUid'
    /// </summary>
    public static string GalaxyCpuModelInterfaceBoardSectionModeUid = "@GalaxyCpuModelInterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@GalaxyCpuModelUid'
    /// </summary>
    public static string GalaxyCpuModelUid = "@GalaxyCpuModelUid";
    /// <summary>
    /// Returns '@InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "@InterfaceBoardSectionModeUid";
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
