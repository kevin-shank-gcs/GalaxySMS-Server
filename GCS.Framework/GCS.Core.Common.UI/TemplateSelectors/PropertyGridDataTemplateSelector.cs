////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TemplateSelectors\PropertyGridDataTemplateSelector.cs
//
// summary:	Implements the property grid data template selector class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;


namespace GCS.Core.Common.UI
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A property grid data template selector. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PropertyGridDataTemplateSelector : DataTemplateSelector
    {
        //public override DataTemplate SelectTemplate(object item, DependencyObject container)
        //{
        //    if (item as PropertyDefinition != null && (item as PropertyDefinition).SourceProperty.PropertyType == typeof(Int32))
        //    {
        //        return IntegerPropertyDataTemplate;
        //    }
        //    if (item as PropertyDefinition != null && (item as PropertyDefinition).SourceProperty.Name == "LastName")
        //    {
        //        return LastNameDataTemplate;
        //    }
        //    return null;
        //}

        //public DataTemplate IntegerPropertyDataTemplate { get; set; }
        //public DataTemplate LastNameDataTemplate { get; set; }
    }
}
