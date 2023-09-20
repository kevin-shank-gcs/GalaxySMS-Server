namespace GCS.Core.Common.Contracts
{
    public interface IPagedResultBase
    {
        int PageNumber { get; set; }

        int PageItemCount { get; set; }

        int PageSize { get; set; }

        int TotalItemCount { get; set; }

        int TotalPageCount { get; set; }
    }
}