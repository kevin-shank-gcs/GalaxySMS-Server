namespace GalaxySMS.Business.Managers.Support
{
    public class MagicStringsSettingsGroup
    {
        public static readonly string SettingsGroup = GCS.Core.Common.Utils.SystemUtilities.MyProcessName;
    }

    public class MagicStringsSettingsSubGroup
    {
        public static readonly string IdProducer = "IdProducer";
        public static readonly string UserSession = "User Session";
        public static readonly string TwoFactorAuth = "Two Factor Authentication";
        public static readonly string PasswordReset = "Password Reset";
        public static readonly string SignalRHub = "SignalR Hub";
        public static readonly string GalaxyCPUConnections = "Galaxy Cpu Connections";
        public static readonly string Cdn = "Cdn";
        public static readonly string Jwt = "Jwt";
        public static readonly string Uploads = "Uploads";
        public static readonly string RedisCache = "RedisCache";
        public static readonly string Hangfire = "Hangfire";
        public static readonly string ApiServer = "ApiServer";
    }

    public class MagicStringsSettingsUserSessionKey
    {
        public static readonly string Timeout = "Timeout";
    }
    public class MagicStringsSettingsUploadsKey
    {
        public static readonly string StaleDays = "Stale Days";
        public static readonly string MaxUploadFileSize = "MaxUploadFileSize";

    }

    public class MagicStringsSettingsIdProducerKey
    {
        public static readonly string Url = "Url";
        public static readonly string DevUrl = "DevUrl";
        public static readonly string SignalRUrl = "SignalRUrl";
        public static readonly string UserName = "UserName";
        public static readonly string Password = "Password";
        public static readonly string FailIfPrintDispatcherStopped = "FailIfPrintDispatcherStopped";
        public static readonly string DefaultSubscriptionId = "DefaultSubscriptionId";
        public static readonly string AlwaysUseRootSub = "Always Use Root Subscription";
        public static readonly string WebClientUrl = "Web Client Url";
    }

    public class MagicStringsSettingsTwoFactorAuthKey
    {
        public static readonly string SmsTemplate = "Token SMS Template";
        public static readonly string EmailTemplate = "Token Email Template";
        public static readonly string EmailSubject = "Token Email Subject";
        public static readonly string TokenLifespan = "Token Lifespan";
    }

    public class MagicStringsSettingsPasswordResetKey
    {
        public static readonly string SmsTemplate = "Token SMS Template";
        public static readonly string EmailTemplate = "Token Email Template";
        public static readonly string EmailSubject = "Token Email Subject";
        public static readonly string TokenLifespan = "Token Lifespan";
    }

    public class MagicStringsSettingsCdn
    {
        public static readonly string GalaxySmsCdnUrl = "GalaxySmsCdnUrl";

        //public static readonly string StorageType = "StorageType";
        //public static readonly string FileSystemPath = "FileSystemPath";
        //public static readonly string PublicUrl = "PublicUrl";

    }
    public class MagicStringsSettingsJwt
    {
        public static readonly string Key = "Key";
        public static readonly string Issuer = "Issuer";
        public static readonly string Audience = "Audience";

        //public static readonly string StorageType = "StorageType";
        //public static readonly string FileSystemPath = "FileSystemPath";
        //public static readonly string PublicUrl = "PublicUrl";

    }

    public class MagicStringsSettingsRedisCache
    {
        public static readonly string Enabled = "Enabled";
        public static readonly string Host = "Host";
        public static readonly string Port = "Port";
        public static readonly string Password = "Password";
    }

    public class MagicStringsSettingsHangfire
    {
        public static readonly string Enabled = "Enabled";
    }

    public class MagicStringsSettingsApiServer
    {
        public static readonly string ApproximateDuration = "Approximate Duration";
        public static readonly string CommandTimeoutSeconds = "Command Timeout Seconds";
        public static readonly string LoadDataTimeoutSeconds = "LoadData Timeout Seconds";

    }

    public class MagicStringsSettingsSignalRHubKey
    {
        public static readonly string HTTPPort = "HTTP Port";
        public static readonly string HTTPSPort = "HTTPS Port";

    }

    public class MagicStringsSettingsGalaxyCPUConnectionsKey
    {
        public static readonly string AutoStartListener = "Automatic Start Listener";
    }

    public class MagicStringsExceptionMessages
    {
        public static string unauthorized = "unauthorized";
        public static string forbidden = "forbidden";
        public static string entity_forbidden = "entity is forbidden";
        public static string command_forbidden = "command is forbidden";
        public static string not_found = "not found";
        public static string not_in_database = "not in database";
    }
}
