using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessGroup_DoesClusterMatchPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroup_DoesClusterMatchPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroup_DoesClusterMatchPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroup_DoesClusterMatchPDSA Entity
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
    /// Clones the current AccessGroup_DoesClusterMatchPDSA
    /// </summary>
    /// <returns>A cloned AccessGroup_DoesClusterMatchPDSA object</returns>
    public AccessGroup_DoesClusterMatchPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroup_DoesClusterMatchPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroup_DoesClusterMatchPDSA entity to clone</param>
    /// <returns>A cloned AccessGroup_DoesClusterMatchPDSA object</returns>
    public AccessGroup_DoesClusterMatchPDSA CloneEntity(AccessGroup_DoesClusterMatchPDSA entityToClone)
    {
      AccessGroup_DoesClusterMatchPDSA newEntity = new AccessGroup_DoesClusterMatchPDSA();

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
      
      props.Add(PDSAProperty.Create(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.uid, GetResourceMessage("GCS_AccessGroup_DoesClusterMatchPDSA_uid_Header", "uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroup_DoesClusterMatchPDSA_uid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.clusterUid, GetResourceMessage("GCS_AccessGroup_DoesClusterMatchPDSA_clusterUid_Header", "cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroup_DoesClusterMatchPDSA_clusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_AccessGroup_DoesClusterMatchPDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroup_DoesClusterMatchPDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessGroup_DoesClusterMatchPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroup_DoesClusterMatchPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.uid).Value = Entity.uid;
      this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.clusterUid).Value = Entity.clusterUid;
      this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.uid).IsNull == false)
        Entity.uid = this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.uid).GetAsGuid();
      if(this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.clusterUid).IsNull == false)
        Entity.clusterUid = this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.clusterUid).GetAsGuid();
      if(this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AccessGroup_DoesClusterMatchPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_DoesClusterMatchPDSA class.
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
    /// Returns '@uid'
    /// </summary>
    public static string uid = "@uid";
    /// <summary>
    /// Returns '@clusterUid'
    /// </summary>
    public static string clusterUid = "@clusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_DoesClusterMatchPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@uid'
    /// </summary>
    public static string uid = "@uid";
    /// <summary>
    /// Returns '@clusterUid'
    /// </summary>
    public static string clusterUid = "@clusterUid";
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
