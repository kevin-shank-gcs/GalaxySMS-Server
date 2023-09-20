using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;

namespace GCS.Framework.CredentialProcessor
{

    public class CredentialPIV75BitFormat : CredentialFormatBase
    {
        private uint _agencyCode;
        private uint _siteCode;
        private uint _credential;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialPIV75BitFormat()
        {
            AgencyCode = 0;
            SiteCode = 0;
            Credential = 0;
            BitCount = 75;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/6/2017. </remarks>
        ///
        /// <param name="agencyCode">   The agency code. </param>
        /// <param name="siteCode">     The site code. </param>
        /// <param name="credential">   The credential. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialPIV75BitFormat(uint agencyCode, uint siteCode, uint credential)
        {
            AgencyCode = agencyCode;
            SiteCode = siteCode;
            Credential = credential;
            BitCount = 75;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the agency code. </summary>
        ///
        /// <value> The agency code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public uint AgencyCode
        {
            get { return _agencyCode; }
            set
            {
                if (value > 0 && value <= 0x3FFF)
                    _agencyCode = value;
                else _agencyCode = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the site code. </summary>
        ///
        /// <value> The site code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public uint SiteCode
        {
            get { return _siteCode; }
            set
            {
                if (value > 0 && value <= 0x3FFF)
                    _siteCode = value;
                else _siteCode = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential. </summary>
        ///
        /// <value> The credential. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public uint Credential
        {
            get { return _credential; }
            set
            {
                if (value > 0 && value <= 0xFFFFF)
                    _credential = value;
                else _credential = 0;
            }
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
                if (AgencyCode != 0 || SiteCode != 0 || Credential != 0)
                    return true;
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the fcc. </summary>
        ///
        /// <value> The fcc. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string FCC
        {
            get
            {
                return Compute(AgencyCode, SiteCode, Credential);
            }
        }


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
                return HexEncoding.GetBytesFromDecimalString(FCC, StandardBinaryDataLength, out discardedCount);
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
                return HexEncoding.GetBytesFromDecimalString(FCC, ExtendedBinaryDataLength, out discardedCount);
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
                    return CredentialFormatCodes.PIV75Bit;
                else
                    return CredentialFormatCodes.None;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Computes. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="AgencyCode">   The agency code. </param>
        /// <param name="SiteCode">     The site code. </param>
        /// <param name="Credential">   The credential. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string Compute(uint AgencyCode, uint SiteCode, uint Credential)
        {

            if (AgencyCode == 0 && SiteCode == 0 && Credential == 0)
                return string.Empty;

            UInt64 hex_code = 0;

            hex_code = (Convert.ToUInt64(AgencyCode) & 0x3FFF);
            hex_code <<= 14;
            hex_code |= (Convert.ToUInt64(SiteCode) & 0x3FFF);
            hex_code <<= 20;
            hex_code |= (Convert.ToUInt64(Credential) & 0xFFFFF);

            return hex_code.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the agency code described by data. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The extracted agency code. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static uint ExtractAgencyCode(ulong data)
        {
            ulong mask = (ulong)0xFFFC00000000;
            ulong agency = data & mask;
            agency >>= 34;
            return (uint)agency;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the site code described by data. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The extracted site code. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static uint ExtractSiteCode(ulong data)
        {
            ulong mask = (ulong)0x3FFF00000;
            ulong site = data & mask;
            site >>= 20;
            return (uint)site;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the credential described by data. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The extracted credential. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static uint ExtractCredential(ulong data)
        {
            ulong mask = (ulong)0xFFFFF;
            ulong id = data & mask;
            return (uint)id;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Is binary data valid. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="array">    The array. </param>
        ///
        /// <returns>   A CredentialPIV75BitFormat. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CredentialPIV75BitFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new CredentialPIV75BitFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            if (hightest1Bit > 75)
                return ret;
            if (array.Length < sizeof(int))
                return ret;

            ulong binaryData = BitConverter.ToUInt64(array, array.Length - sizeof(ulong));
            binaryData = ByteFlipper.ReverseBytes(binaryData);
            uint agencyCode = ExtractAgencyCode(binaryData);
            uint siteCode = ExtractSiteCode(binaryData);
            uint credentialCode = ExtractCredential(binaryData);
            string computedCode = Compute(agencyCode, siteCode, credentialCode);
            if (computedCode != binaryData.ToString())
                return ret;

            ret.AgencyCode = agencyCode;
            ret.SiteCode = siteCode;
            ret.Credential = credentialCode;

            return ret;
        }

        public override string ToString()
        {
            if (this.ContainsData == true)
                return string.Format("{0}:{1}:{2}", AgencyCode, SiteCode, Credential);
            else return string.Empty;
        }
    }

}
