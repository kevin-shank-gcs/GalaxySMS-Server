using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the UserEntityRoleViewPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class UserEntityRoleViewPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the UserEntityRoleViewPDSA class
    /// </summary>
    public UserEntityRoleViewPDSA() : base()
    {
      ClassName = "UserEntityRoleViewPDSA";
    }
    #endregion

  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of UserEntityRoleViewPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class UserEntityRoleViewPDSACollection : List<UserEntityRoleViewPDSA>
  {
    
    /// <summary>
    /// Get all UserEntityRoleViewPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of UserEntityRoleViewPDSA Objects</returns>
    public List<UserEntityRoleViewPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<UserEntityRoleViewPDSA>();
    }
        
    /// <summary>
    /// Get all UserEntityRoleViewPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of UserEntityRoleViewPDSA Objects where IsSelected=True</returns>
    public List<UserEntityRoleViewPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<UserEntityRoleViewPDSA>();
    }

  }
}
