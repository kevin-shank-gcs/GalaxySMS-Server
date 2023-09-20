using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;

namespace GCS.Framework.CredentialProcessor
{
    public class CredentialNumericFormat : CredentialFormatBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialNumericFormat()
        {
            ContainsData = false;
            FCC = string.Empty;
        }


        public CredentialNumericFormat(string cardNumber)
        {
            ContainsData = !string.IsNullOrEmpty(cardNumber);
            FCC = cardNumber;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this object contains data. </summary>
        ///
        /// <value> true if contains data, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override bool ContainsData
        {
            get
            {
                if (FCC != string.Empty)
                    return true;
                else
                    return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the fcc. </summary>
        ///
        /// <value> The fcc. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string FCC { get; internal set; }


        #region Overrides of CredentialFormatBase

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the standard length binary data. </summary>
        ///
        /// <value> Information describing the binary. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override byte[] BinaryDataStandard
        {
            get
            {
                int discardedCount = 0;
                return HexEncoding.GetBytesFromString(FCC, StandardBinaryDataLength, out discardedCount);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the extended length binary data . </summary>
        ///
        /// <value> The binary data extended. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override byte[] BinaryDataExtended
        {
            get
            {
                int discardedCount = 0;
                return HexEncoding.GetBytesFromString(FCC, ExtendedBinaryDataLength, out discardedCount);
            }
        }
        #endregion


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the data format. </summary>
        ///
        /// <value> The data format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override CredentialFormatCodes DataFormat
        {
            get
            {
                if (ContainsData == true)
                    return CredentialFormatCodes.NumericCardCode;
                else
                    return CredentialFormatCodes.None;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Is binary data valid. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="array">    The array. </param>
        ///
        /// <returns>   A CardGenericFormat. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CredentialNumericFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new CredentialNumericFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            ret.FCC = HexEncoding.ToString(array, true, "x", true, 48);
            return ret;
        }

        public override string ToString()
        {
            return FCC;
        }
    }

}
