namespace GCS.Framework.Utilities
{
    public static class UtilityFunctions
    {
        public static int GetTotalPageCount(int totalItemCount, int pageSize)
        {
            if (pageSize <= 0)
                return 0;

            var pageCount = totalItemCount / pageSize;
            if ((totalItemCount % pageSize) != 0)
                pageCount++;
            return pageCount;
        }
    }
}
