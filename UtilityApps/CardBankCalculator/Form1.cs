using System.Globalization;

namespace CardBankCalculator
{
    public partial class Form1 : Form
    {
        private int _baseBucketAddress = 0x320000;
        private int _bucketSizeInBytes = 0x3000;
        public Form1()
        {
            InitializeComponent();
        }

        private void chkExtendedCardMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtendedCardMode.Checked)
                txtCardsPerBucket.Text = 256.ToString();
            else
            {
                txtCardsPerBucket.Text = 512.ToString();
            }
        }
        private void chkHalfCardCapacity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHalfCardCapacity.Checked)
                txtNumberOfBuckets.Text = 64.ToString();
            else
            {
                txtNumberOfBuckets.Text = 128.ToString();
            }

        }

        private void btnCalculateBucket_Click(object sender, EventArgs e)
        {
            txtDumpCommand.Text = string.Empty;
            txtBucketNumber.Text = string.Empty;
            txtBucketAddress.Text = string.Empty;

            var cardNumber = txtCardNumber.Text;
            var numberOfBuckets = 0;
            if (!int.TryParse(txtNumberOfBuckets.Text, out numberOfBuckets))
                return;

            ulong numericCardNumber = 0;
            var numberStyle = NumberStyles.Integer;
            if (!string.IsNullOrEmpty(cardNumber))
            {
                var isHex = cardNumber.StartsWith("0x") || cardNumber.StartsWith("x");
                if (isHex)
                {
                    if (cardNumber.StartsWith("0x"))
                        cardNumber = cardNumber.Substring(2);
                    else cardNumber = cardNumber.Substring(1);
                    numberStyle = NumberStyles.HexNumber;
                }

                numericCardNumber = CallTryParse(cardNumber, numberStyle);
                if (numericCardNumber != 0)
                {
                    var bytes = BitConverter.GetBytes(numericCardNumber);
                    var xOrResult = 0;
                    foreach (var b in bytes)
                    {
                        xOrResult ^= b;
                    }

                    if (xOrResult > numberOfBuckets)
                        xOrResult -= numberOfBuckets;
                    txtBucketNumber.Text = $"{xOrResult}";
                    var bucketBaseAddress = _baseBucketAddress + (xOrResult * _bucketSizeInBytes);
                    txtBucketAddress.Text = bucketBaseAddress.ToString("x6");
                    txtDumpCommand.Text = $"dump {txtBucketAddress.Text}";
                }
            }
        }


        private static ulong CallTryParse(string stringToConvert, NumberStyles styles)
        {
            CultureInfo provider;

            // If currency symbol is allowed, use en-US culture.
            if ((styles & NumberStyles.AllowCurrencySymbol) > 0)
                provider = new CultureInfo("en-US");
            else
                provider = CultureInfo.InvariantCulture;

            bool success = ulong.TryParse(stringToConvert, styles,
                provider, out ulong number);
            if (success)
                return number;
            return 0;
        }

    }
}