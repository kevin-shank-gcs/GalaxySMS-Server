
namespace GalaxySMS.Common.Constants
{
    public class gcsSettingGroup
    {
        public const string gcsEntity = "gcsEntity";
    }

    public class gcsSettingSubGroup
    {
        public const string AccessProfile = "AccessProfile";
        public const string PersonId = "PersonId";
        public const string Person = "Person";
    }

    public class gcsSettingKey
    {
        public const string ControlsAccessGroup1 = "ControlsAccessGroup1";
        public const string ControlsAccessGroup2 = "ControlsAccessGroup2";
        public const string ControlsAccessGroup3 = "ControlsAccessGroup3";
        public const string ControlsAccessGroup4 = "ControlsAccessGroup4";
        public const string ControlsIOGroup1 = "ControlsIOGroup1";
        public const string ControlsIOGroup2 = "ControlsIOGroup2";
        public const string ControlsIOGroup3 = "ControlsIOGroup3";
        public const string ControlsIOGroup4 = "ControlsIOGroup4";
        public const string Prefix = "Prefix";
        public const string Suffix = "Suffix";
        public const string UniquePartLength = "UniquePartLength";
        public const string UseRandomizedString = "UseRandomizedString";
        public const string DefaultPersonRecordTypeUid = "DefaultPersonRecordTypeUid";

    }

    public class DefaultSettingValues
    {
        public const string PersonIdPrefix = "P-";
        public const string PersonIdSuffix = "`";
        public const int PersonIdDefaultUniquePartLength = 10;
        public const bool PersonIdUseRandomizedString = true;
    }

}
