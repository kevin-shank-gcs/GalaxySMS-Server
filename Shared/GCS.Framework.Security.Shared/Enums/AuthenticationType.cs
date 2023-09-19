using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Security
{
	public enum AuthenticationType
	{
		Application,
		WindowsCurrentUser,
        WindowsUser
	}

    public class AuthenticationTypeData
    {
        public AuthenticationTypeData()
        {
            this.AuthenticationType = AuthenticationType.Application;
        }
        public AuthenticationTypeData(AuthenticationType type)
        {
            AuthenticationType = type;
        }

        private string _description;

        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(_description))
                    return AuthenticationType.ToString();
                return _description;
            }
            set { _description = value; }
        }

        public AuthenticationType AuthenticationType { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
