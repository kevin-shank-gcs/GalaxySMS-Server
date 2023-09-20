////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\SchlagePimNumber.cs
//
// summary:	Implements the schlage pim number class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A schlage pim number. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SchlagePimNumber : ObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent schlage pim number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum SchlagePimNumberLimits { MinimumPimNumber = 1, MaximumPimNumber = 16 }

        /// <summary>   The pim number. </summary>
        private Int32 _pimNumber = 1;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String UniqueId { get { return string.Format("{0:D3}", PimNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the pim number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The pim number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 PimNumber
        {
            get { return _pimNumber; }
            set
            {
                if (value >= (Int32)SchlagePimNumberLimits.MinimumPimNumber && value <= (Int32)SchlagePimNumberLimits.MaximumPimNumber)
                {
                    if (_pimNumber != value)
                    {
                        _pimNumber = value;
                        OnPropertyChanged(() => PimNumber);
                    }
                }
                else
                    throw new ArgumentOutOfRangeException("SchlagePimNumber.PimNumber", value, string.Format("The PimNumber value must be between {0} and {1}",
                        SchlagePimNumberLimits.MinimumPimNumber, SchlagePimNumberLimits.MaximumPimNumber));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return PimNumber.ToString();
        }
    }

}
