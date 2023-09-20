////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Mvc\Components\HtmlExtensionsButton.cs
//
// summary:	Implements the HTML extensions button class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Web.Mvc;

namespace GCS.Core.Common.Web.Mvc.Components
{
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HTML extensions button. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static class HtmlExtensionsButton
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Bootstrap Submit Button Helper. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="htmlHelper">       The helper. </param>
            /// <param name="innerHtml">        The text (or HTML) for the button. </param>
            /// <param name="htmlAttributes">   An object that sets the HTML attributes for the element. </param>
            ///
            /// <returns>   A HTML &lt;button&gt; element with the appropriate properties set. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper,
                          string innerHtml,
                          object htmlAttributes = null)
            {
                return HtmlExtensionsButton.BootstrapButton(htmlHelper, innerHtml, null, null, null, false, false, HtmlExtensionsCommon.HtmlButtonTypes.submit, null, htmlAttributes);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Bootstrap Submit Button Helper. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="htmlHelper">       The helper. </param>
            /// <param name="innerHtml">        The text (or HTML) for the button. </param>
            /// <param name="cssClass">         CSS class(es) to add. </param>
            /// <param name="htmlAttributes">   An object that sets the HTML attributes for the element. </param>
            ///
            /// <returns>   A HTML &lt;button&gt; element with the appropriate properties set. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper,
                      string innerHtml,
                      string cssClass,
                      object htmlAttributes = null)
            {
                return HtmlExtensionsButton.BootstrapButton(htmlHelper, innerHtml, cssClass, null, null, false, false, HtmlExtensionsCommon.HtmlButtonTypes.submit, null, htmlAttributes);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Bootstrap Submit Button Helper. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="htmlHelper">       The helper. </param>
            /// <param name="innerHtml">        The text (or HTML) for the button. </param>
            /// <param name="cssClass">         CSS class(es) to add. </param>
            /// <param name="name">             The 'name' attribute for this element. </param>
            /// <param name="pdsaAction">       The 'pdsa-data-action' attribute to add. </param>
            /// <param name="htmlAttributes">   An object that sets the HTML attributes for the element. </param>
            ///
            /// <returns>   A HTML &lt;button&gt; element with the appropriate properties set. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper,
                          string innerHtml,
                          string cssClass,
                          string name,
                          string pdsaAction,
                          object htmlAttributes = null)
            {
                return HtmlExtensionsButton.BootstrapButton(htmlHelper, innerHtml, cssClass, name, null, false, false, HtmlExtensionsCommon.HtmlButtonTypes.submit, pdsaAction, htmlAttributes);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Bootstrap Submit Button Helper. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="htmlHelper">       The helper. </param>
            /// <param name="innerHtml">        The text (or HTML) for the button. </param>
            /// <param name="cssClass">         CSS class(es) to add. </param>
            /// <param name="name">             The 'name' attribute for this element. </param>
            /// <param name="title">            The 'title' for the button. </param>
            /// <param name="isFormNoValidate"> Whether or not this button validates the form. </param>
            /// <param name="isAutoFocus">      Whether or not this button gets the input focus. </param>
            /// <param name="buttonType">       The 'type' of button. Can be 'submit', 'reset', or 'button') </param>
            /// <param name="pdsaAction">       The 'pdsa-data-action' attribute to add. </param>
            /// <param name="htmlAttributes">   An object that sets the HTML attributes for the element. </param>
            ///
            /// <returns>   A HTML &lt;button&gt; element with the appropriate properties set. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public static MvcHtmlString BootstrapButton(
                this HtmlHelper htmlHelper,
                string innerHtml,
                string cssClass,
                string name,
                string title,
                bool isFormNoValidate,
                bool isAutoFocus,
                HtmlExtensionsCommon.HtmlButtonTypes buttonType,
                string pdsaAction,
                object htmlAttributes = null)
            {


                // Create TagBuilder
                TagBuilder tb = new TagBuilder("button");

                // Ensure we have a 'btn-*' class
                if (!string.IsNullOrEmpty(cssClass))
                {
                    if (!cssClass.Contains("btn-"))
                    {
                        cssClass = "btn-primary " + cssClass;
                    }
                }
                else {
                    cssClass = "btn-primary";
                }

                // Add additional CSS classes
                tb.AddCssClass(cssClass);

                // Add 'btn' last so it becomes the first one
                tb.AddCssClass("btn");

                // Add 'name' and 'id' attributes if present
                HtmlExtensionsCommon.AddName(tb, name,
                  null);

                // Add HTML 5 attributes
                if (!string.IsNullOrWhiteSpace(title))
                {
                    tb.MergeAttribute("title", title);
                }
                if (isFormNoValidate)
                {
                    tb.MergeAttribute("formnovalidate",
                      "formnovalidate");
                }
                if (isAutoFocus)
                {
                    tb.MergeAttribute("autofocus",
                      "autofocus");
                }

                // Set the inner html
                tb.InnerHtml = innerHtml;

                // Add type of button
                switch (buttonType)
                {
                    case HtmlExtensionsCommon.HtmlButtonTypes.submit:
                        tb.MergeAttribute("type", "submit");
                        break;
                    case HtmlExtensionsCommon.HtmlButtonTypes.button:
                        tb.MergeAttribute("type", "button");
                        break;
                    case HtmlExtensionsCommon.HtmlButtonTypes.reset:
                        tb.MergeAttribute("type", "reset");
                        break;
                }

                // Set the PDSA action
                if (!string.IsNullOrWhiteSpace(pdsaAction))
                {
                    tb.MergeAttribute("data-pdsa-action",
                                      pdsaAction);
                }

                // Add additional attributes
                tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

                return MvcHtmlString.Create(tb.ToString());
            }
        }
    }