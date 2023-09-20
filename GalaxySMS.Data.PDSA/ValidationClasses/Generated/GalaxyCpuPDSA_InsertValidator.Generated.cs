using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyCpuPDSA_InsertPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyCpuPDSA_InsertPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyCpuPDSA_InsertPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyCpuPDSA_InsertPDSA Entity
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
    /// Clones the current GalaxyCpuPDSA_InsertPDSA
    /// </summary>
    /// <returns>A cloned GalaxyCpuPDSA_InsertPDSA object</returns>
    public GalaxyCpuPDSA_InsertPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyCpuPDSA_InsertPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyCpuPDSA_InsertPDSA entity to clone</param>
    /// <returns>A cloned GalaxyCpuPDSA_InsertPDSA object</returns>
    public GalaxyCpuPDSA_InsertPDSA CloneEntity(GalaxyCpuPDSA_InsertPDSA entityToClone)
    {
      GalaxyCpuPDSA_InsertPDSA newEntity = new GalaxyCpuPDSA_InsertPDSA();


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
      
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.GalaxyCpuModelUid, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_GalaxyCpuModelUid_Header", "Galaxy Cpu Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_GalaxyCpuModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PanelNumber, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.SerialNumber, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_SerialNumber_Header", "Serial Number"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_SerialNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.IpAddress, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_IpAddress_Header", "Ip Address"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_IpAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.Model, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_Model_Header", "Model"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_Model_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PreventFlashLoading, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_PreventFlashLoading_Header", "Prevent Flash Loading"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_PreventFlashLoading_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PreventDataLoading, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_PreventDataLoading_Header", "Prevent Data Loading"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_PreventDataLoading_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.DefaultEventLoggingOn, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_DefaultEventLoggingOn_Header", "Default Event Logging On"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_DefaultEventLoggingOn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.InsertName, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_InsertName_Header", "Insert Name"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.MinValue, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.UpdateName, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_UpdateName_Header", "Update Name"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.UpdateDate, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_UpdateDate_Header", "Update Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.MinValue, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_ConcurrencyValue_Header", "Concurrency Value"), false, typeof(short), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.IsActive, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_IsActive_Header", "Is Active"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuPDSA_InsertPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.GalaxyCpuModelUid).Value = Entity.GalaxyCpuModelUid;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PanelNumber).Value = Entity.PanelNumber;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.SerialNumber).Value = Entity.SerialNumber;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.IpAddress).Value = Entity.IpAddress;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.Model).Value = Entity.Model;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PreventFlashLoading).Value = Entity.PreventFlashLoading;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PreventDataLoading).Value = Entity.PreventDataLoading;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.DefaultEventLoggingOn).Value = Entity.DefaultEventLoggingOn;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.InsertName).Value = Entity.InsertName;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.UpdateName).Value = Entity.UpdateName;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.IsActive).Value = Entity.IsActive;
      Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.GalaxyPanelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.GalaxyCpuModelUid).IsNull == false)
        Entity.GalaxyCpuModelUid = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.GalaxyCpuModelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.SerialNumber).IsNull == false)
        Entity.SerialNumber = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.SerialNumber).GetAsString();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.IpAddress).IsNull == false)
        Entity.IpAddress = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.IpAddress).GetAsString();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.Model).IsNull == false)
        Entity.Model = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.Model).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PreventFlashLoading).IsNull == false)
        Entity.PreventFlashLoading = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PreventFlashLoading).GetAsBool();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PreventDataLoading).IsNull == false)
        Entity.PreventDataLoading = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.PreventDataLoading).GetAsBool();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.DefaultEventLoggingOn).IsNull == false)
        Entity.DefaultEventLoggingOn = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.DefaultEventLoggingOn).GetAsBool();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.IsActive).GetAsBool();
      if(Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(GalaxyCpuPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyCpuPDSA_InsertPDSA class.
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
    /// Returns '@InsertName'
    /// </summary>
    public static string InsertName = "@InsertName";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@UpdateName'
    /// </summary>
    public static string UpdateName = "@UpdateName";
    /// <summary>
    /// Returns '@UpdateDate'
    /// </summary>
    public static string UpdateDate = "@UpdateDate";
    /// <summary>
    /// Returns '@ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "@ConcurrencyValue";
    /// <summary>
    /// Returns '@IsActive'
    /// </summary>
    public static string IsActive = "@IsActive";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
