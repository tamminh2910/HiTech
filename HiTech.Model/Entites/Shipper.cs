using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiTech.Model.Entites
{
    public class Shipper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShipperID { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên người giao hàng")]
        public string ShipperName { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại 1")]
        public string Phone1 { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại 2")]
        public string Phone2 { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}