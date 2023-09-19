namespace GalaxySMS.Common.Interfaces
{
    public interface IAccessGroupAssignment
    {
        System.Guid AccessGroupUid { get; set; }

        short OrderNumber { get; set; }

        int AccessGroupNumber { get; set; }

        string AccessGroupName { get; set; }
    }
}