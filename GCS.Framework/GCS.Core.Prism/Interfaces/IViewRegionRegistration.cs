namespace GCS.Core.Prism
{
    public interface IViewRegionRegistration
    {
        string RegionName { get; }
        bool IsActiveByDefault { get; }
    }
}