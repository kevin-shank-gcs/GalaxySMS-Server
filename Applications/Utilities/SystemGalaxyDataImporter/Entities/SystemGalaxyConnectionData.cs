using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.WebApi.SysGal.Entities;

namespace SystemGalaxyDataImporter.Entities
{
    public class SystemGalaxyConnectionData : ObjectBase
    {
		private string _webApiUrl;

		public string WebApiUrl
		{
			get { return _webApiUrl; }
			set
			{
				if (_webApiUrl != value)
				{
					_webApiUrl = value;
					OnPropertyChanged(() => WebApiUrl, true);
				}
			}
		}

		private string _userName;

		public string UserName
		{
			get { return _userName; }
			set
			{
				if (_userName != value)
				{
                    _userName = value;
					OnPropertyChanged(() => UserName, true);
				}
			}
		}


		private string _password;

		public string Password
		{
			get { return _password; }
			set
			{
				if (_password != value)
				{
					_password = value;
					OnPropertyChanged(() => Password, true);
				}
			}
		}

		private UserToken _userToken;
		    
		public UserToken UserToken
		{
			get { return _userToken; }
			set
			{
				if (_userToken != value)
				{
                    _userToken = value;
					OnPropertyChanged(() => UserToken, true);
				}
			}
		}


	}
}
