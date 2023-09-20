using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;
using System;
using System.Collections.Generic;

namespace GCS.Framework.CredentialProcessor
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A raw credential data. </summary>
    ///
    /// <remarks>   Kevin, 6/10/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum SmartCardType : ushort { Unknown, MiFare, iClass, DesFire }

    public class RawCredentialData
    {
        public class RawDataBitLengthHint
        {
            public int MinBitLength { get; set; }
            public int MaxBitLength { get; set; }
        }
        /// <summary>   The card data hexadecimal string register ex. </summary>
        public const string CardDataHexStringRegEx = "^[0-9a-fA-F]{1,64}$";
        /// <summary>   The card data 0x hexadecimal string register ex. </summary>
        //public const string CardData0xHexStringRegEx = "^0x[0-9a-fA-F]{1,64}$";
        public const string CardData0xHexStringRegEx = "^0?x?[0-9a-fA-F]{1,64}$";
        /// <summary>   Length of the byte array. </summary>
        public const int ByteArrayLength = 32;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent DataType. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum DataType { Auto, DecimalString, HexString, Bytes }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RawCredentialData()
        {
            DataFormat = CredentialFormatCodes.None;
            ExpectedDataFormat = CredentialFormatCodes.None;
            UseDataType = DataType.Auto;
            RawData = string.Empty;
            DataString = string.Empty;
            DataBytes = new byte[ByteArrayLength];
            BitCount = 0;
            ActualHighestOneBit = 0;
            ReaderDataFormat = CredentialReaderDataFormat.WiegandFormat;
            RegularExpression = string.Empty;
            Wiegand26Data = new Credential26BitWiegandFormat();
            Wiegand35HIDCorporate1000Data = new CredentialHIDCorporate1K35BitFormat();
            Wiegand48HIDCorporate1000Data = new CredentialHIDCorporate1K48BitFormat();
            BQT36Data = new CredentialBQT36BitFormat();
            PIV75Data = new CredentialPIV75BitFormat();
            HIDH1030437BitData = new CredentialHIDH1030437BitFormat();
            HIDH1030237BitData = new CredentialHIDH1030237BitFormat();
            XceedId40BitData = new CredentialXceedId40BitFormat();
            Cypress37BitData = new CredentialCypress37BitFormat();
            SoftwareHouse37BitData = new CredentialSoftwareHouse37BitFormat();
            CustomData = new CredentialCustomFormat();
            GenericData = new CredentialNumericFormat();
            RawBitLengthHint = new RawDataBitLengthHint();
            CardSerialNumber = string.Empty;
            SmartCardType = SmartCardType.Unknown;
        }

        public RawCredentialData(CredentialFormatCodes df, string cardNumber, byte[] dataBytes, List<uint> values)
        {
            DataFormat = df;
            ExpectedDataFormat = df;
            UseDataType = DataType.Auto;
            RawData = string.Empty;
            DataString = cardNumber;
            DataBytes = dataBytes;
            BitCount = 0;
            ActualHighestOneBit = 0;
            ReaderDataFormat = CredentialReaderDataFormat.WiegandFormat;
            RegularExpression = string.Empty;
            Wiegand26Data = new Credential26BitWiegandFormat();
            Wiegand35HIDCorporate1000Data = new CredentialHIDCorporate1K35BitFormat();
            Wiegand48HIDCorporate1000Data = new CredentialHIDCorporate1K48BitFormat();
            BQT36Data = new CredentialBQT36BitFormat();
            PIV75Data = new CredentialPIV75BitFormat();
            HIDH1030437BitData = new CredentialHIDH1030437BitFormat();
            HIDH1030237BitData = new CredentialHIDH1030237BitFormat();
            XceedId40BitData = new CredentialXceedId40BitFormat();
            Cypress37BitData = new CredentialCypress37BitFormat();
            SoftwareHouse37BitData = new CredentialSoftwareHouse37BitFormat();
            CustomData = new CredentialCustomFormat();
            GenericData = new CredentialNumericFormat(DataString);
            RawBitLengthHint = new RawDataBitLengthHint();
            CardSerialNumber = string.Empty;
            SmartCardType = SmartCardType.Unknown;
            switch (df)
            {
                case CredentialFormatCodes.NumericCardCode:
                case CredentialFormatCodes.MagneticStripeBarcodeAba:
                case CredentialFormatCodes.GalaxyKeypad:
                case CredentialFormatCodes.USGovernmentID:
                case CredentialFormatCodes.BtFarpointeConektMobile:
                case CredentialFormatCodes.BtHidMobileAccess:
                case CredentialFormatCodes.BtStidMobileId:
                case CredentialFormatCodes.BtAllegion:
                case CredentialFormatCodes.BtBasIp:
                case CredentialFormatCodes.BasIpQr:
                    break;
                case CredentialFormatCodes.Standard26Bit:
                    Wiegand26Data.FCC = cardNumber;
                    if (values.Count == 2)
                    {
                        Wiegand26Data.FacilityCode = (ushort)values[0];
                        Wiegand26Data.IDCode = (int)values[1];
                    }
                    break;
                case CredentialFormatCodes.Corporate1K35Bit:
                    Wiegand35HIDCorporate1000Data.FCC = cardNumber;
                    if (values.Count == 2)
                    {
                        Wiegand35HIDCorporate1000Data.CompanyCode = values[0];
                        Wiegand35HIDCorporate1000Data.IDCode = values[1];
                    }
                    break;
                case CredentialFormatCodes.PIV75Bit:
                    PIV75Data.FCC = cardNumber;
                    if (values.Count == 3)
                    {
                        PIV75Data.AgencyCode = values[0];
                        PIV75Data.SiteCode = values[1];
                        PIV75Data.Credential = values[2];
                    }
                    break;
                case CredentialFormatCodes.Bqt36Bit:
                    break;
                case CredentialFormatCodes.XceedId40Bit:
                    break;
                case CredentialFormatCodes.Corporate1K48Bit:
                    Wiegand48HIDCorporate1000Data.FCC = cardNumber;
                    if (values.Count == 2)
                    {
                        Wiegand48HIDCorporate1000Data.CompanyCode = values[0];
                        Wiegand48HIDCorporate1000Data.IDCode = values[1];
                    }
                    break;
                case CredentialFormatCodes.Cypress37Bit:
                    break;
                case CredentialFormatCodes.H1030437Bit:
                    break;
                case CredentialFormatCodes.H1030237Bit:
                    break;
                case CredentialFormatCodes.SoftwareHouse37Bit:
                    break;
                case CredentialFormatCodes.None:
                    break;
            }
        }

        public RawDataBitLengthHint RawBitLengthHint { get; internal set; }

        public SmartCardType SmartCardType { get; set; }
        public string CardSerialNumber { get; set; }

        public string EnrollmentDeviceDescription { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the raw data from the enrollment reader. </summary>
        ///
        /// <value> Information describing the raw. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RawData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data string. </summary>
        ///
        /// <value> The data string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DataString { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data bytes. </summary>
        ///
        /// <value> The data bytes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public byte[] DataBytes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of bits. </summary>
        ///
        /// <value> The number of bits. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public short BitCount { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the actual highest one bit. </summary>
        ///
        /// <value> The actual highest one bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public short ActualHighestOneBit { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the reader data format. </summary>
        ///
        /// <value> The reader data format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialReaderDataFormat ReaderDataFormat { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the regular expression. </summary>
        ///
        /// <value> The regular expression. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RegularExpression { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the use data. </summary>
        ///
        /// <value> The type of the use data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataType UseDataType { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data format. </summary>
        ///
        /// <value> The data format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialFormatCodes DataFormat { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the expected data format. </summary>
        ///
        /// <value> The expected data format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialFormatCodes ExpectedDataFormat { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the wiegand 26. </summary>
        ///
        /// <value> Information describing the wiegand 26. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Credential26BitWiegandFormat Wiegand26Data { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the wiegand 35 HID corporate 1000. </summary>
        ///
        /// <value> Information describing the wiegand 35 HID corporate 1000. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialHIDCorporate1K35BitFormat Wiegand35HIDCorporate1000Data { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the wiegand 48 HID corporate 1000. </summary>
        ///
        /// <value> Information describing the wiegand 48 HID corporate 1000. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialHIDCorporate1K48BitFormat Wiegand48HIDCorporate1000Data { get; internal set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the bqt 36. </summary>
        ///
        /// <value> Information describing the bqt 36. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialBQT36BitFormat BQT36Data { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the piv 75. </summary>
        ///
        /// <value> Information describing the piv 75. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialPIV75BitFormat PIV75Data { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the hidh 1030437 bit. </summary>
        ///
        /// <value> Information describing the hidh 1030437 bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialHIDH1030437BitFormat HIDH1030437BitData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the hidh 1030237 bit. </summary>
        ///
        /// <value> Information describing the hidh 1030237 bit. </value>
        ///=================================================================================================

        public CredentialHIDH1030237BitFormat HIDH1030237BitData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the xceed identifier 40 bit. </summary>
        ///
        /// <value> The xceed identifier 40 bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialXceedId40BitFormat XceedId40BitData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cypress 37 bit. </summary>
        ///
        /// <value> The cypress 37 bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialCypress37BitFormat Cypress37BitData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the software house 37 bit. </summary>
        ///
        /// <value> Information describing the software house 37 bit. </value>
        ///=================================================================================================

        public CredentialSoftwareHouse37BitFormat SoftwareHouse37BitData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the custom. </summary>
        ///
        /// <value> Information describing the custom. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialCustomFormat CustomData { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the generic. </summary>
        ///
        /// <value> Information describing the generic. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialNumericFormat GenericData { get; internal set; }

        public override string ToString()
        {
            switch (DataFormat)
            {
                case CredentialFormatCodes.Standard26Bit:
                    return Wiegand26Data.ToString();

                case CredentialFormatCodes.Corporate1K35Bit:
                    return Wiegand35HIDCorporate1000Data.ToString();

                case CredentialFormatCodes.Corporate1K48Bit:
                    return Wiegand48HIDCorporate1000Data.ToString();

                case CredentialFormatCodes.Bqt36Bit:
                    return BQT36Data.ToString();

                case CredentialFormatCodes.PIV75Bit:
                    return PIV75Data.ToString();

                case CredentialFormatCodes.NumericCardCode:
                    return GenericData.ToString();

                default:
                case CredentialFormatCodes.BtFarpointeConektMobile:
                case CredentialFormatCodes.BtHidMobileAccess:
                case CredentialFormatCodes.BtStidMobileId:
                case CredentialFormatCodes.BtAllegion:
                case CredentialFormatCodes.BtBasIp:
                case CredentialFormatCodes.BasIpQr:
                    return CustomData.FCC;

            }
        }

        public string FullCardCode
        {
            get
            {
                switch (DataFormat)
                {
                    case CredentialFormatCodes.Standard26Bit:
                        return Wiegand26Data.FCC;

                    case CredentialFormatCodes.Corporate1K35Bit:
                        return Wiegand35HIDCorporate1000Data.FCC;

                    case CredentialFormatCodes.Corporate1K48Bit:
                        return Wiegand48HIDCorporate1000Data.FCC;

                    case CredentialFormatCodes.Bqt36Bit:
                        return BQT36Data.FCC;

                    case CredentialFormatCodes.PIV75Bit:
                        return PIV75Data.FCC;

                    case CredentialFormatCodes.NumericCardCode:
                        return GenericData.FCC;

                    default:
                        return CustomData.FCC;

                }
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential analyzer. </summary>
    ///
    /// <remarks>   Kevin, 6/10/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CredentialAnalyzer
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evaluates RawCredentialData to determine what the credential format. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="data"> RawCredentialData to test. </param>
        ///
        /// <returns>   DataFormat value. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CredentialFormatCodes AnalyzeRawData(RawCredentialData data)
        {
            try
            {
                var ret = CredentialFormatCodes.None;

                if (data == null)
                    return CredentialFormatCodes.None;

                // this first switch block filters evaluates DataType.Auto to determine what format the data is in	
                switch (data.UseDataType)
                {
                    case RawCredentialData.DataType.Auto:
                        if (data.DataString != null && data.DataString != string.Empty)
                        {
                            if (HexEncoding.IsHexFormat(data.DataString))
                                data.UseDataType = RawCredentialData.DataType.HexString;
                            else if (HexEncoding.IsDecimalFormat(data.DataString))
                                data.UseDataType = RawCredentialData.DataType.DecimalString;
                            else
                                return CredentialFormatCodes.None;
                        }
                        else if (data.DataBytes != null && HexEncoding.CompareArray<byte>(data.DataBytes, 0) == false)
                            data.UseDataType = RawCredentialData.DataType.Bytes;
                        else
                            return CredentialFormatCodes.None;
                        break;

                    case RawCredentialData.DataType.HexString:
                    case RawCredentialData.DataType.DecimalString:
                    case RawCredentialData.DataType.Bytes:
                        break;
                }

                int discarded;

                // This switch block validates the data and converts string values to a byte array
                switch (data.UseDataType)
                {
                    case RawCredentialData.DataType.HexString:
                        if (data.DataString == null || data.DataString == string.Empty)
                            return CredentialFormatCodes.None;

                        if (data.RegularExpression != null && data.RegularExpression != string.Empty)
                        {
                            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(data.RegularExpression);
                            if (regEx.IsMatch(data.DataString, 0) == false)
                                return CredentialFormatCodes.None;
                        }
                        else
                        {	//  no regular expression has been provided, therefore, we must validate the string as hex
                            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(RawCredentialData.CardData0xHexStringRegEx);
                            if (regEx.IsMatch(data.DataString, 0) == false)
                            {
                                regEx = new System.Text.RegularExpressions.Regex(RawCredentialData.CardDataHexStringRegEx);
                                if (regEx.IsMatch(data.DataString, 0) == false)
                                    return CredentialFormatCodes.None;
                            }
                        }
                        // the data has been validated as a hex string, now convert it to a byte array
                        data.DataBytes = HexEncoding.GetBytesFromHexString(data.DataString, RawCredentialData.ByteArrayLength, out discarded);
                        data.UseDataType = RawCredentialData.DataType.Bytes;
                        break;

                    case RawCredentialData.DataType.DecimalString:
                        if (data.DataString == null || data.DataString == string.Empty)
                            return CredentialFormatCodes.None;

                        if (data.RegularExpression != null && data.RegularExpression != string.Empty)
                        {
                            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(data.RegularExpression);
                            if (regEx.IsMatch(data.DataString, 0) == false)
                                return CredentialFormatCodes.None;
                        }
                        else
                        {	//  no regular expression has been provided, therefore, we must validate the string as decimal
                            ulong ulongvalue;
                            if (ulong.TryParse(data.DataString, out ulongvalue) == false)
                                return CredentialFormatCodes.None;
                        }
                        // the data has been validated as a hex string, now convert it to a byte array
                        data.DataBytes = HexEncoding.GetBytesFromDecimalString(data.DataString, RawCredentialData.ByteArrayLength, out discarded);
                        data.UseDataType = RawCredentialData.DataType.Bytes;
                        break;

                    case RawCredentialData.DataType.Bytes:
                        if (data.DataBytes == null)
                            return CredentialFormatCodes.None;

                        if (HexEncoding.CompareArray<byte>(data.DataBytes, 0) == true)
                            return CredentialFormatCodes.None;
                        break;

                    case RawCredentialData.DataType.Auto:	// this case should not occur at this point
                    default:
                        return CredentialFormatCodes.None;
                }

                // At this point, the data should be in the DataBytes object
                switch (data.ReaderDataFormat)
                {
                    case CredentialReaderDataFormat.WiegandFormat:
                    case CredentialReaderDataFormat.WiegandKey:
                    case CredentialReaderDataFormat.XceedIdPivWiegand:
                    case CredentialReaderDataFormat.CardaxWiegand:
                        //case CredentialReaderDataFormat.DSI_IR_PIM_WIEGAND_READER:
                        data.ActualHighestOneBit = HexEncoding.GetHighestNonZeroBit(data.DataBytes);

                        switch (data.ExpectedDataFormat)
                        {
                            case CredentialFormatCodes.NumericCardCode:
                            case CredentialFormatCodes.BtFarpointeConektMobile:
                            case CredentialFormatCodes.BtHidMobileAccess:
                            case CredentialFormatCodes.BtStidMobileId:
                            case CredentialFormatCodes.BtAllegion:
                            case CredentialFormatCodes.BtBasIp:
                            case CredentialFormatCodes.BasIpQr:
                                break;
                            case CredentialFormatCodes.MagneticStripeBarcodeAba:
                                break;
                            case CredentialFormatCodes.Standard26Bit:
                                if (data.BitCount <= 26 && data.ActualHighestOneBit <= 26)
                                    data.BitCount = 26;
                                break;
                            case CredentialFormatCodes.GalaxyKeypad:
                                break;
                            case CredentialFormatCodes.Corporate1K35Bit:
                                if (data.BitCount <= 35 && data.ActualHighestOneBit <= 35)
                                    data.BitCount = 35;
                                break;
                            case CredentialFormatCodes.Corporate1K48Bit:
                                if (data.BitCount <= 48 && data.ActualHighestOneBit <= 48)
                                    data.BitCount = 48;
                                break;
                            case CredentialFormatCodes.PIV75Bit:
                                break;
                            case CredentialFormatCodes.Bqt36Bit:
                                break;
                            case CredentialFormatCodes.XceedId40Bit:
                                break;
                            case CredentialFormatCodes.None:
                                if (data.BitCount == 0)
                                {
                                    if (data.BitCount <= 26 &&
                                        data.ActualHighestOneBit <= 26 &&
                                        data.RawBitLengthHint.MinBitLength != 0 &&
                                        (data.RawBitLengthHint.MinBitLength <= 26 &&
                                        data.RawBitLengthHint.MaxBitLength >= 26))
                                        data.BitCount = 26;
                                    else if (data.BitCount <= 35 &&
                                        data.ActualHighestOneBit <= 35 &&
                                        data.RawBitLengthHint.MinBitLength != 0 &&
                                        (data.RawBitLengthHint.MinBitLength <= 35 &&
                                        data.RawBitLengthHint.MaxBitLength >= 35))
                                        data.BitCount = 35;
                                }

                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        switch (data.BitCount)
                        {
                            case 26:
                                data.Wiegand26Data = Credential26BitWiegandFormat.IsBinaryDataValid(data.DataBytes);
                                if (data.Wiegand26Data.DataFormat == CredentialFormatCodes.Standard26Bit)
                                    ret = CredentialFormatCodes.Standard26Bit;
                                else
                                {
                                    data.GenericData = CredentialNumericFormat.IsBinaryDataValid(data.DataBytes);
                                    ret = CredentialFormatCodes.NumericCardCode;
                                }
                                break;

                            case 35:
                                data.Wiegand35HIDCorporate1000Data = CredentialHIDCorporate1K35BitFormat.IsBinaryDataValid(data.DataBytes);
                                if (data.Wiegand35HIDCorporate1000Data.DataFormat == CredentialFormatCodes.Corporate1K35Bit)
                                    ret = CredentialFormatCodes.Corporate1K35Bit;
                                else
                                {
                                    data.GenericData = CredentialNumericFormat.IsBinaryDataValid(data.DataBytes);
                                    ret = CredentialFormatCodes.NumericCardCode;
                                }
                                break;

                            case 36:
                                data.BQT36Data = CredentialBQT36BitFormat.IsBinaryDataValid(data.DataBytes);
                                if (data.BQT36Data.DataFormat == CredentialFormatCodes.Bqt36Bit)
                                    ret = CredentialFormatCodes.Bqt36Bit;
                                else
                                {
                                    data.GenericData = CredentialNumericFormat.IsBinaryDataValid(data.DataBytes);
                                    ret = CredentialFormatCodes.NumericCardCode;
                                }
                                break;

                            case 48:
                                data.Wiegand48HIDCorporate1000Data = CredentialHIDCorporate1K48BitFormat.IsBinaryDataValid(data.DataBytes);
                                if (data.Wiegand48HIDCorporate1000Data.DataFormat == CredentialFormatCodes.Corporate1K48Bit)
                                    ret = CredentialFormatCodes.Corporate1K48Bit;
                                else
                                {
                                    data.GenericData = CredentialNumericFormat.IsBinaryDataValid(data.DataBytes);
                                    ret = CredentialFormatCodes.NumericCardCode;
                                }
                                break;

                            default:
                                data.GenericData = CredentialNumericFormat.IsBinaryDataValid(data.DataBytes);
                                ret = CredentialFormatCodes.NumericCardCode;
                                break;
                        }

                        break;

                    //case CredentialReaderDataFormat.XCEEDID_PIV:
                    //case CredentialReaderDataFormat.XCEEDID_PIV_500i:
                    //    break;

                    default:
                        data.GenericData = CredentialNumericFormat.IsBinaryDataValid(data.DataBytes);
                        ret = CredentialFormatCodes.NumericCardCode;
                        break;
                }

                data.DataFormat = ret;
                if (data.DataBytes.Length < RawCredentialData.ByteArrayLength)
                    data.DataBytes = HexEncoding.PadByteArray(data.DataBytes, RawCredentialData.ByteArrayLength, false);
                return ret;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.Write(e.Message);
            }
            return CredentialFormatCodes.None;
        }
    }

}
