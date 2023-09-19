using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCS.Framework.CredentialProcessor
{
    public class CredentialDataEventArgs : EventArgs
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Constructor. </summary>
        ///
        /// <param name="d">	The RawCredentialData to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialDataEventArgs(RawCredentialData d)
        {
            Data = d;
        }

        /// <summary>	Byte array containing data from serial port. </summary>
        public RawCredentialData Data;

    }
}
