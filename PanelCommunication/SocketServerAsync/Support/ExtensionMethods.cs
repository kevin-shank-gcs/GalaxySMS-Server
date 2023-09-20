using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelCommunicationServerAsync.Support
{
    public static class ExtensionMethods
    {
        public static bool IsCardDataEqual(this byte[] array1, byte[] array2)
        {
            if (array1.Length == array2.Length)
            {
                for (int x = array1.Length - 1; x > 0; x--)
                {
                    if (array1[x] != array2[x])
                        return false;
                }

                return true;
            }

            if (array2.Length < array1.Length)
            {
                var tempBuffer = new byte[array2.Length];
                var excessData = new byte[array1.Length - array2.Length];
                Buffer.BlockCopy(array1, array1.Length - array2.Length, tempBuffer, 0, array2.Length);
                Buffer.BlockCopy(array1, 0, excessData, 0, excessData.Length);
                for (int x = array2.Length - 1; x > 0; x--)
                {
                    if (tempBuffer[x] != array2[x])
                        return false;
                }

                for (int x = excessData.Length - 1; x > 0; x--)
                {
                    if (excessData[x] != 0)
                        return false;
                }

                return true;
            }

            return true;
        }

    }
}
