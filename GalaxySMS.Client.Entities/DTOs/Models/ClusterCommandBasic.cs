//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class ClusterCommandBasic : EntityBaseSimple
    {

        public ClusterCommandBasic()
        {
            
        }

        public ClusterCommandBasic(ClusterCommand c)
        {
            if (c != null)
            {
                this.ClusterCommandUid = c.ClusterCommandUid;
                this.CommandCode = c.CommandCode;
                this.IsActive = c.IsActive;
                this.IsFlashingCommand = c.IsFlashingCommand;
                this.Display = c.Display;
                this.Description = c.Description;
                this.ClusterTypeIds = c.ClusterTypeIds.ToCollection();
                this.ClusterTypeClusterCommands = new HashSet<ClusterTypeClusterCommandBasic>();
                if (c.ClusterTypeClusterCommands != null)
                {
                    foreach (var cc in c.ClusterTypeClusterCommands)
                    {
                        this.ClusterTypeClusterCommands.Add(new ClusterTypeClusterCommandBasic()
                        {
                            ClusterCommandUid = cc.ClusterCommandUid,
                            ClusterTypeClusterCommandUid = cc.ClusterTypeClusterCommandUid,
                            ClusterTypeUid = cc.ClusterTypeUid,
                            ConcurrencyValue = (int)cc.ConcurrencyValue
                        });
                    }
                }
            }
        }

        [DataMember]
        public System.Guid ClusterCommandUid { get; set; }

        [DataMember]
        public short CommandCode { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsFlashingCommand { get; set; }

        [DataMember]
        public ICollection<ClusterTypeClusterCommandBasic> ClusterTypeClusterCommands { get; set; }

        [DataMember]
        public ICollection<Guid> ClusterTypeIds { get; set; }

        [DataMember]
        public string Display { get; set; }

        [DataMember]
        public string Description { get; set; }


        public GalaxyCpuCommandActionCode CommandAction
        {
            get
            {
                if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ActivateCrisisMode)
                    return GalaxyCpuCommandActionCode.ActivateCrisisMode;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_BeginFlashLoad)
                    return GalaxyCpuCommandActionCode.BeginFlashLoad;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ClearLoggingBuffer)
                    return GalaxyCpuCommandActionCode.ClearLoggingBuffer;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_DeleteAllCredentials)
                    return GalaxyCpuCommandActionCode.ClearAllCredentials;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_DisableCredential)
                    return GalaxyCpuCommandActionCode.DisableCredential;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_EnableCredential)
                    return GalaxyCpuCommandActionCode.EnableCredential;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_EnableDaughterBoardFlashUpdate)
                    return GalaxyCpuCommandActionCode.EnableDaughterBoardFlashUpdate;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ForgiveAllPassback)
                    return GalaxyCpuCommandActionCode.ForgivePassbackForAllCredentials;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ForgivePassback)
                    return GalaxyCpuCommandActionCode.ForgivePassbackForCredential;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_GetCardCount)
                    return GalaxyCpuCommandActionCode.RequestCredentialCount;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_GetInfo)
                    return GalaxyCpuCommandActionCode.RequestControllerInformation;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_GetLoggingInfo)
                    return GalaxyCpuCommandActionCode.RequestLoggingInformation;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_Ping)
                    return GalaxyCpuCommandActionCode.Ping;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ClearLoggingBuffer)
                    return GalaxyCpuCommandActionCode.ClearLoggingBuffer;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_RecalibrateInputOutput)
                    return GalaxyCpuCommandActionCode.RecalibrateInputsAndOutputs;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_RequestBoardInformation)
                    return GalaxyCpuCommandActionCode.RequestBoardInformation;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetCrisisMode)
                    return GalaxyCpuCommandActionCode.ResetCrisisMode;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_RetransmitLoggingBuffer)
                    return GalaxyCpuCommandActionCode.RetransmitLoggingBuffer;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetControllerCold)
                    return GalaxyCpuCommandActionCode.ResetCpuCold;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetControllerWarm)
                    return GalaxyCpuCommandActionCode.ResetCpuWarm;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_StartLogging)
                    return GalaxyCpuCommandActionCode.StartLogging;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_StopLogging)
                    return GalaxyCpuCommandActionCode.StopLogging;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ValidateFlash)
                    return GalaxyCpuCommandActionCode.ValidateFlash;
                else if (ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ValidateAndBurnFlash)
                    return GalaxyCpuCommandActionCode.ValidateAndBurnFlash;
                return GalaxyCpuCommandActionCode.None;
            }
        }

        public string CommandActionString => CommandAction.ToString();

    }
}
