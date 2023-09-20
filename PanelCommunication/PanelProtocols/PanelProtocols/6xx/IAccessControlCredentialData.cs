namespace GCS.PanelProtocols.Series6xx.Messages
{
    public interface IAccessControlCredentialData
    {
        byte AccessGroup1 { get; set; }
        byte AccessGroup2 { get; set; }
        ushort AccessGroup3 { get; set; }
        ushort AccessGroup4 { get; set; }
        byte CurrentArea { get; set; }
        byte ExpireCount { get; set; }
        AccessCredentialFlags1 Flags1 { get; set; }
        AccessCredentialFlags2 Flags2 { get; set; }
        AccessCredentialFlags3 Flags3 { get; set; }
        //byte Flags1 { get; set; }
        //byte Flags2 { get; set; }
        //byte Flags3 { get; set; }
        ushort PIN { get; set; }
        ServerOverrideBehaviorFlags ServerOverrideBehavior { get; set; }
        //byte ServerOverrideBehavior { get; set; }
    }
}