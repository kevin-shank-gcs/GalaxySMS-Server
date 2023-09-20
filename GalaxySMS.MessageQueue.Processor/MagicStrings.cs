namespace GalaxySMS.MessageQueue.Processor
{
    public class MagicStringsSettingsGroup
    {
        public static readonly string SettingsGroup = GCS.Core.Common.Utils.SystemUtilities.MyProcessName;
    }

    public class MagicStringsSettingsSubGroup
    {
        public static readonly string Api = "Api";
    }

    public class MagicStringsSettingsApiKey
    {
        public static readonly string UserName = "UserName";
        public static readonly string Password = "Password";
    }

}
