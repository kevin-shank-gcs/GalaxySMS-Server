using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Security
{
    public class RandomTokenGenerator
    {
        public static uint GenerateRandomNumber()
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                var randomvalue = BitConverter.ToUInt32(rno, 0);
                var finalValue = randomvalue % 999999;
                if (finalValue < 100000)
                    finalValue += 100000;
                return finalValue;
            }
        }
    }
}
