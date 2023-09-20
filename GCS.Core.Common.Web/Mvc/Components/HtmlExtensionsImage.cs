////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Mvc\Components\HtmlExtensionsImage.cs
//
// summary:	Implements the HTML extensions image class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Web.Mvc;

namespace GCS.Core.Common.Web.Mvc.Components
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A HTML extensions image. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class HtmlExtensionsImage
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="image">            The image. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString Image(this HtmlHelper htmlHelper, byte[] image, object htmlAttributes = null)
        {
            //var img = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            //return new MvcHtmlString("<img src='" + img + "' />");
            return htmlHelper.Image(image, string.Empty,
                string.Empty, string.Empty, htmlAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="image">            The image. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            byte[] image,
            string altText,
            object htmlAttributes = null)
        {
            return htmlHelper.Image(image, altText,
                string.Empty, string.Empty, htmlAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="image">            The image. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="cssClass">         The CSS class. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            byte[] image,
            string altText,
            string cssClass,
            object htmlAttributes = null)
        {
            return htmlHelper.Image(image, altText,
                cssClass, string.Empty, htmlAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="image">            The image. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="cssClass">         The CSS class. </param>
        /// <param name="name">             The name. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            byte[] image,
            string altText,
            string cssClass,
            string name,
            object htmlAttributes = null)
        {
            var tb = new TagBuilder("img");

            HtmlExtensionsCommon.AddName(tb, name, "");
            var img = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));

            tb.MergeAttribute("src", img);
            tb.MergeAttribute("alt", altText);

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tb.AddCssClass(cssClass);
            }

            tb.MergeAttributes(
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            // HTML Encode the String
            return MvcHtmlString.Create(
                tb.ToString(TagRenderMode.SelfClosing));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that image from base 64 string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="base64String">     The base 64 string. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString ImageFromBase64String(this HtmlHelper htmlHelper, string base64String, object htmlAttributes = null)
        {
            //var img = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            //return new MvcHtmlString("<img src='" + img + "' />");
            return htmlHelper.ImageFromBase64String(base64String, string.Empty,
                string.Empty, string.Empty, htmlAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that image from base 64 string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="base64String">     The base 64 string. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString ImageFromBase64String(
            this HtmlHelper htmlHelper,
            string base64String,
            string altText,
            object htmlAttributes = null)
        {
            return htmlHelper.ImageFromBase64String(base64String, altText,
                string.Empty, string.Empty, htmlAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that image from base 64 string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="base64String">     The base 64 string. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="cssClass">         The CSS class. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString ImageFromBase64String(
            this HtmlHelper htmlHelper,
            string base64String,
            string altText,
            string cssClass,
            object htmlAttributes = null)
        {
            return htmlHelper.ImageFromBase64String(base64String, altText,
                cssClass, string.Empty, htmlAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that image from base 64 string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="base64String">     The base 64 string. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="cssClass">         The CSS class. </param>
        /// <param name="name">             The name. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString ImageFromBase64String(
            this HtmlHelper htmlHelper,
            string base64String,
            string altText,
            string cssClass,
            string name,
            object htmlAttributes = null)
        {
            var tb = new TagBuilder("img");

            HtmlExtensionsCommon.AddName(tb, name, "");
            var img = string.Format("data:image/jpg;base64,{0}", base64String);

            tb.MergeAttribute("src", img);
            tb.MergeAttribute("alt", altText);

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tb.AddCssClass(cssClass);
            }

            tb.MergeAttributes(
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            // HTML Encode the String
            return MvcHtmlString.Create(
                tb.ToString(TagRenderMode.SelfClosing));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="src">              Source for the. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            object htmlAttributes = null)
        {
            return htmlHelper.Image(src, altText,
                string.Empty, string.Empty, htmlAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="src">              Source for the. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="cssClass">         The CSS class. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            object htmlAttributes = null)
        {
            return htmlHelper.Image(src, altText,
                cssClass, string.Empty, htmlAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HtmlHelper extension method that images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="htmlHelper">       The htmlHelper to act on. </param>
        /// <param name="src">              Source for the. </param>
        /// <param name="altText">          The alternate text. </param>
        /// <param name="cssClass">         The CSS class. </param>
        /// <param name="name">             The name. </param>
        /// <param name="htmlAttributes">   The HTML attributes. </param>
        ///
        /// <returns>   A MvcHtmlString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            string name,
            object htmlAttributes = null)
        {
            var tb = new TagBuilder("img");

            HtmlExtensionsCommon.AddName(tb, name, "");

            tb.MergeAttribute("src", src);
            tb.MergeAttribute("alt", altText);

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tb.AddCssClass(cssClass);
            }

            tb.MergeAttributes(
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            // HTML Encode the String
            return MvcHtmlString.Create(
                tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}