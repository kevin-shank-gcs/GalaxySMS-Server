using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GCS.Core.Common.Utils
{
    public class XmlUtilities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Convert object to XML string. </summary>
        ///
        /// <remarks>   Kevin, 6/6/2019. </remarks>
        ///
        /// <param name="classObject">  The class object. </param>
        ///
        /// <returns>   The object converted to XML string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static string ConvertObjectToXMLString(object classObject)
        {
            string xmlString = null;
            XmlSerializer xmlSerializer = new XmlSerializer(classObject.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, classObject);
                memoryStream.Position = 0;
                xmlString = new StreamReader(memoryStream).ReadToEnd();
            }
            return xmlString;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Convert XML string to object of type T. </summary>
        ///
        /// <remarks>   Kevin, 6/6/2019. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="xmlString">    The XML string. </param>
        ///
        /// <returns>   The XML converted string to object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T ConvertXmlStringtoObject<T>(string xmlString)
        {
            T classObject;
 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader stringReader = new StringReader(xmlString))
            {
                classObject = (T)xmlSerializer.Deserialize(stringReader);
            }
            return classObject;
        }
    }
}
