using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.CredentialProcessor
{

    public class CredentialCustomFormat : CredentialFormatBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialCustomFormat()
        {
            Value1 = 0;
            Value2 = 0;
            Value3 = 0;
            Value4 = 0;
            Value5 = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/6/2017. </remarks>
        ///
        /// <param name="value1">   The value 1. </param>
        /// <param name="value2">   The value 2. </param>
        /// <param name="value3">   The value 3. </param>
        /// <param name="value4">   The value 4. </param>
        /// <param name="value5">   The value 5. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialCustomFormat(uint value1, uint value2, uint value3, uint value4, uint value5)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value 1. </summary>
        ///
        /// <value> The value 1. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public uint Value1 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value 2. </summary>
        ///
        /// <value> The value 2. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public uint Value2 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value 3. </summary>
        ///
        /// <value> The value 3. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public uint Value3 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value 4. </summary>
        ///
        /// <value> The value 4. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public uint Value4 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value 5. </summary>
        ///
        /// <value> The value 5. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public uint Value5 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this object contains data. </summary>
        ///
        /// <value> true if contains data, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override bool ContainsData
        {
            get
            {
                if (Value1 != 0 ||
                        Value2 != 0 ||
                        Value3 != 0 ||
                        Value4 != 0 ||
                        Value5 != 0)
                    return true;
                return false;
            }
        }

        //public override string FCC
        //{
        //    get
        //    {
        //        return base.FCC;
        //    }
        //} 

        public override string ToString()
        {
            if (this.ContainsData == true)
                return string.Format("{0}:{1}:{2}", Value1, Value2, Value3);
            else return string.Empty;
        }
    }

}
