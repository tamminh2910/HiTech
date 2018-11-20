using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiTech.Model.Entites
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên công ty")]
        public string CompanyName { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên người đại diện")]
        public string ContactName { get; set; }

        [StringLength(100)]
        [Display(Name = "Tiêu đề")]
        public string ContacTitle { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}