namespace properties.core.DTO
{
    public class MetaData
    {
        public int currentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool PreviousPage { get; set; }
        public bool NextPage { get; set; }
        public string NextPageUrl { get; set; }
        public string PrevioustPageUrl { get; set; }
    }
}
