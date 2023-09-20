using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public partial class AcknowledgedAlarm : ObjectBase
    {
        #region Public Properties
        public Guid ActivityEventUid {get; set;}
        public int ClusterGroupId {get; set;}
        public int ClusterNumber {get; set;}
        public int PanelNumber {get; set;}
        public short CpuId {get; set;}
        public int BoardNumber {get; set;}
        public int SectionNumber {get; set;}
        public int NodeNumber {get; set;}
        public int CpuModel {get; set;}
        public DateTimeOffset DateTimeOffset {get; set;}
        public int BufferIndex {get; set;}
        public PanelActivityEventCode PanelActivityType {get; set;}
        public int InputOutputGroupNumber {get; set;}
        public AccessPortalMultiFactorModeCode MultiFactorMode {get; set;}
        public string DeviceDescription {get; set;}
        public string EventDescription {get; set;}
        public Guid DeviceEntityId {get; set;}
        public Guid DeviceUid {get; set;}
        public Guid CpuUid {get; set;}
        public string ClusterName {get; set;}
        public int IsAlarmEvent {get; set;}
        public int AlarmPriority {get; set;}
        public string Instructions {get; set;}
        public Guid InstructionsNoteUid {get; set;}
        public Guid AudioBinaryResourceUid {get; set;}
        public byte[] RawData {get; set;}
        public int Color {get; set;}
        public Guid PersonUid {get; set;}
        public Guid CredentialUid {get; set;}
        public string PersonDescription {get; set;}
        public string CredentialDescription {get; set;}
        public bool Trace {get;set; }
        #endregion

    }
}
