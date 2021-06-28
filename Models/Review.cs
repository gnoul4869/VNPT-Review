using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace VNPT.Models
{
    public class REVIEW
    {
        [Key]
        [Display(Name = "Mã đánh giá")]
        public string ID { get; set; }

        [ForeignKey("ID")]
        [Display(Name = "Mã phòng ban")]
        public string OFFICE_ID { get; set; }

        [Required]
        [Display(Name = "Mức đánh giá")]
        public decimal RATING { get; set; }

        [Required]
        [Display(Name = "Nội dung đánh giá")]
        public string CONTENT { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CREATED_AT { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime UPDATED_AT { get; set; }

        public virtual OFFICE OFFICE { get; set; }
    }
}
