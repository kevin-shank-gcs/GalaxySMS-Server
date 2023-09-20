namespace GCS.PanelProtocols.Series6xx.Messages
{
    public interface IAlarmControlCredentialData
    {
        byte ExpireCount { get; set; }
        AlarmCredentialFlags1 Flags1 { get; set; }
        AlarmCredentialFlags2 Flags2 { get; set; }
        byte InputOutputGroup1 { get; set; }
        byte InputOutputGroup2 { get; set; }
        ushort InputOutputGroup3 { get; set; }
        ushort InputOutputGroup4 { get; set; }
        ushort PIN { get; set; }
    }
}