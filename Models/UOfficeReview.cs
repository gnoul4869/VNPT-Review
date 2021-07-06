using System.Collections.Generic;

namespace VNPT_Review.Models
{
    public class UOfficeReview
    {
        public OFFICE office { get; set; }
        public List<REVIEW> review { get; set; }
    }
}