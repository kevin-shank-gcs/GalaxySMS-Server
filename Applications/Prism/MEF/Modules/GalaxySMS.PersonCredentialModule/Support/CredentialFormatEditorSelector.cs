using GalaxySMS.Client.Entities;
using GalaxySMS.Common.Enums;
using System.Windows;
using System.Windows.Controls;

namespace GalaxySMS.PersonCredential.Support
{
    public class CredentialFormatEditorSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var credentialFormatCode = CredentialFormatCodes.None;

            if (item is Credential)
            {
                var c = (Credential)item;
                if (c.CredentialFormat == null)
                    return null;
                credentialFormatCode = c.CredentialFormat.CredentialFormatCode;
            }
            else if (item is CredentialFormat)
            {
                var c = (CredentialFormat)item;
                credentialFormatCode = c.CredentialFormatCode;
            }
            switch (credentialFormatCode)
            {
                case CredentialFormatCodes.NumericCardCode:
                case CredentialFormatCodes.BasIpQr:
                case CredentialFormatCodes.BtFarpointeConektMobile:
                case CredentialFormatCodes.BtHidMobileAccess:
                case CredentialFormatCodes.BtStidMobileId:
                case CredentialFormatCodes.BtAllegion:
                case CredentialFormatCodes.BtBasIp:
                    break;
                case CredentialFormatCodes.MagneticStripeBarcodeAba:
                    break;
                case CredentialFormatCodes.Standard26Bit:
                    return Credential26BitStandardTemplate;

                case CredentialFormatCodes.GalaxyKeypad:
                    break;
                case CredentialFormatCodes.Corporate1K35Bit:
                    return CredentialCorporate1K35BitTemplate;

                case CredentialFormatCodes.PIV75Bit:
                    return CredentialPIV75BitTemplate;

                case CredentialFormatCodes.Bqt36Bit:
                    return CredentialBqt36BitTemplate;

                case CredentialFormatCodes.XceedId40Bit:
                    return CredentialXceedId40BitTemplate;

                case CredentialFormatCodes.USGovernmentID:
                    break;
                case CredentialFormatCodes.Corporate1K48Bit:
                    return CredentialCorporate1K48BitTemplate;

                case CredentialFormatCodes.Cypress37Bit:
                    return CredentialCypress37BitTemplate;

                case CredentialFormatCodes.H1030437Bit:
                    return CredentialH1030437BitTemplate;

                case CredentialFormatCodes.H1030237Bit:
                    return CredentialH1030237BitTemplate;

                case CredentialFormatCodes.SoftwareHouse37Bit:
                    return CredentialSoftwareHouse37BitTemplate;

                case CredentialFormatCodes.None:
                    break;
                default:
                    return Credential26BitStandardTemplate;
            }


            return null;
        }

        public DataTemplate Credential26BitStandardTemplate { get; set; }
        public DataTemplate CredentialCorporate1K35BitTemplate { get; set; }
        public DataTemplate CredentialCorporate1K48BitTemplate { get; set; }
        public DataTemplate CredentialH1030437BitTemplate { get; set; }
        public DataTemplate CredentialH1030237BitTemplate { get; set; }
        public DataTemplate CredentialSoftwareHouse37BitTemplate { get; set; }
        public DataTemplate CredentialCypress37BitTemplate { get; set; }
        public DataTemplate CredentialXceedId40BitTemplate { get; set; }
        public DataTemplate CredentialBqt36BitTemplate { get; set; }
        public DataTemplate CredentialPIV75BitTemplate { get; set; }
        public DataTemplate CredentialDataTemplate { get; set; }
        public DataTemplate CredentialNumericTemplate { get; set; }

    }

}
