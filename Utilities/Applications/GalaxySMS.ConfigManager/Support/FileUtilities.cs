using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.ConfigManager.Support
{
    public static class FileUtilities
    {
        public static int CountStringInFile(string filename, string findThis)
        {
            int returnCount = 0;

            using (System.IO.StreamReader sr = System.IO.File.OpenText(filename))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if( s.Contains(findThis))
                        returnCount++;
                }
            }
            return returnCount;
        }
    }

}
