using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAccessPortalNoServerReplyBehaviorUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAccessPortalNoServerReplyBehaviorUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAccessPortalNoServerReplyBehaviorUniquePDSA class
    /// </summary>
    public IsAccessPortalNoServerReplyBehaviorUniquePDSA() : base()
    {
      ClassName = "IsAccessPortalNoServerReplyBehaviorUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAccessPortalNoServerReplyBehaviorUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsAccessPortalNoServerReplyBehaviorUniquePDSACollection : List<IsAccessPortalNoServerReplyBehaviorUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAccessPortalNoServerReplyBehaviorUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAccessPortalNoServerReplyBehaviorUniquePDSA Objects</returns>
    public List<IsAccessPortalNoServerReplyBehaviorUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAccessPortalNoServerReplyBehaviorUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAccessPortalNoServerReplyBehaviorUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAccessPortalNoServerReplyBehaviorUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAccessPortalNoServerReplyBehaviorUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAccessPortalNoServerReplyBehaviorUniquePDSA>();
    }

  }
}
