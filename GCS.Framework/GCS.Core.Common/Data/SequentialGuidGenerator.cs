////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Data\SequentialGuidGenerator.cs
//
// summary:	Implements the sequential unique identifier generator class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GCS.Core.Common.Data
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent sequential Unique identifier types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum SequentialGuidType
    {
        /// <summary>   An enum constant representing the sequential as string option. </summary>
        SequentialAsString,
        /// <summary>   An enum constant representing the sequential as binary option. </summary>
        SequentialAsBinary,
        /// <summary>   An enum constant representing the sequential at end option. </summary>
        SequentialAtEnd
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A sequential unique identifier generator. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class SequentialGuidGenerator
    {
        /// <summary>   The random number generator. </summary>
        private static readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a new sequential unique identifier. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="guidType"> Type of the unique identifier. </param>
        ///
        /// <returns>   A GUID. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Guid NewSequentialGuid(SequentialGuidType guidType)
        {
            byte[] randomBytes = new byte[10];
            _rng.GetBytes(randomBytes);

            long timestamp = DateTimeOffset.UtcNow.Ticks / 10000L;
            byte[] timestampBytes = BitConverter.GetBytes(timestamp);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(timestampBytes);
            }

            byte[] guidBytes = new byte[16];

            switch (guidType)
            {
                case SequentialGuidType.SequentialAsString:
                case SequentialGuidType.SequentialAsBinary:
                    Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
                    Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10);

                    // If formatting as a string, we have to reverse the order
                    // of the Data1 and Data2 blocks on little-endian systems.
                    if (guidType == SequentialGuidType.SequentialAsString && BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(guidBytes, 0, 4);
                        Array.Reverse(guidBytes, 4, 2);
                    }
                    break;

                case SequentialGuidType.SequentialAtEnd:
                    Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
                    Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);
                    break;
            }

            return new Guid(guidBytes);
        }
    }
}
