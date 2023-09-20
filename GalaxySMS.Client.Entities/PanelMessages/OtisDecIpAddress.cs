////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\OtisDecIpAddress.cs
//
// summary:	Implements the otis decrement IP address class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The otis decrement IP address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class OtisDecIpAddress : ObjectBase
	{
        /// <summary>   The third octet. </summary>
	    private byte _octet3;
        /// <summary>   The fourth octet. </summary>
	    private byte _octet4;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the octet 3. </summary>
        ///
        /// <value> The octet 3. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte Octet3
	    {
	        get { return _octet3; }
            set
            {
                if (_octet3 != value)
                {
                    _octet3 = value;
                    OnPropertyChanged(() => Octet3);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the octet 4. </summary>
        ///
        /// <value> The octet 4. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte Octet4
	    {
	        get { return _octet4; }
            set
            {
                if (_octet4 != value)
                {
                    _octet4 = value;
                    OnPropertyChanged(() => Octet4);
                }
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
			return string.Format("192.168.{0}.{1}", Octet3, Octet4);
		}
	}
}
