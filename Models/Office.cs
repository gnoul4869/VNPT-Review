using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable enable
#nullable disable warnings

namespace VNPT.Models
{
    public class OFFICE
    {
        [Key]
        [Display(Name = "Mã phòng ban")]
        [StringLength(5)]
        public string ID { get; set; }

        [Required]
        [Display(Name = "Tên phòng ban")]
        [StringLength(50)]
        public string NAME { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(200)]
        public string? NOTE { get; set; }

        [Display(Name = "Đơn vị cha")]
        [StringLength(5)]
        public string FATHER_ID { get; set; }

        [Display(Name = "Hoạt động")]
        public bool ACTIVE { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CREATED_AT { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime UPDATED_AT { get; set; }

        public virtual REVIEW REVIEW { get; set; }
    }
}
