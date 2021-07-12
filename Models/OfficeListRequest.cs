namespace VNPT_Review.Models
{
    public class OfficeListRequest
    {
        public string SearchValue { get; set; }
        public int ValueNo { get; set; }
        public int PageSize { get; set; }
        public int SortColumn { get; set; }
        public string SortDirection { get; set; }
    }   
}