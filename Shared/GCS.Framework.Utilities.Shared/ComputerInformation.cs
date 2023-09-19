using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GCS.Framework.Utilities.Computer
{
    [Serializable]
	public class ComputerInformation
	{
		private string _MachineName = string.Empty;
	    private List<string> _ipAddresses;

	    public ComputerInformation()
			{
				IPAddresses = new List<string>();
				MachineName = GCS.Framework.Utilities.SystemUtilities.MyMachineName();
				System.Net.IPAddress[] addresses = GCS.Framework.Utilities.SystemUtilities.MyIPAddresses();
				foreach (System.Net.IPAddress address in addresses)
					IPAddresses.Add(address.ToString());

			}


		public string MachineName
		{
			get { return _MachineName; }
			set
			{
				if (_MachineName != value)
				{
					_MachineName = value;
                }
			}
		}

	    public List<string> IPAddresses
	    {
	        get { return _ipAddresses; }
            internal set
            {
                if (_ipAddresses != value)
                {
                    _ipAddresses = value;
                }
            }
	    }
	}
}
