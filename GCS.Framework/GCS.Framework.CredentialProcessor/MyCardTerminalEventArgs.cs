using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Subsembly.SmartCard;

namespace GCS.Framework.CredentialProcessor
{
    public class MyCardTerminalEventArgs
    {
        public MyCardTerminalEventArgs()
        {
            Sender = null;
            EventArgs = null;
        }
        public MyCardTerminalEventArgs(object aSender, CardTerminalEventArgs aEventArgs)
        {
            Sender = aSender;
            EventArgs = aEventArgs;
        }

        public object Sender { get; internal set; }
        public CardTerminalEventArgs EventArgs { get; internal set; }
    }
}
