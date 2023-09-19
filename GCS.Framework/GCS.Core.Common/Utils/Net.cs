////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\Net.cs
//
// summary:	Implements the net class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A net. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Net
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets my IP address. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="family">   The family. </param>
        ///
        /// <returns>   my IP address. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IPAddress GetMyIpAddress(AddressFamily family = AddressFamily.InterNetwork)
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == family);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets my IP addresses in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="family">   The family. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process my IP addresses in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<IPAddress> GetMyIpAddresses(AddressFamily family = AddressFamily.InterNetwork)
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.ToList();
        }
    }
}
