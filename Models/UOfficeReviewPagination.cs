using System.Collections.Generic;

namespace VNPT_Review.Models
{
    public class UOfficeReviewPagination
    {
        public OFFICE office { get; set; }
        public IEnumerable<OFFICE> offices { get; set; }
        public IEnumerable<REVIEW> review { get; set; }
        public Pagination pagination { get; set; }

    }
}