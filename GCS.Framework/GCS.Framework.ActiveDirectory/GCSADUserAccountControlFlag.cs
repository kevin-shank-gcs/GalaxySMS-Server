﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.ActiveDirectory
{
	[Flags]
	public enum GCSADUserAccountControlFlag
	{
		None										= 0,
		SCRIPT									= 0x0001,
		ACCOUNTDISABLE							= 0x0002,
		HOMEDIR_REQUIRED						= 0x0008,
		LOCKOUT									= 0x0010,
		PASSWD_NOTREQD							= 0x0020,
		PASSWD_CANT_CHANGE					= 0x0040,//Note You cannot assign this permission by directly modifying the UserAccountControl attribute. For information about how to set the permission programmatically, see the "Property flag descriptions" section. 	
		ENCRYPTED_TEXT_PWD_ALLOWED			= 0x0080,
		TEMP_DUPLICATE_ACCOUNT				= 0x0100,
		NORMAL_ACCOUNT							= 0x0200,
		INTERDOMAIN_TRUST_ACCOUNT			= 0x0800,
		WORKSTATION_TRUST_ACCOUNT			= 0x1000,
		SERVER_TRUST_ACCOUNT					= 0x2000,
		DONT_EXPIRE_PASSWORD					= 0x10000,
		MNS_LOGON_ACCOUNT						= 0x20000,
		SMARTCARD_REQUIRED					= 0x40000,
		TRUSTED_FOR_DELEGATION				= 0x80000,
		NOT_DELEGATED							= 0x100000,
		USE_DES_KEY_ONLY						= 0x200000,
		DONT_REQ_PREAUTH						= 0x400000,
		PASSWORD_EXPIRED						= 0x800000,
		TRUSTED_TO_AUTH_FOR_DELEGATION	= 0x1000000,
		PARTIAL_SECRETS_ACCOUNT				= 	0x04000000
	}
}
