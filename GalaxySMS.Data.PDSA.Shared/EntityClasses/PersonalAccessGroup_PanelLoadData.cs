using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonalAccessGroup_PanelLoadDataPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class PersonalAccessGroup_PanelLoadDataPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonalAccessGroup_PanelLoadDataPDSA class
    /// </summary>
    public PersonalAccessGroup_PanelLoadDataPDSA() : base()
    {
      ClassName = "PersonalAccessGroup_PanelLoadDataPDSA";
    }
    #endregion

  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonalAccessGroup_PanelLoadDataPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonalAccessGroup_PanelLoadDataPDSACollection : List<PersonalAccessGroup_PanelLoadDataPDSA>
  {
    
    /// <summary>
    /// Get all PersonalAccessGroup_PanelLoadDataPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonalAccessGroup_PanelLoadDataPDSA Objects</returns>
    public List<PersonalAccessGroup_PanelLoadDataPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonalAccessGroup_PanelLoadDataPDSA>();
    }
        
    /// <summary>
    /// Get all PersonalAccessGroup_PanelLoadDataPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonalAccessGroup_PanelLoadDataPDSA Objects where IsSelected=True</returns>
    public List<PersonalAccessGroup_PanelLoadDataPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonalAccessGroup_PanelLoadDataPDSA>();
    }

  }
}
