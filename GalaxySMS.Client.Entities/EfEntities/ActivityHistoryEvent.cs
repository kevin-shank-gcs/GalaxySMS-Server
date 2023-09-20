namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Core;
    using GCS.Core.Common.Contracts;	
    using FluentValidation;
    
    [DataContract]
    public partial class ActivityHistoryEvent //: ObjectBase
    {
        #region Public Properties
        [DataMember]
        public DateTimeOffset ActivityDateTime  {get; set;}

        [DataMember]
        public string EventTypeMessage {get; set;}

        [DataMember]
        public int ForeColor {get; set;}

        [DataMember]
        public string ForeColorHex { get; set; }

        [DataMember]
        public string DeviceName {get; set;}

        [DataMember]
        public string SiteName {get; set;}

        [DataMember]
        public Guid EntityId {get; set;}

        [DataMember]
        public Guid DeviceUid {get; set;}

        [DataMember]
        public Guid EventTypeUid {get; set;}

        [DataMember]
        public string DeviceType {get; set;}

        [DataMember]
        public string LastName {get; set;}

        [DataMember]
        public string FirstName {get; set;}

        [DataMember]
        public string CredentialDescription {get; set;}

        [DataMember]
        public Guid PersonUid {get; set;}

        [DataMember]
        public bool IsTraced { get; set; }

        [DataMember]
        public Guid CredentialUid {get; set;}

        [DataMember]
        public Guid PK {get; set;}

        [DataMember]
        public int ClusterNumber {get; set;}

        [DataMember]
        public int TotalRecordCount {get; set;}

        [DataMember]
        public string ClusterName {get; set;}

        [DataMember]
        public int PageNumber {get; set;}

        [DataMember]
        public Guid ClusterUid { get; set; }


        [DataMember]
        public int ClusterGroupId {get; set;}

        [DataMember]
        public int PageSize {get; set;}

        [DataMember]
        public int PanelNumber {get; set;}

        [DataMember]
        public string InputOutputGroupName {get; set;}

        [DataMember]
        public int InputOutputGroupNumber {get; set;}

        [DataMember]
        public short CpuNumber {get; set;}

        [DataMember]
        public int BoardNumber {get; set;}

        [DataMember]
        public int SectionNumber {get; set;}

        [DataMember]
        public int ModuleNumber {get; set;}

        [DataMember]
        public int NodeNumber {get; set;}

        [DataMember]
        public int AlarmPriority { get; set; }

        [DataMember] public bool ResponseRequired { get; set; }

        [DataMember] public DateTimeOffset? AcknowledgedTime { get; set; }
        [DataMember] public string AcknowledgeComment { get; set; }
        [DataMember] public string AcknowledgedByUser { get; set; }

        #endregion
    }
}
