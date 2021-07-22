using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace VNPT_Review.Models
{
    public class Review
    {
        [Key]
        [Display(Name = "Mã đánh giá")]
        [StringLength(64)]
        public string Id { get; set; }

        [ForeignKey("OFFICE")]
        [Display(Name = "Mã phòng ban")]
        [StringLength(5)]
        public string OfficeId { get; set; }

        [Required]
        [Display(Name = "Đánh giá")]
        public decimal Rating { get; set; }

        [Required]
        [Display(Name = "Nội dung đánh giá")]
        [StringLength(200)]
        public string Content { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; }

        public virtual Office Office { get; set; }
    }
}
