////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Mvc\Components\HtmlExtensionsCommon.cs
//
// summary:	Implements the HTML extensions common class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCS.Core.Common.Web.Mvc.Components
{
  ////////////////////////////////////////////////////////////////////////////////////////////////////
  /// <summary> A HTML extensions common. </summary>
  ///
  /// <remarks> Kevin, 12/26/2018. </remarks>
  ////////////////////////////////////////////////////////////////////////////////////////////////////

  public static class HtmlExtensionsCommon
  {
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent HTML button types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum HtmlButtonTypes
    {
      /// <summary> An enum constant representing the submit option. </summary>
      submit,
      /// <summary> An enum constant representing the button option. </summary>
      button,
      /// <summary> An enum constant representing the reset option. </summary>
      reset
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent HTML 5 input types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum Html5InputTypes
    {
      /// <summary> An enum constant representing the text option. </summary>
      text,
      /// <summary> An enum constant representing the color option. </summary>
      color,
      /// <summary> An enum constant representing the date option. </summary>
      date,
      /// <summary> An enum constant representing the datetime option. </summary>
      datetime,
      /// <summary> An enum constant representing the email option. </summary>
      email,
      /// <summary> An enum constant representing the month option. </summary>
      month,
      /// <summary> An enum constant representing the number option. </summary>
      number,
      /// <summary> An enum constant representing the password option. </summary>
      password,
      /// <summary> An enum constant representing the range option. </summary>
      range,
      /// <summary> An enum constant representing the search option. </summary>
      search,
      /// <summary> An enum constant representing the tel option. </summary>
      tel,
      /// <summary> An enum constant representing the time option. </summary>
      time,
      /// <summary> An enum constant representing the URL option. </summary>
      url,
      /// <summary> An enum constant representing the week option. </summary>
      week
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Adds a name. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <param name="tb">   The terabytes. </param>
    /// <param name="name"> The name. </param>
    /// <param name="id">   The identifier. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static void AddName(TagBuilder tb,
      string name, string id) {

      if (!string.IsNullOrWhiteSpace(name)) {
        name = TagBuilder.CreateSanitizedId(name);

        if (string.IsNullOrWhiteSpace(id)) {
          tb.GenerateId(name);
        }
        else {
          tb.MergeAttribute("id",
            TagBuilder.CreateSanitizedId(id));
        }
      }

      tb.MergeAttribute("name", name);
    }
  }
}