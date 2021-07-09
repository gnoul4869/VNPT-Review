using System;
using System.ComponentModel.DataAnnotations;

namespace VNPT_Review.Models
{
    public partial class OFFICE
    {
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
    }
}