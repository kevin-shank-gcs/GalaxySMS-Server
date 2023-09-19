using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyCpuPDSA_UpdatePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyCpuPDSA_UpdatePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyCpuPDSA_UpdatePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyCpuPDSA_UpdatePDSA Entity
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
    /// Clones the current GalaxyCpuPDSA_UpdatePDSA
    /// </summary>
    /// <returns>A cloned GalaxyCpuPDSA_UpdatePDSA object</returns>
    public GalaxyCpuPDSA_UpdatePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyCpuPDSA_UpdatePDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyCpuPDSA_UpdatePDSA entity to clone</param>
    /// <returns>A cloned GalaxyCpuPDSA_UpdatePDSA object</returns>
    public GalaxyCpuPDSA_UpdatePDSA CloneEntity(GalaxyCpuPDSA_UpdatePDSA entityToClone)
    {
      GalaxyCpuPDSA_UpdatePDSA newEntity = new GalaxyCpuPDSA_UpdatePDSA();


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
      
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.GalaxyCpuModelUid, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_GalaxyCpuModelUid_Header", "Galaxy Cpu Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_GalaxyCpuModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PanelNumber, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.SerialNumber, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_SerialNumber_Header", "Serial Number"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_SerialNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.IpAddress, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_IpAddress_Header", "Ip Address"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_IpAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.Model, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_Model_Header", "Model"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_Model_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PreventFlashLoading, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_PreventFlashLoading_Header", "Prevent Flash Loading"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_PreventFlashLoading_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PreventDataLoading, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_PreventDataLoading_Header", "Prevent Data Loading"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_PreventDataLoading_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.DefaultEventLoggingOn, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_DefaultEventLoggingOn_Header", "Default Event Logging On"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_DefaultEventLoggingOn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.UpdateName, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_UpdateName_Header", "Update Name"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.UpdateDate, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_UpdateDate_Header", "Update Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.MinValue, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.IsActive, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_IsActive_Header", "Is Active"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_ConcurrencyValue_Header", "Concurrency Value"), false, typeof(short), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_UpdatePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (Properties == null)
      {
        InitProperties();
      }
      
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.GalaxyCpuModelUid).Value = Entity.GalaxyCpuModelUid;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PanelNumber).Value = Entity.PanelNumber;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.SerialNumber).Value = Entity.SerialNumber;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.IpAddress).Value = Entity.IpAddress;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.Model).Value = Entity.Model;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PreventFlashLoading).Value = Entity.PreventFlashLoading;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PreventDataLoading).Value = Entity.PreventDataLoading;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.DefaultEventLoggingOn).Value = Entity.DefaultEventLoggingOn;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.UpdateName).Value = Entity.UpdateName;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.IsActive).Value = Entity.IsActive;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.GalaxyPanelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.GalaxyCpuModelUid).IsNull == false)
        Entity.GalaxyCpuModelUid = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.GalaxyCpuModelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.SerialNumber).IsNull == false)
        Entity.SerialNumber = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.SerialNumber).GetAsString();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.IpAddress).IsNull == false)
        Entity.IpAddress = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.IpAddress).GetAsString();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.Model).IsNull == false)
        Entity.Model = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.Model).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PreventFlashLoading).IsNull == false)
        Entity.PreventFlashLoading = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PreventFlashLoading).GetAsBool();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PreventDataLoading).IsNull == false)
        Entity.PreventDataLoading = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.PreventDataLoading).GetAsBool();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.DefaultEventLoggingOn).IsNull == false)
        Entity.DefaultEventLoggingOn = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.DefaultEventLoggingOn).GetAsBool();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.IsActive).GetAsBool();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(GalaxyCpuPDSA_UpdatePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyCpuPDSA_UpdatePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@GalaxyCpuModelUid'
    /// </summary>
    public static string GalaxyCpuModelUid = "@GalaxyCpuModelUid";
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@PanelNumber'
    /// </summary>
    public static string PanelNumber = "@PanelNumber";
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@SerialNumber'
    /// </summary>
    public static string SerialNumber = "@SerialNumber";
    /// <summary>
    /// Returns '@IpAddress'
    /// </summary>
    public static string IpAddress = "@IpAddress";
    /// <summary>
    /// Returns '@Model'
    /// </summary>
    public static string Model = "@Model";
    /// <summary>
    /// Returns '@PreventFlashLoading'
    /// </summary>
    public static string PreventFlashLoading = "@PreventFlashLoading";
    /// <summary>
    /// Returns '@PreventDataLoading'
    /// </summary>
    public static string PreventDataLoading = "@PreventDataLoading";
    /// <summary>
    /// Returns '@DefaultEventLoggingOn'
    /// </summary>
    public static string DefaultEventLoggingOn = "@DefaultEventLoggingOn";
    /// <summary>
    /// Returns '@UpdateName'
    /// </summary>
    public static string UpdateName = "@UpdateName";
    /// <summary>
    /// Returns '@UpdateDate'
    /// </summary>
    public static string UpdateDate = "@UpdateDate";
    /// <summary>
    /// Returns '@IsActive'
    /// </summary>
    public static string IsActive = "@IsActive";
    /// <summary>
    /// Returns '@ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "@ConcurrencyValue";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
