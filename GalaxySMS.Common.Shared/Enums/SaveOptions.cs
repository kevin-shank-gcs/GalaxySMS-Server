namespace GalaxySMS.Common.Enums
{
    public enum SaveAccessGroupAccessPortalsOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
        CreateMissingItems,
        SetMissingItemsToNever
    }

    public enum SaveAccessPortalAreasOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }

    public enum SaveAccessPortalSchedulesOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }

    public enum SaveAccessPortalAlertEventsOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
        NoIoGroupUid, // Delete any items that are not contained in the collection.
    }

    public enum SaveAccessPortalAuxiliaryOutputsOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }

    public enum SaveAccessPortalNotesOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }

    public enum SaveAccessProfileClusterOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }

    public enum SaveAccessProfileAccessGroupOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }

    public enum SaveAccessProfileInputOutputGroupOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }


    public enum SavePersonCredentialOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }

    public enum SavePersonPhoneNumberOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }
    public enum SavePersonEmailAddressOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }


    public enum SavePersonClusterPermissionOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }

    //public enum SaveRoleFiltersOption
    //{
    //    DeleteMissingItems, // Delete any items that are not contained in the collection.
    //}

    public enum SaveInputDeviceEventPropertiesOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }


    public enum SaveInputDeviceOption
    {
        DioInputSupervisionTypeUid,
        Rs485InputModuleSupervisionTypeUid
    }


    public enum GetInputDeviceOption
    {
        IsNodeActiveValue
    }


    public enum SaveInputDeviceAlertEventOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
        NoIoGroupUid, // Delete any items that are not contained in the collection.
        //ClusterUid
    }


    public enum SaveOutputDeviceInputSourcesOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
        NoIoGroupUid, // Delete any items that are not contained in the collection.
        //ClusterUid
    }

    //public enum SaveGalaxyOutputDeviceInputSourceAssignmentsOption
    //{
    //    DeleteMissingItems, // Delete any items that are not contained in the collection.
    //    NoIoGroupUid, // Delete any items that are not contained in the collection.

    //}

    public enum GetOutputDeviceOption
    {
        IsNodeActiveValue
    }

    public enum SaveSettingOption
    {
        Encrypt
    }


    public enum SaveGalaxyPanelCpuOption
    {
        SaveBoards
    }

    public enum SaveDayTypeOption
    {
        DeleteMissingDates, // Delete any items that are not contained in the collection.
        SaveDates,
        ResetConcurrencyValue,
        SelectIsActiveFalseDayTypeForReuse,
        SetIsActiveFalseIfNoDates
    }

    //public enum SaveGalaxyInterfaceBoardOption
    //{
    //    CreateDefaultModulesAndNodes,
    //    DefaultIsActiveValue
    //}

    public enum InitializingSystemOption
    {
        DontValidateAuthorization
    }

    public enum SaveCommandOption
    {
        DeleteMissingItems, // Delete any items that are not contained in the collection.
    }


    public enum SaveEntityOption
    {
        DontEnsureDefaultsExist,
        AddToExistingUsersWithParentEntityAccess,
        InheritParentEntityRoles,
        IsEntityAdministrator
    }

    public enum SaveRoleOption
    {
        AddToExistingUsers,
    }

    public enum SaveUserOption
    {
        AddDescendantEntities,
        InheritParentEntityRoles,
        IsEntityAdministrator,
        DoNotAddDefaultRolesToUser,
        ChangePasswordResponseUrl
    }
}
