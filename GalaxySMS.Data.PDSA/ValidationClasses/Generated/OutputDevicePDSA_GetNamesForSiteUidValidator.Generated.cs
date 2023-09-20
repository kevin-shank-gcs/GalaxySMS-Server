using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the OutputDevicePDSA_GetNamesForSiteUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class OutputDevicePDSA_GetNamesForSiteUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private OutputDevicePDSA_GetNamesForSiteUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new OutputDevicePDSA_GetNamesForSiteUidPDSA Entity
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
    /// Clones the current OutputDevicePDSA_GetNamesForSiteUidPDSA
    /// </summary>
    /// <returns>A cloned OutputDevicePDSA_GetNamesForSiteUidPDSA object</returns>
    public OutputDevicePDSA_GetNamesForSiteUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in OutputDevicePDSA_GetNamesForSiteUidPDSA
    /// </summary>
    /// <param name="entityToClone">The OutputDevicePDSA_GetNamesForSiteUidPDSA entity to clone</param>
    /// <returns>A cloned OutputDevicePDSA_GetNamesForSiteUidPDSA object</returns>
    public OutputDevicePDSA_GetNamesForSiteUidPDSA CloneEntity(OutputDevicePDSA_GetNamesForSiteUidPDSA entityToClone)
    {
      OutputDevicePDSA_GetNamesForSiteUidPDSA newEntity = new OutputDevicePDSA_GetNamesForSiteUidPDSA();

      newEntity.OutputName = entityToClone.OutputName;

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
      
      props.Add(PDSAProperty.Create(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.OutputName, GetResourceMessage("GCS_OutputDevicePDSA_GetNamesForSiteUidPDSA_OutputName_Header", "Output Name"), false, typeof(string), 8000, GetResourceMessage("GCS_OutputDevicePDSA_GetNamesForSiteUidPDSA_OutputName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.SiteUid, GetResourceMessage("GCS_OutputDevicePDSA_GetNamesForSiteUidPDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_OutputDevicePDSA_GetNamesForSiteUidPDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_OutputDevicePDSA_GetNamesForSiteUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_OutputDevicePDSA_GetNamesForSiteUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.OutputName).Value = Entity.OutputName;
      this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.OutputName).IsNull == false)
        Entity.OutputName = this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.OutputName).GetAsString();
      if(this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.SiteUid).IsNull == false)
        Entity.SiteUid = this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.SiteUid).GetAsGuid();
      if(this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(OutputDevicePDSA_GetNamesForSiteUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the OutputDevicePDSA_GetNamesForSiteUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'OutputName'
    /// </summary>
    public static string OutputName = "OutputName";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the OutputDevicePDSA_GetNamesForSiteUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@OutputName'
    /// </summary>
    public static string OutputName = "@OutputName";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
