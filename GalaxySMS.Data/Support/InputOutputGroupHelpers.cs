using GalaxySMS.BusinessLayer;
using System;

namespace GalaxySMS.Data.Support
{
    public class InputOutputGroupHelpers
    {
        public static bool IsInputOutputGroupAssociatedWithGalaxyPanel(Guid inputOutputGroupUid, Guid galaxyPanelUid)
        {
            if (inputOutputGroupUid == Guid.Empty || galaxyPanelUid == Guid.Empty)
                return false;

            var mgr = new IsInputOutputGroupValidForGalaxyPanelPDSAManager()
            {
                Entity =
                {
                    InputOutputGroupUid = inputOutputGroupUid,
                    GalaxyPanelUid = galaxyPanelUid
                }
            };
            var result = mgr.BuildCollection();
            if (result != null && result.Count == 1)
                return result[0].Result == 1;
            return false;
        }

        public static bool IsInputOutputGroupAssociatedWithAccessPortal(Guid inputOutputGroupUid, Guid accessPortalUid)
        {
            if (inputOutputGroupUid == Guid.Empty || accessPortalUid == Guid.Empty)
                return false;

            var mgr = new IsInputOutputGroupValidForAccessPortalPDSAManager()
            {
                Entity =
                {
                    InputOutputGroupUid = inputOutputGroupUid,
                    AccessPortalUid = accessPortalUid
                }
            };
            var result = mgr.BuildCollection();
            if (result != null && result.Count == 1)
                return result[0].Result == 1;
            return false;
        }


        public static bool IsInputOutputGroupAssociatedWithInputDevice(Guid inputOutputGroupUid, Guid inputDeviceUid)
        {
            if (inputOutputGroupUid == Guid.Empty || inputDeviceUid == Guid.Empty)
                return false;

            var mgr = new IsInputOutputGroupValidForInputDevicePDSAManager()
            {
                Entity =
                {
                    InputOutputGroupUid = inputOutputGroupUid,
                    InputDeviceUid = inputDeviceUid
                }
            };
            var result = mgr.BuildCollection();
            if (result != null && result.Count == 1)
                return result[0].Result == 1;
            return false;
        }



        public static bool IsInputOutputGroupAssociatedWithOutputDevice(Guid inputOutputGroupUid, Guid outputDeviceUid)
        {
            if (inputOutputGroupUid == Guid.Empty || outputDeviceUid == Guid.Empty)
                return false;

            var mgr = new IsInputOutputGroupValidForOutputDevicePDSAManager()
            {
                Entity =
                {
                    InputOutputGroupUid = inputOutputGroupUid,
                    OutputDeviceUid = outputDeviceUid
                }
            };
            var result = mgr.BuildCollection();
            if (result != null && result.Count == 1)
                return result[0].Result == 1;
            return false;
        }

        
        public static bool IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(Guid inputOutputGroupAssignmentUid, Guid inputOutputGroupUid)
        {
            var mgr = new InputOutputGroupAssignment_IsAssociatedWithInputOutputGroupPDSAManager
            {
                Entity =
                {
                    InputOutputGroupAssignmentUid = inputOutputGroupAssignmentUid,
                    InputOutputGroupUid = inputOutputGroupUid
                }
            };
            var result = mgr.BuildCollection();
            if (result != null && result.Count == 1)
                return result[0].Result == 1;
            return false;
        }


        public static Guid GetAvailableInputOutputGroupAssignmentUid(Guid inputOutputGroupUid)
        {
            var mgr = new InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAManager
            {
                Entity = { InputOutputGroupUid = inputOutputGroupUid }
            };
            var data = mgr.BuildCollection();
            if (data != null && data.Count == 1)
                return data[0].InputOutputGroupAssignmentUid;
            return Guid.Empty;
        }

        public static Guid GetInputOutputUidFromInputOutputGroupAssignmentUid(Guid inputOutputGroupAssignmentUid)
        {
            var mgr = new InputOutputGroupAssignment_GetInputOutputGroupUidPDSAManager
            {
                Entity = { InputOutputGroupAssignmentUid = inputOutputGroupAssignmentUid }
            };
            var data = mgr.BuildCollection();
            if (data != null && data.Count == 1)
                return data[0].InputOutputGroupUid;
            return Guid.Empty;
        }
    }
}
