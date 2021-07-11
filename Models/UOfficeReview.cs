using System.Collections.Generic;

namespace VNPT_Review.Models
{
    public class UOfficeReview
    {
        public Office office { get; set; }
        public IEnumerable<Office> offices { get; set; }
        public IEnumerable<Review> reviews { get; set; }

    }
}