using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GCS.Core.Common.Extensions
{
    public static class ColorConversions
    {
        // Convert a string in RGBA format to integer equivalent 
        public static int RGBAToInt(this string s)
        {
            if (string.IsNullOrEmpty(s) || !s.StartsWith("#") || s.Length != 9 && s.Length != 7)
                return 0;
            string hex = s.Substring(1);
            
            int intValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return intValue;
        }

        public static string ToRGBA(this int v)
        {
            return ((uint)v).ToRGBA();
        }

        public static string ToRGB(this int v)
        {
            return ((uint) v).ToRGB();
        }
        public static string ToRGBA(this uint v)
        {
            var r = (v & 0xff000000) >> 24;
            var g = (v & 0xff0000) >> 16;
            var b = (v & 0xff00) >> 8;
            var a = v & 0xff;

            return $"#{r:X2}{g:X2}{b:X2}{a:X2}";
        }

        public static string ToRGB(this uint v)
        {
            var r = (v & 0xff000000) >> 24;
            var g = (v & 0xff0000) >> 16;
            var b = (v & 0xff00) >> 8;

            return $"#{r:X2}{g:X2}{b:X2}";
        }

    }
}
