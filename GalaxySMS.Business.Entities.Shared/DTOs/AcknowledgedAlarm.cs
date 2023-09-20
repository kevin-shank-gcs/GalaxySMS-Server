using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

#if NetCoreApi
#else
    [DataContract]
#endif
	public partial class AcknowledgedAlarm : ObjectBase
    {
        #region Public Properties

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ActivityEventUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public short CpuId {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int BoardNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int SectionNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ModuleNumber {get; set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public int NodeNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int CpuModel {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset DateTimeOffset {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int BufferIndex {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelActivityEventCode PanelActivityType {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputOutputGroupNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalMultiFactorModeCode MultiFactorMode {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceDescription {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EventDescription {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceEntityId {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int IsAlarmEvent {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AlarmPriority {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ResponseRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Instructions {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InstructionsNoteUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AudioBinaryResourceUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] RawData {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int Color {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ColorArgb { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PersonDescription {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialDescription {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Trace {get;set; }
        #endregion

    }
}
